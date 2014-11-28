using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Generar_Modificar_Reserva.Nueva;

namespace FrbaHotel.Generar_Modificar_Reserva
{   
    
    public partial class frmModificarRerserva : Form
    {
        frmBuscarReserva frmBuscarReservaPadre;      
        string user;
        string codigoReserva;
        string codigoHotel;
        string codigoRegimen;
        string codigoTipoHabitacion;
        bool habitacionesIsOn;
        bool cargaDevueltaDispTipoHab;
        DataTable dataTableHabitaciones;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmModificarRerserva() { InitializeComponent(); }  
        public frmModificarRerserva(frmBuscarReserva newFrm)
        {
            InitializeComponent();
            frmBuscarReservaPadre = newFrm;

            codigoReserva = frmBuscarReservaPadre.getCodigoReserva(); //obtiene codigo de reserva de la ventana padre
            codigoHotel = frmBuscarReservaPadre.getCodigoHotel(); //obtiene codigo de hotel de la ventana padre
            user = frmBuscarReservaPadre.getUsuario(); //obtiene el user de la ventana padre
            
            habitacionesIsOn = false;
            cargaDevueltaDispTipoHab = false;
            cargarDatosReserva();
            cargarTipoRegimenes();
            //dgvHabitaciones.Columns["codigo"].Visible = false;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        private void frmModificarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            //chequea si existe la tabla temporal
            string checkTablaSQL = "IF OBJECT_ID('tempdb.THE_FOREIGN_FOUR.#TipoHabDisponibles', 'U') IS NOT NULL DROP TABLE THE_FOREIGN_FOUR.#TipoHabDisponibles";
            SqlCommand cmd = new SqlCommand(checkTablaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.ExecuteNonQuery();

            frmBuscarReservaPadre.Enabled = true;
            frmBuscarReservaPadre.Focus();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        private void btnModificar_Click(object sender, EventArgs e)
        {            
                if (validarDatosCompletos())
                {                   
                        //modifica reserva
                        string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
                        string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");

                        string consultaSQLCancelar = "exec THE_FOREIGN_FOUR.proc_modificar_reserva @cod_reserva,@fecha_desde,@fecha_hasta,@cod_regimen,@usuario";
                        SqlCommand cmd = new SqlCommand(consultaSQLCancelar, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                        cmd.Parameters.AddWithValue("@cod_reserva", Convert.ToInt32(codigoReserva));
                        cmd.Parameters.AddWithValue("@fecha_desde", fechaDesde);
                        cmd.Parameters.AddWithValue("@fecha_hasta", fechaHasta);                        
                        cmd.Parameters.AddWithValue("@cod_regimen", Convert.ToInt32(codigoRegimen));
                        cmd.Parameters.AddWithValue("@usuario", user);
                        cmd.ExecuteNonQuery();

                        updatearHabitaciones();
                        agregarHabitaciones();

                        MessageBox.Show("Ha modificado la reserva correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        volverAlMenu();
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
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasta")&
                FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Regimen")&
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)&
                cargoHabitaciones()
            );
        }

        private bool verificarDisponibilidad()
        {
            string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");

            string consultaSQL = "select disponibilidad from #TipoHabDisponibles where cod_tipo_hab=" + codigoTipoHabitacion;
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int disponibilidad = Convert.ToInt32(cmd.ExecuteScalar());

            if (disponibilidad > 0){
                //Descuenta disponibilidad
                string resta = (disponibilidad - 1).ToString();
                string updateSQL = "UPDATE THE_FOREIGN_FOUR.#TipoHabDisponibles SET disponibilidad =" + resta + "WHERE cod_tipo_hab =" + codigoTipoHabitacion;
                cmd = new SqlCommand(updateSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.ExecuteNonQuery();
                return true;
            }else{               
                return false;
            }    
        }

        //carga desde la bd el tipo de habitacion y regimen del hotel
        private void cargarTipoRegimenes()
        {
            string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_regimenes_hotel(" + codigoHotel + ")";
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

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            if (!validarFechas()) return;
            
            if (!habitacionesIsOn){
                if (!cargaDevueltaDispTipoHab)
                {
                    cargarTipoHabitacionesDisponibles();
                }
                new frmHabitaciones(this).Show();
                habitacionesIsOn = true;
                this.Enabled = false;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e){
            cargaDevueltaDispTipoHab = false; limpiar(); 
        }
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e){
            cargaDevueltaDispTipoHab = false; limpiar(); 
        }
        private void txtRegimen_TextChanged(object sender, EventArgs e){
            cargaDevueltaDispTipoHab = false; limpiar(); 
        }

        //obtengo la tabla
        public void cargarTipoHabitacionesDisponibles()
        {
            cargaDevueltaDispTipoHab = true;

            //chequea si existe la tabla temporal
            string checkTablaSQL = "IF OBJECT_ID('tempdb.THE_FOREIGN_FOUR.#TipoHabDisponibles', 'U') IS NOT NULL DROP TABLE THE_FOREIGN_FOUR.#TipoHabDisponibles";
            SqlCommand cmd = new SqlCommand(checkTablaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.ExecuteNonQuery();

            //crea tabla temporal
            string crearTablaTemporalSQL = "CREATE TABLE THE_FOREIGN_FOUR.#TipoHabDisponibles(cod_tipo_hab numeric(18,0),disponibilidad numeric(18,0))";
            cmd = new SqlCommand(crearTablaTemporalSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.ExecuteNonQuery();

            //obtengo los tipos de habitacion del hotel
            string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel(" + codigoHotel + ")";
            dataTableHabitaciones = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);

            string cod_tipo_hab = "";
            string disponibilidad = "";
            string disponibilidadSQL = "";
            string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");

            foreach (DataRow row in dataTableHabitaciones.Rows)
            {
                //obtengo las disponibilidades por tipo habitacion
                cod_tipo_hab = row["cod_tipo_hab"].ToString();
                disponibilidadSQL = "select THE_FOREIGN_FOUR.func_hab_disponibles(" + codigoHotel + "," + cod_tipo_hab + ",'" + fechaDesde + "','" + fechaHasta + "')";
                cmd = new SqlCommand(disponibilidadSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                disponibilidad = cmd.ExecuteScalar().ToString();
                //insert en la tabla
                string insertSQL = "INSERT INTO THE_FOREIGN_FOUR.#TipoHabDisponibles (cod_tipo_hab, disponibilidad)VALUES(" + cod_tipo_hab + "," + disponibilidad + ")";
                cmd = new SqlCommand(insertSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Habitacion tipo: " + cod_tipo_hab + " disponibilidad: " + disponibilidad);
            }
        }

        //tomo la fila seleccionada del form tipo habitaciones
        public void filaSeleccionadaDataGridHabitaciones(DataGridViewRow row)
        {
            codigoTipoHabitacion = row.Cells[0].Value.ToString();           

            if (verificarDisponibilidad()){
                //agrego las habitaciones a la tabla
                string codigo = row.Cells[0].Value.ToString();
                string descripcion = row.Cells[1].Value.ToString();
                string capacidad = row.Cells[3].Value.ToString();
                dgvHabitaciones.Rows.Add(new[] { codigo, descripcion });
            }else{                   
                MessageBox.Show("No hay mas habitaciones "+row.Cells[1].Value.ToString()+" disponibles en el hotel durante el período especificado. Por favor, modifique el período de la reserva y vuelva a intentarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        //Limpia la tabla de habitaciones
        //private void limpiarGridHabitaciones()
        //{
           // dgvHabitaciones.Rows.Clear();
            //cargarTipoHabitacionesDisponibles();            
        //}

        //limpia tabla de habitaciones
        private void limpiar()
        {
            dgvHabitaciones.Rows.Clear();           
        }

        //vuelve al menu
        private void volverAlMenu()
        {
            this.Close();
            frmBuscarReservaPadre.Close();
        }

        //hace update a la tabla de tipo habitacion por reserva
        private void updatearHabitaciones()
        {
            string updateSQL = "exec THE_FOREIGN_FOUR.proc_liberar_habitaciones @cod_reserva";
            SqlCommand cmd = new SqlCommand(updateSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.Parameters.AddWithValue("@cod_reserva",Convert.ToInt32(codigoReserva));
            cmd.ExecuteNonQuery();        
        }

        private void agregarHabitaciones()
        {
            SqlCommand cmd;
            int cod_tipo_hab;
            string habitacionSQL;

            foreach (DataGridViewRow row in dgvHabitaciones.Rows)
            {
                cod_tipo_hab = Convert.ToInt32(row.Cells["codigo"].Value);
                habitacionSQL = "THE_FOREIGN_FOUR.proc_agregar_hab_reserva @cod_reserva, @cod_tipo_hab";
                cmd = new SqlCommand(habitacionSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.Parameters.AddWithValue("@cod_tipo_hab", cod_tipo_hab);
                cmd.Parameters.AddWithValue("@cod_reserva", codigoReserva);
                cmd.ExecuteNonQuery();
            }
        }

        private void cargarDatosReserva()
        {
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_obtener_datos_reserva(" + codigoReserva + ")";
            DataTable dtReserva = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);
            DataRow row = dtReserva.Rows[0];

            string fechaDesde = row["fecha_desde"].ToString();
            DateTime dtFechaDesde = Convert.ToDateTime(fechaDesde);
            dtpFechaDesde.Value = dtFechaDesde;

            string fechaHasta = row["fecha_hasta"].ToString();
            DateTime dtFechaHasta = Convert.ToDateTime(fechaHasta);
            dtpFechaHasta.Value = dtFechaHasta;

            string regimen = row["cod_regimen"].ToString();
            codigoRegimen = regimen;
            string regimenSQL = "select descripcion from THE_FOREIGN_FOUR.Regimenes where cod_regimen =" + regimen;
            SqlCommand cmd = new SqlCommand(regimenSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            txtRegimen.Text = cmd.ExecuteScalar().ToString();

            string habitacionesSQL = "select * from THE_FOREIGN_FOUR.func_obtener_tipo_hab_reserva("+codigoReserva+")";
            DataTable dtHabitaciones = FrbaHotel.Utils.obtenerDatosBD(habitacionesSQL);

            foreach (DataRow rowHab in dtHabitaciones.Rows)
            {
                string codigo = rowHab["cod_tipo_hab"].ToString();
                string descripcion = rowHab["descripcion"].ToString();
                dgvHabitaciones.Rows.Add(new[] {codigo, descripcion });
            }                  
        }

        private bool cargoHabitaciones(){
            if (dgvHabitaciones.Rows.Count <= 0){
                MessageBox.Show("No esta agregando ninguna habitacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }else{
                return true; 
            }
        }

        private bool validarFechas(){
            if (FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
                string consultaSQL = "select THE_FOREIGN_FOUR.func_validar_fecha_reserva(@cod_hotel,@fecha_desde)";
                SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.Parameters.AddWithValue("@cod_hotel", Convert.ToInt32(codigoHotel));
                cmd.Parameters.AddWithValue("@fecha_desde", fechaDesde);
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                if (resultado == 1){
                    return true;
                }else{
                    MessageBox.Show("Ingrese en 'fecha_desde' una fecha mayor a la fecha actual y al de la creacion del hotel", "Advertencia Fecha Antigua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------

        
        //SETTERS---------------------------------------------------------------------------       
        public void setHabitacionesIsOn() { habitacionesIsOn = false; }
        //----------------------------------------------------------------------------------
        
        //GETTERS--------------------------------------------------------------------------- 
        public int getCodigoHotel() { return Convert.ToInt32(codigoHotel); }

       

      

        
        
    }
}

