﻿using System;
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

        private ContextMenuStrip _listBoxTagsMenu;
        private Tag _selectedDocTag;
        private int _selectedDocIndex;

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
            var tags = daoTag.AllTag();
            foreach (var entry in tags.OrderBy(key => key.Key))
                if (entry.Key == 0)
                    foreach (var tag in entry.Value)
                        treeView_tags.Nodes.Add(CreateTagNode(tag));
                else
                {
                    TreeNode[] noeudCourant = treeView_tags.Nodes.Find(entry.Key.ToString(), true);
                    foreach (var tag in entry.Value) noeudCourant[0].Nodes.Add(CreateTagNode(tag));
                }

            listBox_tags.ContextMenuStrip = new ContextMenuStrip();
            _listBoxTagsMenu = CreateContextMenu(new List<Tuple<string, EventHandler>>
            {
                Tuple.Create<string, EventHandler>("Ajouter", ajouterTagADoc),
                Tuple.Create<string, EventHandler>("Supprimer", supprimerTagDeDoc)
            });
        }

        private TagNode CreateTagNode(Tag tag)
        {
            return new TagNode(tag)
            {
                ContextMenuStrip = CreateContextMenu(new List<Tuple<string, EventHandler>>
                {
                    Tuple.Create<string, EventHandler>("Modifier", modifTag),
                    Tuple.Create<string, EventHandler>("Supprimer", supprimerTag)
                })
            };
        }

        private ContextMenuStrip CreateContextMenu(List<Tuple<string, EventHandler>> items)
        {
            var tagMenu = new ContextMenuStrip();
            foreach (var item in items)
            {
                var label = new ToolStripMenuItem();
                label.Text = item.Item1;
                label.Click += item.Item2;
                tagMenu.Items.Add(label);
            }

            return tagMenu;
        }

        private void listBox_tagsClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var index = listBox_tags.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    _selectedDocTag = (Tag) listBox_tags.Items[index];
                    _listBoxTagsMenu.Show(Cursor.Position);
                    _listBoxTagsMenu.Visible = true;
                }
                else
                    _listBoxTagsMenu.Visible = false;
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
                if (listBox_doc.SelectedIndex != -1) _selectedDocIndex = listBox_doc.SelectedIndex;
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
            if (doc != null)
            {
                Process.Start(doc.doc_path);
                webBrowser_affichageDoc.Navigate("");
            }
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

        private void supprimerTag(object sender, EventArgs e)
        {
            TagNode node = (TagNode) treeView_tags.SelectedNode;
            daoTag.DeleteTagWithChildren(node.GetTag());
            treeView_tags.SelectedNode.Remove();
        }

        private void ajouterTagADoc(object sender, EventArgs e)
        {
        }

        private void supprimerTagDeDoc(object sender, EventArgs e)
        {
            var lien = new Lien(_selectedDocTag.idt_tag, ((Document) listBox_doc.Items[_selectedDocIndex]).idt_doc);
            daoLien.Delete(lien);
            listBox_doc.SetSelected(_selectedDocIndex, true);
        }

        private void treeView_tags_DoubleClick(object sender, EventArgs e) => selectTag(sender, e);

        private void label3_Click(object sender, EventArgs e)
        {
            FormAddTag tag = new FormAddTag();
            tag.Show();
        }
    }
}