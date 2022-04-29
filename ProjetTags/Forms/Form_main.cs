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
        private readonly ImageList _icons = new ImageList();
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

        public void LightMode()
        {
            pictureBox1.BackColor = LightTheme.Lightest;
            panel_recherche.BackColor = LightTheme.Lightest;
            btn_ajoutFichier.BackColor = LightTheme.Lightest;
            btn_ajoutFichier.ForeColor = Color.Black;
            btn_recherche.BackColor = LightTheme.Lightest;
            btn_recherche.ForeColor = Color.Black;
            textBox_recherche.BackColor = LightTheme.LightColor;
            textBox_recherche.ForeColor = Color.Black;
            panel_resultatRecherche.BackColor = LightTheme.Lightest;
            label2.BackColor = LightTheme.Lightest;
            listView_doc.BackColor = LightTheme.MainLight;
            panel_apercu.BackColor = LightTheme.Lightest;
            webBrowser_affichageDoc.BackColor = LightTheme.Lightest;
            btn_OuvrirDoc.BackColor = LightTheme.Lightest;
            btn_OuvrirDoc.ForeColor = Color.Black;
            btn_Deldoc.BackColor = LightTheme.Lightest;
            btn_Deldoc.ForeColor = Color.Black;
            panel_tags.BackColor = LightTheme.Lightest;
            listView_tags.BackColor = LightTheme.MainLight;
            treeView_tags.BackColor = LightTheme.MainLight;
            panel_arbo.BackColor = LightTheme.Lightest;
            label3.BackColor = LightTheme.Lightest;
            label1.BackColor = LightTheme.GreyTags;
            BackColor = SystemColors.ScrollBar;
            ForeColor = Color.Black;

            listView_doc.ForeColor = Color.Black;
            btn_DarkMode.Text = @"🌙";
            btn_DarkMode.ForeColor = Color.LightYellow;
            SwitchTheme();
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
            panel_resultatRecherche.BackColor = DarkTheme.MainDark;
            label2.BackColor = DarkTheme.Darkest;
            listView_doc.BackColor = DarkTheme.MainDark;
            panel_apercu.BackColor = DarkTheme.MediumGrey;
            webBrowser_affichageDoc.BackColor = DarkTheme.MainDark;
            btn_OuvrirDoc.BackColor = DarkTheme.Darkest;
            btn_OuvrirDoc.ForeColor = DarkTheme.LightColor;
            btn_Deldoc.BackColor = DarkTheme.Darkest;
            btn_Deldoc.ForeColor = DarkTheme.LightColor;
            panel_tags.BackColor = DarkTheme.MainDark;
            listView_tags.BackColor = DarkTheme.MainDark;
            treeView_tags.BackColor = DarkTheme.MainDark;
            panel_arbo.BackColor = DarkTheme.MediumGrey;
            label3.BackColor = DarkTheme.Darkest;
            label1.BackColor = DarkTheme.MainDark;
            BackColor = Color.Black;
            ForeColor = DarkTheme.LightColor;

            listView_doc.ForeColor = DarkTheme.LightColor;
            btn_DarkMode.Text = @"☀";
            btn_DarkMode.ForeColor = Color.Yellow;
            SwitchTheme();
        }

        private static void SwitchTheme() => DarkTheme.Active = !DarkTheme.Active;

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadIcons();
            LoadDocuments();
            LoadTreeView();
            LoadMenus();
        }

        private void LoadIcons()
        {
            _icons.Images.Add(Image.FromFile(@"..\..\Resources\jpg_icon.jpg"));
            _icons.Images.Add(Image.FromFile(@"..\..\Resources\pdf_icon.jpg"));
        }

        private void LoadDocuments()
        {
            listView_doc.SmallImageList = _icons;
            listView_doc.Items.Clear();
            foreach (var doc in _daoDocument.AllDoc()) listView_doc.Items.Add(new ListViewDoc(doc));
        }

        private void LoadTreeView()
        {
            treeView_tags.Nodes.Clear();
            foreach (var entry in _daoTag.AllTag().OrderBy(key => key.Key))
            foreach (var tag in entry.Value)
                if (entry.Key == 0)
                    treeView_tags.Nodes.Add(CreateTagNode(tag));
                else
                    treeView_tags.Nodes.Find(entry.Key.ToString(), true)[0].Nodes.Add(CreateTagNode(tag));
        }

        private void LoadMenus()
        {
            listView_tags.ContextMenuStrip = new ContextMenuStrip();
            _listViewDocTagsMenu = Utils.CreateContextMenu(new List<Tuple<string, EventHandler>>
            {
                Tuple.Create<string, EventHandler>("Ajouter", AjouterTagADoc),
                Tuple.Create<string, EventHandler>("Supprimer", SupprimerTagDeDoc)
            });
            _listViewTagsMenu = Utils.CreateContextMenu(new List<Tuple<string, EventHandler>>
            {
                Tuple.Create<string, EventHandler>("Ajouter", AjouterTagADoc)
            });
        }

        private TagNode CreateTagNode(Tag tag) =>
            new TagNode(tag)
            {
                ContextMenuStrip = Utils.CreateContextMenu(new List<Tuple<string, EventHandler>>
                {
                    Tuple.Create<string, EventHandler>("Modifier", ModifTag),
                    Tuple.Create<string, EventHandler>("Supprimer", SupprimerTag)
                })
            };

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
                var doc = ((ListViewDoc) listView_doc.SelectedItems[0])._doc;
                LoadPreview(doc);
                LoadListViewTag(doc);
                if (listView_doc.SelectedIndices.Count > 0) _selectedDocIndex = listView_doc.SelectedIndices[0];
            }
        }

        private void LoadListViewTag(Document doc)
        {
            listView_tags.Items.Clear();
            var tags = _daoLien.AllTagDoc(doc);
            foreach (var tag in tags) listView_tags.Items.Add(new ListViewTag(tag));
        }

        private void LoadPreview(Document doc)
        {
            EnablePreviewButtons(true);
            webBrowser_affichageDoc.Navigate(doc.doc_path);
        }

        private void EnablePreviewButtons(bool enable)
        {
            btn_Deldoc.Enabled = enable;
            btn_OuvrirDoc.Enabled = enable;
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            var selection = (ListViewDoc) listView_doc.SelectedItems[0];
            _daoDocument.Delete(selection._doc);
            listView_doc.Items.Remove(selection);
            listView_tags.Items.Clear();
            ClosePreview();
        }

        private void ClosePreview()
        {
            EnablePreviewButtons(false);
            webBrowser_affichageDoc.Navigate("");
        }

        private void FormMain_Activated(object sender, EventArgs e) => FormMain_Load(sender, e);

        private void btn_ouvirDoc_Click(object sender, EventArgs e)
        {
            var doc = ((ListViewDoc) listView_doc.SelectedItems[0])._doc;
            if (doc != null)
            {
                Process.Start(doc.doc_path);
                webBrowser_affichageDoc.Navigate("");
            }
        }

        private void TextBoxSearch(object sender, EventArgs e)
        {
            LoadDocuments();
            var box = new List<Document>();
            TagNode idTag = (TagNode) treeView_tags.SelectedNode;
            int id = idTag.GetTag().idt_tag;
            List<int> listeDoc = _daoLien.FindAllDocByIdtTag(id);
            string filter = textBox_recherche.Text.Trim();
            foreach (ListViewDoc nom in listView_doc.Items)
            {
                //filter matches doc name
                if (nom.ToString().ToLower().Contains(filter.ToLower())) box.Add(nom._doc);
                
                //filter matches link between tag id and doc
                //if (listeDoc.Contains(nom._doc.idt_doc)) box.Add(nom._doc);
                if (_daoLien.AllTagDoc(nom._doc).Any(tag => MatchTag(id, tag))) box.Add(nom._doc);
            }

            listView_doc.Items.Clear();
            foreach (var doc in box) listView_doc.Items.Add(new ListViewDoc(doc));
        }

        private bool MatchTag(int input, Tag tag) =>
            Equals(input, tag.idt_tag) ||
            tag.idt_pere != 0 && MatchTag(input,
                _daoTag.FindByIdt(tag.idt_pere));

        private void ModifTag(object sender, EventArgs e) =>
            new FormUpdateTag((TagNode) treeView_tags.SelectedNode).Show();

        private void SelectTag()
        {
            textBox_recherche.Text = "";
            textBox_recherche.Text = treeView_tags.SelectedNode?.Text;
        }

        private void SupprimerTag(object sender, EventArgs e)
        {
            _daoTag.DeleteTagWithChildren(((TagNode) treeView_tags.SelectedNode).GetTag());
            treeView_tags.SelectedNode.Remove();
        }

        private void AjouterTagADoc(object sender, EventArgs e) =>
            new FormAddTagToDoc(((ListViewDoc) listView_doc.Items[_selectedDocIndex])._doc.idt_doc).Show(this);

        private void SupprimerTagDeDoc(object sender, EventArgs e)
        {
            _daoLien.Delete(
                new Lien(_selectedDocTag.idt_tag, ((ListViewDoc) listView_doc.Items[_selectedDocIndex])._doc.idt_doc));
            ReselectDoc();
        }

        public void ReselectDoc()
        {
            listView_doc.Items[_selectedDocIndex].Selected = false;
            listView_doc.Items[_selectedDocIndex].Selected = true;
        }

        private void treeView_tags_DoubleClick(object sender, EventArgs e) => SelectTag();

        private void label3_Click(object sender, EventArgs e) => new FormAddTag().Show();

        private void btn_ajoutFichier_Click(object sender, EventArgs e) => new FormAddDoc().Show();

        private void btn_DarkMode_Click(object sender, EventArgs e)
        {
            if (btn_DarkMode.Text == @"🌙")
                DarkMode();
            else
                LightMode();
        }
    }
}