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
    public partial class frmGenerarReserva : Form
    {
        public frmGenerarReserva(){
            InitializeComponent();
        }

        private void btnConfirReser_Click(object sender, EventArgs e){
            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                    new frmCliente(this).Show();
                    this.Enabled = false;
            }
        }

        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e){
            DialogResult dialogo = MessageBox.Show("¿ Desea Salir de la Aplicacion S/N ?",
                "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
            if (dialogo == DialogResult.OK) {
            
            }else { 
                   e.Cancel = true; 
            }
        }

        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarTextBoxCompleto(txtCantHues,"cantidad huspedes") &
            FrbaHotel.Utils.validarComboBoxCompleto(cmbTipoHab,"Tipo habitacion") &
            FrbaHotel.Utils.validarComboBoxCompleto(cmbTipoReg,"Tipo regimen") &
            FrbaHotel.Utils.validarDataTimePickerCompleto(dtpFechaDesde,"Fecha desde") &
            FrbaHotel.Utils.validarDataTimePickerCompleto(dtpFechaHasta,"Fecha hasata")
            );
        }

        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
      
    }
}
