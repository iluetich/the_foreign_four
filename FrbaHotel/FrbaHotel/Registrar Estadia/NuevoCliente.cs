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
        IForm formInterface;
        int indexBtn;

        public frmNuevoCliente(Form newFrm, int index)
        {
            InitializeComponent();
            formInterface = this.Owner as IForm;
            frmRegistrarHuespedPadre = newFrm;
            indexBtn = index;
        }
      
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            formInterface.actualizarTxts(indexBtn, txtNombre.Text, txtApellido.Text);
            this.Close();
        }

        //private void frmNuevoCliente_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //}
    }
}
