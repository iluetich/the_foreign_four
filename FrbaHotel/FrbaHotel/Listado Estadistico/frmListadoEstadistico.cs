using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class frmListadoEstadistico : Form
    {
        public frmListadoEstadistico()
        {
            InitializeComponent();
            lblFechaDesde.Hide();
            lblFechaHasta.Hide();
            dtpFechaDesde.Hide();
            dtpFechaHasta.Hide();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (validarCampos()){
            }


        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }

        private bool validarCampos()
        {
            return(
                FrbaHotel.Utils.validarCampoEsteCompleto(txtAño, "Año") &
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTrimestre, "Trimestre") &
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoListado, "Tipo Listado")
            );
        }

        private void cmbTipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoListado.SelectedIndex == 4)
            {
                dtpFechaDesde.Show();
                dtpFechaHasta.Show();
                lblFechaDesde.Show();
                lblFechaHasta.Show();
            }
            else
            {
                lblFechaDesde.Hide();
                lblFechaHasta.Hide();
                dtpFechaDesde.Hide();
                dtpFechaHasta.Hide();
            }
        }



    }


}
