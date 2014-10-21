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
        List<TextBox>listTxt = new List<TextBox>();
        List<Label>listLbl = new List<Label>();
      
        public frmRegistrarHuespedesRestantes(Form newFrm, int cantHuespedes){
            InitializeComponent();
            frmRegistrarEstadiaPadre = newFrm;
            cargarControles(cantHuespedes);
        }

        public void cargarControles(int cant)
        {
            int y = 25;
            for (int i = 0; i < cant; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Cliente:";
                lbl.AutoSize = true;
                lbl.Location = new Point(25, y);
                this.Controls.Add(lbl);
                this.listLbl.Add(lbl);

                TextBox txt = new TextBox();
                txt.Location = new Point((lbl.Location.X + lbl.Width + 5), y);
                this.Controls.Add(txt);
                this.listTxt.Add(txt);               

                y += 25;

            }
        }

        private void frmRegistrarHuespedes_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegistrarEstadiaPadre.Enabled = true;
            frmRegistrarEstadiaPadre.Focus();
        }

        



    }
}
