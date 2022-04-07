using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormMain : Form
    {
        private DocumentDAO dao;
        private LienDAO daoLien;
        private TagDAO daoTag;

        public FormMain()
        {
            InitializeComponent();
            dao = new DocumentDAO();
            daoLien = new LienDAO();
            daoTag = new TagDAO();
        }

        private void btn_ajoutFichier_Click(object sender, EventArgs e)
        {
            FormAdd doc = new FormAdd();
            doc.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listBox_doc.Items.Clear();
            List<Document> docs = dao.allDoc();

            foreach (var doc in docs)
            {
                listBox_doc.Items.Add(doc);
            }

            //Remplissage tag
            treeView_tags.Nodes.Clear();
            IDictionary<int, List<Tag>> tags = daoTag.allTag();
            foreach (KeyValuePair<int, List<Tag>> entry in tags.OrderBy(key => key.Key))
            {
                if (entry.Key == 0)
                {
                    for (int i = 0; i < entry.Value.Count; i++)
                    {
                        treeView_tags.Nodes.Add(new TagNode(entry.Value[i]));
                    }
                }
                else
                {
                    TreeNode[] noeudCourant = treeView_tags.Nodes.Find(entry.Key.ToString(), true);
                    for (int i = 0; i < entry.Value.Count; i++)
                    {
                        noeudCourant[0].Nodes.Add(new TagNode(entry.Value[i]));
                    }
                }
            }
        }

        private void pictureBox_DelDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.delete(doc);
            listBox_doc.Items.Remove(doc);
        }

        private void listBox_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_doc.SelectedItem != null)
            {
                btn_Deldoc.Enabled = true;
                btn_OuvrirDoc.Enabled = true;
                Document doc = (Document) listBox_doc.SelectedItem;
                WebBrowser_affichageDoc.Navigate(doc.getDoc_path());

                // TODO : debug affichage des tags d'un doc??
                listBox_tags.Items.Clear();
                List<Tag> tags = daoLien.allTagDoc(doc);

                foreach (var tag in tags)
                {
                    listBox_tags.Items.Add(tag);
                }
            }
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.delete(doc);
            listBox_doc.Items.Remove(doc);
            btn_Deldoc.Enabled = false;
            btn_OuvrirDoc.Enabled = false;
            WebBrowser_affichageDoc.Navigate("");
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            FormMain_Load(sender, e);
        }

        private void btn_ouvirDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            System.Diagnostics.Process.Start(doc.getDoc_path());
            WebBrowser_affichageDoc.Navigate("");
        }

        private void textBox_recherche_TextChanged(object sender, EventArgs e)
        {
            //TODO : Sortir les méthodes chargementTreeView,chargementListBox
            FormMain_Load(sender, e);
            ListBox box = new ListBox();
            string filter = textBox_recherche.Text.ToString();
            var itemList = listBox_doc.Items;
            if (itemList.Count > 0)
            {
                foreach (var nom in itemList)
                {
                    if (nom.ToString().ToLower().Contains(filter.ToLower()))
                    {
                        box.Items.Add(nom);
                    }
                }

                listBox_doc.Items.Clear();
                foreach (var doc in box.Items)
                {
                    listBox_doc.Items.Add(doc);
                }
            }
        }
    }
}