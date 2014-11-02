using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ModificarOBorrarCliente : Form
    {
        private MenuDinamico menu;

        public ModificarOBorrarCliente(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        public void cargarClientes()
        {
            FrbaHotel.Utils.rellenarDataGridView(datGridViewClientes, "SELECT * FROM THE_FOREIGN_FOUR.Clientes");
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void textBoxBuscadorNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxBuscadorApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void textBoxBuscadorNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorApellido);
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorMail);
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorNombre);
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorNroDoc);
        }

    }
}
