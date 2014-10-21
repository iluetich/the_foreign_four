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
                validarFechas()){
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
            if (txtCantHues.Text != "" &
                cmbFechaDesde.Value != null &
                cmbFechaHasta.Value != null &
                cmbTipoHab.SelectedIndex != -1 &
                cmbTipoReg.SelectedIndex != -1){
                    return true;
            }else{
                    MessageBox.Show("Complete todos los campos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return false;
            }
        }

        private bool validarFechas(){
            if (cmbFechaDesde.Value < cmbFechaHasta.Value){
                return true;
            }else{
                MessageBox.Show("Fecha inicio debe ser menor a fecha final", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){
            FrbaHotel.Utils.allowNumbers(e);
        }
      
    }
}
