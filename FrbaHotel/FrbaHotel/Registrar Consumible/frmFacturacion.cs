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
    public partial class frmFacturacion : Form
    {
        frmRegistrarConsumible frmRegistrarConsumiblePadre;

        public frmFacturacion(){ InitializeComponent();}
        public frmFacturacion(frmRegistrarConsumible newForm)
        {
            InitializeComponent();
            frmRegistrarConsumiblePadre = newForm;

        }

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {

        }

        private void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarConsumiblePadre.Enabled = true;
            frmRegistrarConsumiblePadre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

