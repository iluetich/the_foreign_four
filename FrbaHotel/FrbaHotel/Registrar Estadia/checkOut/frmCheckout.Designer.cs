namespace FrbaHotel.Registrar_Estadia.checkOut
{
    partial class frmCheckout
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
            this.groupBotonera = new System.Windows.Forms.GroupBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnMasDias = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBotonera
            // 
            this.groupBotonera.Controls.Add(this.btnCheckout);
            this.groupBotonera.Controls.Add(this.btnMasDias);
            this.groupBotonera.Location = new System.Drawing.Point(39, 23);
            this.groupBotonera.Name = "groupBotonera";
            this.groupBotonera.Size = new System.Drawing.Size(353, 68);
            this.groupBotonera.TabIndex = 0;
            this.groupBotonera.TabStop = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.AutoSize = true;
            this.btnCheckout.Location = new System.Drawing.Point(177, 19);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(119, 34);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Proceder al checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnMasDias
            // 
            this.btnMasDias.AutoSize = true;
            this.btnMasDias.Location = new System.Drawing.Point(61, 19);
            this.btnMasDias.Name = "btnMasDias";
            this.btnMasDias.Size = new System.Drawing.Size(110, 34);
            this.btnMasDias.TabIndex = 0;
            this.btnMasDias.Text = "Quedarme mas dias";
            this.btnMasDias.UseVisualStyleBackColor = true;
            this.btnMasDias.Click += new System.EventHandler(this.btnMasDias_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(12, 125);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(443, 160);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.groupBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCheckout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Out";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckout_FormClosing);
            this.groupBotonera.ResumeLayout(false);
            this.groupBotonera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBotonera;
        private System.Windows.Forms.Button btnMasDias;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnVolver;
    }
}