using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmRegistrarHuespedesRestantes : Form
    {
        frmInicioEstadia frmRegistrarEstadiaPadre;
      
        public frmRegistrarHuespedesRestantes(frmInicioEstadia newFrm)
        {
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;
        }


        private void frmRegistrarHuespedes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarEstadiaPadre.Enabled = true;
            frmRegistrarEstadiaPadre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            new RegistrarCliente(this).Show();
            this.Enabled = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();
            this.Enabled = false;
        }

        public void llenarGrid(RegistrarCliente form)
        {
            string nombre = form.Controls["textBoxNombre"].Text;
            string apellido = form.Controls["textBoxApellido"].Text;
            string tipoDocumento = form.Controls["textBoxTipoDoc"].Text;
            string documento = form.Controls["textBoxNroDoc"].Text;
            gridDatosHuespedes.Rows.Add(new[] { tipoDocumento, documento, apellido, nombre });

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

    

    }
}
