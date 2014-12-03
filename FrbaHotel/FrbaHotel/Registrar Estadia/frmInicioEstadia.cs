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
            //Valida que no se le haya hecho check in antes
            string consultaSQL = "SELECT cod_estado_reserva FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva = @cod_reserva";
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(txtCodReserva.Text));
            if (Convert.ToInt32(cmd.ExecuteScalar()) == 6){
                MessageBox.Show("Ya se le hizo Check IN a esta reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            //valida existencia
            consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva(" + txtCodReserva.Text + "," + codigoHotel + ")";
            SqlCommand cmd2 = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultado = Convert.ToInt32(cmd2.ExecuteScalar());
            if (resultado == -1)
            {
                MessageBox.Show("La Reserva no existe, o no tiene autorizacion en este hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //valida si no esta cancelada
            consultaSQL = "select THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_guest(" + txtCodReserva.Text + "," + codigoHotel + ")";            
            resultado = FrbaHotel.Utils.ejecutarConsultaResulInt(consultaSQL);
            if (resultado == -1){
                MessageBox.Show("Se trata de una Reserva Cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //validar check in si se puede hacer el dia actual
            string consulta = "DECLARE @resultado numeric(18,0); EXEC @resultado = THE_FOREIGN_FOUR.proc_validar_check_in " + txtCodReserva.Text + "," + codigoHotel + ";SELECT @resultado";
            SqlCommand cmd3 = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultadoCheckIn = Convert.ToInt32(cmd3.ExecuteScalar());
            if (resultadoCheckIn == -1){
                MessageBox.Show("El CHECK IN se debe realizar el dia en que comienza la estadia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (resultadoCheckIn == 0){
                consulta = "SELECT fecha_desde FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva =" + txtCodReserva.Text;
                cmd3 = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                string fecha = cmd3.ExecuteScalar().ToString();
                fecha = fecha.Substring(0,10);
                MessageBox.Show("Se vencio el plazo para realizar CHECK IN, la fecha para realizarlo era el dia '" 
                                + fecha + "' la reserva queda sin efecto.\nNo se cobrara recargo por la misma,"+
                                " si desea hospedarse de todas formas realice una nueva reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
