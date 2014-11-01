namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class frmBuscarReserva
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
            this.groupModificar = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodRes = new System.Windows.Forms.TextBox();
            this.lblCodRes = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupModificar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupModificar
            // 
            this.groupModificar.Controls.Add(this.btnBuscar);
            this.groupModificar.Controls.Add(this.txtCodRes);
            this.groupModificar.Controls.Add(this.lblCodRes);
            this.groupModificar.Location = new System.Drawing.Point(27, 21);
            this.groupModificar.Name = "groupModificar";
            this.groupModificar.Size = new System.Drawing.Size(356, 101);
            this.groupModificar.TabIndex = 0;
            this.groupModificar.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(114, 59);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodRes
            // 
            this.txtCodRes.Location = new System.Drawing.Point(197, 30);
            this.txtCodRes.Name = "txtCodRes";
            this.txtCodRes.Size = new System.Drawing.Size(100, 20);
            this.txtCodRes.TabIndex = 1;
            this.txtCodRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodRes_KeyPress);
            // 
            // lblCodRes
            // 
            this.lblCodRes.AutoSize = true;
            this.lblCodRes.Location = new System.Drawing.Point(58, 33);
            this.lblCodRes.Name = "lblCodRes";
            this.lblCodRes.Size = new System.Drawing.Size(133, 13);
            this.lblCodRes.TabIndex = 0;
            this.lblCodRes.Text = "Ingrese codigo de reserva:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(330, 142);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmBuscarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 170);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.groupModificar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBuscarReserva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Reserva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBuscarReserva_FormClosing);
            this.groupModificar.ResumeLayout(false);
            this.groupModificar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodRes;
        private System.Windows.Forms.Label lblCodRes;
        private System.Windows.Forms.Button btnVolver;
    }
}