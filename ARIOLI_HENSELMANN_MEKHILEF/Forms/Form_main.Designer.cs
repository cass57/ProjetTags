using System;
using System.Drawing;
using System.Windows.Forms;

namespace ARIOLI_HENSELMANN_MEKHILEF.Forms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_recherche = new System.Windows.Forms.Panel();
            this.btn_DarkMode = new System.Windows.Forms.Label();
            this.btn_ajoutFichier = new System.Windows.Forms.Button();
            this.btn_recherche = new System.Windows.Forms.Button();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.panel_resultatRecherche = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_doc = new System.Windows.Forms.ListView();
            this.panel_apercu = new System.Windows.Forms.Panel();
            this.webBrowser_affichageDoc = new System.Windows.Forms.WebBrowser();
            this.btn_OuvrirDoc = new System.Windows.Forms.Button();
            this.btn_Deldoc = new System.Windows.Forms.Button();
            this.panel_tags = new System.Windows.Forms.Panel();
            this.listView_tags = new System.Windows.Forms.ListView();
            this.treeView_tags = new System.Windows.Forms.TreeView();
            this.panel_arbo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.panel_recherche.SuspendLayout();
            this.panel_resultatRecherche.SuspendLayout();
            this.panel_apercu.SuspendLayout();
            this.panel_tags.SuspendLayout();
            this.panel_arbo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ARIOLI_HENSELMANN_MEKHILEF.Properties.Resources.logoProjetDotNet;
            this.pictureBox1.Location = new System.Drawing.Point(2, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_recherche
            // 
            this.panel_recherche.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel_recherche.Controls.Add(this.btn_DarkMode);
            this.panel_recherche.Controls.Add(this.pictureBox1);
            this.panel_recherche.Controls.Add(this.btn_ajoutFichier);
            this.panel_recherche.Controls.Add(this.btn_recherche);
            this.panel_recherche.Controls.Add(this.textBox_recherche);
            this.panel_recherche.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_recherche.Location = new System.Drawing.Point(0, 0);
            this.panel_recherche.Margin = new System.Windows.Forms.Padding(2);
            this.panel_recherche.Name = "panel_recherche";
            this.panel_recherche.Size = new System.Drawing.Size(1064, 60);
            this.panel_recherche.TabIndex = 7;
            // 
            // btn_DarkMode
            // 
            this.btn_DarkMode.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_DarkMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_DarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DarkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_DarkMode.ForeColor = System.Drawing.Color.LightYellow;
            this.btn_DarkMode.Location = new System.Drawing.Point(133, 16);
            this.btn_DarkMode.Name = "btn_DarkMode";
            this.btn_DarkMode.Size = new System.Drawing.Size(30, 30);
            this.btn_DarkMode.TabIndex = 5;
            this.btn_DarkMode.Text = "🌙";
            this.btn_DarkMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_DarkMode.Click += new System.EventHandler(this.btn_DarkMode_Click);
            // 
            // btn_ajoutFichier
            // 
            this.btn_ajoutFichier.Location = new System.Drawing.Point(960, 21);
            this.btn_ajoutFichier.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ajoutFichier.Name = "btn_ajoutFichier";
            this.btn_ajoutFichier.Size = new System.Drawing.Size(84, 23);
            this.btn_ajoutFichier.TabIndex = 4;
            this.btn_ajoutFichier.Text = "Nouveau";
            this.btn_ajoutFichier.UseVisualStyleBackColor = true;
            this.btn_ajoutFichier.Click += new System.EventHandler(this.btn_ajoutFichier_Click);
            // 
            // btn_recherche
            // 
            this.btn_recherche.Location = new System.Drawing.Point(864, 21);
            this.btn_recherche.Margin = new System.Windows.Forms.Padding(2);
            this.btn_recherche.Name = "btn_recherche";
            this.btn_recherche.Size = new System.Drawing.Size(84, 23);
            this.btn_recherche.TabIndex = 1;
            this.btn_recherche.Text = "Rechercher";
            this.btn_recherche.UseVisualStyleBackColor = true;
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(168, 22);
            this.textBox_recherche.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_recherche.Multiline = true;
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(677, 21);
            this.textBox_recherche.TabIndex = 0;
            this.textBox_recherche.TextChanged += new System.EventHandler(this.TextBoxSearch);
            // 
            // panel_resultatRecherche
            // 
            this.panel_resultatRecherche.BackColor = System.Drawing.SystemColors.Window;
            this.panel_resultatRecherche.Controls.Add(this.label2);
            this.panel_resultatRecherche.Controls.Add(this.listView_doc);
            this.panel_resultatRecherche.Location = new System.Drawing.Point(169, 60);
            this.panel_resultatRecherche.Margin = new System.Windows.Forms.Padding(2);
            this.panel_resultatRecherche.Name = "panel_resultatRecherche";
            this.panel_resultatRecherche.Size = new System.Drawing.Size(440, 359);
            this.panel_resultatRecherche.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 359);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 2);
            this.label2.TabIndex = 14;
            // 
            // listView_doc
            // 
            this.listView_doc.FullRowSelect = true;
            this.listView_doc.GridLines = true;
            this.listView_doc.Location = new System.Drawing.Point(-2, -1);
            this.listView_doc.Margin = new System.Windows.Forms.Padding(2);
            this.listView_doc.Name = "listView_doc";
            this.listView_doc.Size = new System.Drawing.Size(446, 368);
            this.listView_doc.TabIndex = 0;
            this.listView_doc.UseCompatibleStateImageBehavior = false;
            this.listView_doc.View = System.Windows.Forms.View.List;
            this.listView_doc.SelectedIndexChanged += new System.EventHandler(this.listBox_doc_SelectedIndexChanged);
            // 
            // panel_apercu
            // 
            this.panel_apercu.Controls.Add(this.webBrowser_affichageDoc);
            this.panel_apercu.Controls.Add(this.btn_OuvrirDoc);
            this.panel_apercu.Controls.Add(this.btn_Deldoc);
            this.panel_apercu.Location = new System.Drawing.Point(612, 61);
            this.panel_apercu.Margin = new System.Windows.Forms.Padding(2);
            this.panel_apercu.Name = "panel_apercu";
            this.panel_apercu.Size = new System.Drawing.Size(452, 520);
            this.panel_apercu.TabIndex = 9;
            // 
            // webBrowser_affichageDoc
            // 
            this.webBrowser_affichageDoc.Location = new System.Drawing.Point(2, -2);
            this.webBrowser_affichageDoc.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser_affichageDoc.MinimumSize = new System.Drawing.Size(10, 10);
            this.webBrowser_affichageDoc.Name = "webBrowser_affichageDoc";
            this.webBrowser_affichageDoc.Size = new System.Drawing.Size(448, 474);
            this.webBrowser_affichageDoc.TabIndex = 13;
            // 
            // btn_OuvrirDoc
            // 
            this.btn_OuvrirDoc.Enabled = false;
            this.btn_OuvrirDoc.Location = new System.Drawing.Point(270, 489);
            this.btn_OuvrirDoc.Name = "btn_OuvrirDoc";
            this.btn_OuvrirDoc.Size = new System.Drawing.Size(144, 20);
            this.btn_OuvrirDoc.TabIndex = 12;
            this.btn_OuvrirDoc.Text = "Ouvrir ce document";
            this.btn_OuvrirDoc.UseVisualStyleBackColor = true;
            this.btn_OuvrirDoc.Click += new System.EventHandler(this.btn_ouvirDoc_Click);
            // 
            // btn_Deldoc
            // 
            this.btn_Deldoc.Enabled = false;
            this.btn_Deldoc.Location = new System.Drawing.Point(30, 489);
            this.btn_Deldoc.Name = "btn_Deldoc";
            this.btn_Deldoc.Size = new System.Drawing.Size(144, 20);
            this.btn_Deldoc.TabIndex = 11;
            this.btn_Deldoc.Text = "Supprimer ce document";
            this.btn_Deldoc.UseVisualStyleBackColor = true;
            this.btn_Deldoc.Click += new System.EventHandler(this.btn_Deldoc_Click);
            // 
            // panel_tags
            // 
            this.panel_tags.BackColor = System.Drawing.SystemColors.Window;
            this.panel_tags.Controls.Add(this.listView_tags);
            this.panel_tags.Location = new System.Drawing.Point(169, 423);
            this.panel_tags.Margin = new System.Windows.Forms.Padding(2);
            this.panel_tags.Name = "panel_tags";
            this.panel_tags.Size = new System.Drawing.Size(441, 158);
            this.panel_tags.TabIndex = 10;
            // 
            // listView_tags
            // 
            this.listView_tags.Location = new System.Drawing.Point(-2, -2);
            this.listView_tags.Name = "listView_tags";
            this.listView_tags.Size = new System.Drawing.Size(448, 172);
            this.listView_tags.TabIndex = 0;
            this.listView_tags.UseCompatibleStateImageBehavior = false;
            this.listView_tags.View = System.Windows.Forms.View.List;
            this.listView_tags.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_tagsClick);
            // 
            // treeView_tags
            // 
            this.treeView_tags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView_tags.Location = new System.Drawing.Point(0, 23);
            this.treeView_tags.Margin = new System.Windows.Forms.Padding(2);
            this.treeView_tags.Name = "treeView_tags";
            this.treeView_tags.Size = new System.Drawing.Size(170, 524);
            this.treeView_tags.TabIndex = 5;
            this.treeView_tags.DoubleClick += new System.EventHandler(this.treeView_tags_DoubleClick);
            // 
            // panel_arbo
            // 
            this.panel_arbo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_arbo.Controls.Add(this.label3);
            this.panel_arbo.Controls.Add(this.label1);
            this.panel_arbo.Controls.Add(this.panel1);
            this.panel_arbo.Controls.Add(this.treeView_tags);
            this.panel_arbo.Location = new System.Drawing.Point(0, 61);
            this.panel_arbo.Margin = new System.Windows.Forms.Padding(2);
            this.panel_arbo.Name = "panel_arbo";
            this.panel_arbo.Size = new System.Drawing.Size(170, 521);
            this.panel_arbo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(140, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mes tags";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(166, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 520);
            this.panel1.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1064, 584);
            this.Controls.Add(this.panel_tags);
            this.Controls.Add(this.panel_apercu);
            this.Controls.Add(this.panel_resultatRecherche);
            this.Controls.Add(this.panel_recherche);
            this.Controls.Add(this.panel_arbo);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(966, 557);
            this.Name = "FormMain";
            this.Text = "E-TAGGER";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_tagsClick);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.panel_recherche.ResumeLayout(false);
            this.panel_recherche.PerformLayout();
            this.panel_resultatRecherche.ResumeLayout(false);
            this.panel_apercu.ResumeLayout(false);
            this.panel_tags.ResumeLayout(false);
            this.panel_arbo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label btn_DarkMode;

        private System.Windows.Forms.ListView listView_tags;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.WebBrowser webBrowser_affichageDoc;

        private System.Windows.Forms.Button btn_OuvrirDoc;

        private System.Windows.Forms.Button btn_Deldoc;

        #endregion
        private System.Windows.Forms.Panel panel_arbo;
        private System.Windows.Forms.Panel panel_recherche;
        private System.Windows.Forms.Button btn_ajoutFichier;
        private System.Windows.Forms.Button btn_recherche;
        private System.Windows.Forms.TextBox textBox_recherche;
        private System.Windows.Forms.Panel panel_resultatRecherche;
        private System.Windows.Forms.Panel panel_apercu;
        private System.Windows.Forms.Panel panel_tags;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView_tags;
        private System.Windows.Forms.ListView listView_doc;
    }
}