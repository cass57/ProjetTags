using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormAddTag : Form
    {
        private TagDAO daoTag;
        
        public FormAddTag()
        {
            InitializeComponent();
            daoTag = new TagDAO();
        }

        protected override void OnLoad(EventArgs e)
        {
           base.OnLoad(e);
           IDictionary<int, List<Tag>> tags = daoTag.AllTag();
           foreach (var entry in tags)
           {
               foreach (var tag in entry.Value) comboBox_parent.Items.Add(tag);
           }
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
                Tag tag;
                if (comboBox_parent.SelectedItem != null)
                { 
                    Tag pere = (Tag) comboBox_parent.SelectedItem;
                    tag = new Tag(0, textBox_nomTag.Text, textBox_couleur.Text, pere.idt_tag);
                    tag = daoTag.Insert(tag);
                }
                else
                {
                    tag = new Tag(0, textBox_nomTag.Text, textBox_couleur.Text);
                    tag = daoTag.insertSansPere(tag);
                }
                Close();
            }
        }
    }
}