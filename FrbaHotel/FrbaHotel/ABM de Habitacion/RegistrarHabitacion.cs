using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class RegistrarHabitacion : Form
    {
        private MenuDinamico menu;

        public RegistrarHabitacion(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

    }
}
