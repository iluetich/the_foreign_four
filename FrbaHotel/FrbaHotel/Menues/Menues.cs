using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Menues
{
    public partial class Menues : Form
    {
        public Menues(int codRol)
        {
            InitializeComponent();
            generarMenu(codRol);
        }


        public void generarMenu(int rol)
        {
            List<string> funcionalidades = new List<string>();

            //se consulta que funcionalidades tiene el rol

            foreach (string funcionalida in funcionalidades)
            {
                if (funcionalida == "generar Reserva")
                {
                    this.generarBoton(
                }


            }


        }
    
    
    }
}

