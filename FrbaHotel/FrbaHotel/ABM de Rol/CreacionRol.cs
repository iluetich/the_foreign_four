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

namespace FrbaHotel.ABM_de_Rol
{
    public partial class CreacionRol : Form
    {
        private MenuDinamico menu;
        private DataSet dataSet;
        private string estado;
        private string funcionalidadElegida;
        private Boolean constructorMod;
        private ModificarYBorrarRol padre;
        private int cod_rolSeleccionado;

        public CreacionRol(MenuDinamico menuPadre)
        {
            constructorMod = false;
            this.menu = menuPadre;
            InitializeComponent();
            dgvFuncionalidades.ReadOnly = true;
            comboBoxEstado.SelectedIndex = 0;
            //cargar en el combo box todas las funcionalidades que hay
            FrbaHotel.Utils.rellenarCombo(comboBoxFuncionalidad, "THE_FOREIGN_FOUR.Funcionalidades", "nombre", "SELECT * FROM THE_FOREIGN_FOUR.Funcionalidades");

            //para la pantalla de creacion no se muestra ya que se asume que se va a cargar habilitado
            estadoRol.Visible = false;
            comboBoxEstado.Visible = false;

            //creo el data set
            this.crearDataSetFuncionalidades();
            this.refrezcarPantalla();
        }

        public CreacionRol(ModificarYBorrarRol frmPadre, DataGridViewRow filaSeleccionada)
        {
            padre = frmPadre;
            constructorMod = true;
            InitializeComponent();
            textBoxNombre.ReadOnly = true;
            dgvFuncionalidades.ReadOnly = true;
            FrbaHotel.Utils.rellenarCombo(comboBoxFuncionalidad, "THE_FOREIGN_FOUR.Funcionalidades", "nombre", "SELECT * FROM THE_FOREIGN_FOUR.Funcionalidades");
            this.crearDataSetFuncionalidades();

            //cargar datos del rol seleccionado
            this.cargarDatos(filaSeleccionada);

            this.refrezcarPantalla();
        }

        public void cargarDatos(DataGridViewRow fila)
        {
            cod_rolSeleccionado = int.Parse(fila.Cells["cod_rol"].Value.ToString());
            textBoxNombre.Text = fila.Cells["nombre"].Value.ToString();
            string estado = fila.Cells["estado"].Value.ToString();
            if (estado == "H")
            {
                comboBoxEstado.SelectedIndex = 0;
            }
            else
            {
                comboBoxEstado.SelectedIndex = 1;
            }

            this.cargarTabla(fila);
        }

        public void cargarTabla(DataGridViewRow fila)
        {
            //1) obetener todas las funciones que tiene el rol
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM THE_FOREIGN_FOUR.view_funcionalidades_rol WHERE Rol='" + fila.Cells["nombre"].Value.ToString() +"'";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();

            //2) cargar el reader en la tabla ya creada
            DataTable table = dataSet.Tables[0];

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string funcionalidad = reader.GetString(1);

                    DataRow row = table.NewRow();
                    row["funcionalidad"] = funcionalidad;

                    table.Rows.Add(row);
                }
            }
            reader.Close();
            reader.Dispose();

            this.refrezcarPantalla();
        }

        public void refrezcarPantalla()
        {
            dgvFuncionalidades.DataSource = dataSet.Tables[0];
        }

        public void crearDataSetFuncionalidades()
        {
            dataSet = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("funcionalidad", typeof(string));
            dataSet.Tables.Add(table);
        }

        private void Cancelar_Click(object sender, EventArgs e)
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

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxNombre);

            //limpio la tabla
            DataTable table = dataSet.Tables[0];
            table.Clear();

            this.refrezcarPantalla();
        }

        private void BotonAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            this.comboBoxFuncionalidad_SelectedIndexChanged(sender, e);
            this.agregaAlDataSet(funcionalidadElegida);
        }

        public void agregaAlDataSet(string funcionalidad)
        {
            DataTable table = dataSet.Tables[0];

            //si la tabla no tiene esa combinacion estonces agregalo           
            DataRow[] matriz = table.Select("funcionalidad='" + funcionalidadElegida +"'");
            int cantidad = matriz.GetLength(0);

            if (cantidad == 0)
            {
                DataRow row = table.NewRow();
                row["funcionalidad"] = funcionalidadElegida;

                table.Rows.Add(row);
            }
            
            this.refrezcarPantalla();
        }

        private void botonQuitar_Click(object sender, EventArgs e)
        {
            //busco
            int indexAEliminar = dgvFuncionalidades.CurrentRow.Index;
            //elimino
            dataSet.Tables[0].Rows[indexAEliminar].Delete();
            //reseteo
            this.refrezcarPantalla();
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = comboBoxEstado.Text;
        }

        private void comboBoxFuncionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            funcionalidadElegida = comboBoxFuncionalidad.Text;
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            Boolean puedeGuardar = true;
            //fijarse si estan completo todos los campos
            puedeGuardar = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombre, "Nombre");

            //tenga al menos un rol
            if (puedeGuardar)
            {
                puedeGuardar = FrbaHotel.Utils.almenosUno(puedeGuardar, dgvFuncionalidades, "Debe tener cargada por lo menos una funcionalidad");
            }
            //verificar que el nombre se unico en sistema siempre que no se este modificando un Rol
            if (!constructorMod)
            {
                if (puedeGuardar)
                {
                    string consulta = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Roles WHERE nombre='" + textBoxNombre.Text + "'";
                    int esUnico = FrbaHotel.Utils.ejecutarConsultaResulInt(consulta);
                    //si encontro uno entonces no es unico y no puede guardar
                    if (esUnico >= 1)
                    {
                        MessageBox.Show("ERROR el nombre del rol ingresado ya existe, ingrese otro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        puedeGuardar = false;
                    }
                }
            }

            if (puedeGuardar)
            {
                if (constructorMod)
                {
                    //hacer el update
                    string comandoUpdateSql = "UPDATE THE_FOREIGN_FOUR.Roles SET nombre='"+ textBoxNombre.Text +"',estado='"+ comboBoxEstado.Text +"' WHERE cod_rol=" + cod_rolSeleccionado;
                    FrbaHotel.Utils.ejecutarConsulta(comandoUpdateSql);

                    //persistir funcionalidades editadas
                    this.insertarFuncionalidadesPorRol();

                    padre.cargarGrid();
                    padre.Show();
                }
                else
                {  
                    //persistir rol
                    string comandoSql = "INSERT INTO THE_FOREIGN_FOUR.Roles (nombre,estado) VALUES ('" + textBoxNombre.Text + "','" + estado + "')";
                    FrbaHotel.Utils.ejecutarConsulta(comandoSql);

                    //persistir funcionalidades del rol
                    this.insertarFuncionalidadesPorRol();

                    menu.Show();
                }
                this.Close();
            }
        }

        public void insertarFuncionalidadesPorRol()
        {
            //obtener el codigo de Rol generado
            int cod_rol = FrbaHotel.Utils.obtenerCod("SELECT SUM(cod_rol) FROM THE_FOREIGN_FOUR.Roles WHERE nombre='" + textBoxNombre.Text + "'");

            //si es una ventana de modificacion
            if (constructorMod)
            {
                //ELMINAS TODOS LAS funcionalidades que tengas por rol
                string comandoSql = "DELETE FROM THE_FOREIGN_FOUR.FuncionalidadPorRol WHERE cod_rol=" + cod_rolSeleccionado;
                FrbaHotel.Utils.ejecutarConsulta(comandoSql);
            }

            //inserta los funcionalidades por rol 
            DataTable table = dataSet.Tables[0];
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                DataRow fila = table.Rows[i];

                //obtener el codigo de la funcionalidad por el cual se inserta
                int cod_funcionalidad = FrbaHotel.Utils.obtenerCod("SELECT cod_funcion FROM THE_FOREIGN_FOUR.Funcionalidades WHERE nombre='" + fila.ItemArray[0].ToString() + "'");

                //inserta en la tabla
                string consulta2 = "INSERT INTO THE_FOREIGN_FOUR.FuncionalidadPorRol (cod_funcion,cod_rol)  VALUES ("+ cod_funcionalidad +","+ cod_rol +")";
                FrbaHotel.Utils.ejecutarConsulta(consulta2);
            }
        }
    }
}

