using System.Windows.Forms;
using System.Drawing;
namespace FrbaHotel
{
    partial class InicioDelSistema
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
            this.TituloEntrada = new System.Windows.Forms.Label();
            this.LabelIngreso = new System.Windows.Forms.Label();
            this.comboBoxEleccionRol = new System.Windows.Forms.ComboBox();
            this.BotonIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TituloEntrada
            // 
            this.TituloEntrada.AutoSize = true;
            this.TituloEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloEntrada.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TituloEntrada.Location = new System.Drawing.Point(68, 9);
            this.TituloEntrada.Name = "TituloEntrada";
            this.TituloEntrada.Size = new System.Drawing.Size(198, 24);
            this.TituloEntrada.TabIndex = 0;
            this.TituloEntrada.Text = "Bienvenido Al Sistema";
            // 
            // LabelIngreso
            // 
            this.LabelIngreso.AutoSize = true;
            this.LabelIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIngreso.Location = new System.Drawing.Point(12, 59);
            this.LabelIngreso.Name = "LabelIngreso";
            this.LabelIngreso.Size = new System.Drawing.Size(155, 15);
            this.LabelIngreso.TabIndex = 3;
            this.LabelIngreso.Text = "Ingresar al Sistema Como :";
            // 
            // comboBoxEleccionRol
            // 
            this.comboBoxEleccionRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEleccionRol.FormattingEnabled = true;
            this.comboBoxEleccionRol.Location = new System.Drawing.Point(173, 59);
            this.comboBoxEleccionRol.Name = "comboBoxEleccionRol";
            this.comboBoxEleccionRol.Size = new System.Drawing.Size(137, 21);
            this.comboBoxEleccionRol.TabIndex = 4;
            this.comboBoxEleccionRol.SelectedIndexChanged += new System.EventHandler(this.comboBoxEleccionRol_SelectedIndexChanged);
            // 
            // BotonIngresar
            // 
            this.BotonIngresar.Location = new System.Drawing.Point(129, 92);
            this.BotonIngresar.Name = "BotonIngresar";
            this.BotonIngresar.Size = new System.Drawing.Size(75, 23);
            this.BotonIngresar.TabIndex = 5;
            this.BotonIngresar.Text = "Ingresar";
            this.BotonIngresar.UseVisualStyleBackColor = true;
            this.BotonIngresar.Click += new System.EventHandler(this.BotonIngresar_Click);
            // 
            // InicioDelSistema
            // 
            this.AcceptButton = this.BotonIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 127);
            this.Controls.Add(this.BotonIngresar);
            this.Controls.Add(this.comboBoxEleccionRol);
            this.Controls.Add(this.LabelIngreso);
            this.Controls.Add(this.TituloEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InicioDelSistema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Entrada";
            this.Load += new System.EventHandler(this.InicioDelSistema_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
  
        #endregion

        private Label TituloEntrada;
        private Label LabelIngreso;
        private ComboBox comboBoxEleccionRol;
        private Button BotonIngresar;
    }
}

