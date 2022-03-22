using System;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormAdd : Form
    {
        private DocumentDAO dao;
        public FormAdd()
        {
            InitializeComponent();
            dao = new DocumentDAO();
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
            dao.insert(doc);
            Hide();
        }
    }
}