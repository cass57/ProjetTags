using System;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void tf_path_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filePath = "";
            for (int i = 0; i < fileList.Length; i++)
            {
                filePath += fileList[i];
            }
            tf_path.Text = filePath;
        }

        private void btn_explorateur_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                //Filtre 
                openFileDialog.Filter = @"JPEG(*.jpg)|*.jpg|PDF Files(*.pdf)|*.pdf|Cassandra(*.jpg,pdf)|*.jpg;*.pdf";
                //On commence sur le filtre double par défaut
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    tf_path.Text = openFileDialog.FileName;
                }
            }
        }

        private void tf_path_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}