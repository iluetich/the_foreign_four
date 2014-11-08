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

        //vuelve form anterior
        public void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        //busca un cliente ya registrado
        public void btnRegistrado_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();
            this.Enabled = false;
        }

        //evento para el cierre del form
        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGenerarReservaPadre.Enabled = true;
            frmGenerarReservaPadre.Focus();
        }

        //genera nuevo alta cliente
        private void btnNuevlClt_Click(object sender, EventArgs e)
        {
            new RegistrarCliente(this).Show();
            this.Enabled = false;
            this.boolClienteRegistrado = true;
        }

        //boton confirmar reserva
        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (boolClienteRegistrado){
                generarReserva();
                agregarOtraHabitacion();
            }else{
                MessageBox.Show("Primero registrese como cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //alta reserva
        private void generarReserva()
        {
            string consultaSQL = "DECLARE @output numeric(18,0) EXEC @output = THE_FOREIGN_FOUR.proc_generar_reserva @cod_hotel, @cod_cliente, @cod_tipo_hab, @cod_regimen, @fecha_desde, @fecha_hasta, @fecha_creacion SELECT @output as resultado";
            SqlCommand command = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            command.Parameters.AddWithValue("@cod_hotel", frmGenerarReservaPadre.getCodigoHotel());
            command.Parameters.AddWithValue("@cod_cliente", 1);
            command.Parameters.AddWithValue("@cod_tipo_hab", frmGenerarReservaPadre.getCodigoTipoHab());
            command.Parameters.AddWithValue("@cod_regimen", frmGenerarReservaPadre.getCodigoRegimen());
            command.Parameters.AddWithValue("@fecha_desde", frmGenerarReservaPadre.getFechaDesde());
            command.Parameters.AddWithValue("@fecha_hasta", frmGenerarReservaPadre.getFechaHasta());
            command.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-dd-MM"));

            Int32 codigo = Convert.ToInt32(command.ExecuteScalar());
            txtCodigoReserva.Text = codigo.ToString();
        }

        //pregunta si se quiere agregar otra habitacion y agrega
        private void agregarOtraHabitacion()
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                new frmGenerarReserva(frmGenerarReservaPadre, true);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
                this.frmGenerarReservaPadre.Close();
            }
        }

        //muestro los datos del cliente que se acaba de registrar o buscar
        public void cargarParametrosClientes(SqlCommand cmd)
        {
            txtTipoIden.Text = cmd.Parameters["@tipo_doc"].Value.ToString();
            txtIden.Text = cmd.Parameters["@nro_doc"].Value.ToString();
            txtMail.Text = cmd.Parameters["@mail"].Value.ToString();
        }

        //obtengo la fila seleccionada del grid de regimenes para llenar el textbox con el regimen
        public void filaSeleccionadaDataGrid(DataGridViewRow row)
        {
            //tipo documento
            txtTipoIden.Text = row.Cells[2].Value.ToString();
            //documento            
            txtIden.Text = row.Cells[3].Value.ToString();            
            //mail
            txtMail.Text = row.Cells[4].Value.ToString();
        }

        //para setear el boolea desde otro form
        public void setBandClienteRegistrado()
        {
            this.boolClienteRegistrado = true;
        }
    }


    
        
}

