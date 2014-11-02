using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.Menues_de_los_Roles;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class RegistrarCliente : Form
    {
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;
        private MenuDinamico menu;
        private Boolean constructorMenu;
        private string nombre;
        private string apellido;
        private int piso;
        private string departamento;
        private string calle;
        private string tipoDoc;
        private int nroDoc;
        private string mail;
        private int telefono;
        private DateTime fechaNac;
        private string nacionalidad;
        private string estado = "H";
        private int nroCalle;
        private string localidad;

        public RegistrarCliente(MenuDinamico menuPadre)
        {
            this.constructorMenu = true;
            this.menu = menuPadre;
            InitializeComponent();
        }

        public RegistrarCliente()
        {
            this.constructorMenu = false;
            InitializeComponent();
        }

        public RegistrarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            this.constructorMenu = false;
            InitializeComponent();
            frmRegistrarHuespedesRestantesPadre = newForm;
        }

        public void RegistrarCliente_FormClosing(object sender, FormClosingEventArgs e){
            if (frmRegistrarHuespedesRestantesPadre != null)
            {
                frmRegistrarHuespedesRestantesPadre.Enabled = true;
                frmRegistrarHuespedesRestantesPadre.Focus();
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {           
            if (constructorMenu)
            {
                menu.Show();
            }
            this.Close();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            Boolean ok;
            nombre = textBoxNombre.Text;
            apellido = textBoxApellido.Text;
            piso = int.Parse(textBoxPiso.Text);
            calle = textBoxCalle.Text;
            departamento = textBoxDepto.Text;
            nroDoc = int.Parse(textBoxNroDoc.Text);
            mail = textBoxMail.Text;
            telefono = int.Parse(textBoxTelefono.Text);
            nacionalidad = textBoxNacionalidad.Text;
            nroCalle = int.Parse(textBoxNroCalle.Text);
            localidad = textBoxLocalidad.Text;

            ok = this.validarCampos();

            if (ok) 
            {
                if (frmRegistrarHuespedesRestantesPadre != null)
                {
                    frmRegistrarHuespedesRestantesPadre.llenarGrid(this);
                    this.Close();
                }
                else
                {
                    //string connstring = "connection string";
                    SqlConnection cnn = new SqlConnection("Data Source=localHost\\SQLSERVER2008;Initial Catalog=GD2C2014;Persist Security Info=True;User ID=gd;Password=gd2014");
	                cnn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@nombre", nombre);
                    cmd.Parameters.Add("@apellido", apellido);
                    cmd.Parameters.Add("@tipo_doc", tipoDoc);
                    cmd.Parameters.Add("@nro_doc", nroDoc);
                    cmd.Parameters.Add("@telefono", telefono);
                    cmd.Parameters.Add("@nom_calle", calle);
                    cmd.Parameters.Add("@nro_calle", nroCalle);
                    cmd.Parameters.Add("@pais_origen", nacionalidad);
                    cmd.Parameters.Add("@nacionalidad", localidad);
                    cmd.Parameters.Add("@piso", piso);
                    cmd.Parameters.Add("@depto", departamento);
                    cmd.Parameters.Add("@fecha_nac", fechaNac);
                    cmd.Parameters.Add("@estado", estado);
                    cmd.Parameters.Add("@mail", mail);

                    cmd.CommandText = "INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre,apellido,tipo_doc,nro_doc,mail,telefono,nom_calle,nro_calle,pais_origen,nacionalidad,piso,depto,fecha_nac,estado) " +
                                      "VALUES (@nombre,@apellido,@tipo_doc,@nro_doc,@mail,@telefono,@nom_calle,@nro_calle,@pais_origen,@nacionalidad,@piso,@depto,@fecha_nac,@estado)";	
	                
	
	                cmd.ExecuteNonQuery();
                    cnn.Close();
                    menu.Show();
                    this.Close();
                }
            }
        }

        public Boolean validarCampos()
        {
            Boolean estaOk = true;

            estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombre, "Nombre");
            estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxApellido, "Apellido");
            estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMail, "Mail");

            //corrobora que el mail si o si tenga mas de 6 cifras
            if((nroDoc - 999999) < 0)
            {
                estaOk = false;
                MessageBox.Show("Complete el campo NroDoc", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
            }

            //corroborar que no ingrese un mail o un numero de documento que ya esta en la base de datos
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cmd2.CommandText = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Clientes c WHERE c.mail='"+ mail +"'"; 
            cmd.CommandText = "SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Clientes c WHERE c.nro_doc=" + nroDoc;
            
            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();
            cmd2.Connection = FrbaHotel.ConexionSQL.getSqlInstanceConnection();

            int resulDni = (int)cmd.ExecuteScalar();
            int resulMail = (int)cmd2.ExecuteScalar();

            if (resulDni != 0)
            {
                MessageBox.Show("ERROR el dni ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                estaOk = false;
            }

            if (resulMail != 0)
            {
                MessageBox.Show("ERROR el mail ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                estaOk = false;
            }

            return estaOk;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            FrbaHotel.Utils.limpiarControl(textBoxNombre);
            FrbaHotel.Utils.limpiarControl(textBoxApellido);
            FrbaHotel.Utils.limpiarControl(textBoxNroDoc);
            FrbaHotel.Utils.limpiarControl(textBoxMail);
            FrbaHotel.Utils.limpiarControl(textBoxTelefono);
            FrbaHotel.Utils.limpiarControl(textBoxCalle);
            FrbaHotel.Utils.limpiarControl(textBoxLocalidad);
            FrbaHotel.Utils.limpiarControl(textBoxNacionalidad);
            FrbaHotel.Utils.limpiarControl(textBoxPiso);
            FrbaHotel.Utils.limpiarControl(textBoxNacionalidad);
            FrbaHotel.Utils.limpiarControl(textBoxNroCalle);
        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tipoDoc = comboBoxTipoDoc.Text;
        }

        private void dateTimePickerFechaNac_ValueChanged(object sender, EventArgs e)
        {
            this.fechaNac = dateTimePickerFechaNac.Value;
        }

        private void textBoxNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxNroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowNumbers(e);
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e); 
        }

    }
}
