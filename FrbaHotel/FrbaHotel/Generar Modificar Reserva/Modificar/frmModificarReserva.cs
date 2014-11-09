using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{   
    
    public partial class frmModificarRerserva : Form
    {
        frmBuscarReserva frmBuscarPadre;
        bool verifico = false;
        string codigoReserva;
        string codigoHotel;
        string codigoRegimen;
        string codigoTipoHabitacion;
        DataSet dataSetTipoHab;
        bool terminoDeCargarTodo = false;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmModificarRerserva(frmBuscarReserva newFrm)
        {
            InitializeComponent();
            frmBuscarPadre = newFrm;

            codigoReserva = frmBuscarPadre.getCodigoReserva(); //obtiene codigo de reserva de la ventana padre
            codigoHotel = frmBuscarPadre.getCodigoHotel(); //obtiene codigo de hotel de la ventana padre
            cargarTipoHabYRegimen();
            terminoDeCargarTodo = true;
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
                MessageBox.Show("Reserva modificada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }else{
                MessageBox.Show("Verifica disponibilidad primero", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVerficarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos()){
                if (verificarDisponibilidad()){
                    verifico = true;
                    MessageBox.Show("Ha modificado la reserva correctamente", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else{
                    MessageBox.Show("No disponible, revise su reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")&
                FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Regimen")&
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)
            );
        }

        private bool verificarDisponibilidad()
        {
            string consultaSQL = "select THE_FOREIGN_FOUR.func_hay_disponibilidad(@cod_hotel,@cod_tipo_hab,@cod_regimen,@fecha_desde,@fecha_hasta) as resultado";
            SqlCommand cmd = new SqlCommand(consultaSQL,FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            
            string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");

            cmd.Parameters.AddWithValue("@cod_hotel", Convert.ToInt32(codigoHotel));
            cmd.Parameters.AddWithValue("@cod_tipo_hab", Convert.ToInt32(codigoTipoHabitacion));
            cmd.Parameters.AddWithValue("@cod_regimen", Convert.ToInt32(codigoRegimen));
            cmd.Parameters.AddWithValue("@fecha_desde", fechaDesde);
            cmd.Parameters.AddWithValue("@fecha_hasta", fechaHasta);

            Console.WriteLine(codigoReserva);
            Console.WriteLine(codigoHotel);            
            Console.WriteLine(codigoTipoHabitacion);
            Console.WriteLine(codigoRegimen);
            Console.WriteLine(fechaDesde);
            Console.WriteLine(fechaHasta);

            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine("el resultado es: " + resultado);

            //DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);
            //DataRow row = dt.Rows[0];
            //int resultado = Convert.ToInt32(row["resultado"]);

            if (resultado == 1){                
                return true;
            }
            return false;            
        }

        //carga desde la bd el tipo de habitacion y regimen del hotel
        private void cargarTipoHabYRegimen(){

            string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel(" + codigoHotel + ")";
            string nombreTabla = "THE_FOREIGN_FOUR.TipoHabitacion";
            string nombreCampo = "descripcion";
            dataSetTipoHab = FrbaHotel.Utils.rellenarCombo(cmbTipoHab, nombreTabla, nombreCampo, consultaSQL);

            consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_regimenes_hotel(" + codigoHotel + ")";
            FrbaHotel.Utils.rellenarDataGridView(dgvRegimenes,consultaSQL);

            dgvRegimenes.Columns["cod_hotel"].Visible = false;
            dgvRegimenes.Columns["cod_regimen"].Visible = false;
        }


        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvRegimenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1){
                DataGridViewRow row = dgvRegimenes.Rows[e.RowIndex];                
                codigoRegimen = row.Cells[1].Value.ToString();
                txtRegimen.Text = row.Cells[2].Value.ToString(); ;
            }
        }

        private void cmbTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (terminoDeCargarTodo)
            {
                DataRow codRowTipoHab = dataSetTipoHab.Tables[0].Rows[cmbTipoHab.SelectedIndex];
                codigoTipoHabitacion = codRowTipoHab["cod_tipo_hab"].ToString();
            }
        }

        private void lblTipoReg_Click(object sender, EventArgs e)
        {

        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

    }
}
