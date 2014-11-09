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
            this.dgvRegimenes = new System.Windows.Forms.DataGridView();
            this.btnVerficarDisponibilidad = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoHab = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.groupReserva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(36, 32);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesde.TabIndex = 0;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(36, 58);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(68, 13);
            this.lblFechaHasta.TabIndex = 1;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // lblTipoHab
            // 
            this.lblTipoHab.AutoSize = true;
            this.lblTipoHab.Location = new System.Drawing.Point(36, 88);
            this.lblTipoHab.Name = "lblTipoHab";
            this.lblTipoHab.Size = new System.Drawing.Size(85, 13);
            this.lblTipoHab.TabIndex = 2;
            this.lblTipoHab.Text = "Tipo Habitacion:";
            // 
            // lblTipoReg
            // 
            this.lblTipoReg.AutoSize = true;
            this.lblTipoReg.Location = new System.Drawing.Point(36, 121);
            this.lblTipoReg.Name = "lblTipoReg";
            this.lblTipoReg.Size = new System.Drawing.Size(76, 13);
            this.lblTipoReg.TabIndex = 3;
            this.lblTipoReg.Text = "Tipo Regimen:";
            this.lblTipoReg.Click += new System.EventHandler(this.lblTipoReg_Click);
            // 
            // groupReserva
            // 
            this.groupReserva.Controls.Add(this.txtRegimen);
            this.groupReserva.Controls.Add(this.dgvRegimenes);
            this.groupReserva.Controls.Add(this.btnVerficarDisponibilidad);
            this.groupReserva.Controls.Add(this.dtpFechaHasta);
            this.groupReserva.Controls.Add(this.dtpFechaDesde);
            this.groupReserva.Controls.Add(this.cmbTipoHab);
            this.groupReserva.Controls.Add(this.lblTipoReg);
            this.groupReserva.Controls.Add(this.lblFechaDesde);
            this.groupReserva.Controls.Add(this.lblFechaHasta);
            this.groupReserva.Controls.Add(this.lblTipoHab);
            this.groupReserva.Location = new System.Drawing.Point(23, 13);
            this.groupReserva.Name = "groupReserva";
            this.groupReserva.Size = new System.Drawing.Size(383, 334);
            this.groupReserva.TabIndex = 8;
            this.groupReserva.TabStop = false;
            this.groupReserva.Text = "Datos Reserva";
            // 
            // dgvRegimenes
            // 
            this.dgvRegimenes.AllowUserToAddRows = false;
            this.dgvRegimenes.AllowUserToDeleteRows = false;
            this.dgvRegimenes.AllowUserToResizeColumns = false;
            this.dgvRegimenes.AllowUserToResizeRows = false;
            this.dgvRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegimenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegimenes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimenes.Location = new System.Drawing.Point(39, 149);
            this.dgvRegimenes.Name = "dgvRegimenes";
            this.dgvRegimenes.ReadOnly = true;
            this.dgvRegimenes.Size = new System.Drawing.Size(313, 116);
            this.dgvRegimenes.TabIndex = 6;
            this.dgvRegimenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegimenes_CellClick);
            // 
            // btnVerficarDisponibilidad
            // 
            this.btnVerficarDisponibilidad.AutoSize = true;
            this.btnVerficarDisponibilidad.Location = new System.Drawing.Point(129, 282);
            this.btnVerficarDisponibilidad.Name = "btnVerficarDisponibilidad";
            this.btnVerficarDisponibilidad.Size = new System.Drawing.Size(123, 23);
            this.btnVerficarDisponibilidad.TabIndex = 5;
            this.btnVerficarDisponibilidad.Text = "Verificar Disponibilidad";
            this.btnVerficarDisponibilidad.UseVisualStyleBackColor = true;
            this.btnVerficarDisponibilidad.Click += new System.EventHandler(this.btnVerficarDisponibilidad_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(142, 60);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 1;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(142, 32);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDesde.TabIndex = 0;
            // 
            // cmbTipoHab
            // 
            this.cmbTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoHab.FormattingEnabled = true;
            this.cmbTipoHab.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbTipoHab.Location = new System.Drawing.Point(142, 87);
            this.cmbTipoHab.Name = "cmbTipoHab";
            this.cmbTipoHab.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoHab.TabIndex = 3;
            this.cmbTipoHab.SelectedIndexChanged += new System.EventHandler(this.cmbTipoHab_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Location = new System.Drawing.Point(23, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(74, 37);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 42);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnModificar.Location = new System.Drawing.Point(197, 37);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(117, 42);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtRegimen
            // 
            this.txtRegimen.Location = new System.Drawing.Point(142, 115);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.ReadOnly = true;
            this.txtRegimen.Size = new System.Drawing.Size(200, 20);
            this.txtRegimen.TabIndex = 7;
            this.txtRegimen.TabStop = false;
            this.txtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmModificarRerserva
            // 
            this.AcceptButton = this.btnVerficarDisponibilidad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(431, 480);
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
        private System.Windows.Forms.ComboBox cmbTipoHab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVerficarDisponibilidad;
        private System.Windows.Forms.DataGridView dgvRegimenes;
        private System.Windows.Forms.TextBox txtRegimen;
    }
}