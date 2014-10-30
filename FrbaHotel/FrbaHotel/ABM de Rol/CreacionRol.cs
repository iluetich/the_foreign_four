using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class CreacionRol : Form
    {
        private MenuDinamico menu;

        public CreacionRol(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }
    }
}
