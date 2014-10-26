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
        
        //Valida que el text box este lleno
        internal static bool validarTextBoxCompleto(TextBox newTxtBox, String msg)
        {
            if (newTxtBox.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        //Valida que el combo box este lleno
        internal static bool validarComboBoxCompleto(ComboBox newCmbBox, String msg)
        {
            if (newCmbBox.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        //Valida que el data time picker este lleno
        internal static bool validarDataTimePickerCompleto(DateTimePicker newDtPicker, String msg)
        {
            if (newDtPicker.Value != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
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
    }
}
