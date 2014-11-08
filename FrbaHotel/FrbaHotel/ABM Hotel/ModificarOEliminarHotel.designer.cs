namespace FrbaHotel.ABM_de_Hotel
{
    partial class ModificarOEliminarHotel
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
            this.textBoxBuscadorPais = new System.Windows.Forms.TextBox();
            this.comboBoxBusCantEstrellas = new System.Windows.Forms.ComboBox();
            this.textBoxBuscadorCiudad = new System.Windows.Forms.TextBox();
            this.textBoxBuscadorNombre = new System.Windows.Forms.TextBox();
            this.labelPais = new System.Windows.Forms.Label();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelCantEstrellas = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.tituloBuscador = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.dgvHoteles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(598, 336);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 35;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonInhabilitar
            // 
            this.botonInhabilitar.Location = new System.Drawing.Point(115, 336);
            this.botonInhabilitar.Name = "botonInhabilitar";
            this.botonInhabilitar.Size = new System.Drawing.Size(75, 23);
            this.botonInhabilitar.TabIndex = 34;
            this.botonInhabilitar.Text = "Inhabilitar";
            this.botonInhabilitar.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(12, 336);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(75, 23);
            this.botonModificar.TabIndex = 33;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(376, 159);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 32;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(238, 159);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 31;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            // 
            // textBoxBuscadorPais
            // 
            this.textBoxBuscadorPais.Location = new System.Drawing.Point(275, 80);
            this.textBoxBuscadorPais.Name = "textBoxBuscadorPais";
            this.textBoxBuscadorPais.Size = new System.Drawing.Size(118, 20);
            this.textBoxBuscadorPais.TabIndex = 28;
            this.textBoxBuscadorPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBuscadorPais_KeyPress);
            // 
            // comboBoxBusCantEstrellas
            // 
            this.comboBoxBusCantEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBusCantEstrellas.FormattingEnabled = true;
            this.comboBoxBusCantEstrellas.Items.AddRange(new object[] {
            "Todas",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxBusCantEstrellas.Location = new System.Drawing.Point(144, 118);
            this.comboBoxBusCantEstrellas.Name = "comboBoxBusCantEstrellas";
            this.comboBoxBusCantEstrellas.Size = new System.Drawing.Size(90, 21);
            this.comboBoxBusCantEstrellas.TabIndex = 27;
            // 
            // textBoxBuscadorCiudad
            // 
            this.textBoxBuscadorCiudad.Location = new System.Drawing.Point(491, 80);
            this.textBoxBuscadorCiudad.Name = "textBoxBuscadorCiudad";
            this.textBoxBuscadorCiudad.Size = new System.Drawing.Size(98, 20);
            this.textBoxBuscadorCiudad.TabIndex = 26;
            // 
            // textBoxBuscadorNombre
            // 
            this.textBoxBuscadorNombre.Location = new System.Drawing.Point(72, 80);
            this.textBoxBuscadorNombre.Name = "textBoxBuscadorNombre";
            this.textBoxBuscadorNombre.Size = new System.Drawing.Size(118, 20);
            this.textBoxBuscadorNombre.TabIndex = 25;
            // 
            // labelPais
            // 
            this.labelPais.AutoSize = true;
            this.labelPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPais.Location = new System.Drawing.Point(235, 85);
            this.labelPais.Name = "labelPais";
            this.labelPais.Size = new System.Drawing.Size(34, 15);
            this.labelPais.TabIndex = 23;
            this.labelPais.Text = "Pais:";
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCiudad.Location = new System.Drawing.Point(436, 85);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(49, 15);
            this.labelCiudad.TabIndex = 22;
            this.labelCiudad.Text = "Ciudad:";
            // 
            // labelCantEstrellas
            // 
            this.labelCantEstrellas.AutoSize = true;
            this.labelCantEstrellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantEstrellas.Location = new System.Drawing.Point(12, 119);
            this.labelCantEstrellas.Name = "labelCantEstrellas";
            this.labelCantEstrellas.Size = new System.Drawing.Size(126, 15);
            this.labelCantEstrellas.TabIndex = 21;
            this.labelCantEstrellas.Text = "Cantidad de Estrellas:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(11, 85);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(55, 15);
            this.labelNombre.TabIndex = 20;
            this.labelNombre.Text = "Nombre:";
            // 
            // tituloBuscador
            // 
            this.tituloBuscador.AutoSize = true;
            this.tituloBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloBuscador.Location = new System.Drawing.Point(272, 45);
            this.tituloBuscador.Name = "tituloBuscador";
            this.tituloBuscador.Size = new System.Drawing.Size(145, 17);
            this.tituloBuscador.TabIndex = 19;
            this.tituloBuscador.Text = "Buscardor de Hoteles";
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Titulo.Location = new System.Drawing.Point(219, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(232, 24);
            this.Titulo.TabIndex = 18;
            this.Titulo.Text = "Modificar/Eliminar Hotel";
            // 
            // dgvHoteles
            // 
            this.dgvHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoteles.Location = new System.Drawing.Point(12, 188);
            this.dgvHoteles.Name = "dgvHoteles";
            this.dgvHoteles.Size = new System.Drawing.Size(661, 130);
            this.dgvHoteles.TabIndex = 36;
            // 
            // ModificarOEliminarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 371);
            this.Controls.Add(this.dgvHoteles);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonInhabilitar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.textBoxBuscadorPais);
            this.Controls.Add(this.comboBoxBusCantEstrellas);
            this.Controls.Add(this.textBoxBuscadorCiudad);
            this.Controls.Add(this.textBoxBuscadorNombre);
            this.Controls.Add(this.labelPais);
            this.Controls.Add(this.labelCiudad);
            this.Controls.Add(this.labelCantEstrellas);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.tituloBuscador);
            this.Controls.Add(this.Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModificarOEliminarHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarOEliminarHotel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonInhabilitar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.TextBox textBoxBuscadorPais;
        private System.Windows.Forms.ComboBox comboBoxBusCantEstrellas;
        private System.Windows.Forms.TextBox textBoxBuscadorCiudad;
        private System.Windows.Forms.TextBox textBoxBuscadorNombre;
        private System.Windows.Forms.Label labelPais;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelCantEstrellas;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label tituloBuscador;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridView dgvHoteles;
    }
}