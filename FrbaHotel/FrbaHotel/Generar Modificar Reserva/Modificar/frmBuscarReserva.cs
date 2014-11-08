using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

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
                }else{
                    MessageBox.Show("No se ha encontrado la reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (user == "Guest"){
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_existe_reserva(" + txtCodRes.Text + ")";
            }else{
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva(" + txtCodRes.Text + "," + codigoHotel + ")";
            }

            int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == 1){
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        //----------------------GETTERS-----------------------------
        public string getCodigoReserva(){   return txtCodRes.Text; }
        public string getCodigoHotel() { return codigoHotel; }
        //----------------------------------------------------------

    }
}
