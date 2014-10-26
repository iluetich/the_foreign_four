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

        private void btnConfirReser_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                    Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
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
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCantHues, "cantidad huespedes") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoReg, "Tipo regimen") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")
            );
        }

        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
      
    }
}
