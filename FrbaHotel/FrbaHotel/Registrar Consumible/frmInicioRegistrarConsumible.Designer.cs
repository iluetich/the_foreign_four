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
            this.txtNroHabitacion = new System.Windows.Forms.TextBox();
            this.lblCodEstadia = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.groupRegEst.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegEst
            // 
            this.groupRegEst.Controls.Add(this.btnContinuar);
            this.groupRegEst.Controls.Add(this.txtNroHabitacion);
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
            // txtNroHabitacion
            // 
            this.txtNroHabitacion.Location = new System.Drawing.Point(169, 35);
            this.txtNroHabitacion.MaxLength = 2;
            this.txtNroHabitacion.Name = "txtNroHabitacion";
            this.txtNroHabitacion.Size = new System.Drawing.Size(128, 20);
            this.txtNroHabitacion.TabIndex = 1;
            this.txtNroHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodEstadia_KeyPress);
            // 
            // lblCodEstadia
            // 
            this.lblCodEstadia.AutoSize = true;
            this.lblCodEstadia.Location = new System.Drawing.Point(14, 38);
            this.lblCodEstadia.Name = "lblCodEstadia";
            this.lblCodEstadia.Size = new System.Drawing.Size(150, 13);
            this.lblCodEstadia.TabIndex = 0;
            this.lblCodEstadia.Text = "Ingrese numero de habitacion:";
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(393, 124);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 1;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // frmInicioRegistrarConsumible
            // 
            this.AcceptButton = this.btnContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 159);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupRegEst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInicioRegistrarConsumible";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Consumibles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicioRegistrarConsumible_FormClosing);
            this.groupRegEst.ResumeLayout(false);
            this.groupRegEst.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegEst;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox txtNroHabitacion;
        private System.Windows.Forms.Label lblCodEstadia;
        private System.Windows.Forms.Button botonVolver;
    }
}