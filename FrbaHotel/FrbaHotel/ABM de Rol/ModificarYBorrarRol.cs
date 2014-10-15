using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ModificarYBorrarRol : Form
    {
        public InicioDelSistema ventanaPadre;

        //le paso la ventana padre asi cuando cierro esta ventana sabe a cual tiene que volver
        public ModificarYBorrarRol(InicioDelSistema formulario)
        {
            InitializeComponent();
            ventanaPadre = formulario;
        }

        private void InhabilitarRol_Click(object sender, EventArgs e)
        {
            BorrarRol vetanaDeBorrado = new BorrarRol();
            vetanaDeBorrado.Show();
        }

    }
}
