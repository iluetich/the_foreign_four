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
            if (validarDatosCompletos()){
                new frmCliente(this).Show();
                this.Enabled = false;
            }else{
                MessageBox.Show("Complete todos los campos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e){
            DialogResult dialogo = MessageBox.Show("¿ Desea Salir de la Aplicacion S/N ?",
                "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                cmbTipoReg.SelectedIndex != -1)
                return true;
            return false;
        }

      
    }
}
