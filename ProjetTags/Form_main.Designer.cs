using System;

using MySql.Data.MySqlClient;

namespace ProjetTags
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_arbo = new System.Windows.Forms.Panel();
            this.treeView_tags = new System.Windows.Forms.TreeView();
            this.pictureBox_droite = new System.Windows.Forms.PictureBox();
            this.pictureBox_arriere = new System.Windows.Forms.PictureBox();
            this.pictureBox_addTag = new System.Windows.Forms.PictureBox();
            this.pictureBox_gauche = new System.Windows.Forms.PictureBox();
            this.pictureBox_DelTag = new System.Windows.Forms.PictureBox();
            this.panel_logoNom = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_recherche = new System.Windows.Forms.Panel();
            this.btn_ajoutFichier = new System.Windows.Forms.Button();
            this.radioButton_ou = new System.Windows.Forms.RadioButton();
            this.radioButton_et = new System.Windows.Forms.RadioButton();
            this.btn_recherche = new System.Windows.Forms.Button();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.panel_resultatRecherche = new System.Windows.Forms.Panel();
            this.listBox_doc = new System.Windows.Forms.ListBox();
            this.panel_apercu = new System.Windows.Forms.Panel();
            this.WebBrowser_affichageDoc = new System.Windows.Forms.WebBrowser();
            this.panel_tags = new System.Windows.Forms.Panel();
            this.listBox_tags = new System.Windows.Forms.ListBox();
            this.btn_Deldoc = new System.Windows.Forms.Button();
            this.btn_OuvrirDoc = new System.Windows.Forms.Button();
            this.panel_arbo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_droite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_arriere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_addTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_gauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_DelTag)).BeginInit();
            this.panel_logoNom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.panel_recherche.SuspendLayout();
            this.panel_resultatRecherche.SuspendLayout();
            this.panel_apercu.SuspendLayout();
            this.panel_tags.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_arbo
            // 
            this.panel_arbo.Controls.Add(this.treeView_tags);
            this.panel_arbo.Controls.Add(this.pictureBox_droite);
            this.panel_arbo.Controls.Add(this.pictureBox_arriere);
            this.panel_arbo.Controls.Add(this.pictureBox_addTag);
            this.panel_arbo.Controls.Add(this.pictureBox_gauche);
            this.panel_arbo.Controls.Add(this.pictureBox_DelTag);
            this.panel_arbo.Location = new System.Drawing.Point(12, 99);
            this.panel_arbo.Name = "panel_arbo";
            this.panel_arbo.Size = new System.Drawing.Size(227, 432);
            this.panel_arbo.TabIndex = 5;
            // 
            // treeView_tags
            // 
            this.treeView_tags.Location = new System.Drawing.Point(8, 42);
            this.treeView_tags.Name = "treeView_tags";
            this.treeView_tags.Size = new System.Drawing.Size(209, 387);
            this.treeView_tags.TabIndex = 5;
            // 
            // pictureBox_droite
            // 
            this.pictureBox_droite.Image = global::ProjetTags.Properties.Resources.flecheDroite;
            this.pictureBox_droite.Location = new System.Drawing.Point(93, 19);
            this.pictureBox_droite.Name = "pictureBox_droite";
            this.pictureBox_droite.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_droite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_droite.TabIndex = 2;
            this.pictureBox_droite.TabStop = false;
            // 
            // pictureBox_arriere
            // 
            this.pictureBox_arriere.Image = global::ProjetTags.Properties.Resources.retour;
            this.pictureBox_arriere.Location = new System.Drawing.Point(180, 19);
            this.pictureBox_arriere.Name = "pictureBox_arriere";
            this.pictureBox_arriere.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_arriere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_arriere.TabIndex = 4;
            this.pictureBox_arriere.TabStop = false;
            // 
            // pictureBox_addTag
            // 
            this.pictureBox_addTag.Image = global::ProjetTags.Properties.Resources.plus;
            this.pictureBox_addTag.Location = new System.Drawing.Point(8, 19);
            this.pictureBox_addTag.Name = "pictureBox_addTag";
            this.pictureBox_addTag.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_addTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_addTag.TabIndex = 0;
            this.pictureBox_addTag.TabStop = false;
            this.pictureBox_addTag.Click += new System.EventHandler(this.pictureBox_addTag_Click);
            // 
            // pictureBox_gauche
            // 
            this.pictureBox_gauche.Image = global::ProjetTags.Properties.Resources.flecheGauche;
            this.pictureBox_gauche.Location = new System.Drawing.Point(137, 19);
            this.pictureBox_gauche.Name = "pictureBox_gauche";
            this.pictureBox_gauche.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_gauche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_gauche.TabIndex = 3;
            this.pictureBox_gauche.TabStop = false;
            // 
            // pictureBox_DelTag
            // 
            this.pictureBox_DelTag.Image = global::ProjetTags.Properties.Resources.moins;
            this.pictureBox_DelTag.Location = new System.Drawing.Point(51, 19);
            this.pictureBox_DelTag.Name = "pictureBox_DelTag";
            this.pictureBox_DelTag.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_DelTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_DelTag.TabIndex = 1;
            this.pictureBox_DelTag.TabStop = false;
            // 
            // panel_logoNom
            // 
            this.panel_logoNom.Controls.Add(this.pictureBox1);
            this.panel_logoNom.Location = new System.Drawing.Point(12, 19);
            this.panel_logoNom.Name = "panel_logoNom";
            this.panel_logoNom.Size = new System.Drawing.Size(227, 74);
            this.panel_logoNom.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetTags.Properties.Resources.logoProjetDotNet;
            this.pictureBox1.Location = new System.Drawing.Point(29, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_recherche
            // 
            this.panel_recherche.Controls.Add(this.btn_ajoutFichier);
            this.panel_recherche.Controls.Add(this.radioButton_ou);
            this.panel_recherche.Controls.Add(this.radioButton_et);
            this.panel_recherche.Controls.Add(this.btn_recherche);
            this.panel_recherche.Controls.Add(this.textBox_recherche);
            this.panel_recherche.Location = new System.Drawing.Point(244, 19);
            this.panel_recherche.Name = "panel_recherche";
            this.panel_recherche.Size = new System.Drawing.Size(580, 74);
            this.panel_recherche.TabIndex = 7;
            // 
            // btn_ajoutFichier
            // 
            this.btn_ajoutFichier.Location = new System.Drawing.Point(517, 29);
            this.btn_ajoutFichier.Name = "btn_ajoutFichier";
            this.btn_ajoutFichier.Size = new System.Drawing.Size(60, 24);
            this.btn_ajoutFichier.TabIndex = 4;
            this.btn_ajoutFichier.Text = "➕";
            this.btn_ajoutFichier.UseVisualStyleBackColor = true;
            this.btn_ajoutFichier.Click += new System.EventHandler(this.btn_ajoutFichier_Click);
            // 
            // radioButton_ou
            // 
            this.radioButton_ou.AutoSize = true;
            this.radioButton_ou.Location = new System.Drawing.Point(461, 29);
            this.radioButton_ou.Name = "radioButton_ou";
            this.radioButton_ou.Size = new System.Drawing.Size(50, 21);
            this.radioButton_ou.TabIndex = 3;
            this.radioButton_ou.TabStop = true;
            this.radioButton_ou.Text = "OU";
            this.radioButton_ou.UseVisualStyleBackColor = true;
            // 
            // radioButton_et
            // 
            this.radioButton_et.AutoSize = true;
            this.radioButton_et.Location = new System.Drawing.Point(408, 29);
            this.radioButton_et.Name = "radioButton_et";
            this.radioButton_et.Size = new System.Drawing.Size(47, 21);
            this.radioButton_et.TabIndex = 2;
            this.radioButton_et.TabStop = true;
            this.radioButton_et.Text = "ET";
            this.radioButton_et.UseVisualStyleBackColor = true;
            // 
            // btn_recherche
            // 
            this.btn_recherche.Location = new System.Drawing.Point(361, 29);
            this.btn_recherche.Name = "btn_recherche";
            this.btn_recherche.Size = new System.Drawing.Size(41, 24);
            this.btn_recherche.TabIndex = 1;
            this.btn_recherche.UseVisualStyleBackColor = true;
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(4, 29);
            this.textBox_recherche.Multiline = true;
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(351, 25);
            this.textBox_recherche.TabIndex = 0;
            this.textBox_recherche.TextChanged += new System.EventHandler(this.textBox_recherche_TextChanged);
            // 
            // panel_resultatRecherche
            // 
            this.panel_resultatRecherche.Controls.Add(this.listBox_doc);
            this.panel_resultatRecherche.Location = new System.Drawing.Point(244, 99);
            this.panel_resultatRecherche.Name = "panel_resultatRecherche";
            this.panel_resultatRecherche.Size = new System.Drawing.Size(580, 432);
            this.panel_resultatRecherche.TabIndex = 8;
            // 
            // listBox_doc
            // 
            this.listBox_doc.FormattingEnabled = true;
            this.listBox_doc.ItemHeight = 16;
            this.listBox_doc.Location = new System.Drawing.Point(7, 8);
            this.listBox_doc.Name = "listBox_doc";
            this.listBox_doc.Size = new System.Drawing.Size(563, 420);
            this.listBox_doc.TabIndex = 0;
            this.listBox_doc.SelectedIndexChanged += new System.EventHandler(this.listBox_doc_SelectedIndexChanged);
            // 
            // panel_apercu
            // 
            this.panel_apercu.Controls.Add(this.WebBrowser_affichageDoc);
            this.panel_apercu.Location = new System.Drawing.Point(829, 19);
            this.panel_apercu.Name = "panel_apercu";
            this.panel_apercu.Size = new System.Drawing.Size(233, 276);
            this.panel_apercu.TabIndex = 9;
            // 
            // WebBrowser_affichageDoc
            // 
            this.WebBrowser_affichageDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser_affichageDoc.Location = new System.Drawing.Point(0, 0);
            this.WebBrowser_affichageDoc.Margin = new System.Windows.Forms.Padding(4);
            this.WebBrowser_affichageDoc.MinimumSize = new System.Drawing.Size(27, 24);
            this.WebBrowser_affichageDoc.Name = "WebBrowser_affichageDoc";
            this.WebBrowser_affichageDoc.Size = new System.Drawing.Size(233, 276);
            this.WebBrowser_affichageDoc.TabIndex = 0;
            // 
            // panel_tags
            // 
            this.panel_tags.Controls.Add(this.listBox_tags);
            this.panel_tags.Location = new System.Drawing.Point(829, 335);
            this.panel_tags.Name = "panel_tags";
            this.panel_tags.Size = new System.Drawing.Size(233, 195);
            this.panel_tags.TabIndex = 10;
            // 
            // listBox_tags
            // 
            this.listBox_tags.FormattingEnabled = true;
            this.listBox_tags.ItemHeight = 16;
            this.listBox_tags.Location = new System.Drawing.Point(3, 10);
            this.listBox_tags.Name = "listBox_tags";
            this.listBox_tags.Size = new System.Drawing.Size(227, 180);
            this.listBox_tags.TabIndex = 0;
            // 
            // btn_Deldoc
            // 
            this.btn_Deldoc.Enabled = false;
            this.btn_Deldoc.Location = new System.Drawing.Point(828, 310);
            this.btn_Deldoc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Deldoc.Name = "btn_Deldoc";
            this.btn_Deldoc.Size = new System.Drawing.Size(65, 24);
            this.btn_Deldoc.TabIndex = 11;
            this.btn_Deldoc.Text = "--";
            this.btn_Deldoc.UseVisualStyleBackColor = true;
            this.btn_Deldoc.Click += new System.EventHandler(this.btn_Deldoc_Click);
            // 
            // btn_OuvrirDoc
            // 
            this.btn_OuvrirDoc.Location = new System.Drawing.Point(957, 308);
            this.btn_OuvrirDoc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OuvrirDoc.Name = "btn_OuvrirDoc";
            this.btn_OuvrirDoc.Size = new System.Drawing.Size(104, 27);
            this.btn_OuvrirDoc.TabIndex = 12;
            this.btn_OuvrirDoc.Text = "Ouvrir";
            this.btn_OuvrirDoc.UseVisualStyleBackColor = true;
            this.btn_OuvrirDoc.Click += new System.EventHandler(this.btn_ouvirDoc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1076, 538);
            this.Controls.Add(this.btn_OuvrirDoc);
            this.Controls.Add(this.btn_Deldoc);
            this.Controls.Add(this.panel_tags);
            this.Controls.Add(this.panel_apercu);
            this.Controls.Add(this.panel_resultatRecherche);
            this.Controls.Add(this.panel_recherche);
            this.Controls.Add(this.panel_logoNom);
            this.Controls.Add(this.panel_arbo);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FormMain";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel_arbo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_droite)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_arriere)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_addTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_gauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox_DelTag)).EndInit();
            this.panel_logoNom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.panel_recherche.ResumeLayout(false);
            this.panel_recherche.PerformLayout();
            this.panel_resultatRecherche.ResumeLayout(false);
            this.panel_apercu.ResumeLayout(false);
            this.panel_tags.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_OuvrirDoc;

        private System.Windows.Forms.WebBrowser WebBrowser_affichageDoc;

        private System.Windows.Forms.Button btn_Deldoc;

        #endregion
        private System.Windows.Forms.Panel panel_arbo;
        private System.Windows.Forms.Panel panel_logoNom;
        private System.Windows.Forms.Panel panel_recherche;
        private System.Windows.Forms.Button btn_ajoutFichier;
        private System.Windows.Forms.RadioButton radioButton_ou;
        private System.Windows.Forms.RadioButton radioButton_et;
        private System.Windows.Forms.Button btn_recherche;
        private System.Windows.Forms.TextBox textBox_recherche;
        private System.Windows.Forms.Panel panel_resultatRecherche;
        private System.Windows.Forms.Panel panel_apercu;
        private System.Windows.Forms.Panel panel_tags;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_droite;
        private System.Windows.Forms.PictureBox pictureBox_arriere;
        private System.Windows.Forms.PictureBox pictureBox_addTag;
        private System.Windows.Forms.PictureBox pictureBox_gauche;
        private System.Windows.Forms.PictureBox pictureBox_DelTag;
        private System.Windows.Forms.TreeView treeView_tags;
        private System.Windows.Forms.ListBox listBox_doc;
        private System.Windows.Forms.ListBox listBox_tags;
    }
}