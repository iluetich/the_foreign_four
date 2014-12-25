namespace FrbaHotel.Registrar_Consumible
{
    partial class frmFacturacion
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
            this.groupFacturaDetalle = new System.Windows.Forms.GroupBox();
            this.dgvFacturaDetalle = new System.Windows.Forms.DataGridView();
            this.groupDetalleDias = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTarjeta = new System.Windows.Forms.RadioButton();
            this.rbtnContado = new System.Windows.Forms.RadioButton();
            this.txtNroTarj = new System.Windows.Forms.TextBox();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.lbltNroTarj = new System.Windows.Forms.Label();
            this.groupFacturaDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDetalle)).BeginInit();
            this.groupDetalleDias.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFacturaDetalle
            // 
            this.groupFacturaDetalle.Controls.Add(this.dgvFacturaDetalle);
            this.groupFacturaDetalle.Location = new System.Drawing.Point(13, 13);
            this.groupFacturaDetalle.Name = "groupFacturaDetalle";
            this.groupFacturaDetalle.Size = new System.Drawing.Size(680, 256);
            this.groupFacturaDetalle.TabIndex = 0;
            this.groupFacturaDetalle.TabStop = false;
            this.groupFacturaDetalle.Text = "Detalle factura";
            // 
            // dgvFacturaDetalle
            // 
            this.dgvFacturaDetalle.AllowUserToAddRows = false;
            this.dgvFacturaDetalle.AllowUserToDeleteRows = false;
            this.dgvFacturaDetalle.AllowUserToResizeColumns = false;
            this.dgvFacturaDetalle.AllowUserToResizeRows = false;
            this.dgvFacturaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturaDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturaDetalle.Location = new System.Drawing.Point(15, 29);
            this.dgvFacturaDetalle.Name = "dgvFacturaDetalle";
            this.dgvFacturaDetalle.ReadOnly = true;
            this.dgvFacturaDetalle.Size = new System.Drawing.Size(639, 204);
            this.dgvFacturaDetalle.TabIndex = 0;
            // 
            // groupDetalleDias
            // 
            this.groupDetalleDias.Controls.Add(this.groupBox1);
            this.groupDetalleDias.Controls.Add(this.txtNroTarj);
            this.groupDetalleDias.Controls.Add(this.btnEmitirFactura);
            this.groupDetalleDias.Controls.Add(this.lbltNroTarj);
            this.groupDetalleDias.Location = new System.Drawing.Point(13, 289);
            this.groupDetalleDias.Name = "groupDetalleDias";
            this.groupDetalleDias.Size = new System.Drawing.Size(680, 142);
            this.groupDetalleDias.TabIndex = 1;
            this.groupDetalleDias.TabStop = false;
            this.groupDetalleDias.Text = "Informacion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnTarjeta);
            this.groupBox1.Controls.Add(this.rbtnContado);
            this.groupBox1.Location = new System.Drawing.Point(28, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 69);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formas de pago:";
            // 
            // rbtnTarjeta
            // 
            this.rbtnTarjeta.AutoSize = true;
            this.rbtnTarjeta.Location = new System.Drawing.Point(28, 44);
            this.rbtnTarjeta.Name = "rbtnTarjeta";
            this.rbtnTarjeta.Size = new System.Drawing.Size(58, 17);
            this.rbtnTarjeta.TabIndex = 1;
            this.rbtnTarjeta.TabStop = true;
            this.rbtnTarjeta.Text = "Tarjeta";
            this.rbtnTarjeta.UseVisualStyleBackColor = true;
            this.rbtnTarjeta.CheckedChanged += new System.EventHandler(this.rbtnTarjeta_CheckedChanged);
            // 
            // rbtnContado
            // 
            this.rbtnContado.AccessibleDescription = "";
            this.rbtnContado.AutoSize = true;
            this.rbtnContado.Location = new System.Drawing.Point(28, 20);
            this.rbtnContado.Name = "rbtnContado";
            this.rbtnContado.Size = new System.Drawing.Size(65, 17);
            this.rbtnContado.TabIndex = 0;
            this.rbtnContado.TabStop = true;
            this.rbtnContado.Text = "Contado";
            this.rbtnContado.UseVisualStyleBackColor = true;
            this.rbtnContado.CheckedChanged += new System.EventHandler(this.rbtnContado_CheckedChanged);
            // 
            // txtNroTarj
            // 
            this.txtNroTarj.Location = new System.Drawing.Point(101, 106);
            this.txtNroTarj.MaxLength = 30;
            this.txtNroTarj.Name = "txtNroTarj";
            this.txtNroTarj.Size = new System.Drawing.Size(121, 20);
            this.txtNroTarj.TabIndex = 7;
            this.txtNroTarj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroTarj_KeyPress);
            // 
            // btnEmitirFactura
            // 
            this.btnEmitirFactura.AutoSize = true;
            this.btnEmitirFactura.Location = new System.Drawing.Point(280, 27);
            this.btnEmitirFactura.Name = "btnEmitirFactura";
            this.btnEmitirFactura.Size = new System.Drawing.Size(352, 99);
            this.btnEmitirFactura.TabIndex = 0;
            this.btnEmitirFactura.Text = "Emitir Factura";
            this.btnEmitirFactura.UseVisualStyleBackColor = true;
            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirFactura_Click);
            // 
            // lbltNroTarj
            // 
            this.lbltNroTarj.AutoSize = true;
            this.lbltNroTarj.Location = new System.Drawing.Point(27, 110);
            this.lbltNroTarj.Name = "lbltNroTarj";
            this.lbltNroTarj.Size = new System.Drawing.Size(59, 13);
            this.lbltNroTarj.TabIndex = 6;
            this.lbltNroTarj.Text = "Nro tarjeta:";
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 455);
            this.Controls.Add(this.groupDetalleDias);
            this.Controls.Add(this.groupFacturaDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFacturacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emitir Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturacion_FormClosing);
            this.groupFacturaDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDetalle)).EndInit();
            this.groupDetalleDias.ResumeLayout(false);
            this.groupDetalleDias.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFacturaDetalle;
        private System.Windows.Forms.DataGridView dgvFacturaDetalle;
        private System.Windows.Forms.GroupBox groupDetalleDias;
        private System.Windows.Forms.Button btnEmitirFactura;
        private System.Windows.Forms.TextBox txtNroTarj;
        private System.Windows.Forms.Label lbltNroTarj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnTarjeta;
        private System.Windows.Forms.RadioButton rbtnContado;
    }
}