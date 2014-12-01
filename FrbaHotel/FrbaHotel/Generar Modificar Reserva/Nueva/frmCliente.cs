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
        int codigoCliente;
        int codigoReserva;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        public frmCliente(frmGenerarReserva newFrm)
        {
            InitializeComponent();
            frmGenerarReservaPadre = newFrm;
            this.boolClienteRegistrado = false;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        //evento para el cierre del form
        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGenerarReservaPadre.Enabled = true;
            frmGenerarReservaPadre.Focus();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        

        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------        
        //busca un cliente ya registrado
        public void btnRegistrado_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();
            this.Enabled = false;
        }

        //boton confirmar reserva
        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (boolClienteRegistrado)
            {
                generarReserva();
            }
            else
            {
                MessageBox.Show("Primero registrese como cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }      

        //genera nuevo alta cliente
        private void btnNuevlClt_Click(object sender, EventArgs e)
        {
            new RegistrarCliente(this).Show();
            this.Enabled = false;
            this.boolClienteRegistrado = true;
        }

        //vuelve form anterior
        public void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        
        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------           
        //alta reserva
        private void generarReserva()
        {
            string consultaSQL = "DECLARE @output numeric(18,0) EXEC @output = THE_FOREIGN_FOUR.proc_generar_reserva @cod_hotel, @cod_cliente, @cod_regimen, @fecha_desde, @fecha_hasta, @usuario SELECT @output as resultado";
            SqlCommand command = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            command.Parameters.AddWithValue("@cod_hotel", frmGenerarReservaPadre.getCodigoHotel());
            command.Parameters.AddWithValue("@cod_cliente", codigoCliente);            
            command.Parameters.AddWithValue("@cod_regimen", frmGenerarReservaPadre.getCodigoRegimen());
            command.Parameters.AddWithValue("@fecha_desde", frmGenerarReservaPadre.getFechaDesde());
            command.Parameters.AddWithValue("@fecha_hasta", frmGenerarReservaPadre.getFechaHasta());
            command.Parameters.AddWithValue("@usuario", frmGenerarReservaPadre.getUserName());

            int codigo = Convert.ToInt32(command.ExecuteScalar());
            txtCodigoReserva.Text = codigo.ToString();
            codigoReserva = codigo;

            agregarHabitaciones();

            MessageBox.Show("Felicidades ha generado una nueva reserva \n su codigo reserva es: "+txtCodigoReserva.Text,"Congrats",MessageBoxButtons.OK,MessageBoxIcon.Information);
            volverAlMenu();
        }

        //muestro los datos del cliente que se acaba de registrar o buscar
        public void cargarParametrosClientes(SqlCommand cmd)
        {
            txtTipoIden.Text = cmd.Parameters["@tipo_doc"].Value.ToString();
            txtIden.Text = cmd.Parameters["@nro_doc"].Value.ToString();
            txtMail.Text = cmd.Parameters["@mail"].Value.ToString();
        }

        //obtengo la fila seleccionada del grid de los clientes buscados
        public void filaSeleccionadaDataGridClientes(DataGridViewRow row)
        {
            //tipo documento
            txtTipoIden.Text = row.Cells[3].Value.ToString();
            //documento            
            txtIden.Text = row.Cells[4].Value.ToString();            
            //mail
            txtMail.Text = row.Cells[5].Value.ToString();
        }

        //agrega las habitaciones a la tabla de ruptura
        private void agregarHabitaciones(){
            DataGridView dgvHabitaciones = frmGenerarReservaPadre.getDGVHabitaciones();

            SqlCommand cmd;
            int cod_tipo_hab;
            string habitacionSQL;

            foreach (DataGridViewRow row in dgvHabitaciones.Rows){                
                cod_tipo_hab = Convert.ToInt32(row.Cells["codigo"].Value);
                habitacionSQL = "THE_FOREIGN_FOUR.proc_agregar_hab_reserva @cod_reserva, @cod_tipo_hab";
                cmd = new SqlCommand(habitacionSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.Parameters.AddWithValue("@cod_tipo_hab", cod_tipo_hab);
                cmd.Parameters.AddWithValue("@cod_reserva", codigoReserva);
                cmd.ExecuteNonQuery();                                         
            }
        }

        //vuelve al menu
        private void volverAlMenu()
        {
            this.Close();
            frmGenerarReservaPadre.Close();
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------


        //----SETTERS------------------------------------------
        public void setCodigoCliente(int codigo) {   
            codigoCliente = codigo;            
        }

        //para setear el booleano desde otro form
        public void setBandClienteRegistrado()
        {
            this.boolClienteRegistrado = true;
        }
        //-----------------------------------------------------
    }


    
        
}

