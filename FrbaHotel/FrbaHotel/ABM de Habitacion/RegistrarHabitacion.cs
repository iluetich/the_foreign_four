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

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class RegistrarHabitacion : Form
    {
        private MenuDinamico menu;
        private string tipoHabitacion;
        private string hotelDeHabitacion;
        private Boolean constructorMod;
        private ModificarOEliminarHabitacion padre;

        public RegistrarHabitacion(ModificarOEliminarHabitacion frmPadre,DataGridViewRow fila)
        {
            constructorMod = true;
            padre = frmPadre;
            InitializeComponent();
            FrbaHotel.Utils.rellenarCombo(comboBoxTipoHabitacion, "descripcion", "SELECT * FROM THE_FOREIGN_FOUR.TipoHabitaciones");
            FrbaHotel.Utils.rellenarCombo(comboBoxHotel, "cod_hotel", "SELECT * FROM THE_FOREIGN_FOUR.Hoteles");
            textBoxNumHabitacion.ReadOnly = true;
            textBoxPiso.ReadOnly = true;
            comboBoxHotel.Visible = false;
            comboBoxTipoHabitacion.Visible = false;
            textBoxTipoHabitacion.ReadOnly = true;
            textBoxHotelEncuentra.ReadOnly = true;
            this.cargarDatos(fila);
            this.labelTitulo.Text = "Modificar Habitacion";
        }

        public void cargarDatos(DataGridViewRow fila)
        {
            textBoxDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
            textBoxHotelEncuentra.Text = fila.Cells["cod_hotel"].Value.ToString();
            textBoxNumHabitacion.Text = fila.Cells["nro_habitacion"].Value.ToString();
            textBoxPiso.Text = fila.Cells["piso"].Value.ToString();

            //obtener la descripcion del tipo de habitacion 
            string consultaSql = "SELECT descripcion FROM THE_FOREIGN_FOUR.TipoHabitaciones WHERE cod_tipo_hab=" + int.Parse(fila.Cells["cod_tipo_hab"].Value.ToString());
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet);
            DataRow filaResultado = dataSet.Tables[0].Rows[0];
            string descripcionTipoHab = filaResultado.ItemArray[0].ToString();

            textBoxTipoHabitacion.Text = descripcionTipoHab;

            string estadoFila = fila.Cells["estado"].Value.ToString();
            if (estadoFila == "H")
            {
                comboBoxEstado.SelectedIndex = 0;
            }
            else
            {
                comboBoxEstado.SelectedIndex = 1;
            }

            string vista = fila.Cells["ubicacion"].Value.ToString();
            if (vista == "S")
            {
                comboBoxVista.SelectedIndex = 1;
            }
            else
            {
                comboBoxVista.SelectedIndex = 0;
            }
        }

        public RegistrarHabitacion(MenuDinamico menuPadre)
        {
            constructorMod = false;
            this.menu = menuPadre;
            InitializeComponent();
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
            textBoxHotelEncuentra.Visible = false;
            textBoxTipoHabitacion.Visible = false;
            comboBoxEstado.SelectedIndex = 0;
            FrbaHotel.Utils.rellenarCombo(comboBoxTipoHabitacion, "descripcion", "SELECT * FROM THE_FOREIGN_FOUR.TipoHabitaciones");
            comboBoxVista.SelectedIndex = 0;
            FrbaHotel.Utils.rellenarCombo(comboBoxHotel, "cod_hotel", "SELECT * FROM THE_FOREIGN_FOUR.Hoteles");
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            if (constructorMod)
            {
                padre.Show();
            }
            else
            {
                menu.Show();
            }
            this.Close();
        }

        private void textBoxNumHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxDescripcion);
            if (!constructorMod)
            {
                FrbaHotel.Utils.limpiarControl(textBoxPiso);
                FrbaHotel.Utils.limpiarControl(textBoxNumHabitacion);
            }
        }

        private void comboBoxTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoHabitacion = comboBoxTipoHabitacion.Text;
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            Boolean estaOk = true;
            // corroborar campos completos
            estaOk = this.camposCompletos(estaOk);

            // corroborar numero de habitacion unico en el hotel que se crea
            if(!constructorMod)
            {
                string consulta = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Habitaciones WHERE cod_hotel="+ hotelDeHabitacion +" AND nro_habitacion=" + textBoxNumHabitacion.Text;//SEGUIR
                int unicoNroHabEnHotel = FrbaHotel.Utils.ejecutarConsultaResulInt(consulta);
                if (unicoNroHabEnHotel > 0)
                {
                    estaOk = false;
                    MessageBox.Show("ERROR el numero de Habitacion ingresado ya existe para ese hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            // persistir
            if (estaOk)
            {
                if (constructorMod)
                {
                    this.actualizaHabitacion();
                    padre.Show();
                    padre.cargarHabitaciones(true);
                }
                else
                {
                    this.guardadHabitacion(sender, e);
                    menu.Show();
                }
                this.Close();
            }
        }

        public void actualizaHabitacion()
        {
            string vista;
            if (comboBoxVista.Text == "Externa")
            {
                vista = "S";
            }
            else
            {
                vista = "N";
            }

            string comandoSql = "UPDATE THE_FOREIGN_FOUR.Habitaciones SET estado='" + comboBoxEstado.Text + "' ,descripcion='" + textBoxDescripcion.Text + "',ubicacion='" + vista + "' WHERE nro_habitacion=" + int.Parse(textBoxNumHabitacion.Text) + " AND cod_hotel=" + int.Parse(textBoxHotelEncuentra.Text);
            FrbaHotel.Utils.ejecutarConsulta(comandoSql);
        }

        public void guardadHabitacion(object sender ,EventArgs e)
        {
            //obtener codigo del tipo de habitacion ingresado
            this.comboBoxTipoHabitacion_SelectedIndexChanged(sender, e);
            string consuta = "SELECT SUM(cod_tipo_hab) FROM THE_FOREIGN_FOUR.TipoHabitaciones WHERE descripcion='"+ tipoHabitacion +"'";
            int codTipoHabitacion = FrbaHotel.Utils.obtenerCod(consuta);

            //insertar
            string vista;
            if (comboBoxVista.Text == "Externo")
            {
                vista = "S";
            }
            else
            {
                vista = "N";
            }

            string comandoSQL = "INSERT INTO THE_FOREIGN_FOUR.Habitaciones (cod_hotel,cod_tipo_hab,nro_habitacion,piso,ubicacion,descripcion,estado)"+
                                " VALUES ("+ hotelDeHabitacion +","+ codTipoHabitacion +","+ int.Parse(textBoxNumHabitacion.Text) +","+ int.Parse(textBoxPiso.Text) +",'"+ vista +"','"+ textBoxDescripcion.Text +"','"+ comboBoxEstado.Text +"')";
            FrbaHotel.Utils.ejecutarConsulta(comandoSQL);
        }

        public Boolean camposCompletos(Boolean ok)
        {
            Boolean completoNroHabitacio = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNumHabitacion, "Numero de Habitacion");
            if (!completoNroHabitacio) { ok = false; }
            Boolean completoPiso = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxPiso, "Piso");
            if (!completoPiso) { ok = false; }

            return ok;
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotelDeHabitacion = comboBoxHotel.Text;
        }
    }
}
