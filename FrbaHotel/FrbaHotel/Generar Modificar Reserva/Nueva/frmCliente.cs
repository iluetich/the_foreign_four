using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmCliente : Form
    {

        frmGenerarReserva frmGenerarReservaPadre;
        bool boolClienteRegistrado;

        public frmCliente(frmGenerarReserva newFrm)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;
            this.boolClienteRegistrado = false;
        }

        public void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        public void btnRegistrado_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();
            this.Enabled = false;
        }

        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGenerarReservaPadre.Enabled = true;
            frmGenerarReservaPadre.Focus();
        }

        private void btnNuevlClt_Click(object sender, EventArgs e)
        {
            new RegistrarCliente(this).Show();
            this.Enabled = false;
            this.boolClienteRegistrado = true;
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (boolClienteRegistrado){
            }else{
                MessageBox.Show("Primero registrese como cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void cargarParametrosClientes(SqlCommand cmd)
        {
            //cmd.Parameters["@mail"].Value
            txtTipoIden.Text = cmd.Parameters["@tipo_doc"].Value.ToString();
            txtIden.Text = cmd.Parameters["@nro_doc"].Value.ToString();
            txtMail.Text = cmd.Parameters["@mail"].Value.ToString();
        }

    }


    
        
}

