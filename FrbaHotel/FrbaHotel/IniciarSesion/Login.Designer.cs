namespace FrbaHotel.IniciarSecion
{
    partial class Login
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
            this.labelTituloLogin = new System.Windows.Forms.Label();
            this.laberUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.botonIngresar = new System.Windows.Forms.Button();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxSelecionHotel = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTituloLogin
            // 
            this.labelTituloLogin.AutoSize = true;
            this.labelTituloLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTituloLogin.Location = new System.Drawing.Point(44, 9);
            this.labelTituloLogin.Name = "labelTituloLogin";
            this.labelTituloLogin.Size = new System.Drawing.Size(160, 24);
            this.labelTituloLogin.TabIndex = 0;
            this.labelTituloLogin.Text = "Inicio de Sesion";
            // 
            // laberUserName
            // 
            this.laberUserName.AutoSize = true;
            this.laberUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberUserName.Location = new System.Drawing.Point(12, 47);
            this.laberUserName.Name = "laberUserName";
            this.laberUserName.Size = new System.Drawing.Size(68, 15);
            this.laberUserName.TabIndex = 1;
            this.laberUserName.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(12, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(64, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(87, 47);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(148, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.Location = new System.Drawing.Point(87, 80);
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.PasswordChar = '*';
            this.textBoxpassword.Size = new System.Drawing.Size(148, 20);
            this.textBoxpassword.TabIndex = 1;
            this.textBoxpassword.TextChanged += new System.EventHandler(this.textBoxpassword_TextChanged);
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(12, 162);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(75, 23);
            this.botonIngresar.TabIndex = 3;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotel.Location = new System.Drawing.Point(12, 118);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(39, 15);
            this.labelHotel.TabIndex = 6;
            this.labelHotel.Text = "Hotel:";
            // 
            // comboBoxSelecionHotel
            // 
            this.comboBoxSelecionHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelecionHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelecionHotel.FormattingEnabled = true;
            this.comboBoxSelecionHotel.Location = new System.Drawing.Point(57, 115);
            this.comboBoxSelecionHotel.Name = "comboBoxSelecionHotel";
            this.comboBoxSelecionHotel.Size = new System.Drawing.Size(146, 23);
            this.comboBoxSelecionHotel.TabIndex = 2;
            this.comboBoxSelecionHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelecionHotel_SelectedIndexChanged);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(160, 162);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 4;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 197);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.comboBoxSelecionHotel);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.botonIngresar);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.laberUserName);
            this.Controls.Add(this.labelTituloLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTituloLogin;
        private System.Windows.Forms.Label laberUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxpassword;
        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxSelecionHotel;
        private System.Windows.Forms.Button botonVolver;
    }
}