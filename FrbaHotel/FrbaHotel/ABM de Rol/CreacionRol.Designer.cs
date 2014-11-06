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
            this.BotonAceptar = new System.Windows.Forms.Button();
            this.tituloVentana = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tituloFuncionalidades = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.BotonAgregarFuncionalidad = new System.Windows.Forms.Button();
            this.estadoRol = new System.Windows.Forms.Label();
            this.dgvFuncionalidades = new System.Windows.Forms.DataGridView();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).BeginInit();
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
            this.funcionalidad.Location = new System.Drawing.Point(5, 126);
            this.funcionalidad.Name = "funcionalidad";
            this.funcionalidad.Size = new System.Drawing.Size(98, 15);
            this.funcionalidad.TabIndex = 1;
            this.funcionalidad.Text = "Funcionalidades";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(109, 58);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 3;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // comboBoxFuncionalidad
            // 
            this.comboBoxFuncionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncionalidad.FormattingEnabled = true;
            this.comboBoxFuncionalidad.Location = new System.Drawing.Point(109, 125);
            this.comboBoxFuncionalidad.Name = "comboBoxFuncionalidad";
            this.comboBoxFuncionalidad.Size = new System.Drawing.Size(168, 21);
            this.comboBoxFuncionalidad.TabIndex = 4;
            this.comboBoxFuncionalidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxFuncionalidad_SelectedIndexChanged);
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.ForeColor = System.Drawing.Color.Black;
            this.BotonAceptar.Location = new System.Drawing.Point(12, 341);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(89, 26);
            this.BotonAceptar.TabIndex = 10;
            this.BotonAceptar.Text = "Guardar";
            this.BotonAceptar.UseVisualStyleBackColor = true;
            this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // tituloVentana
            // 
            this.tituloVentana.AutoSize = true;
            this.tituloVentana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tituloVentana.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tituloVentana.Location = new System.Drawing.Point(116, 9);
            this.tituloVentana.Name = "tituloVentana";
            this.tituloVentana.Size = new System.Drawing.Size(161, 24);
            this.tituloVentana.TabIndex = 11;
            this.tituloVentana.Text = "Creacion de Rol";
            this.tituloVentana.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(120, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tituloFuncionalidades
            // 
            this.tituloFuncionalidades.AutoSize = true;
            this.tituloFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloFuncionalidades.Location = new System.Drawing.Point(133, 91);
            this.tituloFuncionalidades.Name = "tituloFuncionalidades";
            this.tituloFuncionalidades.Size = new System.Drawing.Size(140, 15);
            this.tituloFuncionalidades.TabIndex = 13;
            this.tituloFuncionalidades.Text = "Funcionalidades del Rol";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(288, 341);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(89, 26);
            this.Cancelar.TabIndex = 15;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // BotonAgregarFuncionalidad
            // 
            this.BotonAgregarFuncionalidad.Location = new System.Drawing.Point(288, 125);
            this.BotonAgregarFuncionalidad.Name = "BotonAgregarFuncionalidad";
            this.BotonAgregarFuncionalidad.Size = new System.Drawing.Size(77, 23);
            this.BotonAgregarFuncionalidad.TabIndex = 16;
            this.BotonAgregarFuncionalidad.Text = "Agregar";
            this.BotonAgregarFuncionalidad.UseVisualStyleBackColor = true;
            this.BotonAgregarFuncionalidad.Click += new System.EventHandler(this.BotonAgregarFuncionalidad_Click);
            // 
            // estadoRol
            // 
            this.estadoRol.AutoSize = true;
            this.estadoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoRol.Location = new System.Drawing.Point(244, 59);
            this.estadoRol.Name = "estadoRol";
            this.estadoRol.Size = new System.Drawing.Size(48, 15);
            this.estadoRol.TabIndex = 25;
            this.estadoRol.Text = "Estado:";
            // 
            // dgvFuncionalidades
            // 
            this.dgvFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncionalidades.Location = new System.Drawing.Point(120, 166);
            this.dgvFuncionalidades.Name = "dgvFuncionalidades";
            this.dgvFuncionalidades.Size = new System.Drawing.Size(240, 150);
            this.dgvFuncionalidades.TabIndex = 27;
            // 
            // botonQuitar
            // 
            this.botonQuitar.Location = new System.Drawing.Point(12, 205);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(75, 23);
            this.botonQuitar.TabIndex = 28;
            this.botonQuitar.Text = "Quitar";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "H",
            "I"});
            this.comboBoxEstado.Location = new System.Drawing.Point(295, 58);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(60, 21);
            this.comboBoxEstado.TabIndex = 29;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // CreacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(389, 387);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.botonQuitar);
            this.Controls.Add(this.dgvFuncionalidades);
            this.Controls.Add(this.estadoRol);
            this.Controls.Add(this.BotonAgregarFuncionalidad);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.tituloFuncionalidades);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tituloVentana);
            this.Controls.Add(this.BotonAceptar);
            this.Controls.Add(this.comboBoxFuncionalidad);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.funcionalidad);
            this.Controls.Add(this.nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreacionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creacion De Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nombre;
        private Label funcionalidad;
        private TextBox textBoxNombre;
        private ComboBox comboBoxFuncionalidad;
        private Button BotonAceptar;
        private Label tituloVentana;
        private Button button1;
        private Label tituloFuncionalidades;
        private Button Cancelar;
        private Button BotonAgregarFuncionalidad;
        private Label estadoRol;
        private DataGridView dgvFuncionalidades;
        private Button botonQuitar;
        private ComboBox comboBoxEstado;



    }
}