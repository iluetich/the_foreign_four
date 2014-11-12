using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using FrbaHotel.IniciarSecion;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel
{
    public partial class InicioDelSistema : Form 
    {
        
        //debe leer de la base de datos los roles existentes
        // Hacer consulta sql para ver que roles existen
        private string rolElegido;
        
        public InicioDelSistema()
        {
            InitializeComponent();
            //Establece conexion con la BD
            FrbaHotel.ConexionSQL.establecerConexionBD();

            this.cargarRolesDisponibles();
        }

        public void cargarRolesDisponibles()
        {
            string consultaSql = "SELECT * FROM THE_FOREIGN_FOUR.Roles WHERE estado='H'";
            FrbaHotel.Utils.rellenarCombo(comboBoxEleccionRol, "THE_FOREIGN_FOUR.Roles", "nombre", consultaSql);
        }

        private void BotonIngresar_Click(object sender, EventArgs e)
        {
            if (rolElegido == "Guest")
            {
                //si seleccionaste guest abri el menu de guest
                MenuDinamico menuGuest = new MenuDinamico(this,"Guest", "1");
                menuGuest.Show();
                this.Hide();
            }
            else
            {
                //si se selecciono otro rol entonces abri el formulario de Login
                Form formulario = new Login(this,rolElegido);
                formulario.Show();
                this.Hide();
            }
                
        }

        private void comboBoxEleccionRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolElegido = comboBoxEleccionRol.Text;
        }

       

    }
}
