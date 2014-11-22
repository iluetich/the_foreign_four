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
        string nroTarjeta;
       
        public frmFacturacion(){InitializeComponent();}
        public frmFacturacion(frmRegistrarConsumible newForm,long nroFacturaParametro)
        {
            FrbaHotel.ConexionSQL.establecerConexionBD();

            nroFactura = nroFacturaParametro;
            InitializeComponent();
            frmRegistrarConsumiblePadre = newForm;
            FrbaHotel.Utils.rellenarDataGridView(dgvFacturaDetalle, "SELECT * FROM THE_FOREIGN_FOUR.facturacion ("+ nroFactura +")");            
        }       

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try{
                    string pagoSQL = "exec THE_FOREIGN_FOUR.proc_registrar_pago @nro_factura, @cod_tipo_pago, @nro_tarjeta";
                    SqlCommand cmd = new SqlCommand(pagoSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.Parameters.AddWithValue("@nro_factura", nroFactura);
                    cmd.Parameters.AddWithValue("@cod_tipo_pago", Convert.ToInt32(codigoTipoPago));
                    cmd.Parameters.AddWithValue("@nro_tarjeta", Convert.ToInt32(nroTarjeta));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Felicidades ha pagado la factura", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    volverAlMenu();                    

                }catch(Exception){
                    MessageBox.Show("Hubo un error al facturar","Error");
                }
            }
        }

        private void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarConsumiblePadre.Enabled = true;
            frmRegistrarConsumiblePadre.Focus();
        }      

        //vuelve al menu raiz
        private void volverAlMenu()
        {
            this.Close();
            this.frmRegistrarConsumiblePadre.setCerrate();
            this.frmRegistrarConsumiblePadre.Close();
        }

        private void rbtnTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            txtNroTarj.Enabled = true;
            codigoTipoPago = "2";
        }

        private void rbtnContado_CheckedChanged(object sender, EventArgs e)
        {
            txtNroTarj.Enabled = false;
            codigoTipoPago = "1";
        }

        private bool validarCampos()
        {
            if (rbtnContado.Checked || rbtnTarjeta.Checked){
                if (rbtnTarjeta.Checked){
                    if (txtNroTarj.Text != ""){
                        return true;
                    }else{
                        MessageBox.Show("Complete el numero de tarjeta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;    
                    }
                }else{
                    nroTarjeta = "0";
                    return true;
                }
            }else{
                MessageBox.Show("Seleccione un modo de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

    }
}

