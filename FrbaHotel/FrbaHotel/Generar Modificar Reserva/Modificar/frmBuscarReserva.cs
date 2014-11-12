using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmBuscarReserva : Form
    {
        private MenuDinamico menu;
        string user;
        string codigoHotel;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmBuscarReserva() { InitializeComponent(); }
        public frmBuscarReserva(MenuDinamico menuPadre) { this.menu = menuPadre; InitializeComponent(); }
        
        public frmBuscarReserva(MenuDinamico menuPadre,string userSesion,string hotelSesion)
        {
            this.menu = menuPadre;
            InitializeComponent();

            FrbaHotel.ConexionSQL.establecerConexionBD();//TODO BORRAR ESTA PORQUERIA DESPUES
            user = userSesion;
            codigoHotel = hotelSesion;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        private void txtCodRes_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }

        private void frmBuscarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodRes, "Codigo reserva")){
                if (validarReserva()){
                    MessageBox.Show("Para efectuar la modificacion tiene que volver a llenar todos los campos incluso agregar las habitaciones\n No estan seteados por defecto por motivos de seguridad", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    new frmModificarRerserva(this).Show();
                    this.Enabled = false;
                }else{
                    MessageBox.Show("No se ha encontrado la reserva o se trata de una reserva cancelada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        private bool validarReserva()
        {
            string consultaSQL;

            //chequea si la modificacion de la reserva la hace un usuario o un guest
            if (user == "Guest"){
                //valida existencia
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_existe_reserva_no_cancelada(" + txtCodRes.Text + ")";
            }else{
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada(" + txtCodRes.Text + "," + codigoHotel + ")";
            }

            int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);

            if (resultado == 1){

                if (user == "Guest"){
                    //consulto por el hotel de la reserva
                    string consultaHotel = "select cod_hotel from THE_FOREIGN_FOUR.Reservas WHERE cod_reserva =" + txtCodRes.Text;
                    SqlCommand cmd = new SqlCommand(consultaHotel, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    codigoHotel = cmd.ExecuteScalar().ToString();
                }

                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        //----------------------GETTERS-----------------------------
        public string getCodigoReserva(){   return txtCodRes.Text; }
        public string getCodigoHotel() { return codigoHotel; }
        public string getUsuario() { return user; }
        //----------------------------------------------------------

    }
}
