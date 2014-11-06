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
            dgvBuscarRol.ReadOnly = true;
            menu = menuPadre;
            this.cargarGrid();
        }

        public void cargarGrid()
        {
            string consulta = "SELECT * FROM THE_FOREIGN_FOUR.Roles";
            FrbaHotel.Utils.rellenarDataGridView(dgvBuscarRol, consulta);
        }

        private void InhabilitarRol_Click(object sender, EventArgs e)
        {
            string comandoSql = "UPDATE THE_FOREIGN_FOUR.Roles SET estado='I' WHERE nombre='"+ dgvBuscarRol.CurrentRow.Cells[1].Value.ToString() +"'";
            FrbaHotel.Utils.ejecutarConsulta(comandoSql);
            MessageBox.Show("Se Ha inhabilitado satifactoriamente el Rol seleccionado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.cargarGrid();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void ModificarRol_Click(object sender, EventArgs e)
        {
            CreacionRol frmModRol = new CreacionRol(this,dgvBuscarRol.CurrentRow);
            frmModRol.Show();
            this.Hide();
        }

    }
}
