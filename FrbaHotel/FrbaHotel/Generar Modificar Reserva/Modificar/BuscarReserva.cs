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
    public partial class frmModificarReserva : Form
    {
        public frmModificarReserva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodRes.Text != ""){
                new frmModificarRerserva(this).Show();
                this.Enabled = false;}
            else{
                MessageBox.Show("Complete el campo","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }
        
        private void txtCodRes_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }
    }
}
