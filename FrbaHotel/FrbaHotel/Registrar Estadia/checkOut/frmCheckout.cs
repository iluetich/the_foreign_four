using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Consumible;


namespace FrbaHotel.Registrar_Estadia.checkOut
{
    public partial class frmCheckout : Form
    {
        frmInicioEstadia frmInicioEstadiaPadre;

        public frmCheckout(){InitializeComponent();}
        
        public frmCheckout(frmInicioEstadia newForm) { 
            InitializeComponent();
            frmInicioEstadiaPadre = newForm;
        
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se procedera a registrar los consumibles adicionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new frmRegistrarConsumible(this, frmInicioEstadiaPadre).Show();
        }

        private void frmCheckout_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmInicioEstadiaPadre.Enabled = true;
            frmInicioEstadiaPadre.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
