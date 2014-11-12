using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class frmFacturacion : Form
    {
        frmRegistrarConsumible frmRegistrarConsumiblePadre;
        private long nroFactura;        
        string codigoTipoPago;
        DataSet dataSetTiposPago;
        DataRow codRowTipoPago;
        bool terminoDeCargar = false;

        public frmFacturacion(){InitializeComponent();}

        public frmFacturacion(frmRegistrarConsumible newForm,long nroFacturaParametro)
        {
            FrbaHotel.ConexionSQL.establecerConexionBD();

            nroFactura = nroFacturaParametro;
            InitializeComponent();
            frmRegistrarConsumiblePadre = newForm;
            cargoControles();

            FrbaHotel.Utils.rellenarDataGridView(dgvFacturaDetalle, "SELECT * FROM THE_FOREIGN_FOUR.facturacion ("+ nroFactura +")");
            cmbTipoPago.Focus();
            terminoDeCargar = true;
        }

        private void cargoControles()
        {
            //leno tipos de pago
            string consultaSQL = "select * from THE_FOREIGN_FOUR.TiposPago";
            string nombreTabla = "THE_FOREIGN_FOUR.TiposPago";
            string nombreCampo = "descripcion";
            dataSetTiposPago = FrbaHotel.Utils.rellenarCombo(cmbTipoPago, nombreTabla, nombreCampo, consultaSQL);
        }

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try{
                    string pagoSQL = "exec THE_FOREIGN_FOUR.proc_registrar_pago @nro_factura, @cod_tipo_pago, @nro_tarjeta";
                    SqlCommand cmd = new SqlCommand(pagoSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.Parameters.AddWithValue("@nro_factura", nroFactura);
                    cmd.Parameters.AddWithValue("@cod_tipo_pago", Convert.ToInt32(Convert.ToInt32(codigoTipoPago)));
                    cmd.Parameters.AddWithValue("@nro_tarjeta", Convert.ToInt32(txtNroTarj.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Felicidades ha pagado la factura", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    volverAlMenu();

                }catch(Exception){
                    MessageBox.Show("Hace foco en el comboBox por mas que tenga una opcion seleccionada","Error");
                }
            }
        }

        private void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarConsumiblePadre.Enabled = true;
            frmRegistrarConsumiblePadre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (terminoDeCargar)
            {
                //obtengo codigo tipo pago
                codRowTipoPago = dataSetTiposPago.Tables[0].Rows[cmbTipoPago.SelectedIndex];
                codigoTipoPago = codRowTipoPago["cod_tipo_pago"].ToString();                
            }
        }

        //valida campos
        private bool validarCampos()
        {
            return(
                FrbaHotel.Utils.validarCampoEsteCompleto(cmbTipoPago, "Fecha desde") &
                FrbaHotel.Utils.validarCampoEsteCompleto(txtNroTarj, "Fecha hasata") 
                );
        }

        //vuelve al menu raiz
        private void volverAlMenu()
        {
            this.Close();
            this.frmRegistrarConsumiblePadre.Close();
        }       
    }
}

