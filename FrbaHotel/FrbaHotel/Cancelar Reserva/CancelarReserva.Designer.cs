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
            this.dtpFechaCancel = new System.Windows.Forms.DateTimePicker();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtCodReserva = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblFechaCancel = new System.Windows.Forms.Label();
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
            this.groupCancelar.Controls.Add(this.dtpFechaCancel);
            this.groupCancelar.Controls.Add(this.btnCancelarReserva);
            this.groupCancelar.Controls.Add(this.btnVolver);
            this.groupCancelar.Controls.Add(this.txtUsuario);
            this.groupCancelar.Controls.Add(this.txtMotivo);
            this.groupCancelar.Controls.Add(this.txtCodReserva);
            this.groupCancelar.Controls.Add(this.lblUser);
            this.groupCancelar.Controls.Add(this.lblFechaCancel);
            this.groupCancelar.Controls.Add(this.lblMotivo);
            this.groupCancelar.Controls.Add(this.lblNroReserva);
            this.groupCancelar.Location = new System.Drawing.Point(27, 26);
            this.groupCancelar.Name = "groupCancelar";
            this.groupCancelar.Size = new System.Drawing.Size(389, 250);
            this.groupCancelar.TabIndex = 1;
            this.groupCancelar.TabStop = false;
            this.groupCancelar.Text = "Datos reserva";
            // 
            // dtpFechaCancel
            // 
            this.dtpFechaCancel.Location = new System.Drawing.Point(150, 96);
            this.dtpFechaCancel.Name = "dtpFechaCancel";
            this.dtpFechaCancel.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCancel.TabIndex = 10;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(191, 180);
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
            this.btnVolver.Location = new System.Drawing.Point(68, 180);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 38);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(150, 129);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(150, 63);
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
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(26, 134);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(46, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Usuario:";
            // 
            // lblFechaCancel
            // 
            this.lblFechaCancel.AutoSize = true;
            this.lblFechaCancel.Location = new System.Drawing.Point(26, 103);
            this.lblFechaCancel.Name = "lblFechaCancel";
            this.lblFechaCancel.Size = new System.Drawing.Size(101, 13);
            this.lblFechaCancel.TabIndex = 2;
            this.lblFechaCancel.Text = "Fecha cancelacion:";
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
            this.ClientSize = new System.Drawing.Size(448, 304);
            this.Controls.Add(this.groupCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCancelarReserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Reserva";
            this.groupCancelar.ResumeLayout(false);
            this.groupCancelar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNroReserva;
        private System.Windows.Forms.GroupBox groupCancelar;
        private System.Windows.Forms.DateTimePicker dtpFechaCancel;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtCodReserva;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblFechaCancel;
        private System.Windows.Forms.Label lblMotivo;
    }
}