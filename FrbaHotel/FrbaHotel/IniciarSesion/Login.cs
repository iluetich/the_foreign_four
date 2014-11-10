using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Menues_de_los_Roles;

namespace FrbaHotel.IniciarSecion
{
    public partial class Login : Form
    {
        private InicioDelSistema formPadre;
        private string rol;
        private string user_name;
        private string password;
        private string codHotelElegido;
        private Boolean podesIngresar; //variable que se cambia cuando alguno de los checkeos no da positivo
        private Boolean eligieronHotel;
        private int nroFallos;

        public Login(InicioDelSistema formularioPadre,string rolElegido)
        {
            nroFallos = 0;
            eligieronHotel = false;
            rol = rolElegido;
            formPadre = formularioPadre;
            InitializeComponent();
            string consulta = "SELECT * from THE_FOREIGN_FOUR.Hoteles";
            FrbaHotel.Utils.rellenarComboBox(comboBoxSelecionHotel, "THE_FOREIGN_FOUR.Hoteles", "cod_hotel", consulta);

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formPadre.Show();
            this.Close();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            this.user_name = textBoxUsername.Text;
        }

        private void textBoxpassword_TextChanged(object sender, EventArgs e)
        {
            this.password = textBoxpassword.Text;
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            this.comboBoxSelecionHotel_SelectedIndexChanged(sender, e);
            Boolean estaOk = true;

            //primero corroborar los campos completos
            Boolean camposEstanCompletos = this.camposCompletos(estaOk);
            if (!camposEstanCompletos)
            {
                estaOk = false;
            }
            else
            {
                //segundo corroborar que exista el usuario ingresado 
                Boolean userNameValido = this.corroborarUserNameValido();
                if (!userNameValido) {estaOk = false;}

                //si existe el user name corroborar que el password este correcto y el tenga ese hotel asociado
                if (userNameValido)
                {
                    Boolean passwordCorrecto = this.corroborarPassword();
                    if (!passwordCorrecto)
                    {
                        //no me dejes pasar
                        estaOk = false;
                        //suma la cantidad de veces que ingresaste mal el password
                        this.sumarFallos();
                    }

                    //si el usuario tiene ese hotel para ese rol
                    Boolean hotelEstaAsociado = this.tieneElHotel();
                    if (!hotelEstaAsociado)
                    {
                        estaOk = false;
                    }
                    else
                    {
                        //verifica si el usuario por ese hotel tiene el rol ingresado
                        Boolean usuarioTieneHotelPorRol = this.corroborarUsuarioHotelRol();
                        if (!usuarioTieneHotelPorRol) { estaOk = false; }
                    }
                }

            }


            //SI PODES pasa al menu Dinamico
            if (estaOk)
            {
                //abrir menu del rol especificado
                MenuDinamico ventanaMenu = new MenuDinamico(formPadre, user_name, codHotelElegido);
                ventanaMenu.Show();
                this.Close();
            }
        }

        public Boolean corroborarUsuarioHotelRol()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.view_roles_hoteles_usuarios rhu" +
                               " WHERE rhu.user_name ='" + this.user_name + "' " +
                               "AND  rhu.cod_hotel =" + this.codHotelElegido +
                               " AND  rhu.rol = '" + this.rol + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoConcuerdaRolHotelUsuario = (int)cmd.ExecuteScalar();
            
            if (resultadoConcuerdaRolHotelUsuario == 0)
            {
                MessageBox.Show("No tiene asignado ese Rol para el Hotel ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean tieneElHotel()
        {
            string consultaCmd3 = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('" + this.user_name + "','" + this.password + "')"
                                + " WHERE cod_hotel = " + this.codHotelElegido;

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = consultaCmd3;

            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoHotel = (int)cmd3.ExecuteScalar();

            if (resultadoHotel == 0)
            {
                MessageBox.Show("Su cuenta no esta asociada a ese hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void sumarFallos()
        {
            nroFallos++;

            //si ingreso 3 veces mal el password se inhabilita el usuario
            if (nroFallos > 3)
            {
                SqlCommand cmd = new SqlCommand("THE_FOREIGN_FOUR.proc_inhabilitar_usuario", FrbaHotel.ConexionSQL.getSqlInstanceConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", user_name);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Se ha inhabilitado su usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public Boolean corroborarPassword()
        {
            string consultaSql = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('" + this.user_name + "','" + this.password + "')";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consultaSql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoPassword = (int)cmd.ExecuteScalar();

            //si ingreso bien el password devolve true sino false
            if (resultadoPassword > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public Boolean camposCompletos(Boolean ok)
        {
            Boolean completoUserName = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxUsername,"UserName");
            if (!completoUserName) { ok = false; }
            Boolean completoPassword = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxpassword, "Password");
            if (!completoPassword) { ok = false; }
            return ok;
        }

        public Boolean corroborarUserNameValido()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[Usuarios] WHERE user_name='" + textBoxUsername.Text +"' AND estado='H'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoUserName = (int)cmd.ExecuteScalar();

            if (resultadoUserName == 0)
            {
                MessageBox.Show("El userName ingresado no existe o no esta habilitado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comboBoxSelecionHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            eligieronHotel = true;
            this.codHotelElegido = comboBoxSelecionHotel.Text;
        }

    }
}
