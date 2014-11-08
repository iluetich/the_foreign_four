namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class frmCliente
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
            this.btnNuevlClt = new System.Windows.Forms.Button();
            this.btnRegistrado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoReserva = new System.Windows.Forms.TextBox();
            this.btnConfirmarReserva = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtIden = new System.Windows.Forms.TextBox();
            this.txtTipoIden = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevlClt
            // 
            this.btnNuevlClt.AutoSize = true;
            this.btnNuevlClt.Location = new System.Drawing.Point(50, 19);
            this.btnNuevlClt.Name = "btnNuevlClt";
            this.btnNuevlClt.Size = new System.Drawing.Size(84, 23);
            this.btnNuevlClt.TabIndex = 0;
            this.btnNuevlClt.Text = "Nuevo Cliente";
            this.btnNuevlClt.UseVisualStyleBackColor = true;
            this.btnNuevlClt.Click += new System.EventHandler(this.btnNuevlClt_Click);
            // 
            // btnRegistrado
            // 
            this.btnRegistrado.AutoSize = true;
            this.btnRegistrado.Location = new System.Drawing.Point(140, 19);
            this.btnRegistrado.Name = "btnRegistrado";
            this.btnRegistrado.Size = new System.Drawing.Size(107, 23);
            this.btnRegistrado.TabIndex = 1;
            this.btnRegistrado.Text = "Ya estoy registrado";
            this.btnRegistrado.UseVisualStyleBackColor = true;
            this.btnRegistrado.Click += new System.EventHandler(this.btnRegistrado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrado);
            this.groupBox1.Controls.Add(this.btnNuevlClt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(47, 243);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(96, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código de reserva:";
            // 
            // txtCodigoReserva
            // 
            this.txtCodigoReserva.Location = new System.Drawing.Point(147, 239);
            this.txtCodigoReserva.Name = "txtCodigoReserva";
            this.txtCodigoReserva.ReadOnly = true;
            this.txtCodigoReserva.Size = new System.Drawing.Size(128, 20);
            this.txtCodigoReserva.TabIndex = 4;
            this.txtCodigoReserva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConfirmarReserva
            // 
            this.btnConfirmarReserva.AutoSize = true;
            this.btnConfirmarReserva.Location = new System.Drawing.Point(86, 204);
            this.btnConfirmarReserva.Name = "btnConfirmarReserva";
            this.btnConfirmarReserva.Size = new System.Drawing.Size(134, 26);
            this.btnConfirmarReserva.TabIndex = 5;
            this.btnConfirmarReserva.Text = "Confirmar reserva";
            this.btnConfirmarReserva.UseVisualStyleBackColor = true;
            this.btnConfirmarReserva.Click += new System.EventHandler(this.btnConfirmarReserva_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMail);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.txtIden);
            this.groupBox2.Controls.Add(this.txtTipoIden);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Cliente";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(41, 65);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Mail:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(79, 58);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(174, 20);
            this.txtMail.TabIndex = 2;
            // 
            // txtIden
            // 
            this.txtIden.Location = new System.Drawing.Point(111, 32);
            this.txtIden.Name = "txtIden";
            this.txtIden.ReadOnly = true;
            this.txtIden.Size = new System.Drawing.Size(139, 20);
            this.txtIden.TabIndex = 1;
            // 
            // txtTipoIden
            // 
            this.txtTipoIden.Location = new System.Drawing.Point(44, 32);
            this.txtTipoIden.Name = "txtTipoIden";
            this.txtTipoIden.ReadOnly = true;
            this.txtTipoIden.Size = new System.Drawing.Size(59, 20);
            this.txtTipoIden.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(239, 281);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmCliente
            // 
            this.AcceptButton = this.btnConfirmarReserva;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(320, 310);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConfirmarReserva);
            this.Controls.Add(this.txtCodigoReserva);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cliente_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevlClt;
        private System.Windows.Forms.Button btnRegistrado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigoReserva;
        private System.Windows.Forms.Button btnConfirmarReserva;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtTipoIden;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtIden;
    }
}