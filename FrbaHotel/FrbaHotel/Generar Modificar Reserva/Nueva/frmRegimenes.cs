using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmRegimenes : Form
    {
        //inicializo variables
        frmGenerarReserva frmGenerarReservaPadre;
        bool band;
        string codigoHotel;

        public frmRegimenes(frmGenerarReserva newFrm, bool band, string codigo)
        {
            InitializeComponent();
            this.frmGenerarReservaPadre = newFrm;
            this.band = band;
            this.codigoHotel = codigo;
        }        

        //en load del form carga en el datagrid los valores de regimenes
        private void frmRegimenes_Load(object sender, EventArgs e)
        {
            //location del form
            this.Location = new Point(frmGenerarReservaPadre.Location.X + frmGenerarReservaPadre.Width, frmGenerarReservaPadre.Location.Y + (frmGenerarReservaPadre.Height / 2)- 100);
            dgvRegimenes.BackgroundColor = System.Drawing.Color.White;
            
            //llena la grid con los regimenes del hotel seleccionado
            string consultaSql = "select r.cod_regimen, descripcion, precio from THE_FOREIGN_FOUR.RegimenPorHotel rxh, THE_FOREIGN_FOUR.Regimenes r where cod_hotel = " + codigoHotel + "and r.cod_regimen = rxh.cod_regimen;";
            FrbaHotel.Utils.rellenarDataGridView(dgvRegimenes, consultaSql);
            dgvRegimenes.Columns["cod_regimen"].Visible = false;
        }

        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvRegimenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvRegimenes.Rows[e.RowIndex];
                frmGenerarReservaPadre.filaSeleccionadaDataGrid(row);
                this.Close();
            }
        }

        //evento para cuando se cierra el form
        private void frmRegimenes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGenerarReservaPadre.setRegimesIsOn();
        }
    }
}
