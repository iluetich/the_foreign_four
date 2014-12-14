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
        string codigoReserva;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmBuscarReserva() { InitializeComponent(); }        
        public frmBuscarReserva(MenuDinamico menuPadre,string userSesion,string hotelSesion)
        {               
            this.menu = menuPadre;
            InitializeComponent();
          
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
                    new frmModificarRerserva(this).Show();
                    this.Enabled = false;
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
            codigoReserva = txtCodRes.Text;
            string consultaSQL;

            //valida existencia
            string consultaSQLExistencia = "select THE_FOREIGN_FOUR.func_validar_reserva(@cod_reserva, @cod_hotel)";
            SqlCommand cmdExistencia = new SqlCommand(consultaSQLExistencia, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmdExistencia.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(codigoReserva));
            cmdExistencia.Parameters.AddWithValue("@cod_hotel", Convert.ToInt32(codigoHotel));
            int resultado = Convert.ToInt32(cmdExistencia.ExecuteScalar());
            if (resultado == -1)
            {
                MessageBox.Show("La Reserva no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Valida que no se le haya hecho check in antes
            string hizoCheckIn = "SELECT cod_estado_reserva FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva = @cod_reserva";
            SqlCommand cmdCheckIN = new SqlCommand(hizoCheckIn, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmdCheckIN.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(codigoReserva));
            if (Convert.ToInt32(cmdCheckIN.ExecuteScalar()) == 6)
            {
                MessageBox.Show("No puede modificar una reserva que ya se le hizo CHECK IN ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //chequea si la modificacion de la reserva la hace un usuario o un guest
            if (user == "Guest"){
                //valida existencia
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_guest(" + codigoReserva + ")";
            }else{
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_user(" + codigoReserva + "," + codigoHotel + ")";
            }

            resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);

            if (resultado == 1){
                if (user == "Guest"){
                    //consulto por el hotel de la reserva
                    string consultaHotel = "select cod_hotel from THE_FOREIGN_FOUR.Reservas WHERE cod_reserva =" + codigoReserva;
                    SqlCommand cmdHotel = new SqlCommand(consultaHotel, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    codigoHotel = cmdHotel.ExecuteScalar().ToString();
                }
                return true;
            }

            MessageBox.Show("No se ha encontrado la reserva o se trata de una reserva cancelada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        //----------------------GETTERS-----------------------------
        public string getCodigoReserva() { return codigoReserva; }
        public string getCodigoHotel() { return codigoHotel; }
        public string getUsuario() { return user; }      
        //----------------------------------------------------------

    }
}
