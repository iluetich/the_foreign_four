using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmNuevoCliente : Form
    {
        frmRegistrarHuespedesRestantes frmRegistrarHuespedPadre;
        int indexBtn;

        public frmNuevoCliente(frmRegistrarHuespedesRestantes newFrm, int index)
        {
            InitializeComponent();
            this.frmRegistrarHuespedPadre = newFrm;
            this.indexBtn = index;
        }
      
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.frmRegistrarHuespedPadre.actualizarTxts(indexBtn, txtNombre.Text, txtApellido.Text);
            this.Close();
        }

        //private void frmNuevoCliente_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //}
    }
}
