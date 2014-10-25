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
            this.lblNroHabitacion = new System.Windows.Forms.Label();
            this.txtHabitacion = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.groupConsumible = new System.Windows.Forms.GroupBox();
            this.dgvConsumibles = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntAceptar = new System.Windows.Forms.Button();
            this.groupBotonera = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCodEstadia = new System.Windows.Forms.Label();
            this.lblResultCodEstadia = new System.Windows.Forms.Label();
            this.groupRegConsu.SuspendLayout();
            this.groupConsumible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).BeginInit();
            this.groupBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegConsu
            // 
            this.groupRegConsu.Controls.Add(this.lblResultCodEstadia);
            this.groupRegConsu.Controls.Add(this.lblCodEstadia);
            this.groupRegConsu.Controls.Add(this.btnRegistrarCons);
            this.groupRegConsu.Controls.Add(this.lblNroHabitacion);
            this.groupRegConsu.Controls.Add(this.txtHabitacion);
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
            this.groupRegConsu.Enter += new System.EventHandler(this.groupRegConsu_Enter);
            // 
            // btnRegistrarCons
            // 
            this.btnRegistrarCons.AutoSize = true;
            this.btnRegistrarCons.Location = new System.Drawing.Point(76, 221);
            this.btnRegistrarCons.Name = "btnRegistrarCons";
            this.btnRegistrarCons.Size = new System.Drawing.Size(116, 37);
            this.btnRegistrarCons.TabIndex = 6;
            this.btnRegistrarCons.Text = "Registrar Consumible";
            this.btnRegistrarCons.UseVisualStyleBackColor = true;
            this.btnRegistrarCons.Click += new System.EventHandler(this.btnRegistrarCons_Click);
            // 
            // lblNroHabitacion
            // 
            this.lblNroHabitacion.AutoSize = true;
            this.lblNroHabitacion.Location = new System.Drawing.Point(13, 115);
            this.lblNroHabitacion.Name = "lblNroHabitacion";
            this.lblNroHabitacion.Size = new System.Drawing.Size(82, 13);
            this.lblNroHabitacion.TabIndex = 5;
            this.lblNroHabitacion.Text = "Nro. habitacion:";
            // 
            // txtHabitacion
            // 
            this.txtHabitacion.Location = new System.Drawing.Point(16, 133);
            this.txtHabitacion.Name = "txtHabitacion";
            this.txtHabitacion.Size = new System.Drawing.Size(100, 20);
            this.txtHabitacion.TabIndex = 4;
            this.txtHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHabitacion_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(13, 161);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(16, 179);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Location = new System.Drawing.Point(13, 67);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(129, 13);
            this.lblCodProducto.TabIndex = 1;
            this.lblCodProducto.Text = "Codigo producto/servicio:";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(16, 86);
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
            this.dgvConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCantidad,
            this.colHabitacion,
            this.colDescripcion});
            this.dgvConsumibles.Location = new System.Drawing.Point(20, 26);
            this.dgvConsumibles.Name = "dgvConsumibles";
            this.dgvConsumibles.Size = new System.Drawing.Size(403, 299);
            this.dgvConsumibles.TabIndex = 0;
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
            // colHabitacion
            // 
            this.colHabitacion.HeaderText = "Habitacion";
            this.colHabitacion.Name = "colHabitacion";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(135, 24);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(75, 23);
            this.bntAceptar.TabIndex = 2;
            this.bntAceptar.Text = "Finalizar";
            this.bntAceptar.UseVisualStyleBackColor = true;
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // groupBotonera
            // 
            this.groupBotonera.Controls.Add(this.btnCancelar);
            this.groupBotonera.Controls.Add(this.bntAceptar);
            this.groupBotonera.Location = new System.Drawing.Point(12, 300);
            this.groupBotonera.Name = "groupBotonera";
            this.groupBotonera.Size = new System.Drawing.Size(272, 60);
            this.groupBotonera.TabIndex = 3;
            this.groupBotonera.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(49, 24);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblCodEstadia
            // 
            this.lblCodEstadia.AutoSize = true;
            this.lblCodEstadia.Location = new System.Drawing.Point(16, 26);
            this.lblCodEstadia.Name = "lblCodEstadia";
            this.lblCodEstadia.Size = new System.Drawing.Size(80, 13);
            this.lblCodEstadia.TabIndex = 7;
            this.lblCodEstadia.Text = "Codigo estadia:";
            // 
            // lblResultCodEstadia
            // 
            this.lblResultCodEstadia.AutoSize = true;
            this.lblResultCodEstadia.Location = new System.Drawing.Point(102, 26);
            this.lblResultCodEstadia.Name = "lblResultCodEstadia";
            this.lblResultCodEstadia.Size = new System.Drawing.Size(0, 13);
            this.lblResultCodEstadia.TabIndex = 8;
            // 
            // frmRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegConsu;
        private System.Windows.Forms.Label lblNroHabitacion;
        private System.Windows.Forms.TextBox txtHabitacion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Button btnRegistrarCons;
        private System.Windows.Forms.GroupBox groupConsumible;
        private System.Windows.Forms.DataGridView dgvConsumibles;
        private System.Windows.Forms.Button bntAceptar;
        private System.Windows.Forms.GroupBox groupBotonera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.Label lblResultCodEstadia;
        private System.Windows.Forms.Label lblCodEstadia;
    }
}