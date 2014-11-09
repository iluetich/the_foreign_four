using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class RegistrarHotel : Form
    {
        private MenuDinamico menu;
        private DateTime fechaCreacion;
        private DataSet dataSet;
        private string regimenSelecc;
        private string cantEstrellas;

        public RegistrarHotel(MenuDinamico menuPadre)
        {
            this.menu = menuPadre;
            InitializeComponent();
            dgvRegimen.ReadOnly = true;
            this.crearDataSet();
            this.cargarComboBoxRegimen();           
        }

        public void cargarComboBoxRegimen()
        {
            FrbaHotel.Utils.rellenarCombo(comboBoxTipoRegimen, "descripcion", "SELECT * FROM THE_FOREIGN_FOUR.Regimenes");
        }

        public void crearDataSet()
        {
            dataSet = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("regimen",typeof(string));
            dataSet.Tables.Add(table);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.menu.Show();
            this.Close();
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void textBoxPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void comboBoxCantEstrellas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cantEstrellas = comboBoxCantEstrellas.Text;
        }

        private void comboBoxTipoRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            regimenSelecc = comboBoxCantEstrellas.Text;
        }

        private void dateFechaCreacion_ValueChanged(object sender, EventArgs e)
        {
            fechaCreacion = dateFechaCreacion.Value;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxCiudad);
            FrbaHotel.Utils.limpiarControl(textBoxPais);
            FrbaHotel.Utils.limpiarControl(textBoxMail);
            FrbaHotel.Utils.limpiarControl(textBoxNombreHotel);
            FrbaHotel.Utils.limpiarControl(textBoxTelefono);
            FrbaHotel.Utils.limpiarControl(textBoxCalle);
            FrbaHotel.Utils.limpiarControl(textBoxNroCalle);
            FrbaHotel.Utils.limpiarControl(textBoxRecEstrellas);

            //limpiar la lista
            DataTable table = dataSet.Tables[0];
            table.Clear();

            dgvRegimen.DataSource = dataSet.Tables[0];
        }

        private void botonAgregarRegimen_Click(object sender, EventArgs e)
        {
            this.agregaAlDataSet(comboBoxTipoRegimen.Text);
        }

        public void agregaAlDataSet(string regimen)
        {
            DataTable table = dataSet.Tables[0];

            //si la tabla no tiene esa combinacion estonces agregalo           
            DataRow[] matriz = table.Select("regimen='" + regimen + "'");
            int cantidad = matriz.GetLength(0);

            if (cantidad == 0)
            {
                DataRow row = table.NewRow();
                row["regimen"] = regimen;

                table.Rows.Add(row);
            }

            dgvRegimen.DataSource = dataSet.Tables[0];
        }

        private void botonQuitar_Click(object sender, EventArgs e)
        {
            int indexAEliminar = dgvRegimen.CurrentRow.Index;
            dataSet.Tables[0].Rows[indexAEliminar].Delete();
            dgvRegimen.DataSource = dataSet.Tables[0];
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            Boolean estaOk = true;
            //corroborar que los textbox este llenos
            estaOk = corroborarCamposLlenos(estaOk);

            //que almenos tenga un regimen de estadia asociado
            estaOk = FrbaHotel.Utils.almenosUno(estaOk, dgvRegimen, "ERROR se debe ingresar al menos un regimen");

            //persistir
            if (estaOk)
            {
                //primero persistir el hotel 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
                cmd.CommandType = CommandType.Text;

                this.dateFechaCreacion_ValueChanged(sender, e);
                cmd.Parameters.AddWithValue("@fechaCreacion", fechaCreacion);

                string consulta = "INSERT INTO THE_FOREIGN_FOUR.Hoteles (nombre,mail,telefono,nro_calle,nom_calle,cant_estrellas,ciudad,pais,fecha_creacion,recarga_estrellas) "+
                              " VALUES ('"+ textBoxNombreHotel.Text +"','"+ textBoxMail.Text +"','"+ textBoxTelefono.Text +"',"+ int.Parse(textBoxNroCalle.Text) +",'"+ textBoxCalle.Text +"',"+ int.Parse(cantEstrellas) +",'"+ textBoxCiudad.Text +"','"+ textBoxPais.Text +"',@fechaCreacion,"+ int.Parse(textBoxRecEstrellas.Text) +")";
               
                cmd.CommandText = consulta;

                cmd.ExecuteNonQuery();

                //persistir sus regimenes
                this.persistirRegimenes();

                menu.Show();
                this.Close();
            }
        }

        public void persistirRegimenes()
        {
            //obtener el codigo del usuario generado
            int cod_hotel = FrbaHotel.Utils.obtenerCod("SELECT SUM(cod_hotel) FROM THE_FOREIGN_FOUR.Hoteles WHERE nombre='" + textBoxNombreHotel.Text + "'");

            //si es una ventana de modificacion
            /*if (constructorMod)
            {
                //ELMINAS TODOS LOS roles por hotel que tenga
                string comandoSql = "DELETE FROM THE_FOREIGN_FOUR.UsuariosPorHotel WHERE cod_usuario=" + cod_usuario;
                FrbaHotel.Utils.ejecutarConsulta(comandoSql);
            }*/

            //inserta los regimenes por hotel 
            DataTable table = dataSet.Tables[0];
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                DataRow fila = table.Rows[i];

                //obtener el codigo del regimen por el cual se inserta
                int cod_regimen = FrbaHotel.Utils.obtenerCod("SELECT cod_regimen FROM THE_FOREIGN_FOUR.Regimenes WHERE descripcion='" + fila.ItemArray[0].ToString() + "'");

                //inserta en la tabla
                string consulta2 = "INSERT INTO THE_FOREIGN_FOUR.RegimenPorHotel (cod_hotel,cod_regimen)" +
                    " VALUES (" + cod_hotel + "," + cod_regimen + ")";
                FrbaHotel.Utils.ejecutarConsulta(consulta2);
            }
        }


        public Boolean corroborarCamposLlenos(Boolean ok)
        {
            Boolean completoNombre = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombreHotel,"Nombre de Hotel");
            if (!completoNombre) { ok = false;}
            Boolean mailCompleto = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMail,"Mail");
            if (!mailCompleto) { ok = false;}
            Boolean recEstrellaCompleto = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxRecEstrellas, "Recargo Estrellas");
            if (!recEstrellaCompleto) { ok = false;}

            return ok;
        }

        private void textBoxNroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxRecEstrellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }



    }
}
