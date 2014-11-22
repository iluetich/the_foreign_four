using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Consumible;
using System.Data.SqlClient;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Menues_de_los_Roles;


namespace FrbaHotel.Registrar_Estadia.checkOut
{
    public partial class frmCheckout : Form
    {
        frmInicioEstadia frmInicioEstadiaPadre;
        private string codEstadia;
        private string user;
        MenuDinamico menuRaiz;
        string codigoCliente;
        bool seleccionoCliente = false;
        bool cerrate = false;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmCheckout(){InitializeComponent();}
        
        public frmCheckout(frmInicioEstadia newForm,string codEstadiaParametro,string userParametro, MenuDinamico menuRaiz) {
            codEstadia = codEstadiaParametro;
            user = userParametro;            
            frmInicioEstadiaPadre = newForm;
            this.menuRaiz = menuRaiz;

            InitializeComponent();
            llenarGridClientes();
        }
       
        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM--------------------------------------------------------------- 
        private void frmCheckout_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmInicioEstadiaPadre.Enabled = true;
            frmInicioEstadiaPadre.Focus();
            if (cerrate) frmInicioEstadiaPadre.Close();
        }
        //----------------------FIN EVENTOS DEL FORM-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------         
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!seleccionoCliente){
                MessageBox.Show("Seleccione un cliente de la tabla antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //ejecutar el procedure que realiza el checkout
            SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_realizar_checkout", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod_estadia",int.Parse(codEstadia));
            cmd.Parameters.AddWithValue("@username", user);

            cmd.ExecuteNonQuery();

            //crear Factura
            string consulta = "DECLARE @output numeric(18,0) EXEC THE_FOREIGN_FOUR.proc_crear_factura "+ codEstadia +", @output OUTPUT,"+ codigoCliente +" SELECT @output";
            SqlCommand cmd2 = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd2.CommandType = CommandType.Text;

            object nroFactura = cmd2.ExecuteScalar();

            MessageBox.Show("Se procedera a registrar los consumibles adicionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new frmRegistrarConsumible(this, frmInicioEstadiaPadre,long.Parse(nroFactura.ToString()),codEstadia).Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasDias_Click(object sender, EventArgs e)
        {
            //TE DERIBA A HACER UNA NUEVA RESERVA
            new frmGenerarReserva(menuRaiz, user, "").Show();
        }
        //----------------------FIN BOTONES--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------



        //-------------------------OTROS--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        private void llenarGridClientes(){            
            string consultaSql = "select * from THE_FOREIGN_FOUR.func_clientes_estadia("+codEstadia+")";
            FrbaHotel.Utils.rellenarDataGridView(dgvClientes, consultaSql); 
        }

        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvRegimenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];         
                //codigo cliente
                codigoCliente = row.Cells[0].Value.ToString();
                seleccionoCliente = true;
            }
        }
        //-------------------------FIN OTROS--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------

        public void setCerrate() { cerrate = true; }
    }
}
