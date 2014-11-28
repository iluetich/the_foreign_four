namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class frmModificarRerserva
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
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblTipoHab = new System.Windows.Forms.Label();
            this.lblTipoReg = new System.Windows.Forms.Label();
            this.groupReserva = new System.Windows.Forms.GroupBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHabitaciones = new System.Windows.Forms.Button();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.dgvRegimenes = new System.Windows.Forms.DataGridView();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupReserva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(36, 36);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesde.TabIndex = 0;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(36, 63);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(68, 13);
            this.lblFechaHasta.TabIndex = 1;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // lblTipoHab
            // 
            this.lblTipoHab.AutoSize = true;
            this.lblTipoHab.Location = new System.Drawing.Point(36, 255);
            this.lblTipoHab.Name = "lblTipoHab";
            this.lblTipoHab.Size = new System.Drawing.Size(85, 13);
            this.lblTipoHab.TabIndex = 2;
            this.lblTipoHab.Text = "Tipo Habitacion:";
            // 
            // lblTipoReg
            // 
            this.lblTipoReg.AutoSize = true;
            this.lblTipoReg.Location = new System.Drawing.Point(36, 89);
            this.lblTipoReg.Name = "lblTipoReg";
            this.lblTipoReg.Size = new System.Drawing.Size(76, 13);
            this.lblTipoReg.TabIndex = 3;
            this.lblTipoReg.Text = "Tipo Regimen:";
            // 
            // groupReserva
            // 
            this.groupReserva.Controls.Add(this.label1);
            this.groupReserva.Controls.Add(this.dgvHabitaciones);
            this.groupReserva.Controls.Add(this.btnHabitaciones);
            this.groupReserva.Controls.Add(this.txtRegimen);
            this.groupReserva.Controls.Add(this.dgvRegimenes);
            this.groupReserva.Controls.Add(this.dtpFechaHasta);
            this.groupReserva.Controls.Add(this.dtpFechaDesde);
            this.groupReserva.Controls.Add(this.lblTipoReg);
            this.groupReserva.Controls.Add(this.lblFechaDesde);
            this.groupReserva.Controls.Add(this.lblFechaHasta);
            this.groupReserva.Controls.Add(this.lblTipoHab);
            this.groupReserva.Location = new System.Drawing.Point(14, 13);
            this.groupReserva.Name = "groupReserva";
            this.groupReserva.Size = new System.Drawing.Size(405, 450);
            this.groupReserva.TabIndex = 8;
            this.groupReserva.TabStop = false;
            this.groupReserva.Text = "Datos Reserva";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToResizeColumns = false;
            this.dgvHabitaciones.AllowUserToResizeRows = false;
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHabitaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.Descripcion});
            this.dgvHabitaciones.Location = new System.Drawing.Point(45, 311);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.Size = new System.Drawing.Size(313, 123);
            this.dgvHabitaciones.TabIndex = 4;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // btnHabitaciones
            // 
            this.btnHabitaciones.Location = new System.Drawing.Point(135, 250);
            this.btnHabitaciones.Name = "btnHabitaciones";
            this.btnHabitaciones.Size = new System.Drawing.Size(200, 23);
            this.btnHabitaciones.TabIndex = 3;
            this.btnHabitaciones.Text = "Agregar Habitacion";
            this.btnHabitaciones.UseVisualStyleBackColor = true;
            this.btnHabitaciones.Click += new System.EventHandler(this.btnHabitaciones_Click);
            // 
            // txtRegimen
            // 
            this.txtRegimen.Location = new System.Drawing.Point(158, 85);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.ReadOnly = true;
            this.txtRegimen.Size = new System.Drawing.Size(200, 20);
            this.txtRegimen.TabIndex = 7;
            this.txtRegimen.TabStop = false;
            this.txtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegimen.TextChanged += new System.EventHandler(this.txtRegimen_TextChanged);
            // 
            // dgvRegimenes
            // 
            this.dgvRegimenes.AllowUserToAddRows = false;
            this.dgvRegimenes.AllowUserToDeleteRows = false;
            this.dgvRegimenes.AllowUserToResizeColumns = false;
            this.dgvRegimenes.AllowUserToResizeRows = false;
            this.dgvRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegimenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegimenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegimenes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimenes.Location = new System.Drawing.Point(45, 113);
            this.dgvRegimenes.Name = "dgvRegimenes";
            this.dgvRegimenes.ReadOnly = true;
            this.dgvRegimenes.Size = new System.Drawing.Size(313, 123);
            this.dgvRegimenes.TabIndex = 2;
            this.dgvRegimenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegimenes_CellClick);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(158, 58);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 1;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(158, 32);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDesde.TabIndex = 0;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(14, 469);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(203, 19);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(117, 42);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(80, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 42);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "(Para eliminar una habitacion selecciona la fila completa y presiona la tecla Sup" +
                "r)";
            // 
            // frmModificarRerserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(431, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmModificarRerserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Reserva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModificarReserva_FormClosing);
            this.groupReserva.ResumeLayout(false);
            this.groupReserva.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblTipoHab;
        private System.Windows.Forms.Label lblTipoReg;
        private System.Windows.Forms.GroupBox groupReserva;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvRegimenes;
        private System.Windows.Forms.TextBox txtRegimen;
        private System.Windows.Forms.Button btnHabitaciones;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label1;
    }
}