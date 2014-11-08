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


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmGenerarReserva : Form
    {
        private MenuDinamico menu;
        frmGenerarReserva instanciaReservaAnterior;
        bool agregarOtraHabitacion;
        bool regimenesIsOn;
        bool boolVerificoDisp;
        bool boolPasaAClientes;
        bool terminoDeCargarTodo = false; //para que no rompa el selectindex changed de los combos 
        string codigoHotel;
        int precioBase;
        int costoPorDia;
        int capacidadHabitacionActual;
        string codigoRegimen;
        string codigoTipoHabitacion;
        DataSet dataSetHotel;
        DataSet dataSetHab;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        //constructor generico  
        public frmGenerarReserva() { InitializeComponent(); }

        public frmGenerarReserva(MenuDinamico menuPadre,string userSesion, string hotelSesion)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        //constructor que invoca el menu
        public frmGenerarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        //constructor que se invoca si se quiere agregar otra habitacion
        public frmGenerarReserva(frmGenerarReserva newFrm, bool flag) 
        { 
          InitializeComponent(); 
          agregarOtraHabitacion = true;
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
            boolVerificoDisp = false;
         
            //carga controles desde la BD
            FrbaHotel.ConexionSQL.establecerConexionBD();
            cargarControles();
            terminoDeCargarTodo = true;
            cmbHotel.SelectedIndex = 0;
            
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
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbCantHues, "cantidad huespedes") &
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
                FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata") &
                FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Tipo Regimen") &
                verificarCantHuespedesConTipoHabitacion()
            );
        }

        //carga de controles desde la BD
        private void cargarControles()
        {
            string consultaSql = "select * from THE_FOREIGN_FOUR.Hoteles";
            string nombreTabla = "THE_FOREIGN_FOUR.Hoteles";
            string nombreCampo = "nombre";

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
            if (cmbCantHues.SelectedIndex != -1){
                if (!regimenesIsOn){
                    Console.WriteLine(codigoHotel);
                    new frmRegimenes(this, regimenesIsOn, codigoHotel).Show();
                    regimenesIsOn = true;
                }
            }else{
                MessageBox.Show("Complete la cantidad de huespedes primero");
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

        //verifica que los campos esten completos cuando se verifica la disponibilidad y autoriza al boton siguiente
        private void btnVerificarDisp_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                boolVerificoDisp = true;
                if (verificarDisponibilidad()){
                    txtResul.BackColor = Color.Green;
                    txtResul.Text = "Disponible";
                    calcularCostoTotal();
                }else{
                    txtResul.BackColor = Color.Red;
                    txtResul.Text = "NO Disponible";
                }
            }
        }

        //boton volver
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
     

        //----------------------EVENTOS TEXTBOX Y COMOBOBOX-------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------- 
        //pone en false el booleano cuando se cambia de valor en los cotroles para verificar la diponibilidad nuevamente
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e) { boolVerificoDisp = false; }
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e) { boolVerificoDisp = false; }
        private void txtCantHues_TextChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;
            if (txtRegimen.Text != "")
            {
                txtRegimen_TextChanged(null, null); //si cambio la cant de huespedes llamo al textChanged para que refreshee
            }
        }
        
        //evento para que cuando cambie el idex del combo hotel se auto cargue en el combo habitaciones las correspondientes al hotel
        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;
            
            if (terminoDeCargarTodo)
            {               
                //cargo codigo hotel
                DataRow codRowHotel = dataSetHotel.Tables[0].Rows[cmbHotel.SelectedIndex];
                codigoHotel = codRowHotel["cod_hotel"].ToString();
                
                string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel("+codigoHotel+")";
                string nombreTabla = "THE_FOREIGN_FOUR.TipoHabitacion";
                string nombreCampo = "descripcion";
                dataSetHab = FrbaHotel.Utils.rellenarCombo(cmbTipoHab, nombreTabla, nombreCampo, consultaSQL);                            

            }
        }

        //combo hotel
        private void cmbTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {
           boolVerificoDisp = false;
           //obtiene cod_tipo_habitacion            
            if (terminoDeCargarTodo)
            {
                DataRow codRowTipoHab = dataSetHab.Tables[0].Rows[cmbTipoHab.SelectedIndex];
                codigoTipoHabitacion = codRowTipoHab["cod_tipo_hab"].ToString();
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

            costoPorDia = precioBase * Convert.ToInt32(cmbCantHues.Text) + incrementoPorEstrellas;
            txtCostoXDia.Text = "USD " + (precioBase * Convert.ToInt32(cmbCantHues.Text) + incrementoPorEstrellas).ToString();
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

        //verifica que la cantidad de huespedes ingresada 
        private bool verificarCantHuespedesConTipoHabitacion(){
            if (cmbCantHues.SelectedIndex != -1){
                if (Convert.ToInt32(cmbCantHues.Text) <= capacidadHabitacionActual){
                    return true;
                }else{
                    MessageBox.Show("Seleccione un tipo de habitacion con capacidad suficiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------
        

        //SETTERS--------------------------------------------------------------------------- 
        //metodo llamado del form de regimenes
        public void setRegimesIsOn(){   regimenesIsOn = false;}
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
