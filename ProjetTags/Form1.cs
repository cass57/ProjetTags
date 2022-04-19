using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            for (var i = 0; i < fileList.Length; i++) filePath += fileList[i];
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

        private void tf_path_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            String path = tf_path.Text;
            Document doc = new Document(path);
            docDao.insert(doc);
            foreach (var itemChecked in Clist_tags.CheckedItems)
            {
                var tag = (Tag) itemChecked;
                Tag currentTag = new Tag(tag.getIdt_tag(), tag.getNom(), tag.getClr(), tag.getIdt_pere());
                Lien lien = new Lien(currentTag.getIdt_tag(), docDao.lastIdt_doc());
                lienDao.insert(lien);
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