﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

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
            //Application.Run(new frmGenerarReserva());
            //Application.Run(new frmModificarReserva());
           
        }
    }
}
