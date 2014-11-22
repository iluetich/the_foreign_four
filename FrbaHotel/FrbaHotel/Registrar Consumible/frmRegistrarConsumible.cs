﻿using System;
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
        bool cerrate = false;

        //---------------------------------------------------------------------------------------------------------------------
        public frmRegistrarConsumible(){InitializeComponent();}
        public frmRegistrarConsumible(frmInicioRegistrarConsumible newForm, string codEstadia)
        {
            InitializeComponent();
            frmInicioRegistrarConsumiblePadre = newForm;
            this.codigoEstadia = codEstadia;
            btnFacturar.Text = "Aceptar";
        }

        public frmRegistrarConsumible(frmCheckout newForm, frmInicioEstadia newFormInicioEstadia,long nroFacturaParametro, string codEstadia)
        {
            nroFactura = nroFacturaParametro;
            InitializeComponent();
            frmCheckoutPadre = newForm;
            frmInicioEstadiaPadre = newFormInicioEstadia;
            btnVolver.Enabled = false;
            this.codigoEstadia = codEstadia;
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
                    try{
                        DataGridViewRow fila = dgvConsumibles.Rows[i];
                        SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_aniadir_consumible_estadia", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        Console.WriteLine("el codigo de estadia es: " + codigoEstadia);
                        cmd.Parameters.AddWithValue("@cod_estadia", Convert.ToInt32(codigoEstadia));
                        cmd.Parameters.AddWithValue("@cod_consumible", long.Parse(fila.Cells[0].Value.ToString()));
                        cmd.Parameters.AddWithValue("@cantidad", int.Parse(fila.Cells[1].Value.ToString()));
                        cmd.ExecuteNonQuery();
                    }catch (Exception){
                        MessageBox.Show("Codigo consumible invalido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    MessageBox.Show("Consumibles registrados", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.frmInicioRegistrarConsumiblePadre.Close();            
            }
        }       

        private void btnRegistrarCons_Click(object sender, EventArgs e)
        {
            if (FrbaHotel.Utils.validarCampoEsteCompleto(txtCodProducto, "Codigo producto") &
                FrbaHotel.Utils.validarCampoEsteCompleto(txtCantidad, "Cantidad") )
            {
                agregarConsumible(txtCodProducto.Text, txtCantidad.Text);
            }
        }

        private void agregarConsumible(string codigo, string cantidad)
        {
            fila = dgvConsumibles.Rows.Count - 1;
            dgvConsumibles.Rows.Add(1);

            string consumibleSQL = "SELECT descripcion FROM THE_FOREIGN_FOUR.Consumibles WHERE cod_consumible = @cod_consumible";
            SqlCommand cmd = new SqlCommand(consumibleSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.Parameters.AddWithValue("cod_consumible", codigo);
            string descripcion = cmd.ExecuteScalar().ToString();
            
            dgvConsumibles.Rows[fila].Cells[0].Value = codigo;
            dgvConsumibles.Rows[fila].Cells[1].Value = cantidad; 
            dgvConsumibles.Rows[fila].Cells[2].Value = descripcion;
        }     

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //---------------------------------------------------------------------------------------------------------------------

        public void setCerrate(){ cerrate = true; }
 
    }
}
