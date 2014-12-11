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
        private int cod_hotel;

        public InHabilitarHotel(ModificarOEliminarHotel frmPadre, DataGridViewRow fila)
        {
            cod_hotel = int.Parse(fila.Cells["cod_hotel"].Value.ToString());
            this.padre = frmPadre;
            InitializeComponent();
            FrbaHotel.Utils.actualizarDTP(dateDesde, dateHasta);
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            Boolean camposLlenos = true;
            //primero corrobora que las fechas sean correctas y se halla completado el texto motivo
            Boolean MotivoCompleto = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMotivo, "Motivo");
            if (!MotivoCompleto) { return; }
            Boolean fechasCorrectas = FrbaHotel.Utils.validarFechas(dateDesde,dateHasta);
            if (!fechasCorrectas) { return; }

            //segundo validacion que no pueda inhabilitar el hotel cuando halla reservas en esos dias
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            //convertir las fechas a un formato valido para que me lo hacepte en a funcion
            string fechaDesde = dateDesde.Value.ToString("yyyy-dd-MM");
            string fechaHasta = dateHasta.Value.ToString("yyyy-dd-MM");

            cmd.Parameters.AddWithValue("@codHotel", cod_hotel);
            cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            cmd.CommandText = "SELECT THE_FOREIGN_FOUR.func_hotel_inhabilitable (@codHotel,@fechaDesde,@fechaHasta)";
            
            cmd.CommandType = CommandType.Text;
            
            int puedeInhabilitar = (int)cmd.ExecuteScalar();

            switch(puedeInhabilitar) {
                case -1:
                    MessageBox.Show("El hotel posee reservas en el período especificado. Por favor, modifique el período de inhabilitación y vuelva a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 0:
                    MessageBox.Show("No puede inhabilitarse un hotel en una fecha anterior a su fecha de creación. Por favor, modifique el período de inhabilitación y vuelva a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    break;
                case 1:
                    this.ejecutarProcInhabilitarHotel(fechaDesde, fechaHasta);
                    MessageBox.Show("Se ha inhabilitado el hotel satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //resetear la grid
                    padre.cargarHoteles();
                    padre.Show();
                    this.Close();
                    break;
            };
        }

        public void ejecutarProcInhabilitarHotel(string fechaDesde, string fechaHasta)
        {
            SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_inhabilitar_hotel", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod_hotel", cod_hotel);
            cmd.Parameters.AddWithValue("@motivo", textBoxMotivo.Text);
            cmd.Parameters.AddWithValue("@fecha_inicio", fechaDesde);
            cmd.Parameters.AddWithValue("@fecha_fin", fechaHasta);

            cmd.ExecuteNonQuery();
        }

    }
}
