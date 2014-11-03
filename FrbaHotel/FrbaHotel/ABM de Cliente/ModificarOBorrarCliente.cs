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
            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Clientes c";

            Boolean campoNroDoc = false;
            Boolean campoNombre = false;
            Boolean campoApellido = false;
            Boolean campoTipoDoc = false;
            Boolean campoMail = false;

            if (textBoxBuscadorNroDoc.Text != "")
            {
                campoNroDoc = true;
            }
            if (textBoxBuscadorApellido.Text != "")
            {
                campoApellido = true;
            }
            if (textBoxBuscadorMail.Text != "")
            {
                campoMail = true;
            }
            if (textBoxBuscadorNombre.Text != "")
            {
                campoNombre = true;
            }
            if (TipoDoc != "")
            {
                campoTipoDoc = true;
            }

            //si alguno de los campos se completo entonces mandale where para setear los criterios
            if (campoNroDoc || campoTipoDoc || campoNombre || campoMail || campoApellido)
            {
                consultaSql = consultaSql + " WHERE ";
            }

            if (campoNombre)
            {
                consultaSql = consultaSql + " c.nombre LIKE '%"+ textBoxBuscadorNombre.Text +"%' ";
                campoNombre = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroDoc, campoTipoDoc, campoMail, campoApellido);
            }

            if (campoApellido)
            {
                consultaSql = consultaSql + " c.apellido LIKE '%" + textBoxBuscadorApellido.Text + "%' ";
                campoApellido = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroDoc, campoTipoDoc, campoMail, campoNombre);
            }

            if (campoMail)
            {
                consultaSql = consultaSql + " c.mail LIKE '%" + textBoxBuscadorMail.Text + "%' ";
                campoMail = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroDoc, campoTipoDoc, campoNombre, campoApellido);
            }

            if (campoNroDoc)
            {
                consultaSql = consultaSql + " c.nro_doc = " + textBoxBuscadorNroDoc.Text + " ";
                campoNroDoc = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNombre, campoTipoDoc, campoMail, campoApellido);
            }

            if (campoTipoDoc)
            {
                consultaSql = consultaSql + " c.tipo_doc = '" + TipoDoc + "' ";
                campoTipoDoc = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroDoc, campoTipoDoc, campoMail, campoApellido);
            }

            FrbaHotel.Utils.rellenarDataGridView(datGridViewClientes, consultaSql);
        }


        public string hayOtroCriterio(string consulta,Boolean campo1,Boolean campo2,Boolean campo3,Boolean campo4)
        {
            if (campo1 || campo2 || campo3 || campo4)
            {
                consulta = consulta + " AND ";
            }
            return consulta;
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
