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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarTextBoxCompleto(txtCodRes,"Codigo reserva"))
            {
                new frmModificarRerserva(this).Show();
                this.Enabled = false;
            }
        }
        
        private void txtCodRes_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

    }
}
