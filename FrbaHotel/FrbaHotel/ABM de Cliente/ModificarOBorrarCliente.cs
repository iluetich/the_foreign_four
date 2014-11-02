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
            string consultaSql;
            consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Clientes";

            SqlConnection connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM THE_FOREIGN_FOUR.Clientes", connection);

            DataSet dataSetClientes = new DataSet();

            adaptador.Fill(dataSetClientes);

            datGridViewClientes.DataSource = datGridViewClientes;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void ModificarOBorrarCliente_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

    }
}
