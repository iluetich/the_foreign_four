﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmGenerarReserva : Form
    {
        private MenuDinamico menu;
       
        public frmGenerarReserva(){
            InitializeComponent();            
        }

        public frmGenerarReserva(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
        }

        private void frmGenerarReserva_Load(object sender, EventArgs e)
        {
            cargarControles();
        }

        private void btnSiguietne_Click(object sender, EventArgs e)
        {
            if (validarDatosCompletos() &
                FrbaHotel.Utils.validarFechas(dtpFechaDesde, dtpFechaHasta)){
                    
                    new frmCliente(this).Show();
                    this.Enabled = false;
            }
        }

        private void frmGenerarReserva_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.menu.Show();
        }

        private bool validarDatosCompletos(){
            return (
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbHotel, "Hotel") &
            FrbaHotel.Utils.validarCampoEsteCompleto(txtCantHues, "cantidad huespedes") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoHab, "Tipo habitacion") &
            FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoReg, "Tipo regimen") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaDesde, "Fecha desde") &
            FrbaHotel.Utils.validarCampoEsteCompleto(dtpFechaHasta, "Fecha hasata")
            );
        }

        private void txtCantHues_KeyPress(object sender,KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void cargarControles()
        {
            string consultaSql = "select * from THE_FOREIGN_FOUR.Hoteles";
            string nombreTabla = "THE_FOREIGN_FOUR.Hoteles";
            string nombreCampo = "cod_hotel";

            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql,FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet, nombreTabla);
            cmbHotel.DataSource = dataSet.Tables[0].DefaultView;
            cmbHotel.DisplayMember = nombreCampo;
        }
    }
}
