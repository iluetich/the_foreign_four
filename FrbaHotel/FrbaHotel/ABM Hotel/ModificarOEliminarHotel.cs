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
            dgvHoteles.ReadOnly = true;
            comboBoxBusCantEstrellas.SelectedIndex = 0;
            this.cargarHoteles();
        }

        public void cargarHoteles()
        {
            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Hoteles h";

            Boolean campoNombreHotel = false;
            Boolean campoPais = false;
            Boolean campoCiudad = false;
            Boolean campoEstrellas = false;

            if (textBoxBuscadorNombre.Text != "")
            {
                campoNombreHotel = true;
            }
            if (textBoxBuscadorPais.Text != "")
            {
                campoPais = true;
            }
            if (textBoxBuscadorCiudad.Text != "")
            {
                campoCiudad = true;
            }

            if (comboBoxBusCantEstrellas.Text != "Todas")
            {
                campoEstrellas = true;
            }

            //si alguno de los campos se completo entonces mandale where para setear los criterios
            if (campoNombreHotel || campoPais || campoCiudad || campoEstrellas)
            {
                consultaSql = consultaSql + " WHERE ";
            }

            if (campoPais)
            {
                consultaSql = consultaSql + " h.nombre LIKE '%" + textBoxBuscadorPais.Text + "%' ";
                campoPais = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNombreHotel, campoPais, campoCiudad,campoEstrellas);
            }

            if (campoCiudad)
            {
                consultaSql = consultaSql + " h.ciudad LIKE '%" + textBoxBuscadorCiudad.Text + "%' ";
                campoCiudad = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNombreHotel, campoPais, campoCiudad,campoEstrellas);
            }

            if (campoEstrellas)
            {
                consultaSql = consultaSql + " h.cant_estrellas =" + int.Parse(comboBoxBusCantEstrellas.Text) +" ";
                campoEstrellas = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNombreHotel, campoPais, campoCiudad, campoEstrellas);
            }

            if (campoNombreHotel)
            {
                consultaSql = consultaSql + " h.nombre LIKE '%" + textBoxBuscadorNombre.Text + "%' ";
                campoNombreHotel = false;
            }

            FrbaHotel.Utils.rellenarDataGridView(dgvHoteles, consultaSql);
        }

        public string hayOtroCriterio(string consulta, Boolean campo1, Boolean campo2, Boolean campo3, Boolean campo4)
        {
            if (campo1 || campo2 || campo3 || campo4)
            {
                consulta = consulta + " AND ";
            }
            return consulta;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.menu.Show();
            this.Close();
        }

        private void textBoxBuscadorPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarHoteles();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorCiudad);
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorNombre);
            FrbaHotel.Utils.limpiarControl(textBoxBuscadorPais);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            RegistrarHotel frmModHotel = new RegistrarHotel(this, dgvHoteles.CurrentRow);
            frmModHotel.Show();
            this.Hide();
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            InHabilitarHotel frmInhabilitar = new InHabilitarHotel(this, dgvHoteles.CurrentRow);
            frmInhabilitar.Show();
            this.Hide();
        }
    }
}
