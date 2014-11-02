﻿namespace FrbaHotel.Generar_Modificar_Reserva
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
            this.cmbTipoHab = new System.Windows.Forms.ComboBox();
            this.btnCheckRes = new System.Windows.Forms.Button();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnRegimenes = new System.Windows.Forms.Button();
            this.grbPanel1 = new System.Windows.Forms.GroupBox();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.txtCostoXDia = new System.Windows.Forms.TextBox();
            this.lblCostoXDia = new System.Windows.Forms.Label();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarHotel = new System.Windows.Forms.Label();
            this.txtCantHues = new System.Windows.Forms.TextBox();
            this.lblCantHues = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbPanel2 = new System.Windows.Forms.GroupBox();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.grbPanel1.SuspendLayout();
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
            this.lblTipoHab.Location = new System.Drawing.Point(19, 142);
            this.lblTipoHab.Name = "lblTipoHab";
            this.lblTipoHab.Size = new System.Drawing.Size(85, 13);
            this.lblTipoHab.TabIndex = 0;
            this.lblTipoHab.Text = "Tipo Habitacion:";
            // 
            // cmbTipoHab
            // 
            this.cmbTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoHab.FormattingEnabled = true;
            this.cmbTipoHab.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbTipoHab.Location = new System.Drawing.Point(138, 134);
            this.cmbTipoHab.Name = "cmbTipoHab";
            this.cmbTipoHab.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoHab.TabIndex = 4;
            this.cmbTipoHab.Tag = "Tipo habitacion";
            // 
            // btnCheckRes
            // 
            this.btnCheckRes.Location = new System.Drawing.Point(22, 19);
            this.btnCheckRes.Name = "btnCheckRes";
            this.btnCheckRes.Size = new System.Drawing.Size(129, 23);
            this.btnCheckRes.TabIndex = 8;
            this.btnCheckRes.Text = "Verificar disponibilidad";
            this.btnCheckRes.UseVisualStyleBackColor = true;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(138, 55);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDesde.TabIndex = 1;
            this.dtpFechaDesde.Tag = "Fecha desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(138, 82);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHasta.TabIndex = 2;
            this.dtpFechaHasta.Tag = "Fecha hasta";
            // 
            // btnRegimenes
            // 
            this.btnRegimenes.AutoSize = true;
            this.btnRegimenes.Location = new System.Drawing.Point(22, 171);
            this.btnRegimenes.Name = "btnRegimenes";
            this.btnRegimenes.Size = new System.Drawing.Size(141, 23);
            this.btnRegimenes.TabIndex = 6;
            this.btnRegimenes.Text = "Seleccionar regimen";
            this.btnRegimenes.UseVisualStyleBackColor = true;
            this.btnRegimenes.Click += new System.EventHandler(this.btnRegimenes_Click);
            // 
            // grbPanel1
            // 
            this.grbPanel1.AutoSize = true;
            this.grbPanel1.Controls.Add(this.txtRegimen);
            this.grbPanel1.Controls.Add(this.txtCostoXDia);
            this.grbPanel1.Controls.Add(this.lblCostoXDia);
            this.grbPanel1.Controls.Add(this.cmbHotel);
            this.grbPanel1.Controls.Add(this.lblSeleccionarHotel);
            this.grbPanel1.Controls.Add(this.txtCantHues);
            this.grbPanel1.Controls.Add(this.lblCantHues);
            this.grbPanel1.Controls.Add(this.btnRegimenes);
            this.grbPanel1.Controls.Add(this.lblFechaDesd);
            this.grbPanel1.Controls.Add(this.dtpFechaHasta);
            this.grbPanel1.Controls.Add(this.lblFechaHast);
            this.grbPanel1.Controls.Add(this.dtpFechaDesde);
            this.grbPanel1.Controls.Add(this.lblTipoHab);
            this.grbPanel1.Controls.Add(this.cmbTipoHab);
            this.grbPanel1.Location = new System.Drawing.Point(19, 11);
            this.grbPanel1.Name = "grbPanel1";
            this.grbPanel1.Size = new System.Drawing.Size(364, 262);
            this.grbPanel1.TabIndex = 0;
            this.grbPanel1.TabStop = false;
            this.grbPanel1.Text = "Datos Reserva";
            // 
            // txtRegimen
            // 
            this.txtRegimen.Location = new System.Drawing.Point(173, 173);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.ReadOnly = true;
            this.txtRegimen.Size = new System.Drawing.Size(164, 20);
            this.txtRegimen.TabIndex = 16;
            // 
            // txtCostoXDia
            // 
            this.txtCostoXDia.Enabled = false;
            this.txtCostoXDia.Location = new System.Drawing.Point(138, 215);
            this.txtCostoXDia.Name = "txtCostoXDia";
            this.txtCostoXDia.Size = new System.Drawing.Size(199, 20);
            this.txtCostoXDia.TabIndex = 7;
            // 
            // lblCostoXDia
            // 
            this.lblCostoXDia.AutoSize = true;
            this.lblCostoXDia.Location = new System.Drawing.Point(19, 219);
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
            // txtCantHues
            // 
            this.txtCantHues.Location = new System.Drawing.Point(137, 108);
            this.txtCantHues.MaxLength = 3;
            this.txtCantHues.Name = "txtCantHues";
            this.txtCantHues.Size = new System.Drawing.Size(200, 20);
            this.txtCantHues.TabIndex = 3;
            this.txtCantHues.Tag = "Cantidad de huespedes";
            this.txtCantHues.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantHues_KeyPress);
            // 
            // lblCantHues
            // 
            this.lblCantHues.AutoSize = true;
            this.lblCantHues.Location = new System.Drawing.Point(19, 115);
            this.lblCantHues.Name = "lblCantHues";
            this.lblCantHues.Size = new System.Drawing.Size(109, 13);
            this.lblCantHues.TabIndex = 1;
            this.lblCantHues.Text = "Cantidad Huespedes:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 9;
            // 
            // grbPanel2
            // 
            this.grbPanel2.AutoSize = true;
            this.grbPanel2.Controls.Add(this.txtCostoTotal);
            this.grbPanel2.Controls.Add(this.label2);
            this.grbPanel2.Controls.Add(this.btnCheckRes);
            this.grbPanel2.Controls.Add(this.textBox1);
            this.grbPanel2.Location = new System.Drawing.Point(19, 286);
            this.grbPanel2.Name = "grbPanel2";
            this.grbPanel2.Size = new System.Drawing.Size(364, 85);
            this.grbPanel2.TabIndex = 15;
            this.grbPanel2.TabStop = false;
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.Location = new System.Drawing.Point(157, 46);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.ReadOnly = true;
            this.txtCostoTotal.Size = new System.Drawing.Size(156, 20);
            this.txtCostoTotal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Costo total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Location = new System.Drawing.Point(19, 385);
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
            this.btnCancel.TabIndex = 9;
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
            this.btnSiguiente.TabIndex = 11;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguietne_Click);
            // 
            // frmGenerarReserva
            // 
            this.AcceptButton = this.btnCheckRes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 456);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPanel2);
            this.Controls.Add(this.grbPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGenerarReserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Reserva";
            this.Load += new System.EventHandler(this.frmGenerarReserva_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenerarReserva_FormClosing);
            this.grbPanel1.ResumeLayout(false);
            this.grbPanel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbTipoHab;
        private System.Windows.Forms.Button btnCheckRes;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnRegimenes;
        private System.Windows.Forms.GroupBox grbPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grbPanel2;
        private System.Windows.Forms.TextBox txtCantHues;
        private System.Windows.Forms.Label lblCantHues;
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
    }
}