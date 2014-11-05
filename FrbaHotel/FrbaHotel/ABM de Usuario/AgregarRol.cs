using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AgregarRol : Form
    {
        private string rolElegido;
        private string hotelElegido;
        private CreacionDeUsuario padre;

        public AgregarRol(CreacionDeUsuario frmPadre)
        {
            this.padre = frmPadre;
            InitializeComponent();
            FrbaHotel.Utils.rellenarCombo(comboBoxRol, "THE_FOREIGN_FOUR.Roles", "nombre","SELECT * FROM THE_FOREIGN_FOUR.Roles r WHERE r.nombre!='Guest' AND r.nombre!='Administrador General'");
            FrbaHotel.Utils.rellenarCombo(comboBoxHotel, "THE_FOREIGN_FOUR.Hoteles", "cod_hotel", "SELECT * FROM THE_FOREIGN_FOUR.Hoteles");
            rolElegido = comboBoxRol.SelectedItem.ToString();
            hotelElegido = comboBoxHotel.SelectedItem.ToString();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolElegido = comboBoxRol.Text;
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotelElegido = comboBoxHotel.Text;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            this.comboBoxHotel_SelectedIndexChanged(sender, e);
            this.comboBoxRol_SelectedIndexChanged(sender, e);
            padre.agregaAlDataSet(rolElegido, hotelElegido);
            this.Close();
        }
    }
}
