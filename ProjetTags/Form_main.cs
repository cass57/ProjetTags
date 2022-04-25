using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            treeView_tags.TabStop = false;
        }

        private void btn_ajoutFichier_Click(object sender, EventArgs e)
        {
            FormAddDoc doc = new FormAddDoc();
            doc.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listBox_doc.Items.Clear();
            List<Document> docs = dao.AllDoc();

            foreach (var doc in docs) listBox_doc.Items.Add(doc);


            //Remplissage tag
            treeView_tags.Nodes.Clear();
            IDictionary<int, List<Tag>> tags = daoTag.AllTag();
            foreach (var entry in tags.OrderBy(key => key.Key))
            {
                if (entry.Key == 0)
                {
                    foreach (var tag in entry.Value)
                    {
                        TagNode tagNode = new TagNode(tag);
                        treeView_tags.Nodes.Add(tagNode);
                        ContextMenuStrip tagMenu = new ContextMenuStrip();
                        ToolStripMenuItem modifLabel = new ToolStripMenuItem();
                        modifLabel.Text = "Modifier";
                        modifLabel.Click += modifTag;
                        ToolStripMenuItem suppLabel = new ToolStripMenuItem();
                        suppLabel.Text = "Supprimer";
                        suppLabel.Click += supprimerTag;
                        tagMenu.Items.AddRange(new ToolStripItem[] {modifLabel, suppLabel});
                        tagNode.ContextMenuStrip = tagMenu;
                    }
                }
                else
                {
                    TreeNode[] noeudCourant = treeView_tags.Nodes.Find(entry.Key.ToString(), true);
                    foreach (var tag in entry.Value)
                    {
                        TagNode tagNode = new TagNode(tag);
                        noeudCourant[0].Nodes.Add(tagNode);
                        ContextMenuStrip tagMenu = new ContextMenuStrip();
                        ToolStripMenuItem modifLabel = new ToolStripMenuItem();
                        modifLabel.Text = "Modifier";
                        modifLabel.Click += modifTag;
                        ToolStripMenuItem suppLabel = new ToolStripMenuItem();
                        suppLabel.Text = "Supprimer";
                        suppLabel.Click += supprimerTag;
                        tagMenu.Items.AddRange(new ToolStripItem[] {modifLabel, suppLabel});
                        tagNode.ContextMenuStrip = tagMenu;
                    }
                }
            }
        }

        private void pictureBox_DelDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.Delete(doc);
            listBox_doc.Items.Remove(doc);
        }

        private void listBox_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_doc.SelectedItem != null)
            {
                btn_Deldoc.Enabled = true;
                btn_OuvrirDoc.Enabled = true;
                Document doc = (Document) listBox_doc.SelectedItem;
                webBrowser_affichageDoc.Navigate(doc.doc_path);

                listBox_tags.Items.Clear();
                List<Tag> tags = daoLien.allTagDoc(doc);

                foreach (var tag in tags) listBox_tags.Items.Add(tag);
            }
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.Delete(doc);
            listBox_doc.Items.Remove(doc);
            btn_Deldoc.Enabled = false;
            btn_OuvrirDoc.Enabled = false;
            webBrowser_affichageDoc.Navigate("");
        }

        private void FormMain_Activated(object sender, EventArgs e) => FormMain_Load(sender, e);

        private void btn_ouvirDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            Process.Start(doc.doc_path);
            webBrowser_affichageDoc.Navigate("");
        }

        private void textBox_recherche_TextChanged(object sender, EventArgs e)
        {
            //TODO : Sortir les méthodes chargementTreeView,chargementListBox
            FormMain_Load(sender, e);
            ListBox box = new ListBox();
            List<Tag> tags = new List<Tag>();
            string filter = textBox_recherche.Text;
            var itemList = listBox_doc.Items;
            if (itemList.Count > 0)
            {
                foreach (var nom in itemList)
                {
                    Document doc = (Document) nom;
                    tags = daoLien.allTagDoc(doc);
                    if (nom.ToString().ToLower().Contains(filter.ToLower())) box.Items.Add(nom);

                    //TODO : fix le problème lorsque l'on réduit la fenêtre
                    if (tags.Any(tag => MatchTag(filter, tag))) box.Items.Add(nom);
                }

                listBox_doc.Items.Clear();
                foreach (var doc in box.Items) listBox_doc.Items.Add(doc);
            }
        }

        private bool MatchTag(string input, Tag tag) => input == tag.nom ||
                                                        tag.idt_pere != 0 && MatchTag(input,
                                                            daoTag.FindByIdt(tag.idt_pere));

        private void pictureBox_DelTag_Click(object sender, EventArgs e)
        {
            DialogResult result;

            TagNode node = (TagNode) treeView_tags.SelectedNode;

            if (node == null)
            {
                var message = "Veuillez sélectionner un tag à supprimer";
                var caption = "Impossible de continuer";
                var buttons = MessageBoxButtons.OK;

                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                supprimerTag(sender, e);
                FormMain_Load(sender, e);
            }
        }

        private void modifTag(Object sender, EventArgs e)
        {
            TagNode tagAModif = (TagNode) treeView_tags.SelectedNode;
            FormUpdateTag tag = new FormUpdateTag(tagAModif);
            tag.Show();
        }

        private void selectTag(object sender, EventArgs e)
        {
            string filter = treeView_tags.SelectedNode?.Text;
            textBox_recherche.Text = filter;
        }

        private void supprimerTag(Object sender, EventArgs e)
        {
            TagNode node = (TagNode) treeView_tags.SelectedNode;
            daoTag.DeleteTagWithChildren(node.GetTag());
            treeView_tags.SelectedNode.Remove();
        }

        private void treeView_tags_DoubleClick(object sender, EventArgs e) => selectTag(sender, e);

        private void label3_Click(object sender, EventArgs e)
        {
            FormAddTag tag = new FormAddTag();
            tag.Show();
        }
        
    }
}