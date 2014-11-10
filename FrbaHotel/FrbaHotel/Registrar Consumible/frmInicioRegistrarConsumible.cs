﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.Registrar_Consumible
{

    public partial class frmInicioRegistrarConsumible : Form
    {
        private MenuDinamico menu;

        public frmInicioRegistrarConsumible(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        public frmInicioRegistrarConsumible()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtNroHabitacion, "Codigo estadia"))
            {
                new frmRegistrarConsumible(this).Show();
                this.Enabled = false;
            }
        }

        private void txtCodEstadia_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInicioRegistrarConsumible_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }

    }
}
