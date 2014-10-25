namespace FrbaHotel.Registrar_Consumible
{
    partial class frmInicioRegistrarConsumible
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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.txtCodEstadia = new System.Windows.Forms.TextBox();
            this.lblCodEstadia = new System.Windows.Forms.Label();
            this.groupRegEst.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegEst
            // 
            this.groupRegEst.Controls.Add(this.btnContinuar);
            this.groupRegEst.Controls.Add(this.txtCodEstadia);
            this.groupRegEst.Controls.Add(this.lblCodEstadia);
            this.groupRegEst.Location = new System.Drawing.Point(21, 23);
            this.groupRegEst.Name = "groupRegEst";
            this.groupRegEst.Size = new System.Drawing.Size(447, 92);
            this.groupRegEst.TabIndex = 0;
            this.groupRegEst.TabStop = false;
            this.groupRegEst.Text = "Ingreso de datos";
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(311, 34);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(114, 23);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // txtCodEstadia
            // 
            this.txtCodEstadia.Location = new System.Drawing.Point(169, 35);
            this.txtCodEstadia.MaxLength = 10;
            this.txtCodEstadia.Name = "txtCodEstadia";
            this.txtCodEstadia.Size = new System.Drawing.Size(128, 20);
            this.txtCodEstadia.TabIndex = 1;
            this.txtCodEstadia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodEstadia_KeyPress);
            // 
            // lblCodEstadia
            // 
            this.lblCodEstadia.AutoSize = true;
            this.lblCodEstadia.Location = new System.Drawing.Point(30, 38);
            this.lblCodEstadia.Name = "lblCodEstadia";
            this.lblCodEstadia.Size = new System.Drawing.Size(132, 13);
            this.lblCodEstadia.TabIndex = 0;
            this.lblCodEstadia.Text = "Ingrese codigo de estadia:";
            // 
            // frmInicioRegistrarConsumible
            // 
            this.AcceptButton = this.btnContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 139);
            this.Controls.Add(this.groupRegEst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInicioRegistrarConsumible";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Consumibles";
            this.groupRegEst.ResumeLayout(false);
            this.groupRegEst.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegEst;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox txtCodEstadia;
        private System.Windows.Forms.Label lblCodEstadia;
    }
}