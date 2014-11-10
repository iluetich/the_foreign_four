using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Listado_Estadistico;
using FrbaHotel.Cancelar_Reserva;

namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new InicioDelSistema());
            //Application.Run(new frmGenerarReserva());
<<<<<<< HEAD
            //Application.Run(new frmCancelarReserva(null,"Guest",""));
=======
            //Application.Run(new frmCancelarReserva(null,"admin","9"));
>>>>>>> 13d5a6fa01cb9236918786fa7d583670fa31f224
            //Application.Run(new frmBuscarReserva(null,"Guest",""));
            //Application.Run(new frmGenerarReserva());
            //Application.Run(new frmBuscarCliente());
            //Application.Run(new frmModificarReserva());
            //Application.Run(new frmInicioRegistrarConsumible());
            Application.Run(new frmInicioEstadia(null,"Guest","9"));
            //Application.Run(new frmListadoEstadistico());
           
        }
    }
}
