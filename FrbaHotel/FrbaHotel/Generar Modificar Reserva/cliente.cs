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
    public partial class frmCliente : Form
    {

        Form frmPadreReserva;


        public frmCliente(Form newFrm)
        {
            InitializeComponent();
            frmPadreReserva = newFrm;
        }

        public void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        public void btnRegistrado_Click(object sender, EventArgs e)
        {
            new frmBuscadorCliente(this).Show();
            this.Enabled = false;
        }

        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPadreReserva.Enabled = true;
            frmPadreReserva.Focus();
        }

        


    }


    
        
}

