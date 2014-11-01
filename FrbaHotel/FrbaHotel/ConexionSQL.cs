using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaHotel
{
    class ConexionSQL
    {
        static SqlConnection conexionMaestra;

        internal static void establecerConexionBD()
        {
            string stringConexion = "Data Source=localHost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014";
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = stringConexion;

            try
            {
                conexion.Open();
                conexionMaestra = conexion;
            }
            catch (Exception)
            {
                MessageBox.Show("Conexion a la BD fallida");
            }           
        }

        internal static SqlConnection getSqlInstanceConnection()
        {
            return conexionMaestra;
        }
    }
}
