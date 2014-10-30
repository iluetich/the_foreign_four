using System.Windows.Forms;
using System.Drawing;
namespace FrbaHotel.ABM_de_Rol
{
    partial class CreacionRol : Form
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
            this.nombre = new System.Windows.Forms.Label();
            this.funcionalidad = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.comboBoxFuncionalidad = new System.Windows.Forms.ComboBox();
            this.Comprobacion1 = new System.Windows.Forms.Label();
            this.Comprobacion2 = new System.Windows.Forms.Label();
            this.LeyendaComprobacion = new System.Windows.Forms.Label();
            this.BotonAceptar = new System.Windows.Forms.Button();
            this.tituloVentana = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tituloFuncionalidades = new System.Windows.Forms.Label();
            this.ListaDeFuncionalidades = new System.Windows.Forms.ListBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.BotonAgregarFuncionalidad = new System.Windows.Forms.Button();
            this.Comprobacion3 = new System.Windows.Forms.Label();
            this.checkBoxEstadoRol = new System.Windows.Forms.CheckBox();
            this.estadoRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(9, 58);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(94, 15);
            this.nombre.TabIndex = 0;
            this.nombre.Text = "Nombre del Rol";
            // 
            // funcionalidad
            // 
            this.funcionalidad.AutoSize = true;
            this.funcionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidad.Location = new System.Drawing.Point(9, 88);
            this.funcionalidad.Name = "funcionalidad";
            this.funcionalidad.Size = new System.Drawing.Size(98, 15);
            this.funcionalidad.TabIndex = 1;
            this.funcionalidad.Text = "Funcionalidades";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(120, 53);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 3;
            // 
            // comboBoxFuncionalidad
            // 
            this.comboBoxFuncionalidad.FormattingEnabled = true;
            this.comboBoxFuncionalidad.Location = new System.Drawing.Point(120, 87);
            this.comboBoxFuncionalidad.Name = "comboBoxFuncionalidad";
            this.comboBoxFuncionalidad.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFuncionalidad.TabIndex = 4;
            // 
            // Comprobacion1
            // 
            this.Comprobacion1.AutoSize = true;
            this.Comprobacion1.Location = new System.Drawing.Point(226, 56);
            this.Comprobacion1.Name = "Comprobacion1";
            this.Comprobacion1.Size = new System.Drawing.Size(20, 13);
            this.Comprobacion1.TabIndex = 6;
            this.Comprobacion1.Text = "(#)";
            // 
            // Comprobacion2
            // 
            this.Comprobacion2.AutoSize = true;
            this.Comprobacion2.Location = new System.Drawing.Point(247, 90);
            this.Comprobacion2.Name = "Comprobacion2";
            this.Comprobacion2.Size = new System.Drawing.Size(20, 13);
            this.Comprobacion2.TabIndex = 7;
            this.Comprobacion2.Text = "(#)";
            // 
            // LeyendaComprobacion
            // 
            this.LeyendaComprobacion.AutoSize = true;
            this.LeyendaComprobacion.Location = new System.Drawing.Point(9, 298);
            this.LeyendaComprobacion.Name = "LeyendaComprobacion";
            this.LeyendaComprobacion.Size = new System.Drawing.Size(107, 13);
            this.LeyendaComprobacion.TabIndex = 9;
            this.LeyendaComprobacion.Text = "(#) Campo obligatorio";
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.ForeColor = System.Drawing.Color.Black;
            this.BotonAceptar.Location = new System.Drawing.Point(12, 323);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(89, 26);
            this.BotonAceptar.TabIndex = 10;
            this.BotonAceptar.Text = "Guardar";
            this.BotonAceptar.UseVisualStyleBackColor = true;
            // 
            // tituloVentana
            // 
            this.tituloVentana.AutoSize = true;
            this.tituloVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tituloVentana.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tituloVentana.Location = new System.Drawing.Point(132, 9);
            this.tituloVentana.Name = "tituloVentana";
            this.tituloVentana.Size = new System.Drawing.Size(161, 24);
            this.tituloVentana.TabIndex = 11;
            this.tituloVentana.Text = "Creacion de Rol";
            this.tituloVentana.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(120, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tituloFuncionalidades
            // 
            this.tituloFuncionalidades.AutoSize = true;
            this.tituloFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloFuncionalidades.Location = new System.Drawing.Point(53, 149);
            this.tituloFuncionalidades.Name = "tituloFuncionalidades";
            this.tituloFuncionalidades.Size = new System.Drawing.Size(140, 15);
            this.tituloFuncionalidades.TabIndex = 13;
            this.tituloFuncionalidades.Text = "Funcionalidades del Rol";
            // 
            // ListaDeFuncionalidades
            // 
            this.ListaDeFuncionalidades.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ListaDeFuncionalidades.FormattingEnabled = true;
            this.ListaDeFuncionalidades.Location = new System.Drawing.Point(18, 176);
            this.ListaDeFuncionalidades.Name = "ListaDeFuncionalidades";
            this.ListaDeFuncionalidades.Size = new System.Drawing.Size(365, 108);
            this.ListaDeFuncionalidades.TabIndex = 14;
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(320, 323);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(89, 26);
            this.Cancelar.TabIndex = 15;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // BotonAgregarFuncionalidad
            // 
            this.BotonAgregarFuncionalidad.Location = new System.Drawing.Point(274, 88);
            this.BotonAgregarFuncionalidad.Name = "BotonAgregarFuncionalidad";
            this.BotonAgregarFuncionalidad.Size = new System.Drawing.Size(135, 23);
            this.BotonAgregarFuncionalidad.TabIndex = 16;
            this.BotonAgregarFuncionalidad.Text = "Agregar Funcionalidad";
            this.BotonAgregarFuncionalidad.UseVisualStyleBackColor = true;
            // 
            // Comprobacion3
            // 
            this.Comprobacion3.AutoSize = true;
            this.Comprobacion3.Location = new System.Drawing.Point(122, 125);
            this.Comprobacion3.Name = "Comprobacion3";
            this.Comprobacion3.Size = new System.Drawing.Size(20, 13);
            this.Comprobacion3.TabIndex = 27;
            this.Comprobacion3.Text = "(#)";
            // 
            // checkBoxEstadoRol
            // 
            this.checkBoxEstadoRol.AutoSize = true;
            this.checkBoxEstadoRol.Location = new System.Drawing.Point(60, 123);
            this.checkBoxEstadoRol.Name = "checkBoxEstadoRol";
            this.checkBoxEstadoRol.Size = new System.Drawing.Size(56, 17);
            this.checkBoxEstadoRol.TabIndex = 26;
            this.checkBoxEstadoRol.Text = "Activo";
            this.checkBoxEstadoRol.UseVisualStyleBackColor = true;
            // 
            // estadoRol
            // 
            this.estadoRol.AutoSize = true;
            this.estadoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoRol.Location = new System.Drawing.Point(9, 123);
            this.estadoRol.Name = "estadoRol";
            this.estadoRol.Size = new System.Drawing.Size(45, 15);
            this.estadoRol.TabIndex = 25;
            this.estadoRol.Text = "Estado";
            // 
            // CreacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(421, 361);
            this.Controls.Add(this.Comprobacion3);
            this.Controls.Add(this.checkBoxEstadoRol);
            this.Controls.Add(this.estadoRol);
            this.Controls.Add(this.BotonAgregarFuncionalidad);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.ListaDeFuncionalidades);
            this.Controls.Add(this.tituloFuncionalidades);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tituloVentana);
            this.Controls.Add(this.BotonAceptar);
            this.Controls.Add(this.LeyendaComprobacion);
            this.Controls.Add(this.Comprobacion2);
            this.Controls.Add(this.Comprobacion1);
            this.Controls.Add(this.comboBoxFuncionalidad);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.funcionalidad);
            this.Controls.Add(this.nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreacionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creacion De Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nombre;
        private Label funcionalidad;
        private TextBox textBoxNombre;
        private ComboBox comboBoxFuncionalidad;
        private Label Comprobacion1;
        private Label Comprobacion2;
        private Label LeyendaComprobacion;
        private Button BotonAceptar;
        private Label tituloVentana;
        private Button button1;
        private Label tituloFuncionalidades;
        private ListBox ListaDeFuncionalidades;
        private Button Cancelar;
        private Button BotonAgregarFuncionalidad;
        private Label Comprobacion3;
        private CheckBox checkBoxEstadoRol;
        private Label estadoRol;



    }
}