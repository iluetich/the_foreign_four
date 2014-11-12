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
using FrbaHotel.Generar_Modificar_Reserva.Nueva;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmGenerarReserva : Form
    {
        private MenuDinamico menu;             
        bool regimenesIsOn;
        bool habitacionesIsOn;
        bool boolVerificoDisp;
        bool boolPasaAClientes;
        bool cargaDevueltaDispTipoHab;
        bool terminoDeCargarTodo = false; 
        string codigoHotel;        
        int costoPorDia;
        int costoTotal;
        string codigoRegimen;
        string codigoTipoHabitacion;
        DataSet dataSetHotel;        
        string user;        
        DataTable dataTableHabitaciones;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        //constructor generico  
        public frmGenerarReserva() { InitializeComponent(); }

        public frmGenerarReserva(MenuDinamico menuPadre,string userSesion, string hotelSesion)
        {
            this.menu = menuPadre;
            InitializeComponent();

            codigoHotel = hotelSesion; 
            user = userSesion; 
            costoTotal = 0;
            dgvHabitaciones.Columns["codigo"].Visible = false;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        //evento load del form
        private void frmGenerarReserva_Load(object sender, EventArgs e)
        {
            //seteo de booleanos
            regimenesIsOn = false;
            habitacionesIsOn = false;
            boolVerificoDisp = false;
            cargaDevueltaDispTipoHab = false;         
            
            if (user != "Guest"){
                cmbHotel.Enabled = false;
            }else{
                cargarHoteles();
            }           
            terminoDeCargarTodo = true;            
        }

        //evento para el cierre del form
        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //chequea si existe la tabla temporal
            string checkTablaSQL = "IF OBJECT_ID('tempdb.THE_FOREIGN_FOUR.#TipoHabDisponibles', 'U') IS NOT NULL DROP TABLE THE_FOREIGN_FOUR.#TipoHabDisponibles";
            SqlCommand cmd = new SqlCommand(checkTablaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.ExecuteNonQuery();

            this.menu.Show();
        }

        //valida que los campos esten completos
        private bool validarDatosCompletos()
        {
            if (user != "Guest"){
                return (                    
                    FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                    FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata") &
                    FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Tipo Regimen")
                );
            }else{
                return (
                    FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &
                    FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                    FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata") &
                    FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Tipo Regimen")
                );
            }
        }

        //carga de controles desde la BD
        private void cargarHoteles()
        {
            string consultaSql = "select * from THE_FOREIGN_FOUR.Hoteles";
            string nombreTabla = "THE_FOREIGN_FOUR.Hoteles";
            string nombreCampo = "nombre";

            //llena el combo
            dataSetHotel = FrbaHotel.Utils.rellenarCombo(cmbHotel, nombreTabla, nombreCampo, consultaSql);
         }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        //muestra ventana regimenes
        private void btnRegimenes_Click(object sender, EventArgs e)
        {
            if (!regimenesIsOn){
                    new frmRegimenes(this, regimenesIsOn, codigoHotel).Show();
                    regimenesIsOn = true;
            }           
        }

        //boton a la siguiente ventana
        private void btnSiguietne_Click(object sender, EventArgs e)
        {
            if (boolVerificoDisp){
                if (boolPasaAClientes){
                    new frmCliente(this).Show();
                    this.Enabled = false;
                }else{
                    MessageBox.Show("Reserva no disponible, verifique", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else{
                MessageBox.Show("Cargue los datos de la reserva antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 

        //boton volver
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //agrega tipo habitacion
        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {            
            if (!habitacionesIsOn){

                if (!cargaDevueltaDispTipoHab){
                    cargarTipoHabitacionesDisponibles();                
                }
                new frmHabitaciones(this).Show();
                habitacionesIsOn = true;
                this.Enabled = false;
            }
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
     

        //----------------------EVENTOS TEXTBOX Y COMOBOBOX-------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------- 
        //pone en false el booleano cuando se cambia de valor en los cotroles para verificar la diponibilidad nuevamente
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e) { 
            boolVerificoDisp = false;
            cargaDevueltaDispTipoHab = false;
            limpiar();
        }
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e){
            boolVerificoDisp = false;
            cargaDevueltaDispTipoHab = false;
            limpiar();
        }
                
        //evento para que cuando cambie el idex del combo hotel se auto cargue en el combo habitaciones las correspondientes al hotel
        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar();
            
            boolVerificoDisp = false;
            cargaDevueltaDispTipoHab = false;
            
            if (terminoDeCargarTodo)
            {               
                //cargo codigo hotel
                DataRow codRowHotel = dataSetHotel.Tables[0].Rows[cmbHotel.SelectedIndex];
                codigoHotel = codRowHotel["cod_hotel"].ToString();
            }
        }       

        //muestra costo por dia
        private void txtRegimen_TextChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;
            cargaDevueltaDispTipoHab = false;
            limpiar();
        }
        //------------------------------------------------------------------------------------------------------------
        //----------------------FIN EVENTOS TEXTBOX Y COMOBOBOX-------------------------------------------------------

        
        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        //obtengo la fila seleccionada del grid de regimenes para llenar el textbox con el regimen
        public void filaSeleccionadaDataGrid(DataGridViewRow row)
        {            
            //actualizo txtbox
            txtRegimen.Text = row.Cells[1].Value.ToString();
            //codigo regimen
            codigoRegimen = row.Cells[0].Value.ToString();
        }       

        //verifica la disponibilidad de la reserva
        private bool verificarDisponibilidad()
        {           
            string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");          

            string consultaSQL = "select disponibilidad from #TipoHabDisponibles where cod_tipo_hab="+codigoTipoHabitacion;
            SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int disponibilidad = Convert.ToInt32(cmd.ExecuteScalar());           

            if (disponibilidad > 0)
            {
                //Descuenta disponibilidad
                string resta = (disponibilidad - 1).ToString();
                string updateSQL = "UPDATE THE_FOREIGN_FOUR.#TipoHabDisponibles SET disponibilidad =" + resta + "WHERE cod_tipo_hab =" + codigoTipoHabitacion;
                cmd = new SqlCommand(updateSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.ExecuteNonQuery();

                boolPasaAClientes = true;
                return true; 
            }else{

                boolPasaAClientes = false;
                return false; 
            }
        }

        //calcula el costo total
        private void calcularCostoTotal()
        {
            int cantDias = (dtpFechaHasta.Value - dtpFechaDesde.Value).Days;

            //Calcula costo por dia
            string costoPorDiaSQL = "select THE_FOREIGN_FOUR.func_calcular_precio("+codigoRegimen+","+codigoHotel+","+codigoTipoHabitacion+")";
            SqlCommand cmd = new SqlCommand(costoPorDiaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());

            costoPorDia = resultado;
            txtCostoXDia.Text = "USD " + costoPorDia.ToString();

            costoTotal += (costoPorDia * cantDias);
            txtCostoTotal.Text = "USD " + costoTotal.ToString();
        }        
       
        //tomo la fila seleccionada del form tipo habitaciones
        public void filaSeleccionadaDataGridHabitaciones(DataGridViewRow row)
        {            
            codigoTipoHabitacion = row.Cells[0].Value.ToString();

            if (validarDatosCompletos() & FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){

                boolVerificoDisp = true;
                
                if (verificarDisponibilidad()){
                    //agrego las habitaciones a la tabla
                    string codigo = row.Cells[0].Value.ToString();
                    string descripcion = row.Cells[1].Value.ToString();
                    string capacidad = row.Cells[3].Value.ToString();
                    dgvHabitaciones.Rows.Add(new[] { codigo, descripcion, capacidad }); 

                    txtResul.BackColor = Color.Green;
                    txtResul.Text = "Disponible";
                    calcularCostoTotal();

                }else{
                    txtResul.BackColor = Color.Red;
                    txtResul.Text = "NO Disponible";
                    MessageBox.Show("Modifique su reserva","Reserva No disponible");
                    limpiarGridHabitaciones();
                }
            }                  
        }

        //obtengo la tabla
        public void cargarTipoHabitacionesDisponibles(){

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

            foreach(DataRow row in dataTableHabitaciones.Rows){
                //obtengo las disponibilidades por tipo habitacion
                cod_tipo_hab = row["cod_tipo_hab"].ToString();
                disponibilidadSQL = "select THE_FOREIGN_FOUR.func_hab_disponibles(" + codigoHotel + "," + cod_tipo_hab + ",'" + fechaDesde + "','" + fechaHasta + "')";
                cmd = new SqlCommand(disponibilidadSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                disponibilidad = cmd.ExecuteScalar().ToString();              
                //insert en la tabla
                string insertSQL = "INSERT INTO THE_FOREIGN_FOUR.#TipoHabDisponibles (cod_tipo_hab, disponibilidad)VALUES(" + cod_tipo_hab + "," + disponibilidad + ")";
                cmd = new SqlCommand(insertSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.ExecuteNonQuery();
            }
        }

        //Limpia la tabla de habitaciones
        private void limpiarGridHabitaciones()
        {          
            dgvHabitaciones.Rows.Clear();
            cargarTipoHabitacionesDisponibles();
            txtCostoTotal.Text = "";
            txtCostoXDia.Text = "";
        }
        private void limpiar()
        {
            dgvHabitaciones.Rows.Clear();
            txtCostoTotal.Text = "";
            txtCostoXDia.Text = "";
            txtResul.Text = "";
            txtResul.BackColor = Color.Empty;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------
        

        //SETTERS--------------------------------------------------------------------------- 
        //metodo llamado del form de regimenes
        public void setRegimesIsOn(){   regimenesIsOn = false;}
        public void setHabitacionesIsOn() { habitacionesIsOn = false; }
        //----------------------------------------------------------------------------------

        //GETTERS--------------------------------------------------------------------------- 
        public int getCodigoHotel(){    return Convert.ToInt32(codigoHotel);}        
        public int getCodigoTipoHab(){  return Convert.ToInt32(codigoTipoHabitacion);}
        public int getCodigoRegimen(){  return Convert.ToInt32(codigoRegimen);}
        public string getFechaDesde(){  return dtpFechaDesde.Value.ToString("yyyy-dd-MM");}
        public string getFechaHasta(){  return dtpFechaHasta.Value.ToString("yyyy-dd-MM");}
        public string getUserName() {   return user; }
        public DataGridView getDGVHabitaciones(){ return dgvHabitaciones;}  
    }
}
