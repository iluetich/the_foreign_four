namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class frmRegimenes
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
            this.dgvRegimenes = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegimenes
            // 
            this.dgvRegimenes.AllowUserToDeleteRows = false;
            this.dgvRegimenes.AllowUserToResizeColumns = false;
            this.dgvRegimenes.AllowUserToResizeRows = false;
            this.dgvRegimenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegimenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimenes.Location = new System.Drawing.Point(15, 43);
            this.dgvRegimenes.Name = "dgvRegimenes";
            this.dgvRegimenes.ReadOnly = true;
            this.dgvRegimenes.Size = new System.Drawing.Size(375, 135);
            this.dgvRegimenes.TabIndex = 0;
            this.dgvRegimenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegimenes_CellClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(164, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Seleccione el regimen que desee";
            // 
            // frmRegimenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 198);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvRegimenes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegimenes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Regimenes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRegimenes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegimenes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegimenes;
        private System.Windows.Forms.Label lblInfo;
    }
}