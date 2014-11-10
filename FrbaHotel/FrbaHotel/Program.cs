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
<<<<<<< HEAD
            //Application.Run(new InicioDelSistema());
            Application.Run(new frmGenerarReserva());
=======
            Application.Run(new InicioDelSistema());
            //Application.Run(new frmGenerarReserva());
>>>>>>> e93ee415c29e2d6fc1ce66d78101cbee9ec64e18
            //Application.Run(new frmCancelarReserva(null,"Guest",""));
            //Application.Run(new frmCancelarReserva(null,"admin","9"));
            //Application.Run(new frmBuscarReserva(null,"Guest",""));
            //Application.Run(new frmGenerarReserva());
            //Application.Run(new frmBuscarCliente());
            //Application.Run(new frmModificarReserva());
            //Application.Run(new frmInicioRegistrarConsumible());
            //Application.Run(new frmInicioEstadia(null,"Guest","9"));
            //Application.Run(new frmListadoEstadistico());
           
        }
    }
}
