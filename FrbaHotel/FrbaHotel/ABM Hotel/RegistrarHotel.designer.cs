namespace FrbaHotel.ABM_de_Hotel
{
    partial class RegistrarHotel
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelTituloDatos = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelCantEstrellas = new System.Windows.Forms.Label();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelPais = new System.Windows.Forms.Label();
            this.labelFechaCreacion = new System.Windows.Forms.Label();
            this.labelTipoRegimen = new System.Windows.Forms.Label();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonAgregarRegimen = new System.Windows.Forms.Button();
            this.textBoxNombreHotel = new System.Windows.Forms.TextBox();
            this.comboBoxCantEstrellas = new System.Windows.Forms.ComboBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxCiudad = new System.Windows.Forms.TextBox();
            this.dateFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTipoRegimen = new System.Windows.Forms.ComboBox();
            this.textBoxPais = new System.Windows.Forms.TextBox();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.dgvRegimen = new System.Windows.Forms.DataGridView();
            this.labelCalle = new System.Windows.Forms.Label();
            this.labelNroCalle = new System.Windows.Forms.Label();
            this.textBoxCalle = new System.Windows.Forms.TextBox();
            this.textBoxNroCalle = new System.Windows.Forms.TextBox();
            this.labelRecargoEstrallas = new System.Windows.Forms.Label();
            this.textBoxRecEstrellas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitulo.Location = new System.Drawing.Point(315, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(133, 24);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Registrar Hotel";
            // 
            // labelTituloDatos
            // 
            this.labelTituloDatos.AutoSize = true;
            this.labelTituloDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloDatos.Location = new System.Drawing.Point(51, 46);
            this.labelTituloDatos.Name = "labelTituloDatos";
            this.labelTituloDatos.Size = new System.Drawing.Size(45, 17);
            this.labelTituloDatos.TabIndex = 1;
            this.labelTituloDatos.Text = "Datos";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(10, 83);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(107, 15);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre del Hotel:";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMail.Location = new System.Drawing.Point(10, 140);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(34, 15);
            this.labelMail.TabIndex = 3;
            this.labelMail.Text = "Mail:";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefono.Location = new System.Drawing.Point(10, 166);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(58, 15);
            this.labelTelefono.TabIndex = 4;
            this.labelTelefono.Text = "Telefono:";
            // 
            // labelCantEstrellas
            // 
            this.labelCantEstrellas.AutoSize = true;
            this.labelCantEstrellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantEstrellas.Location = new System.Drawing.Point(10, 112);
            this.labelCantEstrellas.Name = "labelCantEstrellas";
            this.labelCantEstrellas.Size = new System.Drawing.Size(126, 15);
            this.labelCantEstrellas.TabIndex = 6;
            this.labelCantEstrellas.Text = "Cantidad de Estrellas:";
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCiudad.Location = new System.Drawing.Point(9, 226);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(49, 15);
            this.labelCiudad.TabIndex = 7;
            this.labelCiudad.Text = "Ciudad:";
            // 
            // labelPais
            // 
            this.labelPais.AutoSize = true;
            this.labelPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPais.Location = new System.Drawing.Point(204, 226);
            this.labelPais.Name = "labelPais";
            this.labelPais.Size = new System.Drawing.Size(34, 15);
            this.labelPais.TabIndex = 8;
            this.labelPais.Text = "Pais:";
            // 
            // labelFechaCreacion
            // 
            this.labelFechaCreacion.AutoSize = true;
            this.labelFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaCreacion.Location = new System.Drawing.Point(9, 258);
            this.labelFechaCreacion.Name = "labelFechaCreacion";
            this.labelFechaCreacion.Size = new System.Drawing.Size(113, 15);
            this.labelFechaCreacion.TabIndex = 9;
            this.labelFechaCreacion.Text = "Fecha de Creacion:";
            // 
            // labelTipoRegimen
            // 
            this.labelTipoRegimen.AutoSize = true;
            this.labelTipoRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoRegimen.Location = new System.Drawing.Point(343, 82);
            this.labelTipoRegimen.Name = "labelTipoRegimen";
            this.labelTipoRegimen.Size = new System.Drawing.Size(105, 15);
            this.labelTipoRegimen.TabIndex = 10;
            this.labelTipoRegimen.Text = "Tipo de Regimen:";
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(12, 292);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(75, 23);
            this.botonRegistrar.TabIndex = 13;
            this.botonRegistrar.Text = "Registrar";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(112, 292);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 12;
            this.botonLimpiar.TabStop = false;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(674, 292);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 13;
            this.botonVolver.TabStop = false;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonAgregarRegimen
            // 
            this.botonAgregarRegimen.Location = new System.Drawing.Point(581, 80);
            this.botonAgregarRegimen.Name = "botonAgregarRegimen";
            this.botonAgregarRegimen.Size = new System.Drawing.Size(75, 23);
            this.botonAgregarRegimen.TabIndex = 11;
            this.botonAgregarRegimen.Text = "Agregar";
            this.botonAgregarRegimen.UseVisualStyleBackColor = true;
            this.botonAgregarRegimen.Click += new System.EventHandler(this.botonAgregarRegimen_Click);
            // 
            // textBoxNombreHotel
            // 
            this.textBoxNombreHotel.Location = new System.Drawing.Point(123, 82);
            this.textBoxNombreHotel.Name = "textBoxNombreHotel";
            this.textBoxNombreHotel.Size = new System.Drawing.Size(161, 20);
            this.textBoxNombreHotel.TabIndex = 0;
            // 
            // comboBoxCantEstrellas
            // 
            this.comboBoxCantEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCantEstrellas.FormattingEnabled = true;
            this.comboBoxCantEstrellas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxCantEstrellas.Location = new System.Drawing.Point(143, 105);
            this.comboBoxCantEstrellas.Name = "comboBoxCantEstrellas";
            this.comboBoxCantEstrellas.Size = new System.Drawing.Size(45, 21);
            this.comboBoxCantEstrellas.TabIndex = 1;
            this.comboBoxCantEstrellas.SelectedIndexChanged += new System.EventHandler(this.comboBoxCantEstrellas_SelectedIndexChanged);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(51, 134);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(158, 20);
            this.textBoxMail.TabIndex = 3;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(75, 160);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefono.TabIndex = 4;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelefono_KeyPress);
            // 
            // textBoxCiudad
            // 
            this.textBoxCiudad.Location = new System.Drawing.Point(65, 220);
            this.textBoxCiudad.Name = "textBoxCiudad";
            this.textBoxCiudad.Size = new System.Drawing.Size(100, 20);
            this.textBoxCiudad.TabIndex = 7;
            this.textBoxCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCiudad_KeyPress);
            // 
            // dateFechaCreacion
            // 
            this.dateFechaCreacion.Location = new System.Drawing.Point(128, 258);
            this.dateFechaCreacion.Name = "dateFechaCreacion";
            this.dateFechaCreacion.Size = new System.Drawing.Size(224, 20);
            this.dateFechaCreacion.TabIndex = 9;
            this.dateFechaCreacion.ValueChanged += new System.EventHandler(this.dateFechaCreacion_ValueChanged);
            // 
            // comboBoxTipoRegimen
            // 
            this.comboBoxTipoRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoRegimen.FormattingEnabled = true;
            this.comboBoxTipoRegimen.Location = new System.Drawing.Point(454, 82);
            this.comboBoxTipoRegimen.Name = "comboBoxTipoRegimen";
            this.comboBoxTipoRegimen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRegimen.TabIndex = 10;
            this.comboBoxTipoRegimen.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoRegimen_SelectedIndexChanged);
            // 
            // textBoxPais
            // 
            this.textBoxPais.Location = new System.Drawing.Point(244, 225);
            this.textBoxPais.Name = "textBoxPais";
            this.textBoxPais.Size = new System.Drawing.Size(96, 20);
            this.textBoxPais.TabIndex = 8;
            this.textBoxPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPais_KeyPress);
            // 
            // botonQuitar
            // 
            this.botonQuitar.Location = new System.Drawing.Point(661, 80);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(75, 23);
            this.botonQuitar.TabIndex = 12;
            this.botonQuitar.Text = "Quitar";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // dgvRegimen
            // 
            this.dgvRegimen.AllowUserToAddRows = false;
            this.dgvRegimen.AllowUserToDeleteRows = false;
            this.dgvRegimen.AllowUserToResizeColumns = false;
            this.dgvRegimen.AllowUserToResizeRows = false;
            this.dgvRegimen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimen.Location = new System.Drawing.Point(454, 123);
            this.dgvRegimen.Name = "dgvRegimen";
            this.dgvRegimen.ReadOnly = true;
            this.dgvRegimen.Size = new System.Drawing.Size(282, 118);
            this.dgvRegimen.TabIndex = 26;
            // 
            // labelCalle
            // 
            this.labelCalle.AutoSize = true;
            this.labelCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalle.Location = new System.Drawing.Point(12, 195);
            this.labelCalle.Name = "labelCalle";
            this.labelCalle.Size = new System.Drawing.Size(38, 15);
            this.labelCalle.TabIndex = 27;
            this.labelCalle.Text = "Calle:";
            // 
            // labelNroCalle
            // 
            this.labelNroCalle.AutoSize = true;
            this.labelNroCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroCalle.Location = new System.Drawing.Point(196, 195);
            this.labelNroCalle.Name = "labelNroCalle";
            this.labelNroCalle.Size = new System.Drawing.Size(78, 15);
            this.labelNroCalle.TabIndex = 28;
            this.labelNroCalle.Text = "Nro de Calle:";
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(57, 194);
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(100, 20);
            this.textBoxCalle.TabIndex = 5;
            // 
            // textBoxNroCalle
            // 
            this.textBoxNroCalle.Location = new System.Drawing.Point(281, 193);
            this.textBoxNroCalle.Name = "textBoxNroCalle";
            this.textBoxNroCalle.Size = new System.Drawing.Size(100, 20);
            this.textBoxNroCalle.TabIndex = 6;
            this.textBoxNroCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNroCalle_KeyPress);
            // 
            // labelRecargoEstrallas
            // 
            this.labelRecargoEstrallas.AutoSize = true;
            this.labelRecargoEstrallas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecargoEstrallas.Location = new System.Drawing.Point(218, 111);
            this.labelRecargoEstrallas.Name = "labelRecargoEstrallas";
            this.labelRecargoEstrallas.Size = new System.Drawing.Size(122, 15);
            this.labelRecargoEstrallas.TabIndex = 31;
            this.labelRecargoEstrallas.Text = "Recargo Estrellas($):";
            // 
            // textBoxRecEstrellas
            // 
            this.textBoxRecEstrellas.Location = new System.Drawing.Point(346, 107);
            this.textBoxRecEstrellas.Name = "textBoxRecEstrellas";
            this.textBoxRecEstrellas.Size = new System.Drawing.Size(82, 20);
            this.textBoxRecEstrellas.TabIndex = 2;
            this.textBoxRecEstrellas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRecEstrellas_KeyPress);
            // 
            // RegistrarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 327);
            this.Controls.Add(this.textBoxRecEstrellas);
            this.Controls.Add(this.labelRecargoEstrallas);
            this.Controls.Add(this.textBoxNroCalle);
            this.Controls.Add(this.textBoxCalle);
            this.Controls.Add(this.labelNroCalle);
            this.Controls.Add(this.labelCalle);
            this.Controls.Add(this.dgvRegimen);
            this.Controls.Add(this.botonQuitar);
            this.Controls.Add(this.textBoxPais);
            this.Controls.Add(this.comboBoxTipoRegimen);
            this.Controls.Add(this.dateFechaCreacion);
            this.Controls.Add(this.textBoxCiudad);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.comboBoxCantEstrellas);
            this.Controls.Add(this.textBoxNombreHotel);
            this.Controls.Add(this.botonAgregarRegimen);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.labelTipoRegimen);
            this.Controls.Add(this.labelFechaCreacion);
            this.Controls.Add(this.labelPais);
            this.Controls.Add(this.labelCiudad);
            this.Controls.Add(this.labelCantEstrellas);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTituloDatos);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegistrarHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrarHotel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelTituloDatos;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelCantEstrellas;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelPais;
        private System.Windows.Forms.Label labelFechaCreacion;
        private System.Windows.Forms.Label labelTipoRegimen;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonAgregarRegimen;
        private System.Windows.Forms.TextBox textBoxNombreHotel;
        private System.Windows.Forms.ComboBox comboBoxCantEstrellas;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxCiudad;
        private System.Windows.Forms.DateTimePicker dateFechaCreacion;
        private System.Windows.Forms.ComboBox comboBoxTipoRegimen;
        private System.Windows.Forms.TextBox textBoxPais;
        private System.Windows.Forms.Button botonQuitar;
        private System.Windows.Forms.DataGridView dgvRegimen;
        private System.Windows.Forms.Label labelCalle;
        private System.Windows.Forms.Label labelNroCalle;
        private System.Windows.Forms.TextBox textBoxCalle;
        private System.Windows.Forms.TextBox textBoxNroCalle;
        private System.Windows.Forms.Label labelRecargoEstrallas;
        private System.Windows.Forms.TextBox textBoxRecEstrellas;
    }
}