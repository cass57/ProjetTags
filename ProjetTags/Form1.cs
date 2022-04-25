using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormAddDoc : Form
    {
        private DocumentDAO docDao;
        private TagDAO tagDao;
        private LienDAO lienDao;

        public FormAddDoc()
        {
            InitializeComponent();
            docDao = new DocumentDAO();
            tagDao = new TagDAO();
            lienDao = new LienDAO();
        }

        private void tf_path_DragDrop(object sender, DragEventArgs e)
        {
            var fileList = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            var filePath = "";
            foreach (var f in fileList)
                filePath += f;

            tf_path.Text = filePath;
        }

        private void btn_explorateur_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                //Filtre 
                openFileDialog.Filter = @"JPEG(*.jpg)|*.jpg|PDF Files(*.pdf)|*.pdf|Cassandra(*.jpg,pdf)|*.jpg;*.pdf";
                //On commence sur le filtre double par défaut
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) tf_path.Text = openFileDialog.FileName;
            }
        }

        private void tf_path_DragEnter(object sender, DragEventArgs e) => e.Effect =
            e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

        private void btn_valider_Click(object sender, EventArgs e)
        {
            string path = tf_path.Text;
            Document doc = new Document(path);
            docDao.Insert(doc);
            foreach (var itemChecked in Clist_tags.CheckedItems)
            {
                var tag = (Tag) itemChecked;
                Tag currentTag = new Tag(tag.idt_tag, tag.nom, tag.clr, tag.idt_pere);
                Lien lien = new Lien(currentTag.idt_tag, docDao.LastIdtDoc());
                lienDao.Insert(lien);
            }

            Hide();
        }

        private void btn_addTag_Click(object sender, EventArgs e)
        {
            FormAddTag tag = new FormAddTag();
            tag.Show();
        }

        private void FormAddDoc_Activated(object sender, EventArgs e)
        {
            List<Tag> tags = tagDao.allListTag();
            Clist_tags.ValueMember = null;
            Clist_tags.DataSource = tags;
        }
    }
}