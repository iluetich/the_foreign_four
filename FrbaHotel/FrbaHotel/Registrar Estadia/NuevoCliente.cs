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
        Form frmRegistrarHuespedPadre;
        int indexBtn;

        public frmNuevoCliente(Form newFrm, int index)
        {
            InitializeComponent();
            frmRegistrarHuespedPadre = newFrm;
            indexBtn = index;
        }
      
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmRegistrarHuespedPadre.actualizarTxts(indexBtn, txtNombre.Text, txtApellido.Text);
            this.Close();
        }

        //private void frmNuevoCliente_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //}
    }
}
