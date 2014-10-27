using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.IniciarSecion
{
    public partial class Login : Form
    {
        private InicioDelSistema formPadre;
        
        public Login(InicioDelSistema formularioPadre,string rolElegido)
        {
            formPadre = formularioPadre;
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formPadre.Show();
            this.Close();
        }

    }
}
