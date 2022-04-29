using System;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormAddTag : Form
    {
        //DAO
        private readonly TagDAO _daoTag;

        public FormAddTag()
        {
            InitializeComponent();
            _daoTag = new TagDAO();
            if (DarkTheme.Active) DarkMode();
        }

        public void DarkMode()
        {
            labelNomTag.BackColor = DarkTheme.MainDark;
            textBox_nomTag.BackColor = DarkTheme.Darkest;
            textBox_nomTag.ForeColor = DarkTheme.LightColor;
            labelCouleurTag.BackColor = DarkTheme.MainDark;
            btn_createTag.BackColor = DarkTheme.Darkest;
            btn_createTag.ForeColor = DarkTheme.LightColor;
            btn_ouvrirPalette.BackColor = DarkTheme.Darkest;
            btn_ouvrirPalette.ForeColor = DarkTheme.LightColor;
            textBox_couleur.BackColor = DarkTheme.Darkest;
            textBox_couleur.ForeColor = DarkTheme.LightColor;
            comboBox_parent.BackColor = DarkTheme.Darkest;
            comboBox_parent.ForeColor = DarkTheme.LightColor;
            label1.BackColor = DarkTheme.MainDark;
            label2.BackColor = DarkTheme.MainDark;
            BackColor = DarkTheme.MainDark;
            ForeColor = DarkTheme.LightColor;
        }

        /// <summary>
        /// Récupération de tous les tags dans la comboBox afin de choisir un éventuel parent
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var entry in _daoTag.AllTag())
                foreach (var tag in entry.Value)
                    comboBox_parent.Items.Add(tag);
        }

        /// <summary>
        /// Permet le choix de la couleur dans un popUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ouvrirPalette_Click(object sender, EventArgs e)
        {
            var myDialog = new ColorDialog {AllowFullOpen = true, ShowHelp = true};

            if (myDialog.ShowDialog() == DialogResult.OK)
                textBox_couleur.Text = myDialog.Color.R.ToString("X2") + myDialog.Color.G.ToString("X2") +
                                       myDialog.Color.B.ToString("X2");
        }

        /// <summary>
        /// Crée le tag si aucune information n'est manquante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_createTag_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;
            DialogResult result;

            if (textBox_nomTag.Text == "")
            {
                message = "Veuillez saisir le nom du tag";
                caption = "Impossible de continuer";
                buttons = MessageBoxButtons.OK;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK) textBox_nomTag.Focus();
            }
            else if (textBox_couleur.Text == "")
            {
                message = "Veuillez saisir une couleur";
                caption = "Impossible de continuer";
                buttons = MessageBoxButtons.OK;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK) textBox_couleur.Focus();
            }
            else
            {
                if (comboBox_parent.SelectedItem != null)
                    _daoTag.Insert(new Tag(0, textBox_nomTag.Text, textBox_couleur.Text,
                        ((Tag) comboBox_parent.SelectedItem).idt_tag));
                else
                    _daoTag.Insert(new Tag(0, textBox_nomTag.Text, textBox_couleur.Text));

                Close();
            }
        }
    }
}