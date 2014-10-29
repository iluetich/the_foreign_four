using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Menues_de_los_Roles
{
    public partial class MenuDinamico : Form
    {
        private InicioDelSistema ventanaInicio; //me sirve para el boton cerrar sesion
        private string userSesion;
        private string hotelSesion;

        public MenuDinamico(InicioDelSistema formulario,string userName,string hotelElegido)
        {
            this.ventanaInicio = formulario;
            this.userSesion = userName;
            this.hotelSesion = hotelElegido;

            InitializeComponent();
            this.generarBotones();
        }

        public void generarBotones()
        {
            //obtener funcionalidades apartir del rol ingresado
            string stringConnection = "Data Source=localHost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";
            SqlConnection sqlConnection1 = new SqlConnection(stringConnection);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            string consulta;
            if (userSesion == "Guest")
            {
                consulta = "SELECT * FROM THE_FOREIGN_FOUR.view_funcionalidades_rol r WHERE r.rol= 'Guest'";
            }
            else
            {
                consulta = "SELECT * FROM [THE_FOREIGN_FOUR].[login_funcionalidades] ('" + this.userSesion + "', " + this.hotelSesion + ")";
            }

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            //lee todas las filas que se trajo
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string funcionalidad = reader.GetString(1);

                    this.registrarBoton(funcionalidad);
                }
            }

            sqlConnection1.Close();
        }

        public void registrarBoton(string funcionalidad)
        {
            if (funcionalidad == "ABM Clientes")
            {
                this.botonABMCliente.Enabled = true;
            }

            if (funcionalidad == "ABM Habitacion")
            {
                this.botonABMHabitacion.Enabled = true;
            }

            if (funcionalidad == "ABM Hotel")
            {
                this.botonABMHotel.Enabled = true;
            }

            if (funcionalidad == "ABM Regimen De Estadia")
            {
                this.botonABMRegimenEstadia.Enabled = true;
            }

            if (funcionalidad == "ABM Rol")
            {
                this.botonABMRol.Enabled = true;
            }

            if (funcionalidad == "ABM Usuario")
            {
                this.botonABMUsuario.Enabled = true;
            }

            if (funcionalidad == "Cancelar Reserva")
            {
                this.botonCancelarReserva.Enabled = true;
            }

            if (funcionalidad == "Facturar Estadia")
            {
                this.botonFacturarEstadia.Enabled = true;
            }

            if (funcionalidad == "Generar o Modificar Reserva")
            {
                this.botonGenOModRes.Enabled = true;
            }

            if (funcionalidad == "Listado Estadistico")
            {
                this.botonListEstadistico.Enabled = true;
            }

            if (funcionalidad == "Registrar Consumibles")
            {
                this.botonRegConsumibles.Enabled = true;
            }

            if (funcionalidad == "Registrar Estadia")
            {
                this.botonRegistrarEstadia.Enabled = true;
            }  
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            ventanaInicio.Show();
            this.Close();
        }
    }
}
