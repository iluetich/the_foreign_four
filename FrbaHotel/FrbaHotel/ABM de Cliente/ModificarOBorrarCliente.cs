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
        private string TipoDoc;

        public ModificarOBorrarCliente(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
            datGridViewClientes.ReadOnly = true;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        public void cargarClientes()
        {
            string nombre;
            string apellido;
            string tipo_doc;
            string nro_doc;
            string mail;

            if (textBoxBuscadorNombre.Text == "")
                nombre = "null";
            else nombre = "'" + textBoxBuscadorNombre.Text + "'";

            if (textBoxBuscadorApellido.Text == "")
                apellido = "null";
            else apellido = "'" + textBoxBuscadorApellido.Text + "'";

            if (TipoDoc == "")
                tipo_doc = "null";
            else tipo_doc = "'" + TipoDoc + "'";

            if (textBoxBuscadorNroDoc.Text == "")
                nro_doc = "null";
            else nro_doc = ""+ int.Parse(textBoxBuscadorNroDoc.Text)+"";

            if (textBoxBuscadorMail.Text == "")
                mail = "null";
            else mail = "'" + textBoxBuscadorMail.Text + "'"; 


            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.buscar_clientes ("+ nombre +","+ apellido +", "+tipo_doc+", "+nro_doc+", "+ mail +")";
            
            FrbaHotel.Utils.rellenarDataGridView(datGridViewClientes, consultaSql);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.comboBoxBuscadorTipoDoc_SelectedIndexChanged(sender, e);
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

        private void comboBoxBuscadorTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDoc = comboBoxBuscadorTipoDoc.Text;
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            //obtener la celda de la fila seleccionada
            DataGridViewCell celdaFilaSeleccionada = datGridViewClientes.CurrentRow.Cells[5];

            //prepara la consulta para ejecutar
            string consulta = "UPDATE THE_FOREIGN_FOUR.Clientes SET estado ='I' WHERE mail = '"+ celdaFilaSeleccionada.Value.ToString() +"'";
            //proc_inhabilitar_cliente
            //ejecuta la consulta
            FrbaHotel.Utils.ejecutarConsulta(consulta);

            //mostrar menaje de todo ok
            MessageBox.Show("Se Ha inhabilitado satifactoriamente el cliente seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //refrezca la tabla
            this.cargarClientes();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            RegistrarCliente formModCliente = new RegistrarCliente(datGridViewClientes.CurrentRow, this);
            formModCliente.Show();
            this.Hide();
        }

    }
}
