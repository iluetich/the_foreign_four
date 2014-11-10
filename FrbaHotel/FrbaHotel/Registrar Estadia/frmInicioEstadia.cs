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
                if (validarReserva())
                {
                    //REGISTRAR ESTADIA----
                    this.registrarEstadia();
                    //-------------
                    new frmRegistrarHuespedesRestantes(this).Show();
                    this.Enabled = false;
                }
            }
        }

        public void registrarEstadia()
        {
            SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_estadia", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod_reserva", txtCodReserva.Text);
            cmd.Parameters.AddWithValue("@usuario", user);
            
            cmd.ExecuteNonQuery();
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

            //validar check in si se puede hacer el dia actual
            string consulta = "DECLARE @resultado numeric(18,0); EXEC @resultado = THE_FOREIGN_FOUR.proc_validar_check_in " + txtCodReserva.Text + "," + codigoHotel + ";SELECT @resultado";
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = consulta;

            cmd.CommandType = CommandType.Text;

            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoCheckIn = Convert.ToInt32(cmd.ExecuteScalar());
            if (resultadoCheckIn != 1)
            {
                MessageBox.Show("ERROR el check in no se hizo en el dia que se genero la Reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (resultado != 1)
            {
                MessageBox.Show("Reserva no valida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (resultado == 1 && resultadoCheckIn == 1){
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
