using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.Generar_Modificar_Reserva;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmRegistrarHuespedesRestantes : Form
    {
        frmInicioEstadia frmRegistrarEstadiaPadre;
        string codigoCliente;

        //----------------------------------------------------------------------------------------------------
        //----------------------CONSTRUCTORES-----------------------------------------------------------------       
        public frmRegistrarHuespedesRestantes(frmInicioEstadia newFrm)
        {
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;
        }
        //----------------------FIN CONSTRUCTORES--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------
        //----------------------EVENTOS DEL FORM---------------------------------------------------------------       
        private void frmRegistrarHuespedes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarEstadiaPadre.Enabled = true;
            frmRegistrarEstadiaPadre.Focus();
        }
        //----------------------FIN EVENTOS DEL FORM----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        //----------------------BOTONES-----------------------------------------------------------------------  
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {            
            new RegistrarCliente(this).Show();
            this.Enabled = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            new frmBuscarCliente(this).Show();            
            this.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validaClientes()){
                MessageBox.Show("Felicidades ha hecho checkIN", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmRegistrarEstadiaPadre.Close();
            }
        }
        //----------------------FIN BOTONES--------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------


        //----------------------OTROS---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------        
        //muestro los datos del cliente que se acaba de registrar o buscar
        public void cargarParametrosClientes(SqlCommand cmd)
        {
            string nombre = cmd.Parameters["@nombre"].Value.ToString();
            string apellido = cmd.Parameters["@apellido"].Value.ToString();
            string tipoDocmento = cmd.Parameters["@tipo_doc"].Value.ToString();
            string nroDocumento = cmd.Parameters["@nro_doc"].Value.ToString();
            dgvDatosHuespedes.Rows.Add(new[] { nroDocumento, nroDocumento, apellido, nombre });
        }

        //valido que se haya ingresa al menos un cliente
        private bool validaClientes()
        {
            if (dgvDatosHuespedes.Rows.Count <= 0){
                DialogResult boton = MessageBox.Show("No registro ningun huesped ¿Quiere seguir de todas maneras?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (boton == DialogResult.OK){
                    return true;
                }else{
                    return false;
                }   
            }
            return true;
        }

        public void obtenerDatos()
        {
            
        }
        //----------------------------------------------------------------------------------------------------------------
        //----------------------FIN OTROS---------------------------------------------------------------------------------


        //----SETTERS------------------------------------------------------------------
        public void setCodigoCliente(int codigo) { codigoCliente = codigo.ToString(); }
        //-----------------------------------------------------------------------------

    }
}
