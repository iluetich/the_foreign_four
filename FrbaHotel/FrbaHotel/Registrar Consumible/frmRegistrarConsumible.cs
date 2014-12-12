using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Registrar_Estadia.checkOut;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class frmRegistrarConsumible : Form
    {
        frmInicioRegistrarConsumible frmInicioRegistrarConsumiblePadre;
        frmInicioEstadia frmInicioEstadiaPadre;
        frmCheckout frmCheckoutPadre;
        int fila;
        private long nroFactura;
        string codigoEstadia;
        string consumibleElegido;
        int codConsumibleElegido;
        bool cerrate = false;


        //---------------------------------------------------------------------------------------------------------------------
        public frmRegistrarConsumible(){InitializeComponent();}
        public frmRegistrarConsumible(frmInicioRegistrarConsumible newForm, string codEstadia)
        {
            InitializeComponent();
            frmInicioRegistrarConsumiblePadre = newForm;
            this.codigoEstadia = codEstadia;
            btnFacturar.Text = "Aceptar";

            String obtencion_consumibles = "SELECT descripcion FROM THE_FOREIGN_FOUR.view_consumibles";
            FrbaHotel.Utils.rellenarCombo(comboBoxConsumibles, "descripcion", obtencion_consumibles); 
        }

        public frmRegistrarConsumible(frmCheckout newForm, frmInicioEstadia newFormInicioEstadia,long nroFacturaParametro, string codEstadia)
        {
            nroFactura = nroFacturaParametro;
            InitializeComponent();
            frmCheckoutPadre = newForm;
            frmInicioEstadiaPadre = newFormInicioEstadia;
            btnVolver.Enabled = false;
            this.codigoEstadia = codEstadia;

            String obtencion_consumibles = "SELECT descripcion FROM THE_FOREIGN_FOUR.view_consumibles";
            FrbaHotel.Utils.rellenarCombo(comboBoxConsumibles, "descripcion", obtencion_consumibles); 
        }
        //---------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------
        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtHabitacion_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void frmRegistrarConsumible_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicioRegistrarConsumiblePadre != null)
            {
                frmInicioRegistrarConsumiblePadre.Enabled = true;
                frmInicioRegistrarConsumiblePadre.Focus();                
            }
            if (frmCheckoutPadre != null)
            {
                frmCheckoutPadre.Enabled = true;
                frmCheckoutPadre.setCerrate();
                if (cerrate)frmCheckoutPadre.Close();
            }

        }
        //---------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            if (dgvConsumibles.Rows.Count > 0){
                //registrar consumible
                for (int i = 0; i < dgvConsumibles.RowCount - 1; i++)
                {
                    try {
                        DataGridViewRow fila = dgvConsumibles.Rows[i];
                        SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_aniadir_consumible_estadia", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cod_estadia", Convert.ToInt32(codigoEstadia));
                        cmd.Parameters.AddWithValue("@cod_consumible", long.Parse(fila.Cells[0].Value.ToString()));
                        cmd.Parameters.AddWithValue("@cantidad", int.Parse(fila.Cells[1].Value.ToString()));
                        cmd.ExecuteNonQuery();
                    } catch (Exception) {
                        MessageBox.Show("El código de consumible " + dgvConsumibles.Rows[i].Cells[0].Value + " ingresado no existe. Por favor, ingrese un código de consumible válido e intente nuevamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            if(frmCheckoutPadre != null){           
                    //Confirma consumible
                    SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_consumibles", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_factura", nroFactura);
                    cmd.ExecuteNonQuery();                    

                    //confirmo factura
                    SqlCommand cmd2 = new SqlCommand("THE_FOREIGN_FOUR.confirmar_factura", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nro_factura", nroFactura);

                    cmd2.ExecuteNonQuery();
                    //-------------------------------

                    new frmFacturacion(this,nroFactura).Show();
                    this.Enabled = false;

            }else if (frmInicioRegistrarConsumiblePadre != null) {                 

                    MessageBox.Show("Los consumibles fueron registrados satisfactoriamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.frmInicioRegistrarConsumiblePadre.Close();            
            }
        }       

        private void btnRegistrarCons_Click(object sender, EventArgs e)
        {
            this.comboBoxConsumibles_SelectedIndexChanged(sender, e);
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCantidad, "Cantidad") )
            {
                agregarConsumible(consumibleElegido, txtCantidad.Text);
            }
        }

        private void agregarConsumible(string descripcionConsumible, string cantidad)
        {
            fila = dgvConsumibles.Rows.Count - 1;
            dgvConsumibles.Rows.Add(1);

            string consumibleSQL = "SELECT cod_consumible FROM THE_FOREIGN_FOUR.Consumibles WHERE descripcion = @descripcion";
            SqlCommand cmd = new SqlCommand(consumibleSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.Parameters.AddWithValue("descripcion", descripcionConsumible);
            string codigo = cmd.ExecuteScalar().ToString();
            
            dgvConsumibles.Rows[fila].Cells[0].Value = codigo;
            dgvConsumibles.Rows[fila].Cells[1].Value = cantidad; 
            dgvConsumibles.Rows[fila].Cells[2].Value = descripcionConsumible;
        }     

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //---------------------------------------------------------------------------------------------------------------------

        public void setCerrate(){ cerrate = true; }

        private void txtCodProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxConsumibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            consumibleElegido = comboBoxConsumibles.Text;
        }
 
    }
}
