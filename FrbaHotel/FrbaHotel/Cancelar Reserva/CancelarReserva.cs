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
            FrbaHotel.ConexionSQL.establecerConexionBD();
        }

        public frmCancelarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
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
            if (validarReserva()){
                if (validarDatosCompletos())
                {
                    string consultaSQLCancelar = "exec THE_FOREIGN_FOUR.proc_cancelar_reserva @cod_reserva,@motivo,@usuario,@cod_hotel";
                    SqlCommand cmd = new SqlCommand(consultaSQLCancelar, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(txtCodReserva.Text));
                    cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text);
                    cmd.Parameters.AddWithValue("@usuario", user);
                    cmd.Parameters.AddWithValue("@cod_hotel", codigoHotel);

                    //cmd.ExecuteNonQuery();
                    int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQLCancelar);
                    if (resultado == 1)
                        MessageBox.Show("Ha cancelado la reserva satisfactoriamente", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Intento cancelar la reserva desde un hotel al cual no esta registrado en este momento", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else{
                MessageBox.Show("No se ha encontrado la reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (user == "Guest"){
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_existe_reserva_no_cancelada(" + txtCodReserva.Text + ")";
                codigoHotel = "null";
            }else{
                consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada(" + txtCodReserva.Text + "," + codigoHotel + ")";
            }

            int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == 1){
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------
    }
}
