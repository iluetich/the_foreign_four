namespace FrbaHotel.Cancelar_Reserva
{
    partial class frmCancelarReserva
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
            this.lblNroReserva = new System.Windows.Forms.Label();
            this.groupCancelar = new System.Windows.Forms.GroupBox();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtCodReserva = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.groupCancelar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNroReserva
            // 
            this.lblNroReserva.AutoSize = true;
            this.lblNroReserva.Location = new System.Drawing.Point(26, 37);
            this.lblNroReserva.Name = "lblNroReserva";
            this.lblNroReserva.Size = new System.Drawing.Size(81, 13);
            this.lblNroReserva.TabIndex = 0;
            this.lblNroReserva.Text = "Codigo reserva:";
            // 
            // groupCancelar
            // 
            this.groupCancelar.Controls.Add(this.btnCancelarReserva);
            this.groupCancelar.Controls.Add(this.btnVolver);
            this.groupCancelar.Controls.Add(this.txtMotivo);
            this.groupCancelar.Controls.Add(this.txtCodReserva);
            this.groupCancelar.Controls.Add(this.lblMotivo);
            this.groupCancelar.Controls.Add(this.lblNroReserva);
            this.groupCancelar.Location = new System.Drawing.Point(27, 26);
            this.groupCancelar.Name = "groupCancelar";
            this.groupCancelar.Size = new System.Drawing.Size(389, 196);
            this.groupCancelar.TabIndex = 1;
            this.groupCancelar.TabStop = false;
            this.groupCancelar.Text = "Datos reserva";
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(197, 122);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(115, 38);
            this.btnCancelarReserva.TabIndex = 9;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(74, 122);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 38);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(150, 63);
            this.txtMotivo.MaxLength = 255;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(200, 20);
            this.txtMotivo.TabIndex = 5;
            // 
            // txtCodReserva
            // 
            this.txtCodReserva.Location = new System.Drawing.Point(150, 30);
            this.txtCodReserva.Name = "txtCodReserva";
            this.txtCodReserva.Size = new System.Drawing.Size(200, 20);
            this.txtCodReserva.TabIndex = 4;
            this.txtCodReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodReserva_KeyPress);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(26, 70);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 1;
            this.lblMotivo.Text = "Motivo:";
            // 
            // frmCancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(448, 244);
            this.Controls.Add(this.groupCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCancelarReserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Reserva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCancelarReserva_FormClosing);
            this.groupCancelar.ResumeLayout(false);
            this.groupCancelar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNroReserva;
        private System.Windows.Forms.GroupBox groupCancelar;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtCodReserva;
        private System.Windows.Forms.Label lblMotivo;
    }
}