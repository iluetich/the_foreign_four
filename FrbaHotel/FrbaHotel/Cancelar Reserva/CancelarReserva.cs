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

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class frmCancelarReserva : Form
    {
        private MenuDinamico menu;
        string user;
        string codigoHotel;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmCancelarReserva(){InitializeComponent();}

        public frmCancelarReserva(MenuDinamico menuPadre, string userSesion, string hotelSesion)
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
        private void frmCancelarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if ((validarDatosCompletos())){
                if (validarReserva()){
                    string consultaSQLCancelar = "exec THE_FOREIGN_FOUR.proc_cancelar_reserva @cod_reserva,@motivo,@usuario";
                    SqlCommand cmd = new SqlCommand(consultaSQLCancelar, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(txtCodReserva.Text));
                    cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text);
                    cmd.Parameters.AddWithValue("@usuario", user);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ha cancelado la reserva satisfactoriamente, no se cobraran recargos por la misma", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarDatosCompletos()
        {
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCodReserva, "Codigo reserva") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtMotivo, "Motivo") 
            );
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        private bool validarReserva()
        {
            string consultaSQL;

            //valido si no esta efectivizada
            consultaSQL = "SELECT cod_estado_reserva FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva=" + txtCodReserva.Text;
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            if (resultado == 6){
                MessageBox.Show("Ya se vencio el plazo para poder cancelar esta reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //validaciones de no cancelada
            if (user == "Guest"){
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_guest(" + txtCodReserva.Text + ")";
            }else{
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_user(" + txtCodReserva.Text + "," + codigoHotel + ")";
            }

            resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == -1){
                MessageBox.Show("No se ha encontrado la reserva \no se trata de una reserva ya cancelada \no esta intentando con un usuario que no esta registrado para este hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string validacion = "SELECT THE_FOREIGN_FOUR.func_reserva_cancelable(" + txtCodReserva.Text + ")";
            SqlCommand command = new SqlCommand(validacion, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            resultado = (int)command.ExecuteScalar();

            switch (resultado)
            {
                case -1:
                    MessageBox.Show("La reserva ya está cancelada o efectivizada", "Error cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                case 0:
                    MessageBox.Show("No se pudo cancelar la reserva.\n Recuerde que sólo puede cancelar hasta un día antes del inicio de la misma", "Error cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
            }
            return true;
        }

        //solo permite numeros para el input del textbox
        private void txtCodReserva_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------
    }
}
