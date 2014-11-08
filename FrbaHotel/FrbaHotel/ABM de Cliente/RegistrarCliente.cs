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
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class RegistrarCliente : Form
    {
        frmRegistrarHuespedesRestantes frmRegistrarHuespedesRestantesPadre;
        frmCliente frmClientePadre;
        private MenuDinamico menu;
        private ModificarOBorrarCliente frmPadre;
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
        private string estado;
        private int nroCalle;
        private string localidad;
        private Boolean constructorMod;
        private string codCliente;//sirve para hacer el UPDATE

        //constructor de formulario registrar cliente
        public RegistrarCliente(MenuDinamico menuPadre)
        {
            this.constructorMenu = true;
            this.constructorMod = false;
            this.menu = menuPadre;
            InitializeComponent();
            comboBoxEstado.SelectedIndex = 0;//marca que el estado de entrada es H
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
        }

        //contructor de formulario de MODIFICAR cliente
        public RegistrarCliente(DataGridViewRow dgvr,ModificarOBorrarCliente formularioPadre)
        {
            this.constructorMod = true;
            this.constructorMenu = false;
            this.frmPadre = formularioPadre;
            InitializeComponent();
            this.labelTitulo.Text = "Modificar Cliente";
            
            //setear los datos a los controles
            this.setearDatos(dgvr);
        }

        //constructor que viene del flujo de generar reserva
        public RegistrarCliente(frmCliente newForm)
        {
            this.constructorMenu = true;
            this.constructorMod = false;
            this.frmClientePadre = newForm;
            InitializeComponent();
            comboBoxEstado.SelectedIndex = 0;//marca que el estado de entrada es H
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
        }        

        public void setearDatos(DataGridViewRow dgvr)
        {
            textBoxNombre.Text = dgvr.Cells["nombre"].Value.ToString();
            textBoxApellido.Text = dgvr.Cells["apellido"].Value.ToString();
            string itemDelComboBox = dgvr.Cells["tipo_doc"].Value.ToString();
            if (itemDelComboBox == "DNI")
            {
                comboBoxTipoDoc.SelectedIndex = 1;
            }
            else
            {
                comboBoxTipoDoc.SelectedIndex = 0;
            }
            textBoxNroDoc.Text = dgvr.Cells["nro_doc"].Value.ToString();
            textBoxMail.Text = dgvr.Cells["mail"].Value.ToString();
            textBoxTelefono.Text = dgvr.Cells["telefono"].Value.ToString();
            dateTimePickerFechaNac.Text = dgvr.Cells["fecha_nac"].Value.ToString();
            textBoxCalle.Text = dgvr.Cells["nom_calle"].Value.ToString();
            textBoxNroCalle.Text = dgvr.Cells["nro_calle"].Value.ToString();
            textBoxDepto.Text = dgvr.Cells["depto"].Value.ToString();
            textBoxPiso.Text = dgvr.Cells["piso"].Value.ToString();
            textBoxNacionalidad.Text = dgvr.Cells["pais_origen"].Value.ToString();
            textBoxLocalidad.Text = dgvr.Cells["nacionalidad"].Value.ToString();
            codCliente = dgvr.Cells["cod_cliente"].Value.ToString();
            string estadoComboBox = dgvr.Cells["estado"].Value.ToString();
            if (estadoComboBox == "H")
            {
                comboBoxEstado.SelectedIndex = 0;
            }
            else
            {
                comboBoxEstado.SelectedIndex = 1;
            }

        }

        public RegistrarCliente()
        {
            comboBoxEstado.SelectedIndex = 0;//marca que el estado de entrada es H
            this.constructorMenu = false;
            this.constructorMod = false;
            InitializeComponent();
        }

        //constructor de formulario registrar cliente
        public RegistrarCliente(frmRegistrarHuespedesRestantes newForm)
        {
            this.constructorMenu = false;
            InitializeComponent();
            comboBoxEstado.SelectedIndex = 0;//marca que el estado de entrada es H
            labelEstado.Visible = false;
            comboBoxEstado.Visible = false;
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

            if (frmClientePadre != null)//vuelve al flujo de generar reserva(agregado por ian)
            {
                frmClientePadre.Enabled = true;
                frmClientePadre.Focus();
            }
            else if (constructorMenu)
            {
                menu.Show();
            }
            if (constructorMod)
            {
                frmPadre.Show();
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
            estado = comboBoxEstado.Text;

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
                    // SqlCommand cmd = new SqlCommand(); COMENTADO X IVAN
                    string consulta = "DECLARE @output numeric(18,0) EXEC @output = THE_FOREIGN_FOUR.proc_registrar_cliente @nombre, @apellido, @tipo_doc, @nro_doc, @mail, @telefono, @fecha_nac, @nom_calle, @nro_calle, @depto, @piso, @nacionalidad, @localidad SELECT @output as codigo"; // agregado por ivan
                    SqlCommand cmd = new SqlCommand(consulta, FrbaHotel.ConexionSQL.getSqlInstanceConnection());

                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@tipo_doc", tipoDoc);
                    cmd.Parameters.AddWithValue("@nro_doc", nroDoc);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@nom_calle", calle);
                    cmd.Parameters.AddWithValue("@nro_calle", nroCalle);
                    cmd.Parameters.AddWithValue("@pais_origen", nacionalidad);
                    cmd.Parameters.AddWithValue("@nacionalidad", localidad);
                    cmd.Parameters.AddWithValue("@piso", piso);
                    cmd.Parameters.AddWithValue("@depto", departamento);
                    cmd.Parameters.AddWithValue("@fecha_nac", fechaNac);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("localidad", localidad); // agregado por ivan

                    if (constructorMod)
                    {
                        cmd.CommandText = "UPDATE THE_FOREIGN_FOUR.Clientes SET nombre=@nombre,apellido=@apellido,tipo_doc=@tipo_doc,nro_doc=@nro_doc,mail=@mail,telefono=@telefono,"+
                                         "nom_calle=@nom_calle,nro_calle=@nro_calle,pais_origen=@pais_origen,nacionalidad=@nacionalidad,piso=@piso,depto=@depto,fecha_nac=@fecha_nac,estado=@estado"+
                                         " WHERE cod_cliente=" + codCliente;
                    }
                    else
                    {
                    //    cmd.CommandText = "INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre,apellido,tipo_doc,nro_doc,mail,telefono,nom_calle,nro_calle,pais_origen,nacionalidad,piso,depto,fecha_nac,estado) " +
                    //            "VALUES (@nombre,@apellido,@tipo_doc,@nro_doc,@mail,@telefono,@nom_calle,@nro_calle,@pais_origen,@nacionalidad,@piso,@depto,@fecha_nac,@estado)";	
                        // try catch de funcion validar_cliente USAR!!!!!!!!!!!!!!!!!!!!!!!!
                        
                    }
                    int codigo_cliente = Convert.ToInt32(cmd.ExecuteScalar());
	                //cmd.ExecuteNonQuery(); COMENTADO X IVAN
                    cnn.Close();


                    if (frmClientePadre != null)//vuelve al flujo de generar reserva(agregado por ian)
                    {
                        frmClientePadre.Enabled = true;
                        frmClientePadre.Focus();
                        frmClientePadre.cargarParametrosClientes(cmd);
                        frmClientePadre.setCodigoCliente(Convert.ToInt32(codigo_cliente)); // agregado por ivan
                    }
                    else if (constructorMod)
                    {
                        frmPadre.Show();
                    }
                    else
                    {
                        menu.Show();
                    }
                    this.Close();
                }
            }
        }

        public Boolean validarCampos()
        {
            Boolean estaOk = true;

            estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxNombre, "Nombre");
            if (estaOk)
            {
                estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxApellido, "Apellido");
            }
            if (estaOk)
            {
                estaOk = FrbaHotel.Utils.validarCampoEsteCompleto(textBoxMail, "Mail");
            }

            //corrobora que el mail si o si tenga mas de 6 cifras
            if((nroDoc - 999999) < 0)
            {
                estaOk = false;
                MessageBox.Show("Complete el campo NroDoc", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
            }

            //mientras no sea la pantalla de Registrar verifica que el mail y el doc sean unicos sino no
            if (!constructorMod)
            {
                //corroborar que no ingrese un mail o un numero de documento que ya esta en la base de datos
                int resulDni = FrbaHotel.Utils.ejecutarConsultaResulInt("SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Clientes c WHERE c.nro_doc=" + nroDoc);
                int resulMail = FrbaHotel.Utils.ejecutarConsultaResulInt("SELECT COUNT(*) FROM THE_FOREIGN_FOUR.Clientes c WHERE c.mail='" + mail + "'");

                if (resulDni != 0)
                {
                    MessageBox.Show("ERROR el nro de documento ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    estaOk = false;
                }

                if (resulMail != 0)
                {
                    MessageBox.Show("ERROR el mail ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    estaOk = false;
                }
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

        private void textBoxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrbaHotel.Utils.allowLetters(e);
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = comboBoxEstado.Text;
        }

    }
}
