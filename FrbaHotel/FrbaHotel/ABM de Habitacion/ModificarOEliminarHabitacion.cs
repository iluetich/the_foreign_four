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
    public partial class ModificarOEliminarHabitacion : Form
    {
        private MenuDinamico menu;
        private string hotelHab;

        public ModificarOEliminarHabitacion(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
            dgvHabitaciones.ReadOnly = true;
            FrbaHotel.Utils.rellenarCombo(comboBoxHotel, "cod_hotel", "SELECT * FROM THE_FOREIGN_FOUR.Hoteles");
            comboBoxUbicacion.SelectedIndex = 0;
            this.cargarHabitaciones(true);
        }

        //pongo el parametro primero para que no rompa
        public void cargarHabitaciones(Boolean primerVez)
        {
            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Habitaciones h";

            Boolean campoNroHabitacion = false;
            Boolean campoPiso = false;
            Boolean campoUbicacion = false;
            Boolean campoHotel = false;

            if (texBoxNroHab.Text != "")
            {
                campoNroHabitacion = true;
            }
            if (texBoxPiso.Text != "")
            {
                campoPiso = true;
            }
            if (comboBoxUbicacion.Text != "Todos")
            {
                campoUbicacion = true;
            }

            if (hotelHab != "" && !primerVez)
            {
                campoHotel = true;
            }

            //si alguno de los campos se completo entonces mandale where para setear los criterios
            if (campoNroHabitacion || campoPiso || campoUbicacion || campoHotel)
            {
                consultaSql = consultaSql + " WHERE ";
            }

            if (campoPiso)
            {
                consultaSql = consultaSql + " h.piso="+ int.Parse(texBoxPiso.Text) + " ";
                campoPiso = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroHabitacion, campoPiso, campoUbicacion, campoHotel);
            }

            if (campoUbicacion)
            {
                string vista;
                if (comboBoxUbicacion.Text == "Externo")
                {
                    vista = "S";
                }
                else
                {
                    vista = "N";
                }

                consultaSql = consultaSql + " h.ubicacion= '" + vista + "' ";
                campoUbicacion = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroHabitacion, campoPiso, campoUbicacion, campoHotel);
            }

            if (campoHotel && !primerVez)
            {
                consultaSql = consultaSql + " h.cod_hotel =" + int.Parse(hotelHab) + " ";
                campoHotel = false;
                consultaSql = this.hayOtroCriterio(consultaSql, campoNroHabitacion, campoPiso, campoUbicacion, campoHotel);
            }

            if (campoNroHabitacion)
            {
                consultaSql = consultaSql + " h.nro_habitacion=" + int.Parse(texBoxNroHab.Text) + " ";
                campoNroHabitacion = false;
            }

            FrbaHotel.Utils.rellenarDataGridView(dgvHabitaciones, consultaSql);
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
            menu.Show();
            this.Close();
        }

        private void textBoxBuscadorPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxBuscadorNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(texBoxNroHab);
            FrbaHotel.Utils.limpiarControl(texBoxPiso);
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            this.comboBoxHotel_SelectedIndexChanged(sender, e);
            this.cargarHabitaciones(false);
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotelHab = comboBoxHotel.Text;
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            //obtener la celda de la fila seleccionada
            DataGridViewCell celdaFilaCodHotel = dgvHabitaciones.CurrentRow.Cells[0];
            DataGridViewCell celdaFilaNroHabitacion = dgvHabitaciones.CurrentRow.Cells[2];

            //prepara la consulta para ejecutar
            string consulta = "UPDATE THE_FOREIGN_FOUR.Habitaciones SET estado ='I' WHERE cod_hotel ="+ int.Parse(celdaFilaCodHotel.Value.ToString()) +" AND nro_habitacion=" + int.Parse(celdaFilaNroHabitacion.Value.ToString());

            //ejecuta la consulta
            FrbaHotel.Utils.ejecutarConsulta(consulta);

            //mostrar menaje de todo ok
            MessageBox.Show("Se Ha inhabilitado satifactoriamente la Habitacion seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //refrezca la tabla
            this.cargarHabitaciones(false);     
        }

        //HACER EL BOTON DE MODIFICAR
    }
}
