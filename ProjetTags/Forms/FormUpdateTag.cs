using System;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    /// <summary>
    /// Formulaire de modification d'un tag
    /// </summary>
    public partial class FormUpdateTag : Form
    {
        /// <summary>DAO et TAG</summary>
        private readonly TagDAO _daoTag;
        private readonly Tag _tag;

        /// <summary>
        /// Création du formulaire 
        /// </summary>
        /// <param name="tagAModif">Tag à modifier</param>
        public FormUpdateTag(TagNode tagAModif)
        {
            InitializeComponent();
            _daoTag = new TagDAO();
            _tag = tagAModif.GetTag();
            if (DarkTheme.Active) DarkMode();
        }

        /// <summary>
        /// Initialisation du DarkMode
        /// </summary>
        public void DarkMode()
        {
            lbl_tag.BackColor = DarkTheme.MainDark;
            label1.BackColor = DarkTheme.MainDark;
            textBox_couleur.BackColor = DarkTheme.Darkest;
            textBox_couleur.ForeColor = DarkTheme.LightColor;
            label2.BackColor = DarkTheme.MainDark;
            btn_ouvrirPalette.BackColor = DarkTheme.Darkest;
            btn_ouvrirPalette.ForeColor = DarkTheme.LightColor;
            btn_createTag.BackColor = DarkTheme.Darkest;
            btn_createTag.ForeColor = DarkTheme.LightColor;
            textBox_nomTag.BackColor = DarkTheme.Darkest;
            textBox_nomTag.ForeColor = DarkTheme.LightColor;
            BackColor = DarkTheme.MainDark;
            ForeColor = DarkTheme.LightColor;
        }

        /// <summary>
        /// Permet d'ouvrir la palette de couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ouvrirPalette_Click(object sender, EventArgs e)
        {
            var myDialog = new ColorDialog {AllowFullOpen = false, ShowHelp = true};

            if (myDialog.ShowDialog() == DialogResult.OK)
                textBox_couleur.Text = myDialog.Color.R.ToString("X2") + myDialog.Color.G.ToString("X2") +
                                       myDialog.Color.B.ToString("X2");
        }

        /// <summary>
        /// Création du tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_createTag_Click(object sender, EventArgs e)
        {
            if (textBox_nomTag.Text != "") _tag.nom = textBox_nomTag.Text;
            if (textBox_couleur.Text != "") _tag.clr = textBox_couleur.Text;
            _daoTag.Update(_tag);
            Hide();
        }
    }
}