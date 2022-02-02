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
            this.panel_logoNom = new System.Windows.Forms.Panel();
            this.panel_recherche = new System.Windows.Forms.Panel();
            this.btn_ajoutFichier = new System.Windows.Forms.Button();
            this.radioButton_ou = new System.Windows.Forms.RadioButton();
            this.radioButton_et = new System.Windows.Forms.RadioButton();
            this.btn_recherche = new System.Windows.Forms.Button();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.panel_resultatRecherche = new System.Windows.Forms.Panel();
            this.panel_apercu = new System.Windows.Forms.Panel();
            this.panel_tags = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_arriere = new System.Windows.Forms.PictureBox();
            this.pictureBox_gauche = new System.Windows.Forms.PictureBox();
            this.pictureBox_droite = new System.Windows.Forms.PictureBox();
            this.pictureBox_Del = new System.Windows.Forms.PictureBox();
            this.pictureBox_add = new System.Windows.Forms.PictureBox();
            this.treeView_tags = new System.Windows.Forms.TreeView();
            this.listBox_doc = new System.Windows.Forms.ListBox();
            this.listBox_tags = new System.Windows.Forms.ListBox();
            this.panel_arbo.SuspendLayout();
            this.panel_logoNom.SuspendLayout();
            this.panel_recherche.SuspendLayout();
            this.panel_resultatRecherche.SuspendLayout();
            this.panel_tags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_arriere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_droite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_arbo
            // 
            this.panel_arbo.Controls.Add(this.treeView_tags);
            this.panel_arbo.Controls.Add(this.pictureBox_droite);
            this.panel_arbo.Controls.Add(this.pictureBox_arriere);
            this.panel_arbo.Controls.Add(this.pictureBox_add);
            this.panel_arbo.Controls.Add(this.pictureBox_gauche);
            this.panel_arbo.Controls.Add(this.pictureBox_Del);
            this.panel_arbo.Location = new System.Drawing.Point(12, 98);
            this.panel_arbo.Name = "panel_arbo";
            this.panel_arbo.Size = new System.Drawing.Size(226, 432);
            this.panel_arbo.TabIndex = 5;
            // 
            // panel_logoNom
            // 
            this.panel_logoNom.Controls.Add(this.pictureBox1);
            this.panel_logoNom.Location = new System.Drawing.Point(12, 18);
            this.panel_logoNom.Name = "panel_logoNom";
            this.panel_logoNom.Size = new System.Drawing.Size(226, 74);
            this.panel_logoNom.TabIndex = 6;
            // 
            // panel_recherche
            // 
            this.panel_recherche.Controls.Add(this.btn_ajoutFichier);
            this.panel_recherche.Controls.Add(this.radioButton_ou);
            this.panel_recherche.Controls.Add(this.radioButton_et);
            this.panel_recherche.Controls.Add(this.btn_recherche);
            this.panel_recherche.Controls.Add(this.textBox_recherche);
            this.panel_recherche.Location = new System.Drawing.Point(244, 18);
            this.panel_recherche.Name = "panel_recherche";
            this.panel_recherche.Size = new System.Drawing.Size(580, 74);
            this.panel_recherche.TabIndex = 7;
            // 
            // btn_ajoutFichier
            // 
            this.btn_ajoutFichier.Location = new System.Drawing.Point(517, 30);
            this.btn_ajoutFichier.Name = "btn_ajoutFichier";
            this.btn_ajoutFichier.Size = new System.Drawing.Size(60, 23);
            this.btn_ajoutFichier.TabIndex = 4;
            this.btn_ajoutFichier.Text = "➕";
            this.btn_ajoutFichier.UseVisualStyleBackColor = true;
            // 
            // radioButton_ou
            // 
            this.radioButton_ou.AutoSize = true;
            this.radioButton_ou.Location = new System.Drawing.Point(461, 30);
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
            this.radioButton_et.Location = new System.Drawing.Point(408, 30);
            this.radioButton_et.Name = "radioButton_et";
            this.radioButton_et.Size = new System.Drawing.Size(47, 21);
            this.radioButton_et.TabIndex = 2;
            this.radioButton_et.TabStop = true;
            this.radioButton_et.Text = "ET";
            this.radioButton_et.UseVisualStyleBackColor = true;
            // 
            // btn_recherche
            // 
            this.btn_recherche.Location = new System.Drawing.Point(361, 30);
            this.btn_recherche.Name = "btn_recherche";
            this.btn_recherche.Size = new System.Drawing.Size(41, 25);
            this.btn_recherche.TabIndex = 1;
            this.btn_recherche.UseVisualStyleBackColor = true;
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(4, 30);
            this.textBox_recherche.Multiline = true;
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(351, 25);
            this.textBox_recherche.TabIndex = 0;
            // 
            // panel_resultatRecherche
            // 
            this.panel_resultatRecherche.Controls.Add(this.listBox_doc);
            this.panel_resultatRecherche.Location = new System.Drawing.Point(244, 98);
            this.panel_resultatRecherche.Name = "panel_resultatRecherche";
            this.panel_resultatRecherche.Size = new System.Drawing.Size(580, 432);
            this.panel_resultatRecherche.TabIndex = 8;
            // 
            // panel_apercu
            // 
            this.panel_apercu.Location = new System.Drawing.Point(830, 18);
            this.panel_apercu.Name = "panel_apercu";
            this.panel_apercu.Size = new System.Drawing.Size(233, 311);
            this.panel_apercu.TabIndex = 9;
            // 
            // panel_tags
            // 
            this.panel_tags.Controls.Add(this.listBox_tags);
            this.panel_tags.Location = new System.Drawing.Point(830, 335);
            this.panel_tags.Name = "panel_tags";
            this.panel_tags.Size = new System.Drawing.Size(233, 195);
            this.panel_tags.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetTags.Properties.Resources.logoProjetDotNet;
            this.pictureBox1.Location = new System.Drawing.Point(29, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox_arriere
            // 
            this.pictureBox_arriere.Image = global::ProjetTags.Properties.Resources.retour;
            this.pictureBox_arriere.Location = new System.Drawing.Point(180, 19);
            this.pictureBox_arriere.Name = "pictureBox_arriere";
            this.pictureBox_arriere.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_arriere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_arriere.TabIndex = 4;
            this.pictureBox_arriere.TabStop = false;
            // 
            // pictureBox_gauche
            // 
            this.pictureBox_gauche.Image = global::ProjetTags.Properties.Resources.flecheGauche;
            this.pictureBox_gauche.Location = new System.Drawing.Point(137, 19);
            this.pictureBox_gauche.Name = "pictureBox_gauche";
            this.pictureBox_gauche.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_gauche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_gauche.TabIndex = 3;
            this.pictureBox_gauche.TabStop = false;
            // 
            // pictureBox_droite
            // 
            this.pictureBox_droite.Image = global::ProjetTags.Properties.Resources.flecheDroite;
            this.pictureBox_droite.Location = new System.Drawing.Point(94, 19);
            this.pictureBox_droite.Name = "pictureBox_droite";
            this.pictureBox_droite.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_droite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_droite.TabIndex = 2;
            this.pictureBox_droite.TabStop = false;
            // 
            // pictureBox_Del
            // 
            this.pictureBox_Del.Image = global::ProjetTags.Properties.Resources.moins;
            this.pictureBox_Del.Location = new System.Drawing.Point(51, 19);
            this.pictureBox_Del.Name = "pictureBox_Del";
            this.pictureBox_Del.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_Del.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Del.TabIndex = 1;
            this.pictureBox_Del.TabStop = false;
            // 
            // pictureBox_add
            // 
            this.pictureBox_add.Image = global::ProjetTags.Properties.Resources.plus;
            this.pictureBox_add.Location = new System.Drawing.Point(8, 19);
            this.pictureBox_add.Name = "pictureBox_add";
            this.pictureBox_add.Size = new System.Drawing.Size(37, 17);
            this.pictureBox_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_add.TabIndex = 0;
            this.pictureBox_add.TabStop = false;
            // 
            // treeView_tags
            // 
            this.treeView_tags.Location = new System.Drawing.Point(8, 42);
            this.treeView_tags.Name = "treeView_tags";
            this.treeView_tags.Size = new System.Drawing.Size(209, 387);
            this.treeView_tags.TabIndex = 5;
            // 
            // listBox_doc
            // 
            this.listBox_doc.FormattingEnabled = true;
            this.listBox_doc.ItemHeight = 16;
            this.listBox_doc.Location = new System.Drawing.Point(7, 7);
            this.listBox_doc.Name = "listBox_doc";
            this.listBox_doc.Size = new System.Drawing.Size(563, 420);
            this.listBox_doc.TabIndex = 0;
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
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 542);
            this.Controls.Add(this.panel_tags);
            this.Controls.Add(this.panel_apercu);
            this.Controls.Add(this.panel_resultatRecherche);
            this.Controls.Add(this.panel_recherche);
            this.Controls.Add(this.panel_logoNom);
            this.Controls.Add(this.panel_arbo);
            this.Name = "FormMain";
            this.Text = "E-Tagger";
            this.panel_arbo.ResumeLayout(false);
            this.panel_logoNom.ResumeLayout(false);
            this.panel_recherche.ResumeLayout(false);
            this.panel_recherche.PerformLayout();
            this.panel_resultatRecherche.ResumeLayout(false);
            this.panel_tags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_arriere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_gauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_droite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).EndInit();
            this.ResumeLayout(false);

        }

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
        private System.Windows.Forms.PictureBox pictureBox_add;
        private System.Windows.Forms.PictureBox pictureBox_gauche;
        private System.Windows.Forms.PictureBox pictureBox_Del;
        private System.Windows.Forms.TreeView treeView_tags;
        private System.Windows.Forms.ListBox listBox_doc;
        private System.Windows.Forms.ListBox listBox_tags;
    }
}