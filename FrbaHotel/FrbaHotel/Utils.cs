using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel 
{
    public abstract class Utils : Form
    {
        //Para que el textBox solo permita el tipeo de numeros
        internal static void allowNumbers(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espacios
                char.IsPunctuation(e.KeyChar)) //Puntuacion
                e.Handled = true; //No permitir
        }





      
    }
}
