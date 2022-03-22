using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormMain : Form
    {
        private DocumentDAO dao;
        public FormMain()
        {
            InitializeComponent();
            dao = new DocumentDAO();
        }

        private void btn_ajoutFichier_Click(object sender, EventArgs e)
        {
            FormAdd doc = new FormAdd();
            doc.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listBox_doc.Items.Clear();
            List<Document> docs = dao.allDoc();

            foreach (var doc in docs)
            {
                listBox_doc.Items.Add(doc);
            }
            
        }

        private void pictureBox_DelDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.delete(doc);
            listBox_doc.Items.Remove(doc);

        }

        private void listBox_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Deldoc.Enabled = true;
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.delete(doc);
            listBox_doc.Items.Remove(doc);
            btn_Deldoc.Enabled = false;
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            FormMain_Load(sender, e);
        }
    }
}