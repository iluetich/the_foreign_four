namespace FrbaHotel.Registrar_Estadia
{
    partial class frmRegistrarHuespedesRestantes
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
            this.groupHues = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantHuespedes = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.dgvDatosHuespedes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBotonera = new System.Windows.Forms.GroupBox();
            this.groupHues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosHuespedes)).BeginInit();
            this.groupBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupHues
            // 
            this.groupHues.AutoSize = true;
            this.groupHues.Controls.Add(this.label1);
            this.groupHues.Controls.Add(this.txtCantHuespedes);
            this.groupHues.Controls.Add(this.btnBuscarCliente);
            this.groupHues.Controls.Add(this.dgvDatosHuespedes);
            this.groupHues.Controls.Add(this.btnNuevoCliente);
            this.groupHues.Location = new System.Drawing.Point(13, 23);
            this.groupHues.Name = "groupHues";
            this.groupHues.Size = new System.Drawing.Size(433, 267);
            this.groupHues.TabIndex = 0;
            this.groupHues.TabStop = false;
            this.groupHues.Text = "Huespedes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad maxima restante de huespedes a registrar:";
            // 
            // txtCantHuespedes
            // 
            this.txtCantHuespedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantHuespedes.Location = new System.Drawing.Point(392, 16);
            this.txtCantHuespedes.Name = "txtCantHuespedes";
            this.txtCantHuespedes.ReadOnly = true;
            this.txtCantHuespedes.Size = new System.Drawing.Size(29, 22);
            this.txtCantHuespedes.TabIndex = 6;
            this.txtCantHuespedes.TabStop = false;
            this.txtCantHuespedes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.AutoSize = true;
            this.btnBuscarCliente.Location = new System.Drawing.Point(130, 56);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(85, 23);
            this.btnBuscarCliente.TabIndex = 0;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // dgvDatosHuespedes
            // 
            this.dgvDatosHuespedes.AllowUserToAddRows = false;
            this.dgvDatosHuespedes.AllowUserToResizeColumns = false;
            this.dgvDatosHuespedes.AllowUserToResizeRows = false;
            this.dgvDatosHuespedes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatosHuespedes.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosHuespedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosHuespedes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDatosHuespedes.Location = new System.Drawing.Point(27, 91);
            this.dgvDatosHuespedes.Name = "dgvDatosHuespedes";
            this.dgvDatosHuespedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosHuespedes.Size = new System.Drawing.Size(377, 150);
            this.dgvDatosHuespedes.TabIndex = 5;
            this.dgvDatosHuespedes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDatosHuespedes_KeyDown);
            this.dgvDatosHuespedes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDatosHuespedes_KeyUp);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo Documento";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Documento";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Apellido";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nombre";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.AutoSize = true;
            this.btnNuevoCliente.Location = new System.Drawing.Point(218, 56);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(84, 23);
            this.btnNuevoCliente.TabIndex = 1;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(108, 34);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(104, 42);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(221, 34);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 42);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBotonera
            // 
            this.groupBotonera.Controls.Add(this.btnAceptar);
            this.groupBotonera.Controls.Add(this.btnVolver);
            this.groupBotonera.Location = new System.Drawing.Point(13, 296);
            this.groupBotonera.Name = "groupBotonera";
            this.groupBotonera.Size = new System.Drawing.Size(433, 100);
            this.groupBotonera.TabIndex = 3;
            this.groupBotonera.TabStop = false;
            // 
            // frmRegistrarHuespedesRestantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(458, 413);
            this.Controls.Add(this.groupBotonera);
            this.Controls.Add(this.groupHues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegistrarHuespedesRestantes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Huespedes Restantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistrarHuespedes_FormClosing);
            this.groupHues.ResumeLayout(false);
            this.groupHues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosHuespedes)).EndInit();
            this.groupBotonera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupHues;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBotonera;
        private System.Windows.Forms.DataGridView dgvDatosHuespedes;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox txtCantHuespedes;
        private System.Windows.Forms.Label label1;
    }
}