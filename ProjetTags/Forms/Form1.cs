using System;
using System.Windows.Forms;
using ProjetTags.DAO;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public partial class FormAddDoc : Form
    {
        private readonly DocumentDAO _docDao;
        private readonly TagDAO _tagDao;
        private readonly LienDAO _lienDao;

        public FormAddDoc()
        {
            InitializeComponent();
            _docDao = new DocumentDAO();
            _tagDao = new TagDAO();
            _lienDao = new LienDAO();
            if (DarkTheme.Active) DarkMode();
        }

        public void DarkMode()
        {
            tf_path.BackColor = DarkTheme.LightColor;
            btn_explorateur.BackColor = DarkTheme.Darkest;
            btn_explorateur.ForeColor = DarkTheme.LightColor;
            btn_valider.BackColor = DarkTheme.Darkest;
            btn_valider.ForeColor = DarkTheme.LightColor;
            Clist_tags.BackColor = DarkTheme.LightColor;
            lbl_tags.BackColor = DarkTheme.Darkest;
            lbl_tags.ForeColor = DarkTheme.LightColor;
            btn_addTag.BackColor = DarkTheme.Darkest;
            btn_addTag.ForeColor = DarkTheme.LightColor;
            BackColor = DarkTheme.MainDark;
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
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = @"JPEG(*.jpg)|*.jpg|PDF Files(*.pdf)|*.pdf|Cassandra(*.jpg,pdf)|*.jpg;*.pdf",
                FilterIndex = 3,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK) tf_path.Text = openFileDialog.FileName;
        }

        private void tf_path_DragEnter(object sender, DragEventArgs e) => e.Effect =
            e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

        private void btn_valider_Click(object sender, EventArgs e)
        {
            _docDao.Insert(new Document(tf_path.Text));
            foreach (var itemChecked in Clist_tags.CheckedItems)
                _lienDao.Insert(new Lien(new Tag((Tag) itemChecked).idt_tag, _docDao.LastIdtDoc()));

            Hide();
        }

        private void btn_addTag_Click(object sender, EventArgs e) => new FormAddTag().Show();

        private void FormAddDoc_Activated(object sender, EventArgs e)
        {
            Clist_tags.ValueMember = null;
            Clist_tags.DataSource = _tagDao.AllListTag();
        }
    }
}