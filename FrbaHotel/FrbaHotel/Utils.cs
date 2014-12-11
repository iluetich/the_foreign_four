using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace FrbaHotel
{
    public abstract class Utils
    {       
        //Para que el textBox solo permita el tipeo de numeros
        internal static void allowNumbers(KeyPressEventArgs e){
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espacios
                char.IsPunctuation(e.KeyChar)) //Puntuacion
                e.Handled = true; //No permitir
        }

        //Para que el textBox solo permita el tipeo de letras
        internal static void allowLetters(KeyPressEventArgs e){
            if (char.IsNumber(e.KeyChar) || //Numeros
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsPunctuation(e.KeyChar)) //Puntuacion
                e.Handled = true; //No permitir
        }

        //Valida que la fecha inicio sea menor a la fecha final
        internal static bool validarFechas(DateTimePicker dtpFechaDesde, DateTimePicker dtpFechaHasta)
        {
            if (dtpFechaDesde.Value < dtpFechaHasta.Value){
                return true;
            }else{
                MessageBox.Show("Fecha inicio debe ser menor a fecha final", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        //Valida que cualquier tipo de control tenga su campo data completo   
        internal static bool validarCampoEsteCompleto(Control newCtrl, String msg)
        {
            switch (newCtrl.GetType().Name.ToString()){
                case "TextBox":
                    if (newCtrl.Text != "") { return true; }
                    else{
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                    
                case "ComboBox":
                    if (((ComboBox)newCtrl).SelectedIndex != -1) { return true; }
                    else{
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                    
                case "DataTimePicker":                   
                    if (((DateTimePicker)newCtrl).Value != null) { return true; }
                    else{
                        MessageBox.Show("Complete el campo " + msg + " para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;  
                    }                       
            }
            return true;
        }

        internal static void limpiarControl(TextBox txt)
        {
            txt.Text = "";
        }

         //Rellena DataGridView con los header y los campos dependiendo del SELECT de la consulta
        internal static DataSet rellenarDataGridView(DataGridView dgv, string consultaSql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.SelectCommand.CommandTimeout = 600;
            dataAdapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];

            return dataSet;
        }

        //funcion generica que le pasas un combo box y te lo rellena con todos los registros de una tabla de la bd de un campo
        internal static DataSet rellenarCombo(System.Windows.Forms.ComboBox comboBox1, string nombreTabla, string nombreCampo, string consultaSql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet, nombreTabla);
            comboBox1.DataSource = dataSet.Tables[0].DefaultView;
            comboBox1.DisplayMember = nombreCampo;

            return dataSet;
        }

        internal static DataSet rellenarCombo(System.Windows.Forms.ComboBox comboBox1, string nombreCampo, string consultaSql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet);
            comboBox1.DataSource = dataSet.Tables[0].DefaultView;
            comboBox1.DisplayMember = nombreCampo;

            return dataSet;
        }

        //Guarda en una tabla los resultados de hacer una query a la BD para despues pasar a variables individuales
        internal static DataTable obtenerDatosBD(string consultaSQL){
            
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand(consultaSQL, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            adapter.Fill(dt);

            return dt;
        }

        //le pasas la consulta por parametro y la ejecuta
        internal static void ejecutarConsulta(string consulta){           
            SqlConnection cnn = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();
        }

        //le pasas un consulta y devuelve un numero INT resultado de esa consulta
        internal static int ejecutarConsultaResulInt(string consulta){
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //corrobora que en la grilla tenga por lo menos un elemento
        internal static Boolean almenosUno(Boolean ok, DataGridView dgv,string mensajeError){
            int filas = dgv.RowCount;
            if (filas == 0){
                MessageBox.Show(mensajeError, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ok = false;
            }
            return ok;
        }

        //obtiene el codigo de un registro resultado de la consulta dada
        internal static int obtenerCod(string consultaSql){
            string codUsuario;
            DataSet dataSet = new DataSet();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaSql, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            dataAdapter.Fill(dataSet);
            DataRow fila = dataSet.Tables[0].Rows[0];
            codUsuario = fila.ItemArray[0].ToString();

            return int.Parse(codUsuario);
        }

        //encriptar la contraseña
        internal static string encriptarContraseña(string contraseña)
        {
            UnicodeEncoding codificador = new
            UnicodeEncoding();

            string encriptar = contraseña;
            byte[] datos = codificador.GetBytes(encriptar);
            byte[] resultado;
            SHA256 encriptarSHA = new
            SHA256CryptoServiceProvider();
            resultado = encriptarSHA.ComputeHash(datos);

            StringBuilder sBuilder = new
            StringBuilder();
            // Repite a travez de cada byte de el hash y formatea cada uno como un string hexadecimal.
            for (int i = 0; i < resultado.Length; i++){
                sBuilder.Append(resultado[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        internal static DateTime getFechaSistema()
        {
            string fecha_sistema = "SELECT THE_FOREIGN_FOUR.func_get_fecha_sistema ()";
            SqlCommand cmd = new SqlCommand(fecha_sistema, FrbaHotel.ConexionSQL.getSqlInstanceConnection());
            return (DateTime)cmd.ExecuteScalar();
        }

        internal static void actualizarDTP(DateTimePicker dtp)
        {
            dtp.Value = getFechaSistema();
        }

        internal static void actualizarDTP(DateTimePicker dtp_desde, DateTimePicker dtp_hasta)
        {
            actualizarDTP(dtp_desde);
            dtp_hasta.Value = dtp_desde.Value.AddDays(1);
        }
    }
}
