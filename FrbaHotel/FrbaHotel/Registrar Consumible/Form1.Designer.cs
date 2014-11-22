namespace FrbaHotel.Registrar_Consumible
{
    partial class frmRegistrarConsumible
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
            this.groupRegConsu = new System.Windows.Forms.GroupBox();
            this.btnRegistrarCons = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.groupConsumible = new System.Windows.Forms.GroupBox();
            this.dgvConsumibles = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.groupBotonera = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupRegConsu.SuspendLayout();
            this.groupConsumible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).BeginInit();
            this.groupBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegConsu
            // 
            this.groupRegConsu.Controls.Add(this.btnRegistrarCons);
            this.groupRegConsu.Controls.Add(this.lblCantidad);
            this.groupRegConsu.Controls.Add(this.txtCantidad);
            this.groupRegConsu.Controls.Add(this.lblCodProducto);
            this.groupRegConsu.Controls.Add(this.txtCodProducto);
            this.groupRegConsu.Location = new System.Drawing.Point(12, 12);
            this.groupRegConsu.Name = "groupRegConsu";
            this.groupRegConsu.Size = new System.Drawing.Size(273, 282);
            this.groupRegConsu.TabIndex = 0;
            this.groupRegConsu.TabStop = false;
            this.groupRegConsu.Text = "Ingresar datos";
            // 
            // btnRegistrarCons
            // 
            this.btnRegistrarCons.AutoSize = true;
            this.btnRegistrarCons.Location = new System.Drawing.Point(76, 221);
            this.btnRegistrarCons.Name = "btnRegistrarCons";
            this.btnRegistrarCons.Size = new System.Drawing.Size(116, 37);
            this.btnRegistrarCons.TabIndex = 4;
            this.btnRegistrarCons.Text = "Registrar Consumible";
            this.btnRegistrarCons.UseVisualStyleBackColor = true;
            this.btnRegistrarCons.Click += new System.EventHandler(this.btnRegistrarCons_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(13, 92);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(16, 110);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Location = new System.Drawing.Point(13, 40);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(129, 13);
            this.lblCodProducto.TabIndex = 1;
            this.lblCodProducto.Text = "Codigo producto/servicio:";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(16, 59);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(100, 20);
            this.txtCodProducto.TabIndex = 0;
            this.txtCodProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProducto_KeyPress);
            // 
            // groupConsumible
            // 
            this.groupConsumible.Controls.Add(this.dgvConsumibles);
            this.groupConsumible.Location = new System.Drawing.Point(313, 12);
            this.groupConsumible.Name = "groupConsumible";
            this.groupConsumible.Size = new System.Drawing.Size(448, 348);
            this.groupConsumible.TabIndex = 1;
            this.groupConsumible.TabStop = false;
            this.groupConsumible.Text = "Listado consumibles/servicios";
            // 
            // dgvConsumibles
            // 
            this.dgvConsumibles.AllowUserToResizeColumns = false;
            this.dgvConsumibles.AllowUserToResizeRows = false;
            this.dgvConsumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCantidad,
            this.colDescripcion});
            this.dgvConsumibles.Location = new System.Drawing.Point(20, 26);
            this.dgvConsumibles.Name = "dgvConsumibles";
            this.dgvConsumibles.Size = new System.Drawing.Size(403, 299);
            this.dgvConsumibles.TabIndex = 0;
            this.dgvConsumibles.TabStop = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.AutoSize = true;
            this.btnFacturar.Location = new System.Drawing.Point(123, 24);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(104, 23);
            this.btnFacturar.TabIndex = 5;
            this.btnFacturar.Text = "Iniciar Facturacion";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // groupBotonera
            // 
            this.groupBotonera.Controls.Add(this.btnCancelar);
            this.groupBotonera.Controls.Add(this.btnFacturar);
            this.groupBotonera.Location = new System.Drawing.Point(12, 300);
            this.groupBotonera.Name = "groupBotonera";
            this.groupBotonera.Size = new System.Drawing.Size(272, 60);
            this.groupBotonera.TabIndex = 3;
            this.groupBotonera.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(40, 24);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(784, 372);
            this.Controls.Add(this.groupBotonera);
            this.Controls.Add(this.groupConsumible);
            this.Controls.Add(this.groupRegConsu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegistrarConsumible";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Consumible";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistrarConsumible_FormClosing);
            this.groupRegConsu.ResumeLayout(false);
            this.groupRegConsu.PerformLayout();
            this.groupConsumible.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).EndInit();
            this.groupBotonera.ResumeLayout(false);
            this.groupBotonera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegConsu;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Button btnRegistrarCons;
        private System.Windows.Forms.GroupBox groupConsumible;
        private System.Windows.Forms.DataGridView dgvConsumibles;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.GroupBox groupBotonera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}