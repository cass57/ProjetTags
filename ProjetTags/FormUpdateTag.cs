using System;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormUpdateTag : Form
    {
        private TagDAO daoTag;
        private Tag tag;

        public FormUpdateTag(TagNode tagAModif)
        {
            InitializeComponent();
            daoTag = new TagDAO();
            tag = tagAModif.GetTag();
        }


        private void btn_ouvrirPalette_Click(object sender, EventArgs e)
        {
            ColorDialog myDialog = new ColorDialog();
            myDialog.AllowFullOpen = false;
            myDialog.ShowHelp = true;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                string hex = myDialog.Color.R.ToString("X2") + myDialog.Color.G.ToString("X2") +
                             myDialog.Color.B.ToString("X2");
                textBox_couleur.Text = hex;
            }
        }

        private void btn_createTag_Click(object sender, EventArgs e)
        {
            Tag ancienTag = tag;
            if (textBox_nomTag.Text != "") ancienTag.nom = textBox_nomTag.Text;
            if (textBox_couleur.Text != "") ancienTag.clr = textBox_couleur.Text;
            daoTag.Update(ancienTag);
            Hide();
        }
    }
}