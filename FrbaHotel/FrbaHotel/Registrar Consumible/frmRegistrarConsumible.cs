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

        public frmRegistrarConsumible(){InitializeComponent();}

        public frmRegistrarConsumible(frmInicioRegistrarConsumible newForm)
        {
            InitializeComponent();
            frmInicioRegistrarConsumiblePadre = newForm;
            
            
        }

        public frmRegistrarConsumible(frmCheckout newForm, frmInicioEstadia newFormInicioEstadia,long nroFacturaParametro)
        {
            nroFactura = nroFacturaParametro;
            InitializeComponent();
            frmCheckoutPadre = newForm;
            frmInicioEstadiaPadre = newFormInicioEstadia;
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            //registrar los consumibles por factura
            for (int i = 0; i < dgvConsumibles.RowCount - 1; i++)
            {
                DataGridViewRow fila = dgvConsumibles.Rows[i];

                SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_registrar_consumible", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nro_factura", nroFactura);
                cmd.Parameters.AddWithValue("@cod_consumible",long.Parse(fila.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@cantidad", int.Parse(fila.Cells[1].Value.ToString()));

                cmd.ExecuteNonQuery();
            }

            //confirmo factura

            SqlCommand cmd2 = new SqlCommand("THE_FOREIGN_FOUR.confirmar_factura", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@nro_factura", nroFactura);

            cmd2.ExecuteNonQuery();
            //-------------------------------

            new frmFacturacion(this,nroFactura).Show();
            this.Enabled = false;
        }

        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtHabitacion_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void btnRegistrarCons_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodProducto, "Codigo producto") &
                FrbaHotel.Utils.validarCampoEsteCompleto(txtCantidad, "Cantidad") )
            {
                agregarConsumible(txtCodProducto.Text, txtCantidad.Text,"habitacion");
            }
        }

        private void agregarConsumible(string codigo, string cantidad, string habitacion)
        {
            fila = dgvConsumibles.Rows.Count - 1;
            dgvConsumibles.Rows.Add(1);

            dgvConsumibles.Rows[fila].Cells[0].Value = codigo;
            dgvConsumibles.Rows[fila].Cells[1].Value = cantidad;
            dgvConsumibles.Rows[fila].Cells[2].Value = habitacion;           

        }

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
                frmCheckoutPadre.Focus();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
