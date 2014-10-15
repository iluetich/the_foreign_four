using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class InicioDelSistema : Form
    {
        
        //debe leer de la base de datos los roles existentes
        // Hacer consulta sql para ver que roles existen
        private List<String> roles;

        public InicioDelSistema()
        {
            InitializeComponent();
        }

        public void setearRolesAlComboBox()
        {
            //setear los roleas de la lista, una vez que ya se los saco de la base de datos
        }

        private void BotonIngresar_Click(object sender, EventArgs e)
        {
            //Accion que tiene que hacer cuando se elige un rol
        }
    }
}
