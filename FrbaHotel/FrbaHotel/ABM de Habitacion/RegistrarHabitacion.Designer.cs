namespace FrbaHotel.ABM_de_Habitacion
{
    partial class RegistrarHabitacion
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
            this.labelIngreseDatos = new System.Windows.Forms.Label();
            this.labelNumHabitacion = new System.Windows.Forms.Label();
            this.labelPiso = new System.Windows.Forms.Label();
            this.labelVista = new System.Windows.Forms.Label();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.textBoxNumHabitacion = new System.Windows.Forms.TextBox();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.comboBoxVista = new System.Windows.Forms.ComboBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.textBoxTipoHabitacion = new System.Windows.Forms.TextBox();
            this.textBoxHotelEncuentra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitulo.Location = new System.Drawing.Point(101, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(198, 24);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Registrar Habitacion";
            // 
            // labelIngreseDatos
            // 
            this.labelIngreseDatos.AutoSize = true;
            this.labelIngreseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngreseDatos.Location = new System.Drawing.Point(179, 48);
            this.labelIngreseDatos.Name = "labelIngreseDatos";
            this.labelIngreseDatos.Size = new System.Drawing.Size(45, 17);
            this.labelIngreseDatos.TabIndex = 1;
            this.labelIngreseDatos.Text = "Datos";
            // 
            // labelNumHabitacion
            // 
            this.labelNumHabitacion.AutoSize = true;
            this.labelNumHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumHabitacion.Location = new System.Drawing.Point(12, 80);
            this.labelNumHabitacion.Name = "labelNumHabitacion";
            this.labelNumHabitacion.Size = new System.Drawing.Size(134, 15);
            this.labelNumHabitacion.TabIndex = 2;
            this.labelNumHabitacion.Text = "Numero de Habitacion:";
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiso.Location = new System.Drawing.Point(12, 113);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(132, 15);
            this.labelPiso.TabIndex = 3;
            this.labelPiso.Text = "Piso (dentro del Hotel):";
            // 
            // labelVista
            // 
            this.labelVista.AutoSize = true;
            this.labelVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVista.Location = new System.Drawing.Point(12, 146);
            this.labelVista.Name = "labelVista";
            this.labelVista.Size = new System.Drawing.Size(36, 15);
            this.labelVista.TabIndex = 4;
            this.labelVista.Text = "Vista:";
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoHabitacion.Location = new System.Drawing.Point(13, 181);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(113, 15);
            this.labelTipoHabitacion.TabIndex = 5;
            this.labelTipoHabitacion.Text = "Tipo de Habitacion:";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.Location = new System.Drawing.Point(13, 219);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(161, 15);
            this.labelDescripcion.TabIndex = 6;
            this.labelDescripcion.Text = "Descripcion (comodidades):";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(293, 285);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 8;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(105, 285);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 9;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(12, 285);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(75, 23);
            this.botonRegistrar.TabIndex = 10;
            this.botonRegistrar.Text = "Registrar";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // textBoxNumHabitacion
            // 
            this.textBoxNumHabitacion.Location = new System.Drawing.Point(152, 80);
            this.textBoxNumHabitacion.Name = "textBoxNumHabitacion";
            this.textBoxNumHabitacion.Size = new System.Drawing.Size(53, 20);
            this.textBoxNumHabitacion.TabIndex = 13;
            this.textBoxNumHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumHabitacion_KeyPress);
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoHabitacion.FormattingEnabled = true;
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(132, 181);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoHabitacion.TabIndex = 14;
            this.comboBoxTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoHabitacion_SelectedIndexChanged);
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(153, 112);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(52, 20);
            this.textBoxPiso.TabIndex = 15;
            this.textBoxPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(180, 219);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(177, 20);
            this.textBoxDescripcion.TabIndex = 16;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(248, 82);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(48, 15);
            this.labelEstado.TabIndex = 17;
            this.labelEstado.Text = "Estado:";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "H",
            "I"});
            this.comboBoxEstado.Location = new System.Drawing.Point(303, 78);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(54, 21);
            this.comboBoxEstado.TabIndex = 18;
            // 
            // comboBoxVista
            // 
            this.comboBoxVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVista.FormattingEnabled = true;
            this.comboBoxVista.Items.AddRange(new object[] {
            "Interna",
            "Externa"});
            this.comboBoxVista.Location = new System.Drawing.Point(54, 145);
            this.comboBoxVista.Name = "comboBoxVista";
            this.comboBoxVista.Size = new System.Drawing.Size(109, 21);
            this.comboBoxVista.TabIndex = 19;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotel.Location = new System.Drawing.Point(16, 251);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(155, 15);
            this.labelHotel.TabIndex = 20;
            this.labelHotel.Text = "Hotel en que se Encuentra:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(178, 251);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(55, 21);
            this.comboBoxHotel.TabIndex = 21;
            this.comboBoxHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotel_SelectedIndexChanged);
            // 
            // textBoxTipoHabitacion
            // 
            this.textBoxTipoHabitacion.Location = new System.Drawing.Point(132, 181);
            this.textBoxTipoHabitacion.Name = "textBoxTipoHabitacion";
            this.textBoxTipoHabitacion.Size = new System.Drawing.Size(121, 20);
            this.textBoxTipoHabitacion.TabIndex = 22;
            // 
            // textBoxHotelEncuentra
            // 
            this.textBoxHotelEncuentra.Location = new System.Drawing.Point(178, 251);
            this.textBoxHotelEncuentra.Name = "textBoxHotelEncuentra";
            this.textBoxHotelEncuentra.Size = new System.Drawing.Size(55, 20);
            this.textBoxHotelEncuentra.TabIndex = 23;
            // 
            // RegistrarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 320);
            this.Controls.Add(this.textBoxHotelEncuentra);
            this.Controls.Add(this.textBoxTipoHabitacion);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.comboBoxVista);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.comboBoxTipoHabitacion);
            this.Controls.Add(this.textBoxNumHabitacion);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.labelTipoHabitacion);
            this.Controls.Add(this.labelVista);
            this.Controls.Add(this.labelPiso);
            this.Controls.Add(this.labelNumHabitacion);
            this.Controls.Add(this.labelIngreseDatos);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegistrarHabitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Habitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelIngreseDatos;
        private System.Windows.Forms.Label labelNumHabitacion;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.Label labelVista;
        private System.Windows.Forms.Label labelTipoHabitacion;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.TextBox textBoxNumHabitacion;
        private System.Windows.Forms.ComboBox comboBoxTipoHabitacion;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.ComboBox comboBoxVista;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.TextBox textBoxTipoHabitacion;
        private System.Windows.Forms.TextBox textBoxHotelEncuentra;
    }
}