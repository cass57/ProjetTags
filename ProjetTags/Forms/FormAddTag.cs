using System;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormAddTag : Form
    {
        private readonly TagDAO _daoTag;

        public FormAddTag()
        {
            InitializeComponent();
            _daoTag = new TagDAO();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var tags = _daoTag.AllTag();
            foreach (var entry in tags)
                foreach (var tag in entry.Value)
                    comboBox_parent.Items.Add(tag);
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
                {
                    var pere = (Tag) comboBox_parent.SelectedItem;
                    _daoTag.Insert(new Tag(0, textBox_nomTag.Text, textBox_couleur.Text, pere.idt_tag));
                }
                else
                    _daoTag.InsertSansPere(new Tag(0, textBox_nomTag.Text, textBox_couleur.Text));

                Close();
            }
        }
    }
}