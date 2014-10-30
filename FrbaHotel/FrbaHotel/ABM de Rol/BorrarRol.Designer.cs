namespace FrbaHotel.ABM_de_Rol
{
    partial class BorrarRol
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
            this.Leyenda = new System.Windows.Forms.Label();
            this.Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Leyenda
            // 
            this.Leyenda.AutoSize = true;
            this.Leyenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Leyenda.Location = new System.Drawing.Point(12, 21);
            this.Leyenda.Name = "Leyenda";
            this.Leyenda.Size = new System.Drawing.Size(367, 17);
            this.Leyenda.TabIndex = 0;
            this.Leyenda.Text = "Se ha inhabilitado satisfactoriamente el Rol seleccionado";
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(146, 53);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // BorrarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 90);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Leyenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BorrarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Leyenda;
        private System.Windows.Forms.Button Aceptar;
    }
}