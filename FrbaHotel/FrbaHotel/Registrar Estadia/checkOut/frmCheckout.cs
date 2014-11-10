using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Consumible;
using System.Data.SqlClient;


namespace FrbaHotel.Registrar_Estadia.checkOut
{
    public partial class frmCheckout : Form
    {
        frmInicioEstadia frmInicioEstadiaPadre;
        private string codEstadia;
        private string user;

        public frmCheckout(){InitializeComponent();}
        
        public frmCheckout(frmInicioEstadia newForm,string codEstadiaParametro,string userParametro) {
            codEstadia = codEstadiaParametro;
            user = userParametro;
            InitializeComponent();
            frmInicioEstadiaPadre = newForm;
        
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //ejecutar el procedure que realiza el checkout
            SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_realizar_checkout", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod_estadia",int.Parse(codEstadia));
            cmd.Parameters.AddWithValue("@username", user);

            cmd.ExecuteNonQuery();

            //crear Factura
            string consulta = "DECLARE @output numeric(18,0) EXEC THE_FOREIGN_FOUR.proc_crear_factura "+ codEstadia +", @output OUTPUT SELECT @output";
            SqlCommand cmd2 = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd2.CommandType = CommandType.Text;

            object nroFactura = cmd2.ExecuteScalar();

            MessageBox.Show("Se procedera a registrar los consumibles adicionales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new frmRegistrarConsumible(this, frmInicioEstadiaPadre,long.Parse(nroFactura.ToString())).Show();
        }

        private void frmCheckout_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmInicioEstadiaPadre.Enabled = true;
            frmInicioEstadiaPadre.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasDias_Click(object sender, EventArgs e)
        {
            //TE DERIBA A HACER UNA NUEVA RESERVA
        }
    }
}
