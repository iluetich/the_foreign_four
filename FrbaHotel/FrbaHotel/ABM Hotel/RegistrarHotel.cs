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
        private ModificarOEliminarHotel padre;
        private Boolean constructorMod;
        private int cod_hotelElegido;

        public RegistrarHotel(MenuDinamico menuPadre)
        {
            constructorMod = false;
            this.menu = menuPadre;
            InitializeComponent();
            dgvRegimen.ReadOnly = true;
            this.crearDataSet();
            this.cargarComboBoxRegimen();           
        }

        public RegistrarHotel(ModificarOEliminarHotel frmPadre,DataGridViewRow filaSelec)
        {
            constructorMod = true;
            padre = frmPadre;
            InitializeComponent();
            dgvRegimen.ReadOnly = true;
            this.crearDataSet();
            this.cargarComboBoxRegimen();
            this.labelTitulo.Text = "Modificar Hotel";
            this.cargarDatos(filaSelec);
        }

        public void cargarDatos(DataGridViewRow fila)
        {
            cod_hotelElegido = int.Parse(fila.Cells["cod_hotel"].Value.ToString());
            textBoxNombreHotel.Text = fila.Cells["nombre"].Value.ToString();
            textBoxRecEstrellas.Text = fila.Cells["recarga_estrellas"].Value.ToString();
            textBoxMail.Text = fila.Cells["mail"].Value.ToString();
            textBoxTelefono.Text = fila.Cells["telefono"].Value.ToString();
            textBoxCalle.Text = fila.Cells["nom_calle"].Value.ToString();
            textBoxNroCalle.Text = fila.Cells["nro_calle"].Value.ToString();
            textBoxCiudad.Text = fila.Cells["ciudad"].Value.ToString();
            textBoxPais.Text = fila.Cells["pais"].Value.ToString();
            dateFechaCreacion.Text = fila.Cells["fecha_creacion"].Value.ToString();

            //cargar el dataSet con los regimenes que tiene ese hotel
            this.cargarDataGridView(fila);

            //cargar el combo box con la cantidad de estrellas que tiene
            this.cargarComboEstrellas(int.Parse(fila.Cells["cant_estrellas"].Value.ToString()));
        }

        public void cargarComboEstrellas(int cantEstrellas)
        {
            if (cantEstrellas == 1) { comboBoxCantEstrellas.SelectedIndex = 0;}
            if (cantEstrellas == 2) { comboBoxCantEstrellas.SelectedIndex = 1;}
            if (cantEstrellas == 3) { comboBoxCantEstrellas.SelectedIndex = 2;}
            if (cantEstrellas == 4) { comboBoxCantEstrellas.SelectedIndex = 3;}
            if (cantEstrellas == 5) { comboBoxCantEstrellas.SelectedIndex = 4;}
        }

        public void cargarDataGridView(DataGridViewRow fila)
        {
            //cargar la tabla con los regimenes que tiene ese rol
            //1) obetener todos los regimenes que tiene ese hotel

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            SqlDataReader reader;

            cmd.CommandText = "SELECT descripcion FROM THE_FOREIGN_FOUR.buscar_regimenes_hotel ("+ int.Parse(fila.Cells["cod_hotel"].Value.ToString()) +")";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();

            //2) cargar el reader en la tabla ya creada
            DataTable table = dataSet.Tables[0];

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string regimen = reader.GetString(0);

                    DataRow row = table.NewRow();
                    row["regimen"] = regimen;

                    table.Rows.Add(row);
                }
            }
            reader.Dispose();

            //3) mostralos en la tabla
            dgvRegimen.DataSource = dataSet.Tables[0];
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
            if (constructorMod)
            {
                this.padre.Show();
            }
            else
            {
                this.menu.Show();
            }
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
                this.comboBoxCantEstrellas_SelectedIndexChanged(sender, e);
                cmd.Parameters.AddWithValue("@fechaCreacion", fechaCreacion);

                string consulta;
                if (constructorMod)
                {
                    consulta = "UPDATE THE_FOREIGN_FOUR.Hoteles SET nombre='" + textBoxNombreHotel.Text + "'" +
                                ", mail='" + textBoxMail.Text + "'" +
                                ", telefono='" + textBoxTelefono.Text + "'" +
                                ", nro_calle="+ int.Parse(textBoxNroCalle.Text) +
                                ", nom_calle='"+ textBoxCalle.Text +"'" +
                                ", cant_estrellas="+ int.Parse(cantEstrellas) +
                                ", ciudad='"+ textBoxCiudad.Text +"'" +
                                ", pais='"+ textBoxPais.Text +"'" +
                                ", fecha_creacion=@fechaCreacion " +
                                ", recarga_estrellas=" + int.Parse(textBoxRecEstrellas.Text) +
                                " WHERE cod_hotel=" + cod_hotelElegido;
                }
                else
                {
                     consulta = "INSERT INTO THE_FOREIGN_FOUR.Hoteles (nombre,mail,telefono,nro_calle,nom_calle,cant_estrellas,ciudad,pais,fecha_creacion,recarga_estrellas) " +
                            " VALUES ('" + textBoxNombreHotel.Text + "','" + textBoxMail.Text + "','" + textBoxTelefono.Text + "'," + int.Parse(textBoxNroCalle.Text) + ",'" + textBoxCalle.Text + "'," + int.Parse(cantEstrellas) + ",'" + textBoxCiudad.Text + "','" + textBoxPais.Text + "',@fechaCreacion," + int.Parse(textBoxRecEstrellas.Text) + ")";
                }
               
                cmd.CommandText = consulta;

                cmd.ExecuteNonQuery();

                //persistir sus regimenes
                this.persistirRegimenes();
                
                if (constructorMod)
                {
                    this.padre.Show();
                    this.padre.cargarHoteles();
                }
                else
                {
                    this.menu.Show();
                }
                this.Close();
            }
        }

        public void persistirRegimenes()
        {
            //obtener el codigo del usuario generado
            int cod_hotel = FrbaHotel.Utils.obtenerCod("SELECT SUM(cod_hotel) FROM THE_FOREIGN_FOUR.Hoteles WHERE nombre='" + textBoxNombreHotel.Text + "'");

            //si es una ventana de modificacion
            if (constructorMod)
            {
                //ELMINAS TODOS LOS regimenes por hotel que tenga
                string comandoSql = "DELETE FROM THE_FOREIGN_FOUR.RegimenPorHotel WHERE cod_hotel=" + cod_hotel;
                FrbaHotel.Utils.ejecutarConsulta(comandoSql);
            }

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
