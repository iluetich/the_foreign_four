namespace FrbaHotel.ABM_de_Rol
{
    partial class ModificarYBorrarRol
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
            this.TituloRoles = new System.Windows.Forms.Label();
            this.listaRoles = new System.Windows.Forms.ListBox();
            this.ModificarRol = new System.Windows.Forms.Button();
            this.InhabilitarRol = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.TituloVentana = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TituloRoles
            // 
            this.TituloRoles.AutoSize = true;
            this.TituloRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloRoles.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TituloRoles.Location = new System.Drawing.Point(117, 61);
            this.TituloRoles.Name = "TituloRoles";
            this.TituloRoles.Size = new System.Drawing.Size(44, 17);
            this.TituloRoles.TabIndex = 0;
            this.TituloRoles.Text = "Roles";
            // 
            // listaRoles
            // 
            this.listaRoles.FormattingEnabled = true;
            this.listaRoles.Location = new System.Drawing.Point(36, 84);
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.Size = new System.Drawing.Size(234, 134);
            this.listaRoles.TabIndex = 1;
            // 
            // ModificarRol
            // 
            this.ModificarRol.Location = new System.Drawing.Point(290, 84);
            this.ModificarRol.Name = "ModificarRol";
            this.ModificarRol.Size = new System.Drawing.Size(75, 23);
            this.ModificarRol.TabIndex = 2;
            this.ModificarRol.Text = "Modificar";
            this.ModificarRol.UseVisualStyleBackColor = true;
            // 
            // InhabilitarRol
            // 
            this.InhabilitarRol.Location = new System.Drawing.Point(290, 128);
            this.InhabilitarRol.Name = "InhabilitarRol";
            this.InhabilitarRol.Size = new System.Drawing.Size(75, 23);
            this.InhabilitarRol.TabIndex = 3;
            this.InhabilitarRol.Text = "Inhabilitar";
            this.InhabilitarRol.UseVisualStyleBackColor = true;
            this.InhabilitarRol.Click += new System.EventHandler(this.InhabilitarRol_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(302, 234);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 4;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // TituloVentana
            // 
            this.TituloVentana.AutoSize = true;
            this.TituloVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloVentana.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TituloVentana.Location = new System.Drawing.Point(32, 19);
            this.TituloVentana.Name = "TituloVentana";
            this.TituloVentana.Size = new System.Drawing.Size(285, 24);
            this.TituloVentana.TabIndex = 5;
            this.TituloVentana.Text = "Modificacion / Borrado de un Rol";
            // 
            // ModificarYBorrarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 269);
            this.Controls.Add(this.TituloVentana);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.InhabilitarRol);
            this.Controls.Add(this.ModificarRol);
            this.Controls.Add(this.listaRoles);
            this.Controls.Add(this.TituloRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModificarYBorrarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar/Borrar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloRoles;
        private System.Windows.Forms.ListBox listaRoles;
        private System.Windows.Forms.Button ModificarRol;
        private System.Windows.Forms.Button InhabilitarRol;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label TituloVentana;
    }
}