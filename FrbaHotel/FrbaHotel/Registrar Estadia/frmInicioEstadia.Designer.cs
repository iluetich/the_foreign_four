namespace FrbaHotel.Registrar_Estadia
{
    partial class frmInicioEstadia
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
            this.groupCheckin = new System.Windows.Forms.GroupBox();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.txtCodReserva = new System.Windows.Forms.TextBox();
            this.lblNroReserva = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.groupCheckout = new System.Windows.Forms.GroupBox();
            this.txtCodEstadia = new System.Windows.Forms.TextBox();
            this.lblCodEstadia = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.groupCheckin.SuspendLayout();
            this.groupCheckout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCheckin
            // 
            this.groupCheckin.Controls.Add(this.btnCheckin);
            this.groupCheckin.Controls.Add(this.txtCodReserva);
            this.groupCheckin.Controls.Add(this.lblNroReserva);
            this.groupCheckin.Location = new System.Drawing.Point(21, 23);
            this.groupCheckin.Name = "groupCheckin";
            this.groupCheckin.Size = new System.Drawing.Size(528, 103);
            this.groupCheckin.TabIndex = 0;
            this.groupCheckin.TabStop = false;
            this.groupCheckin.Text = "CHECK IN";
            // 
            // btnCheckin
            // 
            this.btnCheckin.Location = new System.Drawing.Point(359, 23);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(114, 43);
            this.btnCheckin.TabIndex = 1;
            this.btnCheckin.Text = "Check IN";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // txtCodReserva
            // 
            this.txtCodReserva.Location = new System.Drawing.Point(195, 35);
            this.txtCodReserva.MaxLength = 10;
            this.txtCodReserva.Name = "txtCodReserva";
            this.txtCodReserva.Size = new System.Drawing.Size(128, 20);
            this.txtCodReserva.TabIndex = 0;
            this.txtCodReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroReserva_KeyPress);
            // 
            // lblNroReserva
            // 
            this.lblNroReserva.AutoSize = true;
            this.lblNroReserva.Location = new System.Drawing.Point(95, 38);
            this.lblNroReserva.Name = "lblNroReserva";
            this.lblNroReserva.Size = new System.Drawing.Size(81, 13);
            this.lblNroReserva.TabIndex = 0;
            this.lblNroReserva.Text = "Codigo reserva:";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(359, 31);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(114, 43);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "Check OUT";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // groupCheckout
            // 
            this.groupCheckout.Controls.Add(this.txtCodEstadia);
            this.groupCheckout.Controls.Add(this.lblCodEstadia);
            this.groupCheckout.Controls.Add(this.btnCheckout);
            this.groupCheckout.Location = new System.Drawing.Point(21, 149);
            this.groupCheckout.Name = "groupCheckout";
            this.groupCheckout.Size = new System.Drawing.Size(528, 98);
            this.groupCheckout.TabIndex = 1;
            this.groupCheckout.TabStop = false;
            this.groupCheckout.Text = "CHECK OUT";
            // 
            // txtCodEstadia
            // 
            this.txtCodEstadia.Location = new System.Drawing.Point(195, 43);
            this.txtCodEstadia.Name = "txtCodEstadia";
            this.txtCodEstadia.Size = new System.Drawing.Size(128, 20);
            this.txtCodEstadia.TabIndex = 2;
            this.txtCodEstadia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodEstadia_KeyPress);
            // 
            // lblCodEstadia
            // 
            this.lblCodEstadia.AutoSize = true;
            this.lblCodEstadia.Location = new System.Drawing.Point(95, 50);
            this.lblCodEstadia.Name = "lblCodEstadia";
            this.lblCodEstadia.Size = new System.Drawing.Size(80, 13);
            this.lblCodEstadia.TabIndex = 4;
            this.lblCodEstadia.Text = "Codigo estadia:";
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(490, 255);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 2;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // frmInicioEstadia
            // 
            this.AcceptButton = this.btnCheckin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 290);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupCheckout);
            this.Controls.Add(this.groupCheckin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInicioEstadia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicioEstadia_FormClosing);
            this.groupCheckin.ResumeLayout(false);
            this.groupCheckin.PerformLayout();
            this.groupCheckout.ResumeLayout(false);
            this.groupCheckout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCheckin;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.TextBox txtCodReserva;
        private System.Windows.Forms.Label lblNroReserva;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.GroupBox groupCheckout;
        private System.Windows.Forms.TextBox txtCodEstadia;
        private System.Windows.Forms.Label lblCodEstadia;
        private System.Windows.Forms.Button botonVolver;
    }
}