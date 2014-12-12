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
        string fechaDesde;
        string fechaHasta;

        public frmListadoEstadistico(MenuDinamico menuPadre)
        {
            //seteo el padre del formulario
            this.menu = menuPadre;
            InitializeComponent();            
        }   
        
        //boton que genera el listado
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (validarCampos()){
                muestraColumnasTipoListado();
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }

        //valida que los campos para ingresar sean correctos
        private bool validarCampos()
        {
            return(
                FrbaHotel.Utils.validarCampoEsteCompleto(txtAño, "Año") &
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTrimestre, "Trimestre") &
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoListado, "Tipo Listado")
            );
        }

        //rellena la grid
        private void muestraColumnasTipoListado()
        {
            try{
                //depende cual sea el caso muestra ejecuta la consulta correspondiente
                switch (cmbTipoListado.SelectedIndex)
                {
                    case 0:
                        hotelesConMayorCantidadDeReservas();
                        break;
                    case 1:
                        hotelesMayorCantidadConsumiblesFacturados();
                        break;
                    case 2:
                        hotelesMayorCantidadDiasFueraDeServicio();
                        break;
                    case 3:
                        habitacionesMayorCantidadDiasVecesQueFueronOcupadas();
                        break;
                    case 4:
                        clienteConMayorCantidadDePuntos();
                        break;
                }
            }catch(Exception){
                if (cmbTipoListado.SelectedIndex == 4)
                    MessageBox.Show("Tiempo de espera cadudado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("No hay datos sobre el año ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //vuelve al menu raiz
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //evento para el cierre del form desde la X
        private void frmListadoEstadistico_FormClosing(object sender, FormClosingEventArgs e){
            this.menu.Show();
        }

        //requerimiento
        private void hotelesConMayorCantidadDeReservas()
        {
            armarFecha();            
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_estadistica_cancelaciones_hotel('" + fechaDesde + "','" + fechaHasta + "')";
            FrbaHotel.Utils.rellenarDataGridView(dgvListado,consultaSQL);
        }

        //requerimiento
        private void hotelesMayorCantidadConsumiblesFacturados()
        {
            armarFecha();            
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_estadistica_consumibles_hotel('" + fechaDesde + "','" + fechaHasta + "')";
            FrbaHotel.Utils.rellenarDataGridView(dgvListado, consultaSQL);
        }

        //requerimiento
        private void hotelesMayorCantidadDiasFueraDeServicio(){
            armarFecha();            
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_estadistica_inactividad_hotel('" + fechaDesde + "','" + fechaHasta + "')";
            FrbaHotel.Utils.rellenarDataGridView(dgvListado, consultaSQL);
        }

        //requerimiento
        private void habitacionesMayorCantidadDiasVecesQueFueronOcupadas(){
            armarFecha();            
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_estadistica_ocupacion_habitacion('" + fechaDesde + "','" + fechaHasta + "')";
            FrbaHotel.Utils.rellenarDataGridView(dgvListado, consultaSQL);
        }

        //requerimiento
        private void clienteConMayorCantidadDePuntos(){
            armarFecha();
            string consultaSQL = "select * from THE_FOREIGN_FOUR.func_estadistica_puntaje_cliente('" + fechaDesde + "','" + fechaHasta + "')";
            FrbaHotel.Utils.rellenarDataGridView(dgvListado, consultaSQL);         
        }

        //builder de fecha
        private void armarFecha()
        {
            //yyyy-dd-MM
            switch (cmbTrimestre.SelectedIndex)
            {
                case 0:
                    fechaDesde = txtAño.Text + "-" + "01-01";
                    fechaHasta = txtAño.Text + "-" + "31-03";
                break;
                case 1:
                    fechaDesde = txtAño.Text + "-" + "01-04";
                    fechaHasta = txtAño.Text + "-" + "30-06";
                break;
                case 2:
                    fechaDesde = txtAño.Text + "-" + "01-07";
                    fechaHasta = txtAño.Text + "-" + "30-09";
                break;
                case 3:
                    fechaDesde = txtAño.Text + "-" + "01-10";
                    fechaHasta = txtAño.Text + "-" + "31-12";
                break;
            }
        }

        private void cmbTipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
        }
    }
}
