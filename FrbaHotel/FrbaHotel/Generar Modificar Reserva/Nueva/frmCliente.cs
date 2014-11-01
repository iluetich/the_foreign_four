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


        public frmCliente(frmGenerarReserva newFrm)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;
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
            new RegistrarCliente().Show();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {

        }

       
        


    }


    
        
}

