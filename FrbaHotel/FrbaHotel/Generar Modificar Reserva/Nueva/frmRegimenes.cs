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
        frmGenerarReserva frmGenerarReservaPadre;
        bool band;

        //inicializo variables
        public frmRegimenes(frmGenerarReserva newFrm, bool band)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;
            this.band = band;           
        }

        //evento para cuando se cierra el form
        private void frmRegimenes_FormClosing(object sender, FormClosingEventArgs e){
            frmGenerarReservaPadre.setRegimesIsOn();            
        }

        //en load del form carga en el datagrid los valores de regimenes
        private void frmRegimenes_Load(object sender, EventArgs e)
        {
            string consultaSql = "select cod_regimen, descripcion, precio from THE_FOREIGN_FOUR.Regimenes";
            FrbaHotel.Utils.rellenarDataGridView(dgvRegimenes,consultaSql);         
        }

        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        //private void dgvRegimenes;
    }
}
