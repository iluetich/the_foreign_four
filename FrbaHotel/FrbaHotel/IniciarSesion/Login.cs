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
        
        public Login(InicioDelSistema formularioPadre,string rolElegido)
        {
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
            //primero corroborar los campos completos
            FrbaHotel.Utils.validarCampoEsteCompleto(textBoxUsername,"UserName");
            FrbaHotel.Utils.validarCampoEsteCompleto(textBoxpassword, "Password");
            
            //segundo corroborar que exista el usuario ingresado y que esa sea su clave
            string consultaSql = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('"+ this.user_name +"','"+ this.password +"')";
            this.corroborar(consultaSql);

            //tercero verificar si el hotel ingresado esta asociado a su usuario

            //cuarto todo ok mostrar menu correspondiente al rol
        }

        public void corroborar(string consultaSql)
        {
            this.podesIngresar = true;
            
            string stringConnection = "Data Source=localHost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = stringConnection;
            
            //corrobora user_name AYUDA MEMORIA MUY IMPORTANTE NO OLVIDARSE LAS COMILLAS CUANDO SE PONEN STRING EN SQL
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[Usuarios] WHERE user_name='" + this.user_name +"'";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = conexion;

            //corrobora password
            SqlCommand cmd = new SqlCommand();          
            cmd.CommandText = consultaSql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;

            //corrobora Hotel
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT COUNT(*) FROM [THE_FOREIGN_FOUR].[login_password] ('"+ this.user_name +"','"+ this.password +"')"
                               + " WHERE cod_hotel = "+ this.codHotelElegido;
            
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = conexion;

            conexion.Open();

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
                    this.podesIngresar = false;
                }

                int resultadoHotel = (int)cmd3.ExecuteScalar();

                if (resultadoHotel == 0)
                {
                    MessageBox.Show("Su cuenta no esta asociada a ese hotel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.podesIngresar = false;
                }
            }

            conexion.Close();

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
            this.codHotelElegido = comboBoxSelecionHotel.Text;
        }

    }
}
