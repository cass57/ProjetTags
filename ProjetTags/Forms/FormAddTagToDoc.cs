using System;
using System.Linq;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormAddTagToDoc : Form
    {
        private readonly DocumentDAO _docDao;
        private readonly TagDAO _tagDao;
        private readonly LienDAO _lienDao;
        private readonly int _idtDoc;

        public FormAddTagToDoc(int idtDoc)
        {
            InitializeComponent();
            _docDao = new DocumentDAO();
            _tagDao = new TagDAO();
            _lienDao = new LienDAO();
            _idtDoc = idtDoc;
            if (DarkTheme.Active) DarkMode();
        }

        public void DarkMode()
        {
            Clist_tags.BackColor = DarkTheme.LightColor;
            lbl_tags.BackColor = DarkTheme.Darkest;
            lbl_tags.ForeColor = DarkTheme.LightColor;
            btn_addTag.BackColor = DarkTheme.Darkest;
            btn_addTag.ForeColor = DarkTheme.LightColor;
            btn_valider.BackColor = DarkTheme.Darkest;
            btn_valider.ForeColor = DarkTheme.LightColor;
            BackColor = DarkTheme.MainDark;
        }

        private void btn_addTag_Click(object sender, EventArgs e) => new FormAddTag().Show();

        private void FormAddTagToDoc_Activated(object sender, EventArgs e)
        {
            var doc = _docDao.FindByIdt(_idtDoc);
            var tagsDoc = _lienDao.AllTagDoc(doc);
            var allTags = _tagDao.AllListTag();
            //TODO Except ne fonctionne pas avec la comparaison d'objet. Trouver un moyen d'enlever les tags associés au doc à la liste possible de tag
            //TODO En fait c'est réparé non ?
            Clist_tags.ValueMember = null;
            Clist_tags.DataSource = allTags.Except(tagsDoc).ToList();
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            foreach (var itemChecked in Clist_tags.CheckedItems)
                _lienDao.Insert(new Lien(new Tag((Tag) itemChecked).idt_tag, _idtDoc));

            Hide();
        }
    }
}