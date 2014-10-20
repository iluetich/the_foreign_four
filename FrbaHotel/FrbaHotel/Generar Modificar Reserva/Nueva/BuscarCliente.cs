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
    public partial class frmBuscadorCliente : Form
    {

        Form frmPadreCliente;

        public frmBuscadorCliente(Form newFrm)
        {
            InitializeComponent();
            frmPadreCliente = newFrm;
        }

        private void btnVolver_Click(object sender, EventArgs e){
            this.Close();
        }

        private void frmBuscadorCliente_FormClosing(object sender, FormClosingEventArgs e) {
            frmPadreCliente.Enabled = true;
            frmPadreCliente.Focus();
        }
    }
}
