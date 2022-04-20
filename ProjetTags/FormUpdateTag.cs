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
            tag = tagAModif.getTag();
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

        private void btn_createTag_Click(object sender, EventArgs e)
        {
            Tag ancienTag = this.tag;
            ancienTag.setNom(textBox_nomTag.Text);
            ancienTag.setClr(textBox_couleur.Text);
            if (ancienTag.getIdt_pere() == 0)
            {
                daoTag.updateSansPere(ancienTag);
            }
            else
            {
                daoTag.update(ancienTag); 
            }
            Hide();
        }
    }
}