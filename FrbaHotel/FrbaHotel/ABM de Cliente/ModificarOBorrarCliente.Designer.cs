namespace FrbaHotel.ABM_de_Cliente
{
    partial class ModificarOBorrarCliente
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
            this.components = new System.ComponentModel.Container();
            this.Titulo = new System.Windows.Forms.Label();
            this.tituloBuscador = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelTipoDoc = new System.Windows.Forms.Label();
            this.labelNroDoc = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.textBoxBuscadorNombre = new System.Windows.Forms.TextBox();
            this.textBoxBuscadorApellido = new System.Windows.Forms.TextBox();
            this.comboBoxBuscadorTipoDoc = new System.Windows.Forms.ComboBox();
            this.textBoxBuscadorNroDoc = new System.Windows.Forms.TextBox();
            this.textBoxBuscadorMail = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonInhabilitar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.gD2C2014DataSet = new FrbaHotel.GD2C2014DataSet();
            this.gD2C2014DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datGridViewClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2014DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2014DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Titulo.Location = new System.Drawing.Point(236, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(248, 24);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Modificar/Eliminar Cliente";
            // 
            // tituloBuscador
            // 
            this.tituloBuscador.AutoSize = true;
            this.tituloBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloBuscador.Location = new System.Drawing.Point(288, 46);
            this.tituloBuscador.Name = "tituloBuscador";
            this.tituloBuscador.Size = new System.Drawing.Size(147, 17);
            this.tituloBuscador.TabIndex = 1;
            this.tituloBuscador.Text = "Buscardor de Clientes";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(12, 85);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(55, 15);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(217, 85);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(54, 15);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelTipoDoc
            // 
            this.labelTipoDoc.AutoSize = true;
            this.labelTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoDoc.Location = new System.Drawing.Point(12, 124);
            this.labelTipoDoc.Name = "labelTipoDoc";
            this.labelTipoDoc.Size = new System.Drawing.Size(79, 15);
            this.labelTipoDoc.TabIndex = 4;
            this.labelTipoDoc.Text = "Tipo de Doc.:";
            // 
            // labelNroDoc
            // 
            this.labelNroDoc.AutoSize = true;
            this.labelNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroDoc.Location = new System.Drawing.Point(237, 124);
            this.labelNroDoc.Name = "labelNroDoc";
            this.labelNroDoc.Size = new System.Drawing.Size(102, 15);
            this.labelNroDoc.TabIndex = 5;
            this.labelNroDoc.Text = "Numero De Doc.:";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMail.Location = new System.Drawing.Point(479, 85);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(34, 15);
            this.labelMail.TabIndex = 6;
            this.labelMail.Text = "Mail:";
            // 
            // textBoxBuscadorNombre
            // 
            this.textBoxBuscadorNombre.Location = new System.Drawing.Point(73, 80);
            this.textBoxBuscadorNombre.Name = "textBoxBuscadorNombre";
            this.textBoxBuscadorNombre.Size = new System.Drawing.Size(118, 20);
            this.textBoxBuscadorNombre.TabIndex = 7;
            // 
            // textBoxBuscadorApellido
            // 
            this.textBoxBuscadorApellido.Location = new System.Drawing.Point(278, 79);
            this.textBoxBuscadorApellido.Name = "textBoxBuscadorApellido";
            this.textBoxBuscadorApellido.Size = new System.Drawing.Size(132, 20);
            this.textBoxBuscadorApellido.TabIndex = 8;
            // 
            // comboBoxBuscadorTipoDoc
            // 
            this.comboBoxBuscadorTipoDoc.FormattingEnabled = true;
            this.comboBoxBuscadorTipoDoc.Location = new System.Drawing.Point(97, 121);
            this.comboBoxBuscadorTipoDoc.Name = "comboBoxBuscadorTipoDoc";
            this.comboBoxBuscadorTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscadorTipoDoc.TabIndex = 9;
            // 
            // textBoxBuscadorNroDoc
            // 
            this.textBoxBuscadorNroDoc.Location = new System.Drawing.Point(345, 123);
            this.textBoxBuscadorNroDoc.Name = "textBoxBuscadorNroDoc";
            this.textBoxBuscadorNroDoc.Size = new System.Drawing.Size(118, 20);
            this.textBoxBuscadorNroDoc.TabIndex = 10;
            // 
            // textBoxBuscadorMail
            // 
            this.textBoxBuscadorMail.Location = new System.Drawing.Point(520, 79);
            this.textBoxBuscadorMail.Name = "textBoxBuscadorMail";
            this.textBoxBuscadorMail.Size = new System.Drawing.Size(138, 20);
            this.textBoxBuscadorMail.TabIndex = 11;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(264, 158);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 13;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(409, 158);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 14;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(12, 424);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(75, 23);
            this.botonModificar.TabIndex = 15;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            // 
            // botonInhabilitar
            // 
            this.botonInhabilitar.Location = new System.Drawing.Point(177, 424);
            this.botonInhabilitar.Name = "botonInhabilitar";
            this.botonInhabilitar.Size = new System.Drawing.Size(75, 23);
            this.botonInhabilitar.TabIndex = 16;
            this.botonInhabilitar.Text = "Inhabilitar";
            this.botonInhabilitar.UseVisualStyleBackColor = true;
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(648, 424);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 17;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // gD2C2014DataSet
            // 
            this.gD2C2014DataSet.DataSetName = "GD2C2014DataSet";
            this.gD2C2014DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gD2C2014DataSetBindingSource
            // 
            this.gD2C2014DataSetBindingSource.DataSource = this.gD2C2014DataSet;
            this.gD2C2014DataSetBindingSource.Position = 0;
            // 
            // datGridViewClientes
            // 
            this.datGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGridViewClientes.Location = new System.Drawing.Point(15, 195);
            this.datGridViewClientes.Name = "datGridViewClientes";
            this.datGridViewClientes.Size = new System.Drawing.Size(708, 210);
            this.datGridViewClientes.TabIndex = 18;
            // 
            // ModificarOBorrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 459);
            this.Controls.Add(this.datGridViewClientes);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonInhabilitar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.textBoxBuscadorMail);
            this.Controls.Add(this.textBoxBuscadorNroDoc);
            this.Controls.Add(this.comboBoxBuscadorTipoDoc);
            this.Controls.Add(this.textBoxBuscadorApellido);
            this.Controls.Add(this.textBoxBuscadorNombre);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelNroDoc);
            this.Controls.Add(this.labelTipoDoc);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.tituloBuscador);
            this.Controls.Add(this.Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModificarOBorrarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarOBorrarCliente";
            this.Load += new System.EventHandler(this.ModificarOBorrarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2014DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2014DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label tituloBuscador;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelTipoDoc;
        private System.Windows.Forms.Label labelNroDoc;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox textBoxBuscadorNombre;
        private System.Windows.Forms.TextBox textBoxBuscadorApellido;
        private System.Windows.Forms.ComboBox comboBoxBuscadorTipoDoc;
        private System.Windows.Forms.TextBox textBoxBuscadorNroDoc;
        private System.Windows.Forms.TextBox textBoxBuscadorMail;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonInhabilitar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.BindingSource gD2C2014DataSetBindingSource;
        private GD2C2014DataSet gD2C2014DataSet;
        private System.Windows.Forms.DataGridView datGridViewClientes;
    }
}