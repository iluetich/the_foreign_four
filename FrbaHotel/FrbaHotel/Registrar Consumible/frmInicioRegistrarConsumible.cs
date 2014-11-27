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

namespace FrbaHotel.Registrar_Consumible
{

    public partial class frmInicioRegistrarConsumible : Form
    {
        private MenuDinamico menu;
        string codigoEstadia;
        string user;

        //------------------------------------------------------------------------------------------------------------
        public frmInicioRegistrarConsumible() { InitializeComponent(); }
        public frmInicioRegistrarConsumible(MenuDinamico menuPadre, string userSesion)
        {            
            InitializeComponent();
            this.menu = menuPadre;
            this.user = userSesion;
        }
        //------------------------------------------------------------------------------------------------------------
        
        
        //------------------------------------------------------------------------------------------------------------
        private void frmInicioRegistrarConsumible_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }
        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
        //------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodEstadia, "Codigo estadia")){
                codigoEstadia = txtCodEstadia.Text;
                object resultado = this.ejecutarConsultaLong("SELECT THE_FOREIGN_FOUR.func_check_out (" + txtCodEstadia.Text + ",'" + user + "')");

                switch ((int)resultado)
                {
                    case -1:
                        MessageBox.Show("La estadía especificada no existe. Por favor, ingrese un código de estadía válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 0:
                        MessageBox.Show("La estadía especificada está registrada como 'check-out'. Por favor, ingrese otra estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 1:
                        new frmRegistrarConsumible(this, codigoEstadia).Show();
                        break;
                }

                /*if (int.Parse(resultado.ToString()) == 1){
                    new frmRegistrarConsumible(this, codigoEstadia).Show();
                    this.Enabled = false;
                }else{
                    MessageBox.Show("ERROR no existe la estadia o la estadia ya finalizo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } */              
            }
        }
       
        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        public object ejecutarConsultaLong(string consulta){
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            return cmd.ExecuteScalar();
        }
        //-----------------------------------------------------------------------------------------------------
    }
}
