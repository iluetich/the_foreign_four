﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Registrar_Consumible;

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
            //Application.Run(new frmModificarReserva());
            //Application.Run(new frmRegistrarEstadia());
            //Application.Run(new frmRegistrarConsumible());
            //Application.Run(new frmInicioRegistrarConsumible());
            Application.Run(new frmInicioEstadia());
           
        }
    }
}
