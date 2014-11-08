using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{   
    
    public partial class frmModificarRerserva : Form
    {
        frmBuscarReserva frmBuscarPadre;
        bool verifico = false;
        string codigoReserva;
        string codigoHotel;


        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmModificarRerserva(frmBuscarReserva newFrm)
        {
            InitializeComponent();
            frmBuscarPadre = newFrm;

            codigoReserva = frmBuscarPadre.getCodigoReserva();
            codigoHotel = frmBuscarPadre.getCodigoHotel();
            cargarTipoHabYRegimen();
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------



        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        private void frmModificarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBuscarPadre.Enabled = true;
            frmBuscarPadre.Focus();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (verifico){
                if (validarDatosCompletos() &
                    FrbaHotel.Utils.validarFechas(dtpFechaDesde,dtpFechaHasta)){
                        MessageBox.Show("Reserva modificada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                }
            }else{
                MessageBox.Show("Verifica disponibilidad antes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVerficarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (verificarDisponibilidad()){
                verifico = true;
            }else{
                MessageBox.Show("No disponible, revise su reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoReg, "Tipo regimen") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")
            );
        }

        private bool verificarDisponibilidad()
        {
            string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");
            string consultaSQL = "select THE_FOREIGN_FOUR.func_hay_disponibilidad(" + codigoReserva + ",'" + fechaDesde + "','" + fechaHasta + "'," + codigoTipoHabitacion + "," + codigoRegimen + ") as resultado";

            DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);
            DataRow row = dt.Rows[0];
            int resultado = Convert.ToInt32(row["resultado"]);

            if (resultado == 1){                
                return true;
            }
            return false;            
        }

        private void cargarTipoHabYRegimen(){

            string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel(" + codigoHotel + ")";
            string nombreTabla = "THE_FOREIGN_FOUR.TipoHabitacion";
            string nombreCampo = "descripcion";
            FrbaHotel.Utils.rellenarCombo(cmbTipoHab, nombreTabla, nombreCampo, consultaSQL);

            consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel(" + codigoHotel + ")";
            nombreTabla = "THE_FOREIGN_FOUR.TipoHabitacion";
            nombreCampo = "descripcion";
            FrbaHotel.Utils.rellenarCombo(cmbTipoHab, nombreTabla, nombreCampo, consultaSQL);                         
        
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

    }
}
