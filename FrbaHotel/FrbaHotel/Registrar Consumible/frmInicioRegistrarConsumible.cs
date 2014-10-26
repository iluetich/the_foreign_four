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
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodEstadia, "Codigo estadia"))
            {
                new frmRegistrarConsumible(this).Show();
                this.Enabled = false;
            }
        }

        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }
    }
}
