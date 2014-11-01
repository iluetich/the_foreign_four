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
        bool regimenesIsOn = true;

        public frmGenerarReserva(){
            InitializeComponent();            
        }

        public frmGenerarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void frmGenerarReserva_Load(object sender, EventArgs e)
        {
            FrbaHotel.ConexionSQL.establecerConexionBD();
            cargarControles();
        }

        private void btnSiguietne_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                    
                    new frmCliente(this).Show();
                    this.Enabled = false;
            }
        }

        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }

        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCantHues, "cantidad huespedes") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &            
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")
            );
        }

        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void cargarControles()
        {
            string consultaSql = "select * from THE_FOREIGN_FOUR.Hoteles";
            string nombreTabla = "THE_FOREIGN_FOUR.Hoteles";
            string nombreCampo = "nombre";

            FrbaHotel.Utils.rellenarComboBox(cmbHotel, nombreTabla, nombreCampo, consultaSql);
           
        }

        private void btnRegimenes_Click(object sender, EventArgs e)
        {
            if (regimenesIsOn)
            {
                new frmRegimenes(this, regimenesIsOn).Show();
                regimenesIsOn = false;
            }
        }

        public void setRegimesIsOn()
        {
            regimenesIsOn = true;
        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemCombo = (cmbHotel.SelectedIndex + 1).ToString();
            string consultaSql = "select distinct h.cod_tipo_hab, t.descripcion from THE_FOREIGN_FOUR.Habitaciones h, THE_FOREIGN_FOUR.TipoHabitaciones t where cod_hotel=" + itemCombo + "and h.cod_tipo_hab = t.cod_tipo_hab";
            string nombreTabla = "THE_FOREIGN_FOUR.TipoHabitaciones";
            string nombreCampo = "descripcion";

            FrbaHotel.Utils.rellenarComboBox(cmbTipoHab, nombreTabla, nombreCampo, consultaSql);

        }
    }
}
