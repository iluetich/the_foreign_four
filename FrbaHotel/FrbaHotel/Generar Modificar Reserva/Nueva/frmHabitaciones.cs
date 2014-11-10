using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva.Nueva
{
    public partial class frmHabitaciones : Form
    {
        frmGenerarReserva frmGenerarReservaPadre;
        string codigoHotel;
        DataTable dataTableHabitaciones;

        public frmHabitaciones(frmGenerarReserva newFrm)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;

            codigoHotel = frmGenerarReservaPadre.getCodigoHotel().ToString();
            cargarTipoHabitaciones();
        }

        private void cargarTipoHabitaciones()
        {
            string consultaSQL = "select * from THE_FOREIGN_FOUR.buscar_tipo_hab_hotel(" + codigoHotel + ")";
            FrbaHotel.Utils.rellenarDataGridView(dgvHabitaciones, consultaSQL);

            dgvHabitaciones.Columns["cod_tipo_hab"].Visible = false;
            dgvHabitaciones.Columns["recargo"].Visible = false;
            dgvHabitaciones.Columns["capacidad"].Visible = false;
        }

        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvRegimenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvHabitaciones.Rows[e.RowIndex];
                frmGenerarReservaPadre.filaSeleccionadaDataGridHabitaciones(row);
                this.Close();
            }
        }

        private void frmHabitaciones_Load(object sender, EventArgs e)
        {
            //location del form
            this.Location = new Point(frmGenerarReservaPadre.Location.X + frmGenerarReservaPadre.Width, frmGenerarReservaPadre.Location.Y + (frmGenerarReservaPadre.Height / 2) - 100);            
        }

        //evento para cuando se cierra el form
        private void frmHabitaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGenerarReservaPadre.setHabitacionesIsOn();
        }
    }
}
