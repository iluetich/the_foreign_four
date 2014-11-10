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
        frmGenerarReserva instanciaReservaAnterior;       
        bool regimenesIsOn;
        bool habitacionesIsOn;
        bool boolVerificoDisp;
        bool boolPasaAClientes;
        bool terminoDeCargarTodo = false; //para que no rompa el selectindex changed de los combos 
        string codigoHotel;
        int precioBase;
        int costoPorDia;        
        string codigoRegimen;
        string codigoTipoHabitacion;
        DataSet dataSetHotel;        
        string user;
        int cantidadHabDispPorHotelYPorTipoHab;

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
        }

        //constructor que se invoca si se quiere agregar otra habitacion
        public frmGenerarReserva(frmGenerarReserva newFrm, bool flag) 
        { 
          InitializeComponent();
          this.instanciaReservaAnterior = newFrm;
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
         
            //carga controles desde la BD
            FrbaHotel.ConexionSQL.establecerConexionBD();
            if (user == "Guest"){
                cmbHotel.Enabled = false;
            }else{
                cargarHoteles();
            }
            terminoDeCargarTodo = true;            
        }

        //evento para el cierre del form
        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }

        //valida que los campos esten completos
        private bool validarDatosCompletos()
        {
            return (
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &                                
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata") &
                FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Tipo Regimen")                
            );
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

        //valida que el input del textbox sean solo numeros
        private void txtCantHues_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); 
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
                MessageBox.Show("Verifique la disponibilidad de la reserva antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 

        //boton volver
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {            
            if (!habitacionesIsOn){
                new frmHabitaciones(this).Show();
                habitacionesIsOn = true;
            }
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
     

        //----------------------EVENTOS TEXTBOX Y COMOBOBOX-------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------- 
        //pone en false el booleano cuando se cambia de valor en los cotroles para verificar la diponibilidad nuevamente
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e) { boolVerificoDisp = false; }
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e) { boolVerificoDisp = false; }
                
        //evento para que cuando cambie el idex del combo hotel se auto cargue en el combo habitaciones las correspondientes al hotel
        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;
            
            if (terminoDeCargarTodo)
            {               
                //cargo codigo hotel
                DataRow codRowHotel = dataSetHotel.Tables[0].Rows[cmbHotel.SelectedIndex];
                codigoHotel = codRowHotel["cod_hotel"].ToString();

                string fechaDesde = dtpFechaDesde.Value.ToString("yyyy-dd-MM");
                string fechaHasta = dtpFechaHasta.Value.ToString("yyyy-dd-MM");
                string consultaSQL = "select THE_FOREIGN_FOUR.func_hab_disponibles(" + codigoHotel + "," + codigoTipoHabitacion + ",'" + fechaDesde + "','" + fechaHasta + "')";
                SqlCommand cmd = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cantidadHabDispPorHotelYPorTipoHab = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }       

        //muestra costo por dia
        private void txtRegimen_TextChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;

            //Obtengo el recargo por estrellas del hotel           
            string consultaSQL = "select recarga_estrellas from THE_FOREIGN_FOUR.Hoteles where cod_hotel=" + codigoHotel + ";";
            DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);

            DataRow row = dt.Rows[0];
            int incrementoPorEstrellas = Convert.ToInt32(row["recarga_estrellas"]);
            //TODO modificar esto
            //costoPorDia = precioBase * Convert.ToInt32(txtCantHuespedes.Text) + incrementoPorEstrellas;
            //txtCostoXDia.Text = "USD " + (precioBase * Convert.ToInt32(txtCantHuespedes.Text) + incrementoPorEstrellas).ToString();
        }
        //------------------------------------------------------------------------------------------------------------
        //----------------------FIN EVENTOS TEXTBOX Y COMOBOBOX-------------------------------------------------------

        
        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        //obtengo la fila seleccionada del grid de regimenes para llenar el textbox con el regimen
        public void filaSeleccionadaDataGrid(DataGridViewRow row)
        {
            //precio base del regimen            
            precioBase = Convert.ToInt32(row.Cells[2].Value);        
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
            string consultaSQL = "select THE_FOREIGN_FOUR.func_hay_disponibilidad(" + codigoHotel + "," + codigoTipoHabitacion + "," + codigoRegimen + ",'" + fechaDesde + "','" + fechaHasta + "') as resultado;";
            
            DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);
            DataRow row = dt.Rows[0];
            int resultado = Convert.ToInt32(row["resultado"]);                    
            
            if (resultado == 1) {
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
            int costoTotal = 0;
            int cantDias = (dtpFechaHasta.Value - dtpFechaDesde.Value).Days;

            costoTotal += costoPorDia;
            costoTotal *= cantDias;

            txtCostoTotal.Text = "USD " + costoTotal.ToString();
        }        
       
        //tomo la fila seleccionada del form tipo habitaciones
        public void filaSeleccionadaDataGridHabitaciones(DataGridViewRow row)
        {
            //obtengo codigo tipo habitacion
            codigoTipoHabitacion = row.Cells[0].Value.ToString();

            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                boolVerificoDisp = true;

                if (verificarDisponibilidad()){
                    string descripcion = row.Cells[1].Value.ToString();
                    string capacidad = row.Cells[3].Value.ToString();
                    dgvHabitaciones.Rows.Add(new[] { descripcion, capacidad }); 

                    txtResul.BackColor = Color.Green;
                    txtResul.Text = "Disponible";
                    calcularCostoTotal();

                }else{
                    txtResul.BackColor = Color.Red;
                    txtResul.Text = "NO Disponible";
                }
            }                  
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
        //----------------------------------------------------------------------------------
    }
}
