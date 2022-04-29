using System;
using System.Linq;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormAddTagToDoc : Form
    {
        //DAO
        private readonly DocumentDAO _docDao;
        private readonly TagDAO _tagDao;
        private readonly LienDAO _lienDao;
        //Identifiant doc selectionné sur la  fenêtre principale
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

        /// <summary>
        /// Ouvre la fenêtre pour créer un nouveau tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addTag_Click(object sender, EventArgs e) => new FormAddTag().Show();

        /// <summary>
        /// Remplissage de la comboBox avec les tags non liés au document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddTagToDoc_Activated(object sender, EventArgs e)
        {
            var tagsDoc = _lienDao.AllTagDoc(_docDao.FindByIdt(_idtDoc));
            var allTags = _tagDao.AllListTag();
            Clist_tags.ValueMember = null;
            Clist_tags.DataSource = allTags.Except(tagsDoc).ToList();
        }

        
        /// <summary>
        /// Ajout du tag au document (création de la liaison)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_valider_Click(object sender, EventArgs e)
        {
            foreach (var itemChecked in Clist_tags.CheckedItems)
                _lienDao.Insert(new Lien(new Tag((Tag) itemChecked).idt_tag, _idtDoc));
            ((FormMain) Owner).ReselectDoc();
            Hide();
        }
    }
}