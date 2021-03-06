﻿namespace FrbaHotel.Listado_Estadistico
{
    partial class frmListadoEstadistico
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
            System.Windows.Forms.Label lblTipoListado;
            this.lblAño = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.lblTrim = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.cmbTipoListado = new System.Windows.Forms.ComboBox();
            this.groupListado = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            lblTipoListado = new System.Windows.Forms.Label();
            this.groupListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipoListado
            // 
            lblTipoListado.AutoSize = true;
            lblTipoListado.Location = new System.Drawing.Point(19, 89);
            lblTipoListado.Name = "lblTipoListado";
            lblTipoListado.Size = new System.Drawing.Size(68, 13);
            lblTipoListado.TabIndex = 4;
            lblTipoListado.Text = "Tipo Listado:";
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(19, 29);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(29, 13);
            this.lblAño.TabIndex = 0;
            this.lblAño.Text = "Año:";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(93, 21);
            this.txtAño.MaxLength = 4;
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(362, 20);
            this.txtAño.TabIndex = 1;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // lblTrim
            // 
            this.lblTrim.AutoSize = true;
            this.lblTrim.Location = new System.Drawing.Point(19, 59);
            this.lblTrim.Name = "lblTrim";
            this.lblTrim.Size = new System.Drawing.Size(53, 13);
            this.lblTrim.TabIndex = 2;
            this.lblTrim.Text = "Trimestre:";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Trimestre 1:   01 - 01  - ->  03 - 31",
            "Trimestre 2:   04 - 01  - ->  06 - 30",
            "Trimestre 3:   07 - 01  - ->  09 - 30",
            "Trimestre 4:   10 - 01  - ->  12 - 31"});
            this.cmbTrimestre.Location = new System.Drawing.Point(93, 51);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(362, 21);
            this.cmbTrimestre.TabIndex = 3;
            // 
            // cmbTipoListado
            // 
            this.cmbTipoListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoListado.FormattingEnabled = true;
            this.cmbTipoListado.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas",
            "Hoteles con mayor cantidad de consumibles facturados",
            "Hoteles con mayor cantidad de dias fuera de servicio",
            "Habitaciones con mayor cantidad de dias y veces que fueron ocupadas",
            "Cliente con mayor cantidad de puntos"});
            this.cmbTipoListado.Location = new System.Drawing.Point(93, 81);
            this.cmbTipoListado.Name = "cmbTipoListado";
            this.cmbTipoListado.Size = new System.Drawing.Size(362, 21);
            this.cmbTipoListado.TabIndex = 5;
            this.cmbTipoListado.SelectedIndexChanged += new System.EventHandler(this.cmbTipoListado_SelectedIndexChanged);
            // 
            // groupListado
            // 
            this.groupListado.Controls.Add(this.lblMsg);
            this.groupListado.Controls.Add(this.btnGenerar);
            this.groupListado.Controls.Add(this.cmbTipoListado);
            this.groupListado.Controls.Add(this.lblAño);
            this.groupListado.Controls.Add(lblTipoListado);
            this.groupListado.Controls.Add(this.txtAño);
            this.groupListado.Controls.Add(this.cmbTrimestre);
            this.groupListado.Controls.Add(this.lblTrim);
            this.groupListado.Location = new System.Drawing.Point(15, 12);
            this.groupListado.Name = "groupListado";
            this.groupListado.Size = new System.Drawing.Size(685, 137);
            this.groupListado.TabIndex = 6;
            this.groupListado.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(119, 116);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 7;
            // 
            // btnGenerar
            // 
            this.btnGenerar.AutoSize = true;
            this.btnGenerar.Location = new System.Drawing.Point(533, 38);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(120, 55);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar Listado";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeColumns = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(15, 178);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(687, 143);
            this.dgvListado.TabIndex = 7;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(627, 332);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmListadoEstadistico
            // 
            this.AcceptButton = this.btnGenerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 368);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.groupListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmListadoEstadistico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadistico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListadoEstadistico_FormClosing);
            this.groupListado.ResumeLayout(false);
            this.groupListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label lblTrim;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.ComboBox cmbTipoListado;
        private System.Windows.Forms.GroupBox groupListado;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblMsg;
    }
}