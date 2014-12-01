using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class frmBuscarCliente : Form
    {

        frmCliente frmClientePadre;
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;
        bool seleccionoCliente = false;
        int codigoCliente;        
        DataGridViewRow row;

        //------------------------------------------------------------------------------------------------
        //---------------------CONSTRUCTORES--------------------------------------------------------------
        //constructor generico
        public frmBuscarCliente() { InitializeComponent();}

        //constructor del flujo de registrar los huespedes que queda
        public frmBuscarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            InitializeComponent();
            frmRegistrarHuespedesRestantesPadre = newForm;
        }

        //constructor del flujo normal
        public frmBuscarCliente(frmCliente newFrm)
        {
            InitializeComponent();
            frmClientePadre = newFrm;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------



        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------
        //evento para el close del form
        private void frmBuscadorCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        //valida que el input del textbox sean solo numeros
        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e) { FrbaHotel.Utils.allowNumbers(e); 
        }
        //----------------------FIN EVENTOS DEL FORM-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        
        
        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------  
        //busca cliente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consultaSQL="";
            if (controlesCargados()){                
                //busquedas por algunos de los campos
                string doc = txtIdentificacion.Text;
                string mail = txtMail.Text;
                string tipoDoc = cmbTipoDoc.Text;
               
                if (tipoDoc == "") tipoDoc = "null"; else tipoDoc = "'" + tipoDoc + "'";
                if (doc == "") doc = "null";
                if (mail == "") mail = "null"; else mail = "'" + mail + "'";                
               
                try{
                    consultaSQL = "select cod_cliente, nombre, apellido, tipo_doc, nro_doc, mail from THE_FOREIGN_FOUR.buscar_clientes(null,null," + tipoDoc + "," + doc + "," + mail + ")";
                    FrbaHotel.Utils.rellenarDataGridView(dgvResultCltes, consultaSQL);
                    dgvResultCltes.Columns["cod_cliente"].Visible = false;
                    codigoCliente = Convert.ToInt32(dgvResultCltes.Rows[0].Cells["cod_cliente"].Value);
                }
                catch (Exception) {
                    MessageBox.Show("No hubo coincidencias, revisa los parametros de tu busqueda","Atencion");
                }
                
            }else{
                MessageBox.Show("Complete al menos un campo");
            }
        }
        
        //selecciona cliente
        private void btnSelec_Click(object sender, EventArgs e)
        {
            if (seleccionoCliente){
                if (frmClientePadre != null){
                    frmClientePadre.setBandClienteRegistrado();
                    frmClientePadre.setCodigoCliente(codigoCliente);
                }else if (frmRegistrarHuespedesRestantesPadre != null){
                    frmRegistrarHuespedesRestantesPadre.obtenerDatosDelBuscador(row);
                    frmRegistrarHuespedesRestantesPadre.setCodigoCliente(codigoCliente);
                }
                this.Close();
            }else{
                MessageBox.Show("Seleccione un cliente antes de continuar \n(haga click en la tabla por mas que haya obtenido resultados)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
        }

        //boton volver
        private void btnVolver_Click(object sender, EventArgs e){
            this.Close();
        }

        //limpia los controles
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(txtMail);
            FrbaHotel.Utils.limpiarControl(txtIdentificacion);
            DataTable dt = (DataTable)dgvResultCltes.DataSource;
            dt.Clear();
            seleccionoCliente = false;
        }
        //----------------------FIN BOTONES-----------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------- 



        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------
        //evento para cuando se hace click en una celda devuelva la fila correspondiente
        private void dgvResultCltes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                row = dgvResultCltes.Rows[e.RowIndex];
                if (frmClientePadre != null){                   
                    frmClientePadre.filaSeleccionadaDataGridClientes(row);                    
                }               
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
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------
           
    }
}
