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
using System.Security.Cryptography;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class CreacionDeUsuario : Form
    {
        private MenuDinamico menu;
        private ModificarYBorrarUsuario frmPadre;
        private string estado;
        private string tipoDoc;
        private DataSet dataSet;
        private DateTime fechaDeNac;
        private Boolean constructorMod;
        private string passwordAnterior;

        public CreacionDeUsuario(MenuDinamico menuPadre)
        {
            this.constructorMod = false;
            this.crearDataSet();
            this.menu = menuPadre;
            InitializeComponent();
            dgvRolesHoteles.ReadOnly = true;
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
            comboBoxEstado.SelectedIndex = 0;
        }

        public CreacionDeUsuario(ModificarYBorrarUsuario padre,DataGridViewRow fila)
        {
            this.constructorMod = true;
            this.crearDataSet();
            this.frmPadre = padre;
            InitializeComponent();
            labelCrearUsuario.Text = "Modificar Usuario";
            textBoxUsername.ReadOnly = true;
            dgvRolesHoteles.ReadOnly = true;
            this.setearDatos(fila);
        }

        public void setearDatos(DataGridViewRow fila)
        {
            textBoxUsername.Text = fila.Cells["user_name"].Value.ToString();
            passwordAnterior = fila.Cells["password"].Value.ToString();
            textBoxPassword1.Text = fila.Cells["password"].Value.ToString();
            textBoxPassword2.Text = fila.Cells["password"].Value.ToString();
            string estadoComboBox = fila.Cells["estado"].Value.ToString();
            if (estadoComboBox == "H")
            {
                comboBoxEstado.SelectedIndex = 0;
            }
            else
            {
                comboBoxEstado.SelectedIndex = 1;
            }
            textBoxNombre.Text = fila.Cells["nombre"].Value.ToString();
            textBoxApellido.Text = fila.Cells["apellido"].Value.ToString();
            string itemDelComboBox = fila.Cells["tipo_doc"].Value.ToString();
            if (itemDelComboBox == "DNI")
            {
                comboBoxTipoDoc.SelectedIndex = 1;
            }
            else
            {
                comboBoxTipoDoc.SelectedIndex = 0;
            }
            textBoxNumeroDeDoc.Text = fila.Cells["nro_doc"].Value.ToString();
            textBoxMail.Text = fila.Cells["mail"].Value.ToString();
            textBoxTelefono.Text = fila.Cells["telefono"].Value.ToString();
            textBoxDireccion.Text = fila.Cells["direccion"].Value.ToString();
            dateTimePickFechaNac.Text = fila.Cells["fecha_nac"].Value.ToString();

            //cargar la tabla con sus roles por hoteles
            //1) obetener todos los roles que tiene por hotel

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM THE_FOREIGN_FOUR.view_roles_hoteles_usuarios WHERE cod_usuario=" + fila.Cells["cod_usuario"].Value.ToString();
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();

            //2) cargar el reader en la tabla ya creada
            DataTable table = dataSet.Tables[0];

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    int hotel = int.Parse(reader.GetDecimal(2).ToString());
                    string rol = reader.GetString(3);

                    DataRow row = table.NewRow();
                    row["rol"] = rol;
                    row["hotel"] = hotel.ToString();

                    table.Rows.Add(row);                
                }
            }
            reader.Close();
            reader.Dispose();

            //3) mostralos en la tabla
            dgvRolesHoteles.DataSource = dataSet.Tables[0];
        }

        public void crearDataSet()
        {
            dataSet = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("rol",typeof(string));
            table.Columns.Add("hotel",typeof(string));
            dataSet.Tables.Add(table);
        }

        public void agregaAlDataSet(string rol, string hotel)
        {
            DataTable table = dataSet.Tables[0];

            //si la tabla no tiene esa combinacion estonces agregalo           
            DataRow[] matriz = table.Select("rol='"+ rol +"' AND hotel="+ hotel);
            int cantidad = matriz.GetLength(0);

            if(cantidad == 0)
            {
                DataRow row = table.NewRow();
                row["rol"] = rol;
                row["hotel"] = hotel;

                table.Rows.Add(row);
            }

            dgvRolesHoteles.DataSource = dataSet.Tables[0];
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            if (constructorMod)
            {
                frmPadre.Show();
            }
            else
            {
                menu.Show();
            }
            this.Close();
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = comboBoxEstado.Text;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxUsername);
            FrbaHotel.Utils.limpiarControl(textBoxPassword1);
            FrbaHotel.Utils.limpiarControl(textBoxPassword2);
            FrbaHotel.Utils.limpiarControl(textBoxNombre);
            FrbaHotel.Utils.limpiarControl(textBoxApellido);
            FrbaHotel.Utils.limpiarControl(textBoxNumeroDeDoc);
            FrbaHotel.Utils.limpiarControl(textBoxMail);
            FrbaHotel.Utils.limpiarControl(textBoxTelefono);
            FrbaHotel.Utils.limpiarControl(textBoxDireccion);

            //resetear la tabla
            DataTable table = dataSet.Tables[0];
            table.Clear();

            dgvRolesHoteles.DataSource = dataSet.Tables[0];
        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoDoc = comboBoxTipoDoc.Text;
        }

        private void botonAgregarRol_Click(object sender, EventArgs e)
        {
            AgregarRol frmAgregarRol = new AgregarRol(this);
            frmAgregarRol.ShowDialog(this);
        }

        private void botonQuitarRol_Click(object sender, EventArgs e)
        {
            int indexAEliminar = dgvRolesHoteles.CurrentRow.Index;
            dataSet.Tables[0].Rows[indexAEliminar].Delete();
            dgvRolesHoteles.DataSource = dataSet.Tables[0];
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Boolean textosCompletos = true;
            Boolean passwordIguales = true;
            Boolean userUnico = true;
            Boolean almenosUnRol = true;

            //corroborar que los texbox esten completos
            textosCompletos = this.corroborarTextosCompletos(textosCompletos);
            //corroborar que los password sean iguales
            passwordIguales = this.passwordIguales(passwordIguales);
            //corroborar que el username sea unico (si es la pantalla de modificar entonces no se controla ya que no se puede cambiar el UserName)
            if (!constructorMod)
            {
                userUnico = this.userNameUnico(userUnico);
            }
            //corroborar que tenga almenos un rol asignado
            almenosUnRol = FrbaHotel.Utils.almenosUno(almenosUnRol,dgvRolesHoteles,"El usuario debe tener almenos un Rol asignado");
            //PERSISTIR O MODIFICAR
            if (textosCompletos && passwordIguales && userUnico && almenosUnRol)
            {
                if (constructorMod)
                {
                    this.actualizarUsuario();
                    frmPadre.Show();
                }
                else
                {
                    this.guardarUsuario();
                    menu.Show();
                }
                this.Close();
            }
        }

        public void actualizarUsuario()
        {
            //UPDATE usuario
            int nroDoc = int.Parse(textBoxNumeroDeDoc.Text);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaDeNac);

            string contraseña;
            if (passwordAnterior == textBoxPassword1.Text)
            {
                contraseña = passwordAnterior;
            }
            else
            {
                contraseña = FrbaHotel.Utils.encriptarContraseña(textBoxPassword1.Text);
            }
            cmd.Parameters.AddWithValue("@password", contraseña);
            cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", textBoxApellido.Text);
            cmd.Parameters.AddWithValue("@tipo_doc", tipoDoc);
            cmd.Parameters.AddWithValue("@nro_doc", textBoxNumeroDeDoc.Text);
            cmd.Parameters.AddWithValue("@mail", textBoxMail.Text);
            cmd.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);
            cmd.Parameters.AddWithValue("@direccion", textBoxDireccion.Text);
            cmd.Parameters.AddWithValue("@estado", estado);

            cmd.CommandText = "UPDATE THE_FOREIGN_FOUR.Usuarios SET password=@password,nombre=@nombre,apellido=@apellido,tipo_doc=@tipo_doc,nro_doc=@nro_doc,mail=@mail,telefono=@telefono," +
                                "direccion=@direccion,fecha_nac=@fechaNacimiento,estado=@estado WHERE user_name='" + textBoxUsername.Text +"'";

            cmd.ExecuteNonQuery();

            //CARGAR todos los roles por hotel que tenga
            this.insertarRolesPorHotel();
        }

        public void guardarUsuario()
        {
            //INSERTA usuario en la tabla usuarios
            int nroDoc = int.Parse(textBoxNumeroDeDoc.Text);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaDeNac);

            string contraseña = FrbaHotel.Utils.encriptarContraseña(textBoxPassword1.Text);
            cmd.CommandText = "INSERT INTO THE_FOREIGN_FOUR.Usuarios (user_name,password,nombre,apellido,tipo_doc,nro_doc,mail,telefono,direccion,fecha_nac,estado)" +
                        " VALUES ('" + textBoxUsername.Text + "','" + contraseña +"','" + textBoxNombre.Text + "','" + textBoxApellido.Text + "','" + tipoDoc + "'," + nroDoc + ",'" + textBoxMail.Text + "','" + textBoxTelefono.Text + "','" + textBoxDireccion.Text + "',@fechaNacimiento,'" + estado + "')";

            cmd.ExecuteNonQuery();
            
            //inserta los roles por hotel que tiene el usuario
            this.insertarRolesPorHotel();
        }

        public void insertarRolesPorHotel()
        {
            //obtener el codigo del usuario generado
            int cod_usuario = FrbaHotel.Utils.obtenerCod("SELECT SUM(cod_usuario) FROM THE_FOREIGN_FOUR.Usuarios WHERE user_name='" + textBoxUsername.Text + "'");

            //si es una ventana de modificacion
            if (constructorMod)
            {
                //ELMINAS TODOS LOS roles por hotel que tenga
                string comandoSql = "DELETE FROM THE_FOREIGN_FOUR.UsuariosPorHotel WHERE cod_usuario=" + cod_usuario;
                FrbaHotel.Utils.ejecutarConsulta(comandoSql);
            }

            //inserta los roles por hotel 
            DataTable table = dataSet.Tables[0];
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                DataRow fila = table.Rows[i];

                //obtener el codigo del rol por el cual se inserta
                int cod_rol = FrbaHotel.Utils.obtenerCod("SELECT cod_rol FROM THE_FOREIGN_FOUR.Roles WHERE nombre='" + fila.ItemArray[0].ToString() + "'");

                //inserta en la tabla
                string consulta2 = "INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel (cod_usuario,cod_hotel,cod_rol)" +
                    " VALUES (" + cod_usuario + "," + int.Parse(fila.ItemArray[1].ToString()) + "," + cod_rol + ")";
                FrbaHotel.Utils.ejecutarConsulta(consulta2);
            }
        }

        public Boolean userNameUnico(Boolean ok)
        {
            int resultado = FrbaHotel.Utils.ejecutarConsultaResulInt("SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Usuarios WHERE user_name='"+ textBoxUsername.Text +"'");
            //si el password no es unico
            if (resultado == 1)
            {
                MessageBox.Show("El UserName ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
                ok = false;
            }
            
            return ok;
        }

        public Boolean passwordIguales(Boolean ok)
        {
            if (textBoxPassword1.Text != textBoxPassword2.Text)
            {
                ok = false;
                MessageBox.Show("Los campos Password y Repetir Password Difieren", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
            }
            return ok;
        }

        public Boolean corroborarTextosCompletos(Boolean ok)
        {
            Boolean okUsername = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxUsername,"UserName");
            if (!okUsername) {ok = false;}
            Boolean okPassword = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxPassword1, "Password");
            if (!okPassword) {ok = false;}
            Boolean okRPassword = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxPassword2, "repertir Password");
            if (!okRPassword) {ok = false;}
            Boolean okNombre = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombre, "Nombre");
            if (!okNombre) {ok = false;}
            Boolean okApellido = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxApellido, "Apellido");
            if (!okApellido) {ok = false;}            
            Boolean okNroDoc = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNumeroDeDoc, "Numero de Documento");
            if (!okNroDoc) {ok = false;}            
            Boolean okMail = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMail, "Mail");
            if (!okMail) {ok = false;}            
            Boolean okTelefono = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxTelefono, "Telefono");
            if (!okTelefono) { ok = false;}            
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxDireccion, "Direccion");
            return ok;
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxNumeroDeDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void fechaDeNac_ValueChanged(object sender, EventArgs e)
        {
            fechaDeNac = dateTimePickFechaNac.Value;
        }
    }
}
