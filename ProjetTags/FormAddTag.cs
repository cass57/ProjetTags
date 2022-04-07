using System;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormAddTag : Form
    {
        public FormAddTag()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        

        private void btn_ouvrirPalette_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                string hex = MyDialog.Color.R.ToString("X2") + MyDialog.Color.G.ToString("X2") +
                             MyDialog.Color.B.ToString("X2");
                textBox_couleur.Text = hex;
            }
        }
        
    }
}