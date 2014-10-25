using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class frmInicioRegistrarConsumible : Form
    {
        public frmInicioRegistrarConsumible()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                new frmRegistrarConsumible(this).Show();
                this.Enabled = false;
            }
        }

        public bool validarCampos()
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

        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
    }
}
