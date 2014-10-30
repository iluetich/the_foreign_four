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
    public partial class ModificarYBorrarRol : Form
    {
        public MenuDinamico menu;

        //le paso la ventana padre asi cuando cierro esta ventana sabe a cual tiene que volver
        public ModificarYBorrarRol(MenuDinamico menuPadre)
        {
            InitializeComponent();
            menu = menuPadre;
        }

        private void InhabilitarRol_Click(object sender, EventArgs e)
        {
            BorrarRol vetanaDeBorrado = new BorrarRol();
            vetanaDeBorrado.Show();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

    }
}
