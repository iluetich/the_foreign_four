using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class RegistrarCliente : Form
    {
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;
        private MenuDinamico menu;
        private Boolean constructorMenu;

        public RegistrarCliente(MenuDinamico menuPadre)
        {
            this.constructorMenu = true;
            this.menu = menuPadre;
            InitializeComponent();
        }

        public RegistrarCliente()
        {
            this.constructorMenu = false;
            InitializeComponent();
        }

        public RegistrarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            this.constructorMenu = false;
            InitializeComponent();
            frmRegistrarHuespedesRestantesPadre = newForm;
        }

        public void RegistrarCliente_FormClosing(object sender, FormClosingEventArgs e){
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.Enabled = true;
                frmRegistrarHuespedesRestantesPadre.Focus();
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            if (constructorMenu)
            {
                menu.Show();
            }
            this.Close();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.llenarGrid(this);
                this.Close();
            }

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxNombre);
            FrbaHotel.Utils.limpiarControl(textBoxApellido);
            FrbaHotel.Utils.limpiarControl(textBoxNroDoc);
            FrbaHotel.Utils.limpiarControl(textBoxMail);
            FrbaHotel.Utils.limpiarControl(textBoxTelefono);
            FrbaHotel.Utils.limpiarControl(textBoxCalle);
            FrbaHotel.Utils.limpiarControl(textBoxLocalidad);
            FrbaHotel.Utils.limpiarControl(textBoxNacionalidad);
        }
    }
}
