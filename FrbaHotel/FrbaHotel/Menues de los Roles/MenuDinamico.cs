using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Listado_Estadistico;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Cancelar_Reserva;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Hotel;

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
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

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
        }

        public void registrarBoton(string funcionalidad)
        {
            if (funcionalidad == "ABM Clientes")
            {
                this.botonRegCliente.Enabled = true;
                this.botonModElimCliente.Enabled = true;
            }

            if (funcionalidad == "ABM Habitacion")
            {
                this.botonRegHabitacion.Enabled = true;
                this.botonModElimHab.Enabled = true;
            }

            if (funcionalidad == "ABM Hotel")
            {
                this.botonRegHotel.Enabled = true;
                this.botonModElimHotel.Enabled = true;
            }

            if (funcionalidad == "ABM Regimen De Estadia")
            {
                this.botonRegRegimen.Enabled = true;
                this.botonModElimRegEsta.Enabled = true;
            }

            if (funcionalidad == "ABM Rol")
            {
                this.botonRegRol.Enabled = true;
                this.botonModElimRol.Enabled = true;
            }

            if (funcionalidad == "ABM Usuario")
            {
                this.botonRegUsuario.Enabled = true;
                this.botonModElimUsuario.Enabled = true;
            }

            if (funcionalidad == "Cancelar Reserva")
            {
                this.botonCancelarReserva.Enabled = true;
            }

            //Problema Ver Con Ian
            /*if (funcionalidad == "Facturar Estadia")
            {
                this.botonFacturarEstadia.Enabled = true;
            }*/

            if (funcionalidad == "Generar o Modificar Reserva")
            {
                this.botonGenRes.Enabled = true;
                this.botonModRes.Enabled = true;
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
                this.botonRegFacEstadia.Enabled = true;
            }  
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            ventanaInicio.cargarRolesDisponibles();
            ventanaInicio.Show();
            this.Close();
        }

        private void botonListEstadistico_Click(object sender, EventArgs e)
        {
            frmListadoEstadistico formEstad = new frmListadoEstadistico(this);
            formEstad.Show();
            this.Hide();
        }

        private void botonRegConsumibles_Click(object sender, EventArgs e)
        {
            frmInicioRegistrarConsumible frmRegConsumible = new frmInicioRegistrarConsumible(this);
            frmRegConsumible.Show();
            this.Hide();
        }

        private void botonRegFacEstadia_Click(object sender, EventArgs e)
        {
            frmInicioEstadia frmEstadia = new frmInicioEstadia(this,userSesion,hotelSesion);
            frmEstadia.Show();
            this.Hide();
        }

        private void botonCancelarReserva_Click(object sender, EventArgs e)
        {
            frmCancelarReserva frmCanRes = new frmCancelarReserva(this,userSesion,hotelSesion);
            frmCanRes.Show();
            this.Hide();
        }

        private void botonModRes_Click(object sender, EventArgs e)
        {
            frmBuscarReserva frmModRes = new frmBuscarReserva(this,userSesion,hotelSesion);
            frmModRes.Show();
            this.Hide();
        }

        private void botonGenRes_Click(object sender, EventArgs e)
        {
            frmGenerarReserva frmGenRes = new frmGenerarReserva(this,userSesion,hotelSesion);
            frmGenRes.Show();
            this.Hide();
        }

        private void botonRegCliente_Click(object sender, EventArgs e)
        {
            RegistrarCliente frmRegCliente = new RegistrarCliente(this);
            frmRegCliente.Show();
            this.Hide();
        }

        private void botonModElimCliente_Click(object sender, EventArgs e)
        {
            ModificarOBorrarCliente frmModEliCli = new ModificarOBorrarCliente(this);
            frmModEliCli.Show();
            this.Hide();
        }

        private void botonRegHabitacion_Click(object sender, EventArgs e)
        {
            RegistrarHabitacion frmRegHab = new RegistrarHabitacion(this);
            frmRegHab.Show();
            this.Hide();
        }

        private void botonModElimHab_Click(object sender, EventArgs e)
        {
            ModificarOEliminarHabitacion frmModOElimHab = new ModificarOEliminarHabitacion(this);
            frmModOElimHab.Show();
            this.Hide();
        }

        private void botonRegHotel_Click(object sender, EventArgs e)
        {
            RegistrarHotel frmRegHotel = new RegistrarHotel(this);
            frmRegHotel.Show();
            this.Hide();
        }

        private void botonRegRol_Click(object sender, EventArgs e)
        {
            CreacionRol frmCreaRol = new CreacionRol(this);
            frmCreaRol.Show();
            this.Hide();
        }

        private void botonModElimRol_Click(object sender, EventArgs e)
        {
            ModificarYBorrarRol frmModYElimRol = new ModificarYBorrarRol(this);
            frmModYElimRol.Show();
            this.Hide();
        }

        private void botonRegUsuario_Click(object sender, EventArgs e)
        {
            CreacionDeUsuario frmCreUsuario = new CreacionDeUsuario(this);
            frmCreUsuario.Show();
            this.Hide();
        }

        private void botonModElimUsuario_Click(object sender, EventArgs e)
        {
            ModificarYBorrarUsuario frmModElimUsuario = new ModificarYBorrarUsuario(this,userSesion,hotelSesion);
            frmModElimUsuario.Show();
            this.Hide();
        }

        private void botonModElimHotel_Click(object sender, EventArgs e)
        {
            ModificarOEliminarHotel frmModElimHotel = new ModificarOEliminarHotel(this);
            frmModElimHotel.Show();
            this.Hide();
        }
    }
}
