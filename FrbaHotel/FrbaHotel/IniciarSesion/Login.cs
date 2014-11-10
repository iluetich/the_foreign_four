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
            string consulta = "select * from THE_FOREIGN_FOUR.Hoteles";
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

            //primero corroborar los campos completos
            FrbaHotel.Utils.validarCampoEsteCompleto(textBoxUsername,"UserName");
            FrbaHotel.Utils.validarCampoEsteCompleto(textBoxpassword, "Password");
            
            //segundo corroborar que exista el usuario ingresado y que esa sea su clave
            string consultaSql = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('"+ this.user_name +"','"+ this.password +"')";
            this.corroborar(consultaSql);
            
            //LOS SIGUIENTE PASO SE HACEN YA EN EL METODO corroborar
            //tercero verificar si el hotel ingresado esta asociado a su usuario

            //cuarto todo ok mostrar menu correspondiente al rol
        }

        public void corroborar(string consultaSql)
        {
            this.podesIngresar = true;
            
            //corrobora user_name AYUDA MEMORIA MUY IMPORTANTE NO OLVIDARSE LAS COMILLAS CUANDO SE PONEN STRING EN SQL
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[Usuarios] WHERE user_name='" + this.user_name +"'";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            //corrobora password
            SqlCommand cmd = new SqlCommand();          
            cmd.CommandText = consultaSql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            //para que no me salte error si no se elige nada
            string consultaCmd3;
            /*if (!eligieronHotel)
            {
                consultaCmd3 = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('" + this.user_name + "' , '" + this.password +"') WHERE cod_hotel = 1";
            }
            else 
            {*/
                consultaCmd3 = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('" + this.user_name + "','" + this.password + "')"
                               + " WHERE cod_hotel = " + this.codHotelElegido;
            //}

            //corrobora Hotel
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = consultaCmd3;
            
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            //corrobora que el usuario en ese hotel tenga el rol elegido
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.view_roles_hoteles_usuarios rhu" +
                               " WHERE rhu.user_name ='"+ this.user_name +"' " +
                               "AND  rhu.cod_hotel ="+ this.codHotelElegido +
                               " AND  rhu.rol = '"+ this.rol+"'";
            cmd4.CommandType = CommandType.Text;
            cmd4.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resultadoUserName = (int)cmd2.ExecuteScalar();

            if (resultadoUserName == 0)
            {
                MessageBox.Show("El userName ingresado no existe o no esta habilitado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.podesIngresar = false;
            }
            else
            {
                int resultadoPassword = (int)cmd.ExecuteScalar();

                if (resultadoPassword == 0)
                {
                    MessageBox.Show("Contraseña Incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nroFallos++;
                    
                    //si ingreso 3 veces mal el password se inhabilita el usuario
                    if (nroFallos > 3)
                    {
                        //ACA VA EL PROCEDURE QUE TE INHABILITA EL USUARIO
                    }

                    this.podesIngresar = false;
                }

                int resultadoHotel = (int)cmd3.ExecuteScalar();

                if (resultadoHotel == 0)
                {
                    MessageBox.Show("Su cuenta no esta asociada a ese hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.podesIngresar = false;
                }

                int resultadoConcuerdaRolHotelUsuario = (int)cmd4.ExecuteScalar();
                if (resultadoConcuerdaRolHotelUsuario == 0)
                {
                    MessageBox.Show("No tiene asignado ese Rol para el Hotel ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.podesIngresar = false;
                }
            }

            if (podesIngresar) 
            {
                //abrir menu del rol especificado
                MenuDinamico ventanaMenu = new MenuDinamico(formPadre,user_name,codHotelElegido);
                ventanaMenu.Show();
                this.Close();
            }
        }

        private void comboBoxSelecionHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            eligieronHotel = true;
            this.codHotelElegido = comboBoxSelecionHotel.Text;
        }

    }
}
