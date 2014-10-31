using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class frmCancelarReserva : Form
    {
        private MenuDinamico menu;

        public frmCancelarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos())
            {
            }

        }

        private bool validarDatosCompletos()
        {
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCodReserva, "Codigo reserva") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtMotivo, "Motivo") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaCancel, "Fecha cancelacion") 
            );
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void frmCancelarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }
    }
}
