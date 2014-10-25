namespace FrbaHotel.Registrar_Estadia
{
    partial class frmRegistrarEstadia
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
            this.groupRegEst = new System.Windows.Forms.GroupBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtNroReserva = new System.Windows.Forms.TextBox();
            this.lblNroReserva = new System.Windows.Forms.Label();
            this.groupRegEst.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegEst
            // 
            this.groupRegEst.Controls.Add(this.btnRegistrar);
            this.groupRegEst.Controls.Add(this.txtNroReserva);
            this.groupRegEst.Controls.Add(this.lblNroReserva);
            this.groupRegEst.Location = new System.Drawing.Point(21, 23);
            this.groupRegEst.Name = "groupRegEst";
            this.groupRegEst.Size = new System.Drawing.Size(419, 92);
            this.groupRegEst.TabIndex = 0;
            this.groupRegEst.TabStop = false;
            this.groupRegEst.Text = "Ingreso datos";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(272, 34);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 23);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar Estadia";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtNroReserva
            // 
            this.txtNroReserva.Location = new System.Drawing.Point(130, 35);
            this.txtNroReserva.MaxLength = 10;
            this.txtNroReserva.Name = "txtNroReserva";
            this.txtNroReserva.Size = new System.Drawing.Size(128, 20);
            this.txtNroReserva.TabIndex = 1;
            this.txtNroReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroReserva_KeyPress);
            // 
            // lblNroReserva
            // 
            this.lblNroReserva.AutoSize = true;
            this.lblNroReserva.Location = new System.Drawing.Point(30, 38);
            this.lblNroReserva.Name = "lblNroReserva";
            this.lblNroReserva.Size = new System.Drawing.Size(81, 13);
            this.lblNroReserva.TabIndex = 0;
            this.lblNroReserva.Text = "Codigo reserva:";
            // 
            // frmRegistrarEstadia
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 139);
            this.Controls.Add(this.groupRegEst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegistrarEstadia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Estadia";
            this.groupRegEst.ResumeLayout(false);
            this.groupRegEst.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegEst;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtNroReserva;
        private System.Windows.Forms.Label lblNroReserva;
    }
}