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
    
    public partial class frmModificarRerserva : Form
    {
        Form frmBuscarPadre;
        bool verifico = false;

        public frmModificarRerserva(Form newFrm)
        {
            InitializeComponent();
            frmBuscarPadre = newFrm;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (verifico)
            {
                if (validarDatosCompletos() &
                    FrbaHotel.Utils.validarFechas(dtpFechaDesde,dtpFechaHasta))
                {
                    MessageBox.Show("Reserva modificada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Verifica disponibilidad antes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModificarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBuscarPadre.Enabled = true;
            frmBuscarPadre.Focus();

        }

        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoReg, "Tipo regimen") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")
            );
        }

        private void btnVerficarDisponibilidad_Click(object sender, EventArgs e)
        {
            verifico = true;
        }

        



    }
}
