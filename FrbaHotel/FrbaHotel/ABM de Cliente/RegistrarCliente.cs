using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class RegistrarCliente : Form
    {
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;

        public RegistrarCliente()
        {
            InitializeComponent();
        }

        public RegistrarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            InitializeComponent();
            frmRegistrarHuespedesRestantesPadre = newForm;
        }

        public void RegistrarCliente_FormClosing(object sender, FormClosingEventArgs e){
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.Enabled = true;
                frmRegistrarHuespedesRestantesPadre.Focus();
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.llenarGrid(this);
                this.Close();
            }

        }
    }
}
