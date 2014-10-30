using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class CreacionDeUsuario : Form
    {
        private MenuDinamico menu;

        public CreacionDeUsuario(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }
    }
}
