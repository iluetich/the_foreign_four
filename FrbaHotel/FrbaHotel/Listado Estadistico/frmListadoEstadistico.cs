using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class frmListadoEstadistico : Form
    {
        private MenuDinamico menu;

        public frmListadoEstadistico(MenuDinamico menuPadre)
        {
            //seteo el padre del formulario
            this.menu = menuPadre;
            InitializeComponent();
            //Autoajusto celdas
            this.dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //oculto columnas
            for (int i = 0; i < dgvListado.Columns.Count; i++ )
                this.dgvListado.Columns[i].Visible = false;
            
        }

        public frmListadoEstadistico()
        {
            InitializeComponent();
            //Autoajusto celdas
            this.dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //oculto columnas
            for (int i = 0; i < dgvListado.Columns.Count; i++)
                this.dgvListado.Columns[i].Visible = false;

        }
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (validarCampos()){
                muestraColumnasTipoListado();
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

        private void muestraColumnasTipoListado()
        {
            switch (cmbTipoListado.SelectedIndex)
            {
                case 0:
                    this.dgvListado.Columns[clmHotel.Name].Visible = true;
                    this.dgvListado.Columns[clmCantResCanc.Name].Visible = true;
                    this.dgvListado.Columns[clmCantConsFact.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasFueraServ.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasOcup.Name].Visible = false;
                    this.dgvListado.Columns[clmCliente.Name].Visible = false;
                    this.dgvListado.Columns[clmHabitacion.Name].Visible = false;
                    this.dgvListado.Columns[clmPuntaje.Name].Visible = false;
                    break;
                case 1:
                    this.dgvListado.Columns[clmHotel.Name].Visible = true;
                    this.dgvListado.Columns[clmCantResCanc.Name].Visible = false;
                    this.dgvListado.Columns[clmCantConsFact.Name].Visible = true;
                    this.dgvListado.Columns[clmCantDiasFueraServ.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasOcup.Name].Visible = false;
                    this.dgvListado.Columns[clmCliente.Name].Visible = false;
                    this.dgvListado.Columns[clmHabitacion.Name].Visible = false;
                    this.dgvListado.Columns[clmPuntaje.Name].Visible = false;
                    break;
                case 2:
                    this.dgvListado.Columns[clmHotel.Name].Visible = true;
                    this.dgvListado.Columns[clmCantResCanc.Name].Visible = false;
                    this.dgvListado.Columns[clmCantConsFact.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasFueraServ.Name].Visible = true;
                    this.dgvListado.Columns[clmCantDiasOcup.Name].Visible = false;
                    this.dgvListado.Columns[clmCliente.Name].Visible = false;
                    this.dgvListado.Columns[clmHabitacion.Name].Visible = false;
                    this.dgvListado.Columns[clmPuntaje.Name].Visible = false;
                    break;
                case 3:
                    this.dgvListado.Columns[clmHotel.Name].Visible = true;
                    this.dgvListado.Columns[clmCantResCanc.Name].Visible = false;
                    this.dgvListado.Columns[clmCantConsFact.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasFueraServ.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasOcup.Name].Visible = true;
                    this.dgvListado.Columns[clmCliente.Name].Visible = false;
                    this.dgvListado.Columns[clmHabitacion.Name].Visible = true;
                    this.dgvListado.Columns[clmPuntaje.Name].Visible = false;
                    break;
                case 4:
                    this.dgvListado.Columns[clmHotel.Name].Visible = false;
                    this.dgvListado.Columns[clmCantResCanc.Name].Visible = false;
                    this.dgvListado.Columns[clmCantConsFact.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasFueraServ.Name].Visible = false;
                    this.dgvListado.Columns[clmCantDiasOcup.Name].Visible = false;
                    this.dgvListado.Columns[clmCliente.Name].Visible = true;
                    this.dgvListado.Columns[clmHabitacion.Name].Visible = false;
                    this.dgvListado.Columns[clmPuntaje.Name].Visible = true;
                    break;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoEstadistico_FormClosing(object sender, FormClosingEventArgs e){
            this.menu.Show();
        }



    }


}
