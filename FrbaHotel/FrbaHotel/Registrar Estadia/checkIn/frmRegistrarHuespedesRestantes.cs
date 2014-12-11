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
        string user;
        int cantidadHuespedesDGV;

        //----------------------------------------------------------------------------------------------------
        //----------------------CONSTRUCTORES-----------------------------------------------------------------       
        public frmRegistrarHuespedesRestantes(frmInicioEstadia newFrm)
        {
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;

            codigoReserva = frmRegistrarEstadiaPadre.getCodigoReserva();
            user = frmRegistrarEstadiaPadre.getUsuario();
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
            if (alMenosUnCliente())
            {
                //REGISTRAR ESTADIA----
                registrarEstadia();
                //---------------------

                //OBTENER EL COD DE ESTADIA GENERADO POR LA RESERVA
                int cod_estadia = FrbaHotel.Utils.ejecutarConsultaResulInt("SELECT THE_FOREIGN_FOUR.func_obtener_estadia (" + codigoReserva + ")");
                
                //REGISTRA EL HUESPED EN LA ESTADIA
                for(int i = 0;i < dgvDatosHuespedes.RowCount ;i++)
                {
                    //obtener el codigo de cliente por cada fila del data grid
                    string consulta = "SELECT cod_cliente FROM THE_FOREIGN_FOUR.buscar_clientes(NULL,NULL,NULL,"+ int.Parse(dgvDatosHuespedes.Rows[i].Cells[1].Value.ToString()) +",NULL)";
                    int codigoCliente = FrbaHotel.Utils.ejecutarConsultaResulInt(consulta);
                    
                    SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_huesped", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_cliente",codigoCliente);
                    cmd.Parameters.AddWithValue("@cod_estadia",cod_estadia); 
                    cmd.ExecuteNonQuery();
                }
                //------------------------------------------------------------------
                MessageBox.Show("Felicidades ha hecho checkIN \n Su código de Estadía es: "+ cod_estadia +".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmRegistrarEstadiaPadre.Close();
            }
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
            string tipoDocumento = cmd.Parameters["@tipo_doc"].Value.ToString();
            string nroDocumento = cmd.Parameters["@nro_doc"].Value.ToString();

            switch (sePuedeRegistrarHuesped(dgvDatosHuespedes, nroDocumento)){
                case -1:
                    MessageBox.Show("El cliente creado tiene datos identificatorios que posee otro cliente. Consulte a su administrador", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show("Ya se ha llenado el cupo de alojamiento de esta reserva.", "Cupo completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    dgvDatosHuespedes.Rows.Add(new[] { tipoDocumento, nroDocumento, apellido, nombre });
                    txtCantHuespedes.Text = (Convert.ToInt32(txtCantHuespedes.Text) - 1).ToString();
                    break;
            }
        }

        //valido que se haya ingresa al menos un cliente
        private bool alMenosUnCliente()
        {
            if (dgvDatosHuespedes.Rows.Count <= 0){
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
            string tipoDocumento = row.Cells[3].Value.ToString();
            string nroDocumento = row.Cells[4].Value.ToString();

            //agregado por Iván desde acá
            switch (sePuedeRegistrarHuesped(dgvDatosHuespedes, nroDocumento)){
                case -1: 
                    MessageBox.Show("El cliente " + nombre + " " + apellido + " ya está registrado como huésped. Por favor, seleccione otro cliente e intente nuevamente.", "Huésped ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 0:
                    MessageBox.Show("Ya se ha llenado el cupo de alojamiento de esta reserva.", "Cupo completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    dgvDatosHuespedes.Rows.Add(new[] { tipoDocumento, nroDocumento, apellido, nombre });
                    txtCantHuespedes.Text = (Convert.ToInt32(txtCantHuespedes.Text) - 1).ToString();
                    break;
            }
            // hasta acá      
        }

        //pregunta si el cliente ya esta registrado
        private bool yaEstaRegistrado(DataGridView huespedes, string documento_huesped)
        {
            if (huespedes.Rows.Count <= 0) return false;
            foreach (DataGridViewRow fila in huespedes.Rows){               
                if (String.Equals(fila.Cells[1].Value.ToString(), documento_huesped)){
                    return true;
                }
            }
            return false;
        }

        //obtengo la cantidad máxima de personas que pueden registrarse como huéspedes de la reserva 
        //aplicación parcial en su ¿máximo? esplendor (?);; agregado por Iván
        private int cantidadMaximaHuespedes(int reserva)
        {
            string query = "SELECT THE_FOREIGN_FOUR.func_max_cant_huespedes(" + reserva + ")";
            return FrbaHotel.Utils.ejecutarConsultaResulInt(query);            
        }

        private int sePuedeRegistrarHuesped(DataGridView huespedesRegistrados, string nro_doc)
        {
            if (dgvDatosHuespedes.Rows.Count == cantidadMaximaHuespedes(int.Parse(codigoReserva))) return 0;
            if (yaEstaRegistrado(huespedesRegistrados, nro_doc)) return -1;
            return 1337;
        }

        //obtiene la cantidad maxima de huespedes que puede registrar en la estadia
        public void obtenerCantHuespedes(){            
            string consultaSQL = "select THE_FOREIGN_FOUR.func_max_cant_huespedes("+codigoReserva+")";
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            txtCantHuespedes.Text = cmd.ExecuteScalar().ToString();
        }

        //Registra la nueva  estadia
        public void registrarEstadia()
        {   // Armo una transaccion y un try & catch por si sucediera el caso en que al momento de 
            // hacer el check-in no se encontrasen habitaciones habilitadas disponibles, se agarra 
            // el error desde la base de datos, la cual genera un RAISERROR; en ese caso, se 
            // realizará un rollback de la transaccion. Sino, se commitea. {Iván}
                SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_estadia", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(codigoReserva));
                cmd.Parameters.AddWithValue("@usuario", user);
                cmd.ExecuteNonQuery();
            
        }

        //cuando se suprime un cliente de la tabla aumenta el contado de maxima cantidad restante de huespedes a registrar
        private void dgvDatosHuespedes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete){
                if (dgvDatosHuespedes.Rows.Count < cantidadHuespedesDGV )
                    txtCantHuespedes.Text = (Convert.ToInt32(txtCantHuespedes.Text) + 1).ToString();
            }
        }
        private void dgvDatosHuespedes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete){
                cantidadHuespedesDGV = dgvDatosHuespedes.Rows.Count;
            }
        }  
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

      
        //----SETTERS------------------------------------------------------------------
        public void setCodigoCliente(int codigo) { codigoCliente = codigo.ToString(); }                
        //-----------------------------------------------------------------------------

    }
}
