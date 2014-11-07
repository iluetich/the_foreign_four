using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmBuscarCliente : Form
    {

        frmCliente frmClientePadre;
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;
        bool seleccionoCliente = false;

        //form generico
        public frmBuscarCliente() { InitializeComponent(); FrbaHotel.ConexionSQL.establecerConexionBD(); }

        public frmBuscarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            InitializeComponent();
            frmRegistrarHuespedesRestantesPadre = newForm;
        }

        public frmBuscarCliente(frmCliente newFrm)
        {
            InitializeComponent();
            frmClientePadre = newFrm;
        }

        //busca clinte
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (controlesCargados()){
                string consultaSql = "select nombre, apellido, tipo_doc, nro_doc, mail from THE_FOREIGN_FOUR.buscar_clientes(null,null,'" + cmbTipoDoc.Text + "'," + txtIdentificacion.Text + ",'" + txtMail.Text + "');";
                FrbaHotel.Utils.rellenarDataGridView(dgvResultCltes, consultaSql);
            }else{
                MessageBox.Show("Complete al menos un campo");
            }
        }
        
        //selecciona cliente
        private void btnSelec_Click(object sender, EventArgs e)
        {
            if (seleccionoCliente){
                frmClientePadre.setBandClienteRegistrado();
                this.Close();
            }else{
                MessageBox.Show("Seleccione un cliente antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
        }

        //boton volver
        private void btnVolver_Click(object sender, EventArgs e){
            this.Close();
        }

        //evento para el close del form
        private void frmBuscadorCliente_FormClosing(object sender, FormClosingEventArgs e) {
            if (frmClientePadre != null)
            {
                frmClientePadre.Enabled = true;
                frmClientePadre.Focus();
            }
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.Enabled = true;
                frmRegistrarHuespedesRestantesPadre.Focus();
            }
        }

        //limpia los controles
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(txtMail);
            FrbaHotel.Utils.limpiarControl(txtIdentificacion);
        }

        //valida que el input del textbox sean solo numeros
        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); }

        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvResultCltes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvResultCltes.Rows[e.RowIndex];
                frmClientePadre.filaSeleccionadaDataGrid(row);
                seleccionoCliente = true;
            }
        }

        //valida que se completo algun campo para realizar la busqueda
        private bool controlesCargados()
        {
            if (txtMail.Text != "" | (txtIdentificacion.Text != "" & cmbTipoDoc.SelectedIndex != -1) ){
                return true;
            }else{
                return false;
            }
        }

        
    }
}
