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
            this.ModificarRol = new System.Windows.Forms.Button();
            this.InhabilitarRol = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.TituloVentana = new System.Windows.Forms.Label();
            this.dgvBuscarRol = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarRol)).BeginInit();
            this.SuspendLayout();
            // 
            // TituloRoles
            // 
            this.TituloRoles.AutoSize = true;
            this.TituloRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloRoles.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TituloRoles.Location = new System.Drawing.Point(187, 43);
            this.TituloRoles.Name = "TituloRoles";
            this.TituloRoles.Size = new System.Drawing.Size(44, 17);
            this.TituloRoles.TabIndex = 0;
            this.TituloRoles.Text = "Roles";
            // 
            // ModificarRol
            // 
            this.ModificarRol.Location = new System.Drawing.Point(12, 234);
            this.ModificarRol.Name = "ModificarRol";
            this.ModificarRol.Size = new System.Drawing.Size(75, 23);
            this.ModificarRol.TabIndex = 1;
            this.ModificarRol.Text = "Modificar";
            this.ModificarRol.UseVisualStyleBackColor = true;
            this.ModificarRol.Click += new System.EventHandler(this.ModificarRol_Click);
            // 
            // InhabilitarRol
            // 
            this.InhabilitarRol.Location = new System.Drawing.Point(103, 234);
            this.InhabilitarRol.Name = "InhabilitarRol";
            this.InhabilitarRol.Size = new System.Drawing.Size(75, 23);
            this.InhabilitarRol.TabIndex = 3;
            this.InhabilitarRol.TabStop = false;
            this.InhabilitarRol.Text = "Inhabilitar";
            this.InhabilitarRol.UseVisualStyleBackColor = true;
            this.InhabilitarRol.Click += new System.EventHandler(this.InhabilitarRol_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(324, 234);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // TituloVentana
            // 
            this.TituloVentana.AutoSize = true;
            this.TituloVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloVentana.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TituloVentana.Location = new System.Drawing.Point(62, 9);
            this.TituloVentana.Name = "TituloVentana";
            this.TituloVentana.Size = new System.Drawing.Size(285, 24);
            this.TituloVentana.TabIndex = 5;
            this.TituloVentana.Text = "Modificacion / Borrado de un Rol";
            // 
            // dgvBuscarRol
            // 
            this.dgvBuscarRol.AllowUserToAddRows = false;
            this.dgvBuscarRol.AllowUserToDeleteRows = false;
            this.dgvBuscarRol.AllowUserToResizeColumns = false;
            this.dgvBuscarRol.AllowUserToResizeRows = false;
            this.dgvBuscarRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuscarRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarRol.Location = new System.Drawing.Point(12, 74);
            this.dgvBuscarRol.Name = "dgvBuscarRol";
            this.dgvBuscarRol.ReadOnly = true;
            this.dgvBuscarRol.Size = new System.Drawing.Size(387, 139);
            this.dgvBuscarRol.TabIndex = 0;
            // 
            // ModificarYBorrarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 269);
            this.Controls.Add(this.dgvBuscarRol);
            this.Controls.Add(this.TituloVentana);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.InhabilitarRol);
            this.Controls.Add(this.ModificarRol);
            this.Controls.Add(this.TituloRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModificarYBorrarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar/Borrar Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloRoles;
        private System.Windows.Forms.Button ModificarRol;
        private System.Windows.Forms.Button InhabilitarRol;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label TituloVentana;
        private System.Windows.Forms.DataGridView dgvBuscarRol;
    }
}