using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Listado_Estadistico;
using FrbaHotel.Cancelar_Reserva;
using FrbaHotel.Menues_de_los_Roles;
using System.Configuration;

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
            Application.Run(new InicioDelSistema());           
        }
    }
}
