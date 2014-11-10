using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.Generar_Modificar_Reserva;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmRegistrarHuespedesRestantes : Form
    {
        frmInicioEstadia frmRegistrarEstadiaPadre;
        string codigoCliente;
        string codigoReserva;

        //----------------------------------------------------------------------------------------------------
        //----------------------CONSTRUCTORES-----------------------------------------------------------------       
        public frmRegistrarHuespedesRestantes(frmInicioEstadia newFrm)
        {
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;

            obtenerCantHuespedes();
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------       
        private void frmRegistrarHuespedes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarEstadiaPadre.Enabled = true;
            frmRegistrarEstadiaPadre.Focus();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------  
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {            
            new RegistrarCliente(this).Show();
            this.Enabled = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();            
            this.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validaClientes())
            {
                //NACHO----------------------(agrega los huespedes a la tabla huespedes por estadia)
                //OBTENER EL COD DE ESTADIA GENERADO POR LA RESERVA
                object cod_estadia = this.ejecutarConsultaLong("SELECT THE_FOREIGN_FOUR.func_obtener_estadia (" + codigoReserva + ")");

                //REGISTRA EL HUESPED EN LA ESTADIA
                for(int i = 0;i < dgvDatosHuespedes.RowCount ;i++)
                {
                    //obtener el codigo de cliente por cada fila del data grid
                    string consulta = "SELECT cod_cliente FROM THE_FOREIGN_FOUR.buscar_clientes(NULL,NULL,NULL,"+ int.Parse(dgvDatosHuespedes.Rows[i].Cells[1].Value.ToString()) +",NULL)";
                    object codigoCliente = this.ejecutarConsultaLong(consulta);

                    SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_huesped", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod_cliente",long.Parse(codigoCliente.ToString()));
                    cmd.Parameters.AddWithValue("@cod_estadia",long.Parse(cod_estadia.ToString())); 

                    cmd.ExecuteNonQuery();
                }
                //------------------------------------------------------------------
                MessageBox.Show("Felicidades ha hecho checkIN", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmRegistrarEstadiaPadre.Close();
            }
        }

        public object ejecutarConsultaLong(string consulta)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = consulta;

            cmd.CommandType = CommandType.Text;

            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            return cmd.ExecuteScalar();
        }
        //----------------------FIN BOTONES--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------        
        //muestro los datos del cliente que se acaba de registrar o buscar
        public void cargarParametrosClientes(SqlCommand cmd)
        {
            string nombre = cmd.Parameters["@nombre"].Value.ToString();
            string apellido = cmd.Parameters["@apellido"].Value.ToString();
            string tipoDocmento = cmd.Parameters["@tipo_doc"].Value.ToString();
            string nroDocumento = cmd.Parameters["@nro_doc"].Value.ToString();
            dgvDatosHuespedes.Rows.Add(new[] { nroDocumento, nroDocumento, apellido, nombre });
        }

        //valido que se haya ingresa al menos un cliente
        private bool validaClientes()
        {
            if (dgvDatosHuespedes.Rows.Count <= Convert.ToInt32(txtCantHuespedes.Text)){
                MessageBox.Show("Te faltan registrar huespedes", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }               
            return true;
        }

        //me paso los datos del cliente que se busco
        public void obtenerDatosDelBuscador(DataGridViewRow row)
        {
            string nombre = row.Cells[1].Value.ToString();
            string apellido = row.Cells[2].Value.ToString();
            string tipoDocmento = row.Cells[3].Value.ToString();
            string nroDocumento = row.Cells[4].Value.ToString();
            dgvDatosHuespedes.Rows.Add(new[] { nroDocumento, nroDocumento, apellido, nombre });
        
        }
        public void obtenerCantHuespedes(){
            
            codigoReserva = frmRegistrarEstadiaPadre.getCodigoReserva();
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_obtener_cant_huespedes("+codigoReserva+")";
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            txtCantHuespedes.Text = cmd.ExecuteScalar().ToString();
            Console.WriteLine("la cantidad de huespedes es: " + txtCantHuespedes.Text);

        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------


        //----SETTERS------------------------------------------------------------------
        public void setCodigoCliente(int codigo) { codigoCliente = codigo.ToString(); }
        //-----------------------------------------------------------------------------

    }
}
