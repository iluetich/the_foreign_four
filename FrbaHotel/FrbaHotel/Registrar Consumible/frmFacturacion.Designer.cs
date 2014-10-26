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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiasNoAlojados = new System.Windows.Forms.TextBox();
            this.txtDiasAlojados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBotonera = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.groupFacturaDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDetalle)).BeginInit();
            this.groupDetalleDias.SuspendLayout();
            this.groupBotonera.SuspendLayout();
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
            this.dgvFacturaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturaDetalle.Location = new System.Drawing.Point(15, 29);
            this.dgvFacturaDetalle.Name = "dgvFacturaDetalle";
            this.dgvFacturaDetalle.Size = new System.Drawing.Size(639, 204);
            this.dgvFacturaDetalle.TabIndex = 0;
            // 
            // groupDetalleDias
            // 
            this.groupDetalleDias.Controls.Add(this.comboBox1);
            this.groupDetalleDias.Controls.Add(this.label3);
            this.groupDetalleDias.Controls.Add(this.txtDiasNoAlojados);
            this.groupDetalleDias.Controls.Add(this.txtDiasAlojados);
            this.groupDetalleDias.Controls.Add(this.label2);
            this.groupDetalleDias.Controls.Add(this.label1);
            this.groupDetalleDias.Location = new System.Drawing.Point(13, 289);
            this.groupDetalleDias.Name = "groupDetalleDias";
            this.groupDetalleDias.Size = new System.Drawing.Size(680, 105);
            this.groupDetalleDias.TabIndex = 1;
            this.groupDetalleDias.TabStop = false;
            this.groupDetalleDias.Text = "Informacion";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(422, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Formas de pago:";
            // 
            // txtDiasNoAlojados
            // 
            this.txtDiasNoAlojados.Location = new System.Drawing.Point(168, 52);
            this.txtDiasNoAlojados.Name = "txtDiasNoAlojados";
            this.txtDiasNoAlojados.ReadOnly = true;
            this.txtDiasNoAlojados.Size = new System.Drawing.Size(100, 20);
            this.txtDiasNoAlojados.TabIndex = 3;
            // 
            // txtDiasAlojados
            // 
            this.txtDiasAlojados.Location = new System.Drawing.Point(168, 25);
            this.txtDiasAlojados.Name = "txtDiasAlojados";
            this.txtDiasAlojados.ReadOnly = true;
            this.txtDiasAlojados.Size = new System.Drawing.Size(100, 20);
            this.txtDiasAlojados.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dias no alojados:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dias alojados:";
            // 
            // groupBotonera
            // 
            this.groupBotonera.Controls.Add(this.btnCancelar);
            this.groupBotonera.Controls.Add(this.btnEmitirFactura);
            this.groupBotonera.Location = new System.Drawing.Point(13, 415);
            this.groupBotonera.Name = "groupBotonera";
            this.groupBotonera.Size = new System.Drawing.Size(680, 100);
            this.groupBotonera.TabIndex = 2;
            this.groupBotonera.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(219, 32);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 46);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEmitirFactura
            // 
            this.btnEmitirFactura.AutoSize = true;
            this.btnEmitirFactura.Location = new System.Drawing.Point(348, 32);
            this.btnEmitirFactura.Name = "btnEmitirFactura";
            this.btnEmitirFactura.Size = new System.Drawing.Size(123, 46);
            this.btnEmitirFactura.TabIndex = 0;
            this.btnEmitirFactura.Text = "Emitir Factura";
            this.btnEmitirFactura.UseVisualStyleBackColor = true;
            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirFactura_Click);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 537);
            this.Controls.Add(this.groupBotonera);
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
            this.groupBotonera.ResumeLayout(false);
            this.groupBotonera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFacturaDetalle;
        private System.Windows.Forms.DataGridView dgvFacturaDetalle;
        private System.Windows.Forms.GroupBox groupDetalleDias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiasNoAlojados;
        private System.Windows.Forms.TextBox txtDiasAlojados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBotonera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEmitirFactura;
    }
}