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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consultaSql = "select nombre, apellido, tipo_doc, nro_doc, mail from THE_FOREIGN_FOUR.buscar_clientes(null,null,'" + cmbTipoDoc.Text +"'," + txtIdentificacion.Text + ",'" + txtMail.Text + "');";
            FrbaHotel.Utils.rellenarDataGridView(dgvResultCltes, consultaSql);
        }

        private void btnVolver_Click(object sender, EventArgs e){
            this.Close();
        }

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(txtMail);
            FrbaHotel.Utils.limpiarControl(txtIdentificacion);
        }

        
        

        
    }
}
