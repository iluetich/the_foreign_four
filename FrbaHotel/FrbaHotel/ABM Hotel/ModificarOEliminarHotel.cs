using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class ModificarOEliminarHotel : Form
    {
        private MenuDinamico menu;

        public ModificarOEliminarHotel(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.menu.Show();
            this.Close();
        }
    }
}
