using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia.checkOut;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmInicioEstadia : Form
    {
        public frmInicioEstadia(){InitializeComponent();}

        //Evento click boton check in
        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodReserva, "Codigo reserva")) //valida text box completo
            {
                new frmRegistrarHuespedesRestantes(this).Show();
                this.Enabled = false;
            }

        }

        //evento click boton check  out
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodEstadia, "Codigo estadia"))
            {
                new frmCheckout(this).Show();
                this.Enabled = false;
            }
        }

        //evento para cuando se escribe en un text box, permita solo numeros
        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtNroReserva_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        


    }
}
