namespace FrbaHotel.ABM_de_Usuario
{
    partial class CreacionDeUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCrearUsuario = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelRepetirPassword = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.labelTituloDatosPersonales = new System.Windows.Forms.Label();
            this.labelTituloDatos = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.TipoDoc = new System.Windows.Forms.Label();
            this.numeroDeDocumento = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.Label();
            this.Direccion = new System.Windows.Forms.Label();
            this.fechaDeNacimiento = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword1 = new System.Windows.Forms.TextBox();
            this.textBoxPassword2 = new System.Windows.Forms.TextBox();
            this.dateTimePickFechaNac = new System.Windows.Forms.DateTimePicker();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxNumeroDeDoc = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.botonAgregarRol = new System.Windows.Forms.Button();
            this.labelEstado = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.dgvRolesHoteles = new System.Windows.Forms.DataGridView();
            this.botonQuitarRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolesHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCrearUsuario
            // 
            this.labelCrearUsuario.AutoSize = true;
            this.labelCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrearUsuario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelCrearUsuario.Location = new System.Drawing.Point(215, 9);
            this.labelCrearUsuario.Name = "labelCrearUsuario";
            this.labelCrearUsuario.Size = new System.Drawing.Size(138, 24);
            this.labelCrearUsuario.TabIndex = 0;
            this.labelCrearUsuario.Text = "Crear Usuario";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(11, 70);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(68, 15);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(11, 100);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(64, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // labelRepetirPassword
            // 
            this.labelRepetirPassword.AutoSize = true;
            this.labelRepetirPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepetirPassword.Location = new System.Drawing.Point(11, 128);
            this.labelRepetirPassword.Name = "labelRepetirPassword";
            this.labelRepetirPassword.Size = new System.Drawing.Size(107, 15);
            this.labelRepetirPassword.TabIndex = 3;
            this.labelRepetirPassword.Text = "Repetir Password:";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRol.Location = new System.Drawing.Point(274, 71);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(122, 15);
            this.labelRol.TabIndex = 4;
            this.labelRol.Text = "Rol que desempeña:";
            // 
            // labelTituloDatosPersonales
            // 
            this.labelTituloDatosPersonales.AutoSize = true;
            this.labelTituloDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloDatosPersonales.Location = new System.Drawing.Point(36, 190);
            this.labelTituloDatosPersonales.Name = "labelTituloDatosPersonales";
            this.labelTituloDatosPersonales.Size = new System.Drawing.Size(120, 17);
            this.labelTituloDatosPersonales.TabIndex = 5;
            this.labelTituloDatosPersonales.Text = "Datos Personales";
            // 
            // labelTituloDatos
            // 
            this.labelTituloDatos.AutoSize = true;
            this.labelTituloDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloDatos.Location = new System.Drawing.Point(36, 42);
            this.labelTituloDatos.Name = "labelTituloDatos";
            this.labelTituloDatos.Size = new System.Drawing.Size(45, 17);
            this.labelTituloDatos.TabIndex = 6;
            this.labelTituloDatos.Text = "Datos";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(14, 220);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(55, 15);
            this.labelNombre.TabIndex = 7;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(253, 220);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(54, 15);
            this.labelApellido.TabIndex = 8;
            this.labelApellido.Text = "Apellido:";
            // 
            // TipoDoc
            // 
            this.TipoDoc.AutoSize = true;
            this.TipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoDoc.Location = new System.Drawing.Point(14, 255);
            this.TipoDoc.Name = "TipoDoc";
            this.TipoDoc.Size = new System.Drawing.Size(79, 15);
            this.TipoDoc.TabIndex = 9;
            this.TipoDoc.Text = "Tipo de Doc.:";
            // 
            // numeroDeDocumento
            // 
            this.numeroDeDocumento.AutoSize = true;
            this.numeroDeDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroDeDocumento.Location = new System.Drawing.Point(253, 254);
            this.numeroDeDocumento.Name = "numeroDeDocumento";
            this.numeroDeDocumento.Size = new System.Drawing.Size(100, 15);
            this.numeroDeDocumento.TabIndex = 10;
            this.numeroDeDocumento.Text = "Número de Doc.:";
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.Location = new System.Drawing.Point(14, 286);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(34, 15);
            this.mail.TabIndex = 11;
            this.mail.Text = "Mail:";
            // 
            // telefono
            // 
            this.telefono.AutoSize = true;
            this.telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono.Location = new System.Drawing.Point(199, 286);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(58, 15);
            this.telefono.TabIndex = 12;
            this.telefono.Text = "Telefono:";
            // 
            // Direccion
            // 
            this.Direccion.AutoSize = true;
            this.Direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Direccion.Location = new System.Drawing.Point(14, 319);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(62, 15);
            this.Direccion.TabIndex = 13;
            this.Direccion.Text = "Direccion:";
            // 
            // fechaDeNacimiento
            // 
            this.fechaDeNacimiento.AutoSize = true;
            this.fechaDeNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDeNacimiento.Location = new System.Drawing.Point(294, 319);
            this.fechaDeNacimiento.Name = "fechaDeNacimiento";
            this.fechaDeNacimiento.Size = new System.Drawing.Size(89, 15);
            this.fechaDeNacimiento.TabIndex = 14;
            this.fechaDeNacimiento.Text = "Fecha de Nac.:";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(14, 361);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 13;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(100, 361);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 17;
            this.limpiar.TabStop = false;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(514, 361);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 18;
            this.cancelar.TabStop = false;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(86, 70);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword1
            // 
            this.textBoxPassword1.Location = new System.Drawing.Point(125, 99);
            this.textBoxPassword1.Name = "textBoxPassword1";
            this.textBoxPassword1.PasswordChar = '*';
            this.textBoxPassword1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword1.TabIndex = 1;
            // 
            // textBoxPassword2
            // 
            this.textBoxPassword2.Location = new System.Drawing.Point(125, 128);
            this.textBoxPassword2.Name = "textBoxPassword2";
            this.textBoxPassword2.PasswordChar = '*';
            this.textBoxPassword2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword2.TabIndex = 2;
            // 
            // dateTimePickFechaNac
            // 
            this.dateTimePickFechaNac.Location = new System.Drawing.Point(390, 319);
            this.dateTimePickFechaNac.Name = "dateTimePickFechaNac";
            this.dateTimePickFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickFechaNac.TabIndex = 11;
            this.dateTimePickFechaNac.ValueChanged += new System.EventHandler(this.fechaDeNac_ValueChanged);
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(264, 286);
            this.textBoxTelefono.MaxLength = 20;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefono.TabIndex = 9;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelefono_KeyPress);
            // 
            // textBoxNumeroDeDoc
            // 
            this.textBoxNumeroDeDoc.Location = new System.Drawing.Point(359, 253);
            this.textBoxNumeroDeDoc.MaxLength = 8;
            this.textBoxNumeroDeDoc.Name = "textBoxNumeroDeDoc";
            this.textBoxNumeroDeDoc.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumeroDeDoc.TabIndex = 7;
            this.textBoxNumeroDeDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroDeDoc_KeyPress);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(55, 285);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(100, 20);
            this.textBoxMail.TabIndex = 8;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(76, 220);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(149, 20);
            this.textBoxNombre.TabIndex = 4;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(317, 219);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(144, 20);
            this.textBoxApellido.TabIndex = 5;
            this.textBoxApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxApellido_KeyPress);
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(83, 319);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(199, 20);
            this.textBoxDireccion.TabIndex = 10;
            // 
            // botonAgregarRol
            // 
            this.botonAgregarRol.Location = new System.Drawing.Point(402, 68);
            this.botonAgregarRol.Name = "botonAgregarRol";
            this.botonAgregarRol.Size = new System.Drawing.Size(75, 23);
            this.botonAgregarRol.TabIndex = 12;
            this.botonAgregarRol.Text = "Agregar Rol";
            this.botonAgregarRol.UseVisualStyleBackColor = true;
            this.botonAgregarRol.Click += new System.EventHandler(this.botonAgregarRol_Click);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(11, 156);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(48, 15);
            this.labelEstado.TabIndex = 34;
            this.labelEstado.Text = "Estado:";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "H",
            "I"});
            this.comboBoxEstado.Location = new System.Drawing.Point(65, 155);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(44, 21);
            this.comboBoxEstado.TabIndex = 3;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Items.AddRange(new object[] {
            "PAS",
            "DNI"});
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(100, 255);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(86, 21);
            this.comboBoxTipoDoc.TabIndex = 6;
            this.comboBoxTipoDoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDoc_SelectedIndexChanged);
            // 
            // dgvRolesHoteles
            // 
            this.dgvRolesHoteles.AllowUserToAddRows = false;
            this.dgvRolesHoteles.AllowUserToDeleteRows = false;
            this.dgvRolesHoteles.AllowUserToResizeColumns = false;
            this.dgvRolesHoteles.AllowUserToResizeRows = false;
            this.dgvRolesHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRolesHoteles.Location = new System.Drawing.Point(277, 100);
            this.dgvRolesHoteles.Name = "dgvRolesHoteles";
            this.dgvRolesHoteles.Size = new System.Drawing.Size(281, 90);
            this.dgvRolesHoteles.TabIndex = 41;
            // 
            // botonQuitarRol
            // 
            this.botonQuitarRol.Location = new System.Drawing.Point(483, 68);
            this.botonQuitarRol.Name = "botonQuitarRol";
            this.botonQuitarRol.Size = new System.Drawing.Size(75, 23);
            this.botonQuitarRol.TabIndex = 42;
            this.botonQuitarRol.TabStop = false;
            this.botonQuitarRol.Text = "Quitar Rol";
            this.botonQuitarRol.UseVisualStyleBackColor = true;
            this.botonQuitarRol.Click += new System.EventHandler(this.botonQuitarRol_Click);
            // 
            // CreacionDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 400);
            this.Controls.Add(this.botonQuitarRol);
            this.Controls.Add(this.dgvRolesHoteles);
            this.Controls.Add(this.comboBoxTipoDoc);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.botonAgregarRol);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxNumeroDeDoc);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.dateTimePickFechaNac);
            this.Controls.Add(this.textBoxPassword2);
            this.Controls.Add(this.textBoxPassword1);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.fechaDeNacimiento);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.telefono);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.numeroDeDocumento);
            this.Controls.Add(this.TipoDoc);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTituloDatos);
            this.Controls.Add(this.labelTituloDatosPersonales);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.labelRepetirPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labelCrearUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreacionDeUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creacion de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolesHoteles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCrearUsuario;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRepetirPassword;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Label labelTituloDatosPersonales;
        private System.Windows.Forms.Label labelTituloDatos;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label TipoDoc;
        private System.Windows.Forms.Label numeroDeDocumento;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label telefono;
        private System.Windows.Forms.Label Direccion;
        private System.Windows.Forms.Label fechaDeNacimiento;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword1;
        private System.Windows.Forms.TextBox textBoxPassword2;
        private System.Windows.Forms.DateTimePicker dateTimePickFechaNac;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxNumeroDeDoc;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Button botonAgregarRol;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.DataGridView dgvRolesHoteles;
        private System.Windows.Forms.Button botonQuitarRol;
    }
}