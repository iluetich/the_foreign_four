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
        string codigoHotel;
        int precioBase;
        int costoPorDia;
        string codigoRegimen;
        string codigoTipoHabitacion;

        //constructor generico  
        public frmGenerarReserva() { InitializeComponent(); }

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

        //evento load del form
        private void frmGenerarReserva_Load(object sender, EventArgs e)
        {
            //seteo de booleanos
            regimenesIsOn = false;
            boolVerificoDisp = false;
         
            //carga controles desde la BD
            FrbaHotel.ConexionSQL.establecerConexionBD();
            cargarControles();            
        }
        
        //muestra ventana regimenes
        private void btnRegimenes_Click(object sender, EventArgs e)
        {
            if (txtCantHues.Text != ""){
                if (!regimenesIsOn){
                    new frmRegimenes(this, regimenesIsOn, codigoHotel).Show();
                    regimenesIsOn = true;
                }
            }else{
                MessageBox.Show("Complete la cantidad de huespedes primero");
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

        //valida que los campos esten completos
        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCantHues, "cantidad huespedes") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &            
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtRegimen, "Tipo Regimen")
            );
        }

        //valida que el input del textbox sean solo numeros
        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        //boton volver
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        //carga de controles desde la BD
        private void cargarControles()
        {
            string consultaSql = "select * from THE_FOREIGN_FOUR.Hoteles";
            string nombreTabla = "THE_FOREIGN_FOUR.Hoteles";
            string nombreCampo = "nombre";

            FrbaHotel.Utils.rellenarCombo(cmbHotel, nombreTabla, nombreCampo, consultaSql);           
        }      

        //metodo llamado del form de regimenes
        public void setRegimesIsOn()
        {
            regimenesIsOn = false;
        }

        //evento para que cuando cambie el idex del combo hotel se auto cargue en el combo habitaciones las correspondientes al hotel
        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;

            string itemCombo = (cmbHotel.SelectedIndex + 1).ToString();
            string consultaSql = "select distinct h.cod_tipo_hab, t.descripcion from THE_FOREIGN_FOUR.Habitaciones h, THE_FOREIGN_FOUR.TipoHabitaciones t where cod_hotel=" + itemCombo + "and h.cod_tipo_hab = t.cod_tipo_hab";
            string nombreTabla = "THE_FOREIGN_FOUR.TipoHabitaciones";
            string nombreCampo = "descripcion";

            FrbaHotel.Utils.rellenarCombo(cmbTipoHab, nombreTabla, nombreCampo, consultaSql);
            codigoHotel = itemCombo;
        }

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

        //evento para el cierre del form
        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }

        //--------------------------------------------------------------------------------------------------------------
        //pone en false el booleano cuando se cambia de valor en los cotroles para verificar la diponibilidad nuevamente
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e){boolVerificoDisp = false;}
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e){boolVerificoDisp = false;}
        private void txtCantHues_TextChanged(object sender, EventArgs e){
            boolVerificoDisp = false;
            if (txtRegimen.Text != ""){
                txtRegimen_TextChanged(null, null); //si cambio la cant de huespedes llamo al textChanged para que refreshee
            }
        }
        private void cmbTipoHab_SelectedIndexChanged(object sender, EventArgs e){
            boolVerificoDisp = false;            
            if (cmbTipoHab.Text != "System.Data.DataRowView"){
                string consultaSQL = "select cod_tipo_hab from THE_FOREIGN_FOUR.TipoHabitaciones where descripcion ='" + cmbTipoHab.Text + "';";
                DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);
                DataRow row = dt.Rows[0];
                codigoTipoHabitacion = row["cod_tipo_hab"].ToString();
            }
        }
        //--------------------------------------------------------------------------------------------------------------

        //muestra costo por dia
        private void txtRegimen_TextChanged(object sender, EventArgs e)
        {
            boolVerificoDisp = false;

            //Obtengo el recargo por estrellas del hotel           
            string consultaSQL = "select recarga_estrellas from THE_FOREIGN_FOUR.Hoteles where cod_hotel=" + codigoHotel + ";";
            DataTable dt = FrbaHotel.Utils.obtenerDatosBD(consultaSQL);            
       
            DataRow row = dt.Rows[0];
            int incrementoPorEstrellas = Convert.ToInt32(row["recarga_estrellas"]);

            costoPorDia = precioBase * Convert.ToInt32(txtCantHues.Text) + incrementoPorEstrellas;
            txtCostoXDia.Text = "USD " + (precioBase * Convert.ToInt32(txtCantHues.Text) + incrementoPorEstrellas).ToString();
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

        private void calcularCostoTotal()
        {
            int costoTotal = 0;
            int cantDias = (dtpFechaHasta.Value - dtpFechaDesde.Value).Days;

            costoTotal += costoPorDia;
            costoTotal *= cantDias;

            txtCostoTotal.Text = "USD " + costoTotal.ToString();

        }
               
    }
}
