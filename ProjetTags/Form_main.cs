using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetTags
{
    public partial class FormMain : Form
    {
        private DocumentDAO dao;
        private LienDAO daoLien;
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
            if (listBox_doc.SelectedItem != null)
            {
                btn_Deldoc.Enabled = true;
                button1.Enabled = true;
                Document doc = (Document) listBox_doc.SelectedItem;
                //WebBrowser_affichageDoc.Navigate(doc.getDoc_path());
                
                // TODO : debug affichage des tags d'un doc??
                /*listBox_tags.Items.Clear();
                var tags = daoLien.allTagDoc(doc);

                foreach (var tag in tags)
                {
                    listBox_tags.Items.Add(tag);
                }*/
            }
        }

        private void btn_Deldoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            dao.delete(doc);
            listBox_doc.Items.Remove(doc);
            btn_Deldoc.Enabled = false;
            button1.Enabled = false;
            //WebBrowser_affichageDoc.Navigate("");
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            FormMain_Load(sender, e);
        }

        private void btn_ouvirDoc_Click(object sender, EventArgs e)
        {
            Document doc = (Document) listBox_doc.SelectedItem;
            System.Diagnostics.Process.Start(doc.getDoc_path());
            //WebBrowser_affichageDoc.Navigate("");
        }
    }
}