using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormMain : Form
    {
        private readonly DocumentDAO _daoDocument;
        private readonly LienDAO _daoLien;
        private readonly TagDAO _daoTag;

        private ContextMenuStrip _listViewDocTagsMenu;
        private ContextMenuStrip _listViewTagsMenu;
        private Tag _selectedDocTag;
        private int _selectedDocIndex;

        public FormMain()
        {
            InitializeComponent();
            _daoDocument = new DocumentDAO();
            _daoLien = new LienDAO();
            _daoTag = new TagDAO();
            treeView_tags.TabStop = false;
            if (DarkTheme.Active) DarkMode();
        }

        public void DarkMode()
        {
            pictureBox1.BackColor = DarkTheme.Darkest;
            panel_recherche.BackColor = DarkTheme.Darkest;
            btn_ajoutFichier.BackColor = DarkTheme.Darkest;
            btn_ajoutFichier.ForeColor = DarkTheme.LightColor;
            btn_recherche.BackColor = DarkTheme.Darkest;
            btn_recherche.ForeColor = DarkTheme.LightColor;
            textBox_recherche.BackColor = DarkTheme.LightColor;
            textBox_recherche.ForeColor = DarkTheme.Darkest;
            panel_resultatRecherche.BackColor = DarkTheme.Darkest;
            label2.BackColor = DarkTheme.Darkest;
            listView_doc.BackColor = DarkTheme.MainDark;
            panel_apercu.BackColor = DarkTheme.MediumGrey;
            webBrowser_affichageDoc.BackColor = DarkTheme.MainDark;
            btn_OuvrirDoc.BackColor = DarkTheme.Darkest;
            btn_OuvrirDoc.ForeColor = DarkTheme.LightColor;
            btn_Deldoc.BackColor = DarkTheme.Darkest;
            btn_Deldoc.ForeColor = DarkTheme.LightColor;
            panel_tags.BackColor = DarkTheme.Darkest;
            listView_tags.BackColor = DarkTheme.MainDark;
            treeView_tags.BackColor = DarkTheme.MainDark;
            panel_arbo.BackColor = DarkTheme.Darkest;
            label3.BackColor = DarkTheme.Darkest;
            label1.BackColor = DarkTheme.MainDark;
            panel1.BackColor = DarkTheme.Darkest;
            BackColor = Color.Black;
            ForeColor = DarkTheme.LightColor;

            listView_doc.ForeColor = DarkTheme.LightColor;
            webBrowser_affichageDoc.Visible = false;
        }

        private void btn_ajoutFichier_Click(object sender, EventArgs e) => new FormAddDoc().Show();

        private ImageList icons = new ImageList();

        private void FormMain_Load(object sender, EventArgs e)
        {
            listView_doc.Items.Clear();
            icons.Images.Add(Image.FromFile(@"..\..\Resources\jpg_icon.jpg"));
            icons.Images.Add(Image.FromFile(@"..\..\Resources\pdf_icon.jpg"));
            listView_doc.SmallImageList = icons;

            foreach (var doc in _daoDocument.AllDoc()) listView_doc.Items.Add(new ListViewDoc(doc));

            //Remplissage tag
            treeView_tags.Nodes.Clear();
            var tags = _daoTag.AllTag();
            foreach (var entry in tags.OrderBy(key => key.Key))
                if (entry.Key == 0)
                {
                    foreach (var tag in entry.Value)
                        treeView_tags.Nodes.Add(CreateTagNode(tag));
                }
                else
                {
                    var noeudCourant = treeView_tags.Nodes.Find(entry.Key.ToString(), true);
                    foreach (var tag in entry.Value) noeudCourant[0].Nodes.Add(CreateTagNode(tag));
                }

            listView_tags.ContextMenuStrip = new ContextMenuStrip();
            _listViewDocTagsMenu = CreateContextMenu(new List<Tuple<string, EventHandler>>
            {
                Tuple.Create<string, EventHandler>("Ajouter", AjouterTagADoc),
                Tuple.Create<string, EventHandler>("Supprimer", SupprimerTagDeDoc)
            });
            _listViewTagsMenu = CreateContextMenu(new List<Tuple<string, EventHandler>>
            {
                Tuple.Create<string, EventHandler>("Ajouter", AjouterTagADoc)
            });
        }

        private TagNode CreateTagNode(Tag tag) =>
            new TagNode(tag)
            {
                ContextMenuStrip = CreateContextMenu(new List<Tuple<string, EventHandler>>
                {
                    Tuple.Create<string, EventHandler>("Modifier", ModifTag),
                    Tuple.Create<string, EventHandler>("Supprimer", SupprimerTag)
                })
            };

        private static ContextMenuStrip CreateContextMenu(List<Tuple<string, EventHandler>> items)
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

        private void listView_tagsClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView_doc.SelectedItems.Count != 0)
            {
                var item = (ListViewTag) listView_tags.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    _selectedDocTag = item._tag;
                    _listViewDocTagsMenu.Show(Cursor.Position);
                    _listViewDocTagsMenu.Visible = true;
                    _listViewTagsMenu.Visible = false;
                }
                else
                {
                    _listViewTagsMenu.Show(Cursor.Position);
                    _listViewTagsMenu.Visible = true;
                    _listViewDocTagsMenu.Visible = false;
                }
            }
        }

        private void listBox_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_doc.SelectedItems.Count > 0)
            {
                btn_Deldoc.Enabled = true;
                btn_OuvrirDoc.Enabled = true;
                var doc = ((ListViewDoc) listView_doc.SelectedItems[0])._doc;
                webBrowser_affichageDoc.Navigate(doc.doc_path);
                webBrowser_affichageDoc.Visible = true; //darkmode

                listView_tags.Items.Clear();
                var tags = _daoLien.AllTagDoc(doc);
                foreach (var tag in tags) listView_tags.Items.Add(new ListViewTag(tag));
                if (listView_doc.SelectedIndices.Count > 0) _selectedDocIndex = listView_doc.SelectedIndices[0];
            }
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            var selection = (ListViewDoc) listView_doc.SelectedItems[0];
            var doc = selection._doc;
            _daoDocument.Delete(doc);
            listView_doc.Items.Remove(selection);
            btn_Deldoc.Enabled = false;
            btn_OuvrirDoc.Enabled = false;
            webBrowser_affichageDoc.Navigate("");
            listView_tags.Items.Clear();
            webBrowser_affichageDoc.Visible = false; //darkmode
        }

        private void FormMain_Activated(object sender, EventArgs e) => FormMain_Load(sender, e);

        private void btn_ouvirDoc_Click(object sender, EventArgs e)
        {
            var doc = (Document) listView_doc.SelectedItems[0].Tag;
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
            var box = new List<Document>();
            string filter = textBox_recherche.Text;
            foreach (ListViewDoc nom in listView_doc.Items)
            {
                var tags = _daoLien.AllTagDoc(nom._doc);
                if (nom.ToString().ToLower().Contains(filter.ToLower())) box.Add(nom._doc);

                //TODO : fix le problème lorsque l'on réduit la fenêtre
                if (tags.Any(tag => MatchTag(filter, tag))) box.Add(nom._doc);
            }

            listView_doc.Items.Clear();
            foreach (var doc in box) listView_doc.Items.Add(new ListViewDoc(doc));
        }

        private bool MatchTag(string input, Tag tag) => input == tag.nom ||
                                                        tag.idt_pere != 0 && MatchTag(input,
                                                            _daoTag.FindByIdt(tag.idt_pere));

        private void ModifTag(object sender, EventArgs e) =>
            new FormUpdateTag((TagNode) treeView_tags.SelectedNode).Show();

        private void SelectTag(object sender, EventArgs e) => textBox_recherche.Text = treeView_tags.SelectedNode?.Text;

        private void SupprimerTag(object sender, EventArgs e)
        {
            var node = (TagNode) treeView_tags.SelectedNode;
            _daoTag.DeleteTagWithChildren(node.GetTag());
            treeView_tags.SelectedNode.Remove();
        }

        private void AjouterTagADoc(object sender, EventArgs e)
        {
            // TODO si aucun tag comment en ajouter ?
            var idt_doc = ((ListViewDoc) listView_doc.Items[_selectedDocIndex])._doc.idt_doc;
            new FormAddTagToDoc(idt_doc).Show();
        }

        private void SupprimerTagDeDoc(object sender, EventArgs e)
        {
            _daoLien.Delete(
                new Lien(_selectedDocTag.idt_tag, ((ListViewDoc) listView_doc.Items[_selectedDocIndex])._doc.idt_doc));
            listView_doc.Items[_selectedDocIndex].Selected = false;
            listView_doc.Items[_selectedDocIndex].Selected = true;
        }

        private void treeView_tags_DoubleClick(object sender, EventArgs e) => SelectTag(sender, e);

        private void label3_Click(object sender, EventArgs e) => new FormAddTag().Show();
    }
}