﻿namespace FrbaHotel.ABM_de_Hotel
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
            this.labelDireccion = new System.Windows.Forms.Label();
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
            this.listBoxRegimenes = new System.Windows.Forms.ListBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxPais = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitulo.Location = new System.Drawing.Point(237, 9);
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
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(193, 165);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(62, 15);
            this.labelDireccion.TabIndex = 5;
            this.labelDireccion.Text = "Direccion:";
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
            this.labelCiudad.Location = new System.Drawing.Point(10, 194);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(49, 15);
            this.labelCiudad.TabIndex = 7;
            this.labelCiudad.Text = "Ciudad:";
            // 
            // labelPais
            // 
            this.labelPais.AutoSize = true;
            this.labelPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPais.Location = new System.Drawing.Point(205, 194);
            this.labelPais.Name = "labelPais";
            this.labelPais.Size = new System.Drawing.Size(34, 15);
            this.labelPais.TabIndex = 8;
            this.labelPais.Text = "Pais:";
            // 
            // labelFechaCreacion
            // 
            this.labelFechaCreacion.AutoSize = true;
            this.labelFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaCreacion.Location = new System.Drawing.Point(10, 226);
            this.labelFechaCreacion.Name = "labelFechaCreacion";
            this.labelFechaCreacion.Size = new System.Drawing.Size(113, 15);
            this.labelFechaCreacion.TabIndex = 9;
            this.labelFechaCreacion.Text = "Fecha de Creacion:";
            // 
            // labelTipoRegimen
            // 
            this.labelTipoRegimen.AutoSize = true;
            this.labelTipoRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoRegimen.Location = new System.Drawing.Point(314, 82);
            this.labelTipoRegimen.Name = "labelTipoRegimen";
            this.labelTipoRegimen.Size = new System.Drawing.Size(105, 15);
            this.labelTipoRegimen.TabIndex = 10;
            this.labelTipoRegimen.Text = "Tipo de Regimen:";
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(13, 261);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(75, 23);
            this.botonRegistrar.TabIndex = 11;
            this.botonRegistrar.Text = "Registrar";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(113, 261);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 12;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(552, 261);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 13;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            // 
            // botonAgregarRegimen
            // 
            this.botonAgregarRegimen.Location = new System.Drawing.Point(552, 80);
            this.botonAgregarRegimen.Name = "botonAgregarRegimen";
            this.botonAgregarRegimen.Size = new System.Drawing.Size(75, 23);
            this.botonAgregarRegimen.TabIndex = 14;
            this.botonAgregarRegimen.Text = "Agregar";
            this.botonAgregarRegimen.UseVisualStyleBackColor = true;
            // 
            // textBoxNombreHotel
            // 
            this.textBoxNombreHotel.Location = new System.Drawing.Point(123, 82);
            this.textBoxNombreHotel.Name = "textBoxNombreHotel";
            this.textBoxNombreHotel.Size = new System.Drawing.Size(161, 20);
            this.textBoxNombreHotel.TabIndex = 15;
            // 
            // comboBoxCantEstrellas
            // 
            this.comboBoxCantEstrellas.FormattingEnabled = true;
            this.comboBoxCantEstrellas.Location = new System.Drawing.Point(143, 105);
            this.comboBoxCantEstrellas.Name = "comboBoxCantEstrellas";
            this.comboBoxCantEstrellas.Size = new System.Drawing.Size(45, 21);
            this.comboBoxCantEstrellas.TabIndex = 16;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(51, 134);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(158, 20);
            this.textBoxMail.TabIndex = 17;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(75, 160);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefono.TabIndex = 18;
            // 
            // textBoxCiudad
            // 
            this.textBoxCiudad.Location = new System.Drawing.Point(66, 188);
            this.textBoxCiudad.Name = "textBoxCiudad";
            this.textBoxCiudad.Size = new System.Drawing.Size(100, 20);
            this.textBoxCiudad.TabIndex = 19;
            // 
            // dateFechaCreacion
            // 
            this.dateFechaCreacion.Location = new System.Drawing.Point(129, 226);
            this.dateFechaCreacion.Name = "dateFechaCreacion";
            this.dateFechaCreacion.Size = new System.Drawing.Size(224, 20);
            this.dateFechaCreacion.TabIndex = 20;
            // 
            // comboBoxTipoRegimen
            // 
            this.comboBoxTipoRegimen.FormattingEnabled = true;
            this.comboBoxTipoRegimen.Location = new System.Drawing.Point(425, 82);
            this.comboBoxTipoRegimen.Name = "comboBoxTipoRegimen";
            this.comboBoxTipoRegimen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRegimen.TabIndex = 21;
            // 
            // listBoxRegimenes
            // 
            this.listBoxRegimenes.FormattingEnabled = true;
            this.listBoxRegimenes.Location = new System.Drawing.Point(425, 120);
            this.listBoxRegimenes.Name = "listBoxRegimenes";
            this.listBoxRegimenes.Size = new System.Drawing.Size(199, 121);
            this.listBoxRegimenes.TabIndex = 22;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(261, 164);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(134, 20);
            this.textBoxDireccion.TabIndex = 23;
            // 
            // textBoxPais
            // 
            this.textBoxPais.Location = new System.Drawing.Point(245, 193);
            this.textBoxPais.Name = "textBoxPais";
            this.textBoxPais.Size = new System.Drawing.Size(96, 20);
            this.textBoxPais.TabIndex = 24;
            // 
            // RegistrarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 296);
            this.Controls.Add(this.textBoxPais);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.listBoxRegimenes);
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
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTituloDatos);
            this.Controls.Add(this.labelTitulo);
            this.Name = "RegistrarHotel";
            this.Text = "RegistrarHotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelTituloDatos;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelDireccion;
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
        private System.Windows.Forms.ListBox listBoxRegimenes;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxPais;
    }
}