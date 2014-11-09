using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class InHabilitarHotel : Form
    {
        private ModificarOEliminarHotel padre;
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private int cod_hotel;

        public InHabilitarHotel(ModificarOEliminarHotel frmPadre, DataGridViewRow fila)
        {
            cod_hotel = int.Parse(fila.Cells["cod_hotel"].Value.ToString());
            this.padre = frmPadre;
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            Boolean estaOk = true;
            //primero corrobora que las fechas sean correctas y se halla completado el texto motivo
            Boolean MotivoCompleto = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMotivo, "Motivo");
            if (!MotivoCompleto) { estaOk = false;}
            Boolean fechasCorrectas = FrbaHotel.Utils.validarFechas(dateDesde,dateHasta);
            if (!fechasCorrectas) { estaOk = false; }

            //segundo validacion que no pueda inhabilitar el hotel cuando halla reservas en esos dias
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            dateDesde_ValueChanged(sender, e);
            dateHasta_ValueChanged(sender, e);

            cmd.Parameters.AddWithValue("@codHotel", cod_hotel);
            cmd.Parameters.AddWithValue("@fechaDesde", dateDesde);
            cmd.Parameters.AddWithValue("@fechaHasta", dateHasta);

            cmd.CommandText = "SELECT THE_FOREIGN_FOUR.func_hotel_inhabilitable (@codHotel,@fechaDesde,@fechaHasta)";
            
            cmd.CommandType = CommandType.Text;
            //NO ME TOMA LA FECHA
            int puedeInhabilitar = (int)cmd.ExecuteScalar();
            
            if(puedeInhabilitar > 0)
            {
                estaOk = false;
                MessageBox.Show("EL hotel no se puede Inhabilitar ya que se han hecho reservas para ese periodo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //tercero inhabilitar hotel

            //resetear la grid
            padre.cargarHoteles();
            padre.Show();
            this.Close();
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            fechaDesde = dateDesde.Value;
        }

        private void dateHasta_ValueChanged(object sender, EventArgs e)
        {
            fechaHasta = dateHasta.Value;
        }
    }
}
