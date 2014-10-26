using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public abstract class Utils
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

        //Valida que la fecha inicio sea menor a la fecha final
        internal static bool validarFechas(DateTimePicker dtpFechaDesde, DateTimePicker dtpFechaHasta)
        {
            if (dtpFechaDesde.Value < dtpFechaHasta.Value)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Fecha inicio debe ser menor a fecha final", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        //Valida que cualquier tipo de control tenga su campo data completo   
        internal static bool validarCampoEsteCompleto(Control newCtrl, String msg)
        {

            switch (newCtrl.GetType().Name.ToString())
            {
                case "TextBox":
                    if (newCtrl.Text != "") { return true; }
                    else
                    {
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                    
                case "ComboBox":
                    if (((ComboBox)newCtrl).SelectedIndex != -1) { return true; }
                    else
                    {
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                    
                case "DataTimePicker":                   
                    if (((DateTimePicker)newCtrl).Value != null) { return true; }
                    else
                    {
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                       
            }
            return true;
        }
    }
}
