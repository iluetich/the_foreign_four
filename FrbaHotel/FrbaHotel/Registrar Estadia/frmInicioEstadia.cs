﻿using System;
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
                if (validarReserva())
                {                    
                    new frmRegistrarHuespedesRestantes(this).Show();
                    this.Enabled = false;
                }
            }
        }

        //evento click boton check  out
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodEstadia, "Codigo estadia"))
            {
                string consultaSQL = "SELECT THE_FOREIGN_FOUR.func_check_out (" + txtCodEstadia.Text + ",'" + user + "')";
                SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                switch (resultado){
                    case -1:
                        MessageBox.Show("La estadía especificada no existe. Por favor, ingrese un código de estadía válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 0:
                        MessageBox.Show("La estadía especificada está registrada como 'check-out'. Por favor, ingrese otra estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 1:
                        new frmCheckout(this, txtCodEstadia.Text, user, menu).Show();
                        break;
                }                
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
            string consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva(" + txtCodReserva.Text + "," + codigoHotel + ")";
            SqlCommand comand = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultado = Convert.ToInt32(comand.ExecuteScalar());
            if (resultado == -1)
            {
                MessageBox.Show("La Reserva no existe, o no tiene autorizacion en este hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada(" + txtCodReserva.Text + "," + codigoHotel + ")";            
            resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == -1){
                MessageBox.Show("Se trata de una Reserva Cancelada", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //validar check in si se puede hacer el dia actual
            string consulta = "DECLARE @resultado numeric(18,0); EXEC @resultado = THE_FOREIGN_FOUR.proc_validar_check_in " + txtCodReserva.Text + "," + codigoHotel + ";SELECT @resultado";
            SqlCommand cmd = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultadoCheckIn = Convert.ToInt32(cmd.ExecuteScalar());
            if (resultadoCheckIn != 1){
                MessageBox.Show("El CHECK IN se debe realizar el dia en que comienza la estadia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;     

        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        //----------------------GETTERS-----------------------------
        public string getCodigoReserva() { return txtCodReserva.Text; }
        //public string getCodigoHotel() { return codigoHotel; }
        public string getUsuario() { return user; }
        //----------------------------------------------------------
    }
}
