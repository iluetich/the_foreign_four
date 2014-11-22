namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class frmGenerarReserva
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
            this.lblFechaDesd = new System.Windows.Forms.Label();
            this.lblFechaHast = new System.Windows.Forms.Label();
            this.lblTipoHab = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnRegimenes = new System.Windows.Forms.Button();
            this.groupDatos = new System.Windows.Forms.GroupBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.txtCostoXDia = new System.Windows.Forms.TextBox();
            this.lblCostoXDia = new System.Windows.Forms.Label();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarHotel = new System.Windows.Forms.Label();
            this.txtResul = new System.Windows.Forms.TextBox();
            this.grbPanel2 = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.groupDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.grbPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaDesd
            // 
            this.lblFechaDesd.AutoSize = true;
            this.lblFechaDesd.Location = new System.Drawing.Point(21, 59);
            this.lblFechaDesd.Name = "lblFechaDesd";
            this.lblFechaDesd.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesd.TabIndex = 3;
            this.lblFechaDesd.Text = "Fecha desde:";
            // 
            // lblFechaHast
            // 
            this.lblFechaHast.AutoSize = true;
            this.lblFechaHast.Location = new System.Drawing.Point(21, 86);
            this.lblFechaHast.Name = "lblFechaHast";
            this.lblFechaHast.Size = new System.Drawing.Size(69, 13);
            this.lblFechaHast.TabIndex = 2;
            this.lblFechaHast.Text = "Fecha hasta:";
            // 
            // lblTipoHab
            // 
            this.lblTipoHab.AutoSize = true;
            this.lblTipoHab.Location = new System.Drawing.Point(19, 143);
            this.lblTipoHab.Name = "lblTipoHab";
            this.lblTipoHab.Size = new System.Drawing.Size(85, 13);
            this.lblTipoHab.TabIndex = 0;
            this.lblTipoHab.Text = "Tipo Habitacion:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(138, 55);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDesde.TabIndex = 1;
            this.dtpFechaDesde.Tag = "Fecha desde";
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(138, 82);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 2;
            this.dtpFechaHasta.Tag = "Fecha hasta";
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // btnRegimenes
            // 
            this.btnRegimenes.AutoSize = true;
            this.btnRegimenes.Location = new System.Drawing.Point(22, 108);
            this.btnRegimenes.Name = "btnRegimenes";
            this.btnRegimenes.Size = new System.Drawing.Size(141, 23);
            this.btnRegimenes.TabIndex = 3;
            this.btnRegimenes.Text = "Seleccionar regimen";
            this.btnRegimenes.UseVisualStyleBackColor = true;
            this.btnRegimenes.Click += new System.EventHandler(this.btnRegimenes_Click);
            // 
            // groupDatos
            // 
            this.groupDatos.AutoSize = true;
            this.groupDatos.Controls.Add(this.dgvHabitaciones);
            this.groupDatos.Controls.Add(this.btnAgregarHabitacion);
            this.groupDatos.Controls.Add(this.txtRegimen);
            this.groupDatos.Controls.Add(this.txtCostoXDia);
            this.groupDatos.Controls.Add(this.lblCostoXDia);
            this.groupDatos.Controls.Add(this.cmbHotel);
            this.groupDatos.Controls.Add(this.lblSeleccionarHotel);
            this.groupDatos.Controls.Add(this.btnRegimenes);
            this.groupDatos.Controls.Add(this.lblFechaDesd);
            this.groupDatos.Controls.Add(this.dtpFechaHasta);
            this.groupDatos.Controls.Add(this.lblFechaHast);
            this.groupDatos.Controls.Add(this.dtpFechaDesde);
            this.groupDatos.Controls.Add(this.lblTipoHab);
            this.groupDatos.Location = new System.Drawing.Point(19, 11);
            this.groupDatos.Name = "groupDatos";
            this.groupDatos.Size = new System.Drawing.Size(364, 329);
            this.groupDatos.TabIndex = 0;
            this.groupDatos.TabStop = false;
            this.groupDatos.Text = "Datos Reserva";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.AllowUserToResizeColumns = false;
            this.dgvHabitaciones.AllowUserToResizeRows = false;
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descripcion,
            this.capacidad});
            this.dgvHabitaciones.Location = new System.Drawing.Point(22, 175);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.Size = new System.Drawing.Size(313, 97);
            this.dgvHabitaciones.TabIndex = 5;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // capacidad
            // 
            this.capacidad.HeaderText = "capacidad";
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(139, 137);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(199, 23);
            this.btnAgregarHabitacion.TabIndex = 4;
            this.btnAgregarHabitacion.Text = "Agregar Habitacion";
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click);
            // 
            // txtRegimen
            // 
            this.txtRegimen.Location = new System.Drawing.Point(173, 110);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.ReadOnly = true;
            this.txtRegimen.Size = new System.Drawing.Size(164, 20);
            this.txtRegimen.TabIndex = 16;
            this.txtRegimen.TabStop = false;
            this.txtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegimen.TextChanged += new System.EventHandler(this.txtRegimen_TextChanged);
            // 
            // txtCostoXDia
            // 
            this.txtCostoXDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoXDia.Location = new System.Drawing.Point(138, 287);
            this.txtCostoXDia.Name = "txtCostoXDia";
            this.txtCostoXDia.ReadOnly = true;
            this.txtCostoXDia.Size = new System.Drawing.Size(199, 21);
            this.txtCostoXDia.TabIndex = 7;
            this.txtCostoXDia.TabStop = false;
            this.txtCostoXDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCostoXDia
            // 
            this.lblCostoXDia.AutoSize = true;
            this.lblCostoXDia.Location = new System.Drawing.Point(19, 291);
            this.lblCostoXDia.Name = "lblCostoXDia";
            this.lblCostoXDia.Size = new System.Drawing.Size(72, 13);
            this.lblCostoXDia.TabIndex = 15;
            this.lblCostoXDia.Text = "Costo por dia:";
            // 
            // cmbHotel
            // 
            this.cmbHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHotel.FormattingEnabled = true;
            this.cmbHotel.Location = new System.Drawing.Point(138, 27);
            this.cmbHotel.Name = "cmbHotel";
            this.cmbHotel.Size = new System.Drawing.Size(199, 21);
            this.cmbHotel.TabIndex = 0;
            this.cmbHotel.Tag = "";
            this.cmbHotel.SelectedIndexChanged += new System.EventHandler(this.cmbHotel_SelectedIndexChanged);
            // 
            // lblSeleccionarHotel
            // 
            this.lblSeleccionarHotel.AutoSize = true;
            this.lblSeleccionarHotel.Location = new System.Drawing.Point(21, 35);
            this.lblSeleccionarHotel.Name = "lblSeleccionarHotel";
            this.lblSeleccionarHotel.Size = new System.Drawing.Size(94, 13);
            this.lblSeleccionarHotel.TabIndex = 14;
            this.lblSeleccionarHotel.Text = "Seleccionar Hotel:";
            // 
            // txtResul
            // 
            this.txtResul.Location = new System.Drawing.Point(157, 22);
            this.txtResul.Name = "txtResul";
            this.txtResul.ReadOnly = true;
            this.txtResul.Size = new System.Drawing.Size(156, 20);
            this.txtResul.TabIndex = 9;
            this.txtResul.TabStop = false;
            this.txtResul.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbPanel2
            // 
            this.grbPanel2.AutoSize = true;
            this.grbPanel2.Controls.Add(this.lblEstado);
            this.grbPanel2.Controls.Add(this.txtCostoTotal);
            this.grbPanel2.Controls.Add(this.label2);
            this.grbPanel2.Controls.Add(this.txtResul);
            this.grbPanel2.Location = new System.Drawing.Point(19, 350);
            this.grbPanel2.Name = "grbPanel2";
            this.grbPanel2.Size = new System.Drawing.Size(364, 86);
            this.grbPanel2.TabIndex = 15;
            this.grbPanel2.TabStop = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(65, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(86, 13);
            this.lblEstado.TabIndex = 16;
            this.lblEstado.Text = "Estado Reserva:";
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCostoTotal.Location = new System.Drawing.Point(157, 46);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.ReadOnly = true;
            this.txtCostoTotal.Size = new System.Drawing.Size(156, 21);
            this.txtCostoTotal.TabIndex = 10;
            this.txtCostoTotal.TabStop = false;
            this.txtCostoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Costo total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Location = new System.Drawing.Point(19, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 50);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(92, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Volver";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.AutoSize = true;
            this.btnSiguiente.Location = new System.Drawing.Point(173, 19);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(104, 23);
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguietne_Click);
            // 
            // frmGenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 518);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPanel2);
            this.Controls.Add(this.groupDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGenerarReserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Reserva";
            this.Load += new System.EventHandler(this.frmGenerarReserva_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenerarReserva_FormClosing);
            this.groupDatos.ResumeLayout(false);
            this.groupDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.grbPanel2.ResumeLayout(false);
            this.grbPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaDesd;
        private System.Windows.Forms.Label lblFechaHast;
        private System.Windows.Forms.Label lblTipoHab;
        private System.Windows.Forms.Button btnRegimenes;
        private System.Windows.Forms.GroupBox groupDatos;
        private System.Windows.Forms.TextBox txtResul;
        private System.Windows.Forms.GroupBox grbPanel2;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ComboBox cmbHotel;
        private System.Windows.Forms.Label lblSeleccionarHotel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCostoXDia;
        private System.Windows.Forms.TextBox txtCostoXDia;
        private System.Windows.Forms.TextBox txtRegimen;
        public System.Windows.Forms.DateTimePicker dtpFechaDesde;
        public System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
    }
}