using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmRegistrarHuespedesRestantes : Form
    {

        Form frmRegistrarEstadiaPadre;
        List<TextBox>listTxtNom = new List<TextBox>();
        List<TextBox> listTxtApe = new List<TextBox>();
        List<Label>listLbl = new List<Label>();
        List<Button> listBtn = new List<Button>(4);

        public frmRegistrarHuespedesRestantes(Form newFrm, int cantHuespedes){
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;
            cargarControles(cantHuespedes);
        }

        private void cargarControles(int cant)
        {
            int y = 25;
            for (int i = 0; i < cant; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Huesped nº: " + i;
                lbl.AutoSize = true;
                lbl.Location = new Point(25, y);
                this.Controls.Add(lbl);
                this.listLbl.Add(lbl);
                this.groupHues.Controls.Add(lbl);

                TextBox txtNom = new TextBox();
                txtNom.ReadOnly = true;
                txtNom.TabStop = false;
                txtNom.Location = new Point((lbl.Location.X + lbl.Width + 5), y);
                this.listTxtNom.Add(txtNom);
                this.Controls.Add(txtNom);
                this.groupHues.Controls.Add(txtNom);

                TextBox txtApe = new TextBox();
                txtApe.TabStop = false;
                txtApe.ReadOnly = true;
                txtApe.Location = new Point((txtNom.Location.X + txtNom.Width + 5), y);
                this.listTxtApe.Add(txtApe);
                this.Controls.Add(txtApe);
                this.groupHues.Controls.Add(txtApe);

                Button btnNewHues = new Button();
                btnNewHues.AutoSize = true;
                btnNewHues.Text = "Agregar...";
                btnNewHues.Location = new Point(txtApe.Location.X + txtApe.Width + 5, y);
                btnNewHues.Click += (sender, args) => listBtnClick(i);
                this.listBtn.Add(btnNewHues);
                this.Controls.Add(btnNewHues);
                this.groupHues.Controls.Add(btnNewHues);

                y += 25;

            }
        }

        private void frmRegistrarHuespedes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarEstadiaPadre.Enabled = true;
            frmRegistrarEstadiaPadre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBtnClick(int index)
        {
            new frmNuevoCliente(this,index).Show();
        }

        public void actualizarTxts(int index, String nombre, String apellido)
        {
            this.listTxtApe[index].Text = nombre;

        }


    }
}
