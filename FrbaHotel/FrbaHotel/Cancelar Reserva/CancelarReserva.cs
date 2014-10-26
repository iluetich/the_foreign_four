using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class frmCancelarReserva : Form
    {
        public frmCancelarReserva()
        {
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
            FrbaHotel.Utils.validarTextBoxCompleto(txtCodReserva, "Codigo reserva")             &   
            FrbaHotel.Utils.validarTextBoxCompleto(txtMotivo, "Motivo")                         &
            FrbaHotel.Utils.validarDataTimePickerCompleto(dtpFechaCancel, "Fecha cancelacion") 
            );
        }


    }
}
