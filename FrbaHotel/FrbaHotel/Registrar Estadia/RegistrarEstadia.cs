using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmRegistrarEstadia : Form
    {

        int cantHuespedes = 5; //dato provisorio

        public frmRegistrarEstadia()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos())
            {
                new frmRegistrarHuespedesRestantes(this, cantHuespedes).Show();
                this.Enabled = false;
            }
        }

        private bool validarDatosCompletos()
        {
            if (txtNroReserva.Text != ""){
                return true;
            }else{
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void txtNroReserva_KeyPress(object sender, KeyPressEventArgs e){
            FrbaHotel.Utils.allowNumbers(e);
        }


    }
}
