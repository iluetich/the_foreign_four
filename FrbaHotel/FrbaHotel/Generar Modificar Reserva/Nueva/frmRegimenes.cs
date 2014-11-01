using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmRegimenes : Form
    {
        frmGenerarReserva frmGenerarReservaPadre;
        bool band;

        public frmRegimenes(frmGenerarReserva newFrm, bool band)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;
            this.band = band;
        }

        private void frmRegimenes_FormClosing(object sender, FormClosingEventArgs e){
            frmGenerarReservaPadre.setRegimesIsOn();            
        }
    }
}
