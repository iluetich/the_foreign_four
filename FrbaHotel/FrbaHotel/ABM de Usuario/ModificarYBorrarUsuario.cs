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
    public partial class ModificarYBorrarUsuario : Form
    {
        private MenuDinamico menu;
        private string usuarioLogeado;
        private string hotelLogeado;

        public ModificarYBorrarUsuario(MenuDinamico menuPadre,string usuario, string hotel)
        {
            usuarioLogeado = usuario;
            hotelLogeado = hotel;
            this.menu = menuPadre;
            InitializeComponent();
            dgvUsuarios.ReadOnly = true;
            this.cargarUsuarios();
        }

        public void cargarUsuarios()
        {
            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Usuarios u";

            Boolean campoUserName = false;
            Boolean campoNombre = false;
            Boolean campoApellido = false;

            if (textBoxUserName.Text != "")
            {
                campoUserName = true;
            }
            if (textBoxApellido.Text != "")
            {
                campoApellido = true;
            }
            if (textBoxNombre.Text != "")
            {
                campoNombre = true;
            }

            //si alguno de los campos se completo entonces mandale where para setear los criterios
            if (campoUserName || campoNombre || campoApellido)
            {
                consultaSql = consultaSql + " WHERE ";
            }

            if (campoNombre)
            {
                consultaSql = consultaSql + " u.nombre LIKE '%" + textBoxNombre.Text + "%' ";
                campoNombre = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoUserName, campoNombre, campoApellido);
            }

            if (campoApellido)
            {
                consultaSql = consultaSql + " u.apellido LIKE '%" + textBoxApellido.Text + "%' ";
                campoApellido = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoUserName, campoNombre, campoApellido);
            }

            if (campoUserName)
            {
                consultaSql = consultaSql + " u.user_name LIKE '%" + textBoxUserName.Text + "%' ";
                campoUserName = false;
            }

            FrbaHotel.Utils.rellenarDataGridView(dgvUsuarios, consultaSql);
        }

        public string hayOtroCriterio(string consulta, Boolean campo1, Boolean campo2, Boolean campo3)
        {
            if (campo1 || campo2 || campo3)
            {
                consulta = consulta + " AND ";
            }
            return consulta;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxUserName);
            FrbaHotel.Utils.limpiarControl(textBoxNombre);
            FrbaHotel.Utils.limpiarControl(textBoxApellido);
        }

        private void InhabilitarUsuario_Click(object sender, EventArgs e)
        {
            //corroborar que el usuario a dar de baja trabaje en el mismo hotel que el usuario que se logeo
            DataGridViewCell celdaFilaSeleccCodUsuario = dgvUsuarios.CurrentRow.Cells[0];
            int puedeInhabilitar;
            string consulta = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.UsuariosPorHotel WHERE cod_usuario="+ celdaFilaSeleccCodUsuario.Value.ToString() +" AND cod_hotel="+ hotelLogeado;
            puedeInhabilitar = FrbaHotel.Utils.ejecutarConsultaResulInt(consulta);

            if (puedeInhabilitar >= 1)
            {
                //obtener la celda de la fila seleccionada
                DataGridViewCell celdaFilaSeleccionadaUserName = dgvUsuarios.CurrentRow.Cells[1];

                //prepara la consulta para ejecutar
                string consulta2 = "UPDATE THE_FOREIGN_FOUR.Usuarios SET estado ='I' WHERE user_name = '" + celdaFilaSeleccionadaUserName.Value.ToString() + "'";

                //ejecuta la consulta
                FrbaHotel.Utils.ejecutarConsulta(consulta2);

                //mostrar menaje de todo ok
                MessageBox.Show("Se Ha inhabilitado satifactoriamente el Usuario seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //refrezca la tabla
                this.cargarUsuarios();
            }
            else
            {
                MessageBox.Show("ERROR no se pudo inhabilitar el usuario seleccionado ya que no trabaja en el hotel logeado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ModificarUsuario_Click(object sender, EventArgs e)
        {
            CreacionDeUsuario frmModUsuario = new CreacionDeUsuario(this, dgvUsuarios.CurrentRow);
            frmModUsuario.Show();
            this.Hide();
        }
    }
}
