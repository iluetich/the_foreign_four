using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class frmRegistrarConsumible : Form
    {
        frmInicioRegistrarConsumible frmInicioRegistrarConsumiblePadre;
        int fila;

        public frmRegistrarConsumible(){InitializeComponent();}

        public frmRegistrarConsumible(frmInicioRegistrarConsumible newForm)
        {
            InitializeComponent();
            frmInicioRegistrarConsumiblePadre = newForm;
            lblResultCodEstadia.Text = newForm.Controls["groupRegEst"].Controls["txtCodEstadia"].Text;
            
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            new frmFacturacion(this).Show();
            this.Enabled = false;
        }
        
        public bool validarCampos(){
            if( txtCodProducto.Text != "" & 
                txtCantidad.Text    != "" &
                txtHabitacion.Text  != ""){
                return true;
            }else{
                MessageBox.Show("Complete todos los campos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}
        private void txtHabitacion_KeyPress(object sender, KeyPressEventArgs e){FrbaHotel.Utils.allowNumbers(e);}

        private void btnRegistrarCons_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                agregarConsumible(txtCodProducto.Text, txtCantidad.Text, txtHabitacion.Text);
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
            frmInicioRegistrarConsumiblePadre.Enabled = true;
            frmInicioRegistrarConsumiblePadre.Focus();
        }

        private void groupRegConsu_Enter(object sender, EventArgs e)
        {

        }
 
    }
}
