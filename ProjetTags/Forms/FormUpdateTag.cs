using System;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormUpdateTag : Form
    {
        private readonly TagDAO _daoTag;
        private readonly Tag _tag;

        public FormUpdateTag(TagNode tagAModif)
        {
            InitializeComponent();
            _daoTag = new TagDAO();
            _tag = tagAModif.GetTag();
        }


        private void btn_ouvrirPalette_Click(object sender, EventArgs e)
        {
            var myDialog = new ColorDialog();
            myDialog.AllowFullOpen = false;
            myDialog.ShowHelp = true;

            if (myDialog.ShowDialog() == DialogResult.OK)
                textBox_couleur.Text = myDialog.Color.R.ToString("X2") + myDialog.Color.G.ToString("X2") +
                                       myDialog.Color.B.ToString("X2");
        }

        private void btn_createTag_Click(object sender, EventArgs e)
        {
            var ancienTag = _tag;
            if (textBox_nomTag.Text != "") ancienTag.nom = textBox_nomTag.Text;
            if (textBox_couleur.Text != "") ancienTag.clr = textBox_couleur.Text;
            _daoTag.Update(ancienTag);
            Hide();
        }
    }
}