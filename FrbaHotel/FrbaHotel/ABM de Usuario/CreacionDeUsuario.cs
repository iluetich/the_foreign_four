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

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class CreacionDeUsuario : Form
    {
        private MenuDinamico menu;
        private string estado;
        private string tipoDoc;
        private DataSet dataSet;
        private DateTime fechaDeNac;

        public CreacionDeUsuario(MenuDinamico menuPadre)
        {
            this.crearDataSet();
            this.menu = menuPadre;
            InitializeComponent();
            dgvRolesHoteles.ReadOnly = true;
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
            comboBoxEstado.SelectedIndex = 0;
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
            menu.Show();
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
            Boolean estaOk = true;
            //corroborar que los texbox esten completos
            estaOk = this.corroborarTextosCompletos(estaOk);
            //corroborar que los password sean iguales
            estaOk = this.passwordIguales(estaOk);
            //corroborar que el username sea unico
            estaOk = this.userNameUnico(estaOk);
            //corroborar que tenga almenos un rol asignado
            estaOk = this.almenosUnRol(estaOk);
            //PERSISTIR
            if (estaOk)
            {
                this.guardarUsuario();
                menu.Show();
                this.Close();
            }
        }

        public void guardarUsuario()
        {
            //INSERTA usuario en la tabla usuarios
            int nroDoc = int.Parse(textBoxNumeroDeDoc.Text);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaDeNac);

            cmd.CommandText = "INSERT INTO THE_FOREIGN_FOUR.Usuarios (user_name,password,nombre,apellido,tipo_doc,nro_doc,mail,telefono,direccion,fecha_nac,estado)" + 
                        " VALUES ('"+ textBoxUsername.Text +"','"+ textBoxPassword1.Text +"','"+ textBoxNombre.Text +"','"+ textBoxApellido.Text +"','"+ tipoDoc +"',"+ nroDoc +",'"+ textBoxMail.Text +"','"+ textBoxTelefono.Text +"','"+ textBoxDireccion.Text +"',@fechaNacimiento,'"+ estado +"')";

            cmd.ExecuteNonQuery();
            
            //obtener el codigo del usuario generado
            int cod_usuario = int.Parse(this.obtenerCod("SELECT SUM(cod_usuario) FROM THE_FOREIGN_FOUR.Usuarios WHERE user_name='" + textBoxUsername.Text + "'"));

            //inserta los roles por hotel que tiene el usuario
            DataTable table = dataSet.Tables[0];
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                DataRow fila = table.Rows[i];

                //obtener el codigo del rol por el cual se inserta
                int cod_rol = int.Parse(this.obtenerCod("SELECT cod_rol FROM THE_FOREIGN_FOUR.Roles WHERE nombre='" + fila.ItemArray[0].ToString() + "'"));

                //inserta en la tabla
                string consulta2 = "INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel (cod_usuario,cod_hotel,cod_rol)" +
                    " VALUES ("+ cod_usuario +","+ int.Parse(fila.ItemArray[1].ToString()) +","+ cod_rol +")";
                FrbaHotel.Utils.ejecutarConsulta(consulta2);
            }
        }

        public string obtenerCod(string consultaSql)
        {
            string codUsuario;

            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet);
            DataRow fila = dataSet.Tables[0].Rows[0];
            codUsuario = fila.ItemArray[0].ToString();

            return codUsuario;
        }

        public Boolean almenosUnRol(Boolean ok)
        {
            int filas = dgvRolesHoteles.RowCount;
            if (filas == 0)
            {
                MessageBox.Show("El usuario debe tener almenos un Rol asignado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
                ok = false;
            }
            return ok;
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
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxUsername,"UserName");
            if (!ok) {return ok;}
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxPassword1, "Password");
            if (!ok) {return ok;}
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxPassword2, "repertir Password");
            if (!ok) {return ok;}
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombre, "Nombre");
            if (!ok) {return ok;}
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxApellido, "Apellido");
            if (!ok) {return ok;}            
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNumeroDeDoc, "Numero de Documento");
            if (!ok) {return ok;}            
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMail, "Mail");
            if (!ok) {return ok;}            
            ok = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxTelefono, "Telefono");
            if (!ok) { return ok;}            
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
