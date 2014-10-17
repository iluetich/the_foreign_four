namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class GenerarReserva
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
            this.lblTipoReg = new System.Windows.Forms.Label();
            this.cmbTipoReg = new System.Windows.Forms.ComboBox();
            this.btnCheckRes = new System.Windows.Forms.Button();
            this.cmbFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblFechaDesd
            // 
            this.lblFechaDesd.AutoSize = true;
            this.lblFechaDesd.Location = new System.Drawing.Point(19, 30);
            this.lblFechaDesd.Name = "lblFechaDesd";
            this.lblFechaDesd.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDesd.TabIndex = 0;
            this.lblFechaDesd.Text = "Fecha desde:";
            // 
            // lblFechaHast
            // 
            this.lblFechaHast.AutoSize = true;
            this.lblFechaHast.Location = new System.Drawing.Point(19, 53);
            this.lblFechaHast.Name = "lblFechaHast";
            this.lblFechaHast.Size = new System.Drawing.Size(69, 13);
            this.lblFechaHast.TabIndex = 1;
            this.lblFechaHast.Text = "Fecha hasta:";
            // 
            // lblTipoHab
            // 
            this.lblTipoHab.AutoSize = true;
            this.lblTipoHab.Location = new System.Drawing.Point(17, 88);
            this.lblTipoHab.Name = "lblTipoHab";
            this.lblTipoHab.Size = new System.Drawing.Size(85, 13);
            this.lblTipoHab.TabIndex = 4;
            this.lblTipoHab.Text = "Tipo Habitación:";
            // 
            // cmbTipoHab
            // 
            this.cmbTipoHab.FormattingEnabled = true;
            this.cmbTipoHab.Location = new System.Drawing.Point(111, 83);
            this.cmbTipoHab.Name = "cmbTipoHab";
            this.cmbTipoHab.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoHab.TabIndex = 5;
            // 
            // lblTipoReg
            // 
            this.lblTipoReg.AutoSize = true;
            this.lblTipoReg.Location = new System.Drawing.Point(18, 120);
            this.lblTipoReg.Name = "lblTipoReg";
            this.lblTipoReg.Size = new System.Drawing.Size(76, 13);
            this.lblTipoReg.TabIndex = 6;
            this.lblTipoReg.Text = "Tipo Régimen:";
            // 
            // cmbTipoReg
            // 
            this.cmbTipoReg.FormattingEnabled = true;
            this.cmbTipoReg.Location = new System.Drawing.Point(111, 114);
            this.cmbTipoReg.Name = "cmbTipoReg";
            this.cmbTipoReg.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoReg.TabIndex = 7;
            // 
            // btnCheckRes
            // 
            this.btnCheckRes.Location = new System.Drawing.Point(103, 215);
            this.btnCheckRes.Name = "btnCheckRes";
            this.btnCheckRes.Size = new System.Drawing.Size(129, 23);
            this.btnCheckRes.TabIndex = 8;
            this.btnCheckRes.Text = "Verificar disponibilidad";
            this.btnCheckRes.UseVisualStyleBackColor = true;
            // 
            // cmbFechaDesde
            // 
            this.cmbFechaDesde.Location = new System.Drawing.Point(111, 22);
            this.cmbFechaDesde.Name = "cmbFechaDesde";
            this.cmbFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.cmbFechaDesde.TabIndex = 9;
            // 
            // cmbFechaHasta
            // 
            this.cmbFechaHasta.Location = new System.Drawing.Point(111, 53);
            this.cmbFechaHasta.Name = "cmbFechaHasta";
            this.cmbFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.cmbFechaHasta.TabIndex = 10;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 266);
            this.Controls.Add(this.cmbFechaHasta);
            this.Controls.Add(this.cmbFechaDesde);
            this.Controls.Add(this.btnCheckRes);
            this.Controls.Add(this.cmbTipoReg);
            this.Controls.Add(this.lblTipoReg);
            this.Controls.Add(this.cmbTipoHab);
            this.Controls.Add(this.lblTipoHab);
            this.Controls.Add(this.lblFechaHast);
            this.Controls.Add(this.lblFechaDesd);
            this.Name = "GenerarReserva";
            this.Text = "Nueva Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaDesd;
        private System.Windows.Forms.Label lblFechaHast;
        private System.Windows.Forms.Label lblTipoHab;
        private System.Windows.Forms.ComboBox cmbTipoHab;
        private System.Windows.Forms.Label lblTipoReg;
        private System.Windows.Forms.ComboBox cmbTipoReg;
        private System.Windows.Forms.Button btnCheckRes;
        private System.Windows.Forms.DateTimePicker cmbFechaDesde;
        private System.Windows.Forms.DateTimePicker cmbFechaHasta;
    }
}