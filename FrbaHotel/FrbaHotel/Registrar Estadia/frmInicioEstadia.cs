using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia.checkOut;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmInicioEstadia : Form
    {
        public frmInicioEstadia(){InitializeComponent();}

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletosCheckin())
            {
                new frmRegistrarHuespedesRestantes(this).Show();
                this.Enabled = false;
            }
        }

        private void txtNroReserva_KeyPress(object sender, KeyPressEventArgs e){
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletosCheckout())
            {
                new frmCheckout(this).Show();
                this.Enabled = false;
            }
        }

        private bool validarDatosCompletosCheckin()
        {
            if (txtCodReserva.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool validarDatosCompletosCheckout()
        {
            if (txtCodEstadia.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }


    }
}
