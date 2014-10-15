namespace FrbaHotel.ABM_de_Usuario
{
    partial class ModificarYBorrarUsuario
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
            this.TituloVentanaUsuarios = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.InhabilitarUsuario = new System.Windows.Forms.Button();
            this.ModificarUsuario = new System.Windows.Forms.Button();
            this.listaUsuarios = new System.Windows.Forms.ListBox();
            this.TituloUsuarios = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TituloVentanaUsuarios
            // 
            this.TituloVentanaUsuarios.AutoSize = true;
            this.TituloVentanaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloVentanaUsuarios.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TituloVentanaUsuarios.Location = new System.Drawing.Point(37, 9);
            this.TituloVentanaUsuarios.Name = "TituloVentanaUsuarios";
            this.TituloVentanaUsuarios.Size = new System.Drawing.Size(255, 24);
            this.TituloVentanaUsuarios.TabIndex = 11;
            this.TituloVentanaUsuarios.Text = "Modificar/Eliminar un Usuario";
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(269, 219);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 10;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            // 
            // InhabilitarUsuario
            // 
            this.InhabilitarUsuario.Location = new System.Drawing.Point(99, 215);
            this.InhabilitarUsuario.Name = "InhabilitarUsuario";
            this.InhabilitarUsuario.Size = new System.Drawing.Size(75, 23);
            this.InhabilitarUsuario.TabIndex = 9;
            this.InhabilitarUsuario.Text = "Inhabilitar";
            this.InhabilitarUsuario.UseVisualStyleBackColor = true;
            // 
            // ModificarUsuario
            // 
            this.ModificarUsuario.Location = new System.Drawing.Point(15, 215);
            this.ModificarUsuario.Name = "ModificarUsuario";
            this.ModificarUsuario.Size = new System.Drawing.Size(75, 23);
            this.ModificarUsuario.TabIndex = 8;
            this.ModificarUsuario.Text = "Modificar";
            this.ModificarUsuario.UseVisualStyleBackColor = true;
            // 
            // listaUsuarios
            // 
            this.listaUsuarios.FormattingEnabled = true;
            this.listaUsuarios.Location = new System.Drawing.Point(15, 63);
            this.listaUsuarios.Name = "listaUsuarios";
            this.listaUsuarios.Size = new System.Drawing.Size(318, 134);
            this.listaUsuarios.TabIndex = 7;
            // 
            // TituloUsuarios
            // 
            this.TituloUsuarios.AutoSize = true;
            this.TituloUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloUsuarios.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TituloUsuarios.Location = new System.Drawing.Point(142, 43);
            this.TituloUsuarios.Name = "TituloUsuarios";
            this.TituloUsuarios.Size = new System.Drawing.Size(64, 17);
            this.TituloUsuarios.TabIndex = 6;
            this.TituloUsuarios.Text = "Usuarios";
            // 
            // ModificarYBorrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.TituloVentanaUsuarios);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.InhabilitarUsuario);
            this.Controls.Add(this.ModificarUsuario);
            this.Controls.Add(this.listaUsuarios);
            this.Controls.Add(this.TituloUsuarios);
            this.Name = "ModificarYBorrarUsuario";
            this.Text = "ModificarYBorrarUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloVentanaUsuarios;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button InhabilitarUsuario;
        private System.Windows.Forms.Button ModificarUsuario;
        private System.Windows.Forms.ListBox listaUsuarios;
        private System.Windows.Forms.Label TituloUsuarios;
    }
}