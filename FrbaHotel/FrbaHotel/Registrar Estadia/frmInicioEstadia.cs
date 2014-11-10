using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia.checkOut;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmInicioEstadia : Form
    {
        private MenuDinamico menu;
        string user;
        string codigoHotel;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmInicioEstadia(){  InitializeComponent(); }
        public frmInicioEstadia(MenuDinamico menuPadre, string userSesion, string hotelSesion)
        {
            this.menu = menuPadre;
            InitializeComponent();

            FrbaHotel.ConexionSQL.establecerConexionBD();// TODO: BORRAR ESTA PORQUERIA DESPUES

            user = userSesion;
            codigoHotel = hotelSesion;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------      
        private void frmInicioEstadia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }
        //evento para cuando se escribe en un text box, permita solo numeros
        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
        private void txtNroReserva_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
        //----------------------FIN EVENTOS DEL FORM-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
       

        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------         
        //Evento click boton check in
        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodReserva, "Codigo reserva")) //valida text box completo
            {
                if (validarReserva()){
                    new frmRegistrarHuespedesRestantes(this).Show();
                    this.Enabled = false;
                }else{
                    MessageBox.Show("Reserva no valida","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //evento click boton check  out
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodEstadia, "Codigo estadia"))
            {
                new frmCheckout(this).Show();
                this.Enabled = false;
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------FIN BOTONES--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------        
        private bool validarReserva()
        {
            //valida existencia
            string consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada(" + txtCodReserva.Text + "," + codigoHotel + ")";
            
            int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == 1){
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        //----------------------GETTERS-----------------------------
        public string getCodigoReserva() { return txtCodReserva.Text; }
        //public string getCodigoHotel() { return codigoHotel; }
        //public string getUsuario() { return user; }
        //----------------------------------------------------------
    }
}
