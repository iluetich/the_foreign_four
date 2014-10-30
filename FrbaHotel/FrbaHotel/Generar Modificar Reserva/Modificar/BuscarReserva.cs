using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmModificarReserva : Form
    {
        private MenuDinamico menu;
        
        public frmModificarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        public frmModificarReserva()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodRes, "Codigo reserva"))
            {
                new frmModificarRerserva(this).Show();
                this.Enabled = false;
            }
        }
        
        private void txtCodRes_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.menu.Show();
            this.Close();
        }

    }
}
