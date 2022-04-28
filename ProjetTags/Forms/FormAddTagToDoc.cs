using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Forms;
using ProjetTags.Model;

namespace ProjetTags
{
    public partial class FormAddTagToDoc : Form
    {
        private readonly DocumentDAO _docDao;
        private readonly TagDAO _tagDao;
        private readonly LienDAO _lienDao;
        private readonly int idt_doc;
        
        public FormAddTagToDoc(int idtDoc)
        {
            InitializeComponent();
            _docDao = new DocumentDAO();
            _tagDao = new TagDAO();
            _lienDao = new LienDAO();
            idt_doc = idtDoc;
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
            Document doc = _docDao.FindByIdt(idt_doc);
            List<Tag> tagsDoc = _lienDao.AllTagDoc(doc);
            List<Tag> allTags = _tagDao.AllListTag();
            List<Tag> affiche = new List<Tag>();
            //TODO Except ne fonctionne pas avec la comparaison d'objet. Trouver un moyen d'enlever les tags associés au doc à la liste possible de tag
            affiche = allTags.Except(tagsDoc).ToList();
            Clist_tags.ValueMember = null;
            Clist_tags.DataSource = affiche;
            
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            foreach (var itemChecked in Clist_tags.CheckedItems)
            {
                var tag = (Tag) itemChecked;
                var currentTag = new Tag(tag.idt_tag, tag.nom, tag.clr, tag.idt_pere);
                var lien = new Lien(currentTag.idt_tag, idt_doc);
                _lienDao.Insert(lien);
            }

            Hide();
        }
    }
}