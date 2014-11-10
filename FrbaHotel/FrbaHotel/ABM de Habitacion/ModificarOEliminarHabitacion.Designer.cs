namespace FrbaHotel.ABM_de_Habitacion
{
    partial class ModificarOEliminarHabitacion
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
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonInhabilitar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.texBoxPiso = new System.Windows.Forms.TextBox();
            this.texBoxNroHab = new System.Windows.Forms.TextBox();
            this.labelPiso = new System.Windows.Forms.Label();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.labelNroHab = new System.Windows.Forms.Label();
            this.tituloBuscador = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(413, 336);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 51;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonInhabilitar
            // 
            this.botonInhabilitar.Location = new System.Drawing.Point(93, 338);
            this.botonInhabilitar.Name = "botonInhabilitar";
            this.botonInhabilitar.Size = new System.Drawing.Size(75, 23);
            this.botonInhabilitar.TabIndex = 50;
            this.botonInhabilitar.Text = "Inhabilitar";
            this.botonInhabilitar.UseVisualStyleBackColor = true;
            this.botonInhabilitar.Click += new System.EventHandler(this.botonInhabilitar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(12, 338);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(75, 23);
            this.botonModificar.TabIndex = 49;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(270, 157);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 48;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(158, 157);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 47;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // texBoxPiso
            // 
            this.texBoxPiso.Location = new System.Drawing.Point(429, 88);
            this.texBoxPiso.Name = "texBoxPiso";
            this.texBoxPiso.Size = new System.Drawing.Size(62, 20);
            this.texBoxPiso.TabIndex = 45;
            this.texBoxPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBuscadorPais_KeyPress);
            // 
            // texBoxNroHab
            // 
            this.texBoxNroHab.Location = new System.Drawing.Point(90, 84);
            this.texBoxNroHab.Name = "texBoxNroHab";
            this.texBoxNroHab.Size = new System.Drawing.Size(68, 20);
            this.texBoxNroHab.TabIndex = 42;
            this.texBoxNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBuscadorNombre_KeyPress);
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiso.Location = new System.Drawing.Point(389, 89);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(34, 15);
            this.labelPiso.TabIndex = 41;
            this.labelPiso.Text = "Piso:";
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUbicacion.Location = new System.Drawing.Point(178, 89);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(65, 15);
            this.labelUbicacion.TabIndex = 40;
            this.labelUbicacion.Text = "Ubicacion:";
            // 
            // labelNroHab
            // 
            this.labelNroHab.AutoSize = true;
            this.labelNroHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroHab.Location = new System.Drawing.Point(9, 85);
            this.labelNroHab.Name = "labelNroHab";
            this.labelNroHab.Size = new System.Drawing.Size(76, 15);
            this.labelNroHab.TabIndex = 38;
            this.labelNroHab.Text = "Nro de Hab.:";
            // 
            // tituloBuscador
            // 
            this.tituloBuscador.AutoSize = true;
            this.tituloBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloBuscador.Location = new System.Drawing.Point(105, 45);
            this.tituloBuscador.Name = "tituloBuscador";
            this.tituloBuscador.Size = new System.Drawing.Size(164, 17);
            this.tituloBuscador.TabIndex = 37;
            this.tituloBuscador.Text = "Buscardor de Habitacion";
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Titulo.Location = new System.Drawing.Point(110, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(282, 24);
            this.Titulo.TabIndex = 36;
            this.Titulo.Text = "Modificar/Eliminar Habitacion";
            // 
            // comboBoxUbicacion
            // 
            this.comboBoxUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUbicacion.FormattingEnabled = true;
            this.comboBoxUbicacion.Items.AddRange(new object[] {
            "Todos",
            "Externo",
            "Interno"});
            this.comboBoxUbicacion.Location = new System.Drawing.Point(250, 86);
            this.comboBoxUbicacion.Name = "comboBoxUbicacion";
            this.comboBoxUbicacion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUbicacion.TabIndex = 52;
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 186);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.Size = new System.Drawing.Size(478, 146);
            this.dgvHabitaciones.TabIndex = 53;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotel.Location = new System.Drawing.Point(12, 123);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(135, 15);
            this.labelHotel.TabIndex = 54;
            this.labelHotel.Text = "Hotel al que Pertenece:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(154, 123);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHotel.TabIndex = 55;
            this.comboBoxHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotel_SelectedIndexChanged);
            // 
            // ModificarOEliminarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 373);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.comboBoxUbicacion);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonInhabilitar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.texBoxPiso);
            this.Controls.Add(this.texBoxNroHab);
            this.Controls.Add(this.labelPiso);
            this.Controls.Add(this.labelUbicacion);
            this.Controls.Add(this.labelNroHab);
            this.Controls.Add(this.tituloBuscador);
            this.Controls.Add(this.Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModificarOEliminarHabitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarOEliminarHabitacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonInhabilitar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.TextBox texBoxPiso;
        private System.Windows.Forms.TextBox texBoxNroHab;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Label labelNroHab;
        private System.Windows.Forms.Label tituloBuscador;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.ComboBox comboBoxUbicacion;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxHotel;
    }
}