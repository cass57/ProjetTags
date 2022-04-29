namespace ProjetTags.Forms
{

    partial class FormAddDoc
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
            if (disposing && (components != null)) components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tf_path = new System.Windows.Forms.TextBox();
            this.btn_explorateur = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.Clist_tags = new System.Windows.Forms.CheckedListBox();
            this.lbl_tags = new System.Windows.Forms.Label();
            this.btn_addTag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tf_path
            // 
            this.tf_path.AllowDrop = true;
            this.tf_path.Location = new System.Drawing.Point(33, 46);
            this.tf_path.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tf_path.Name = "tf_path";
            this.tf_path.Size = new System.Drawing.Size(386, 20);
            this.tf_path.TabIndex = 0;
            this.tf_path.DragDrop += new System.Windows.Forms.DragEventHandler(this.tf_path_DragDrop);
            this.tf_path.DragEnter += new System.Windows.Forms.DragEventHandler(this.tf_path_DragEnter);
            // 
            // btn_explorateur
            // 
            this.btn_explorateur.Location = new System.Drawing.Point(423, 45);
            this.btn_explorateur.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_explorateur.Name = "btn_explorateur";
            this.btn_explorateur.Size = new System.Drawing.Size(90, 23);
            this.btn_explorateur.TabIndex = 1;
            this.btn_explorateur.Text = "Explorateur";
            this.btn_explorateur.UseVisualStyleBackColor = true;
            this.btn_explorateur.Click += new System.EventHandler(this.btn_explorateur_Click);
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(237, 309);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(96, 25);
            this.btn_valider.TabIndex = 2;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // Clist_tags
            // 
            this.Clist_tags.FormattingEnabled = true;
            this.Clist_tags.Location = new System.Drawing.Point(33, 102);
            this.Clist_tags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Clist_tags.Name = "Clist_tags";
            this.Clist_tags.Size = new System.Drawing.Size(200, 79);
            this.Clist_tags.TabIndex = 3;
            // 
            // lbl_tags
            // 
            this.lbl_tags.Location = new System.Drawing.Point(33, 80);
            this.lbl_tags.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tags.Name = "lbl_tags";
            this.lbl_tags.Size = new System.Drawing.Size(128, 19);
            this.lbl_tags.TabIndex = 4;
            this.lbl_tags.Text = "Liste des tags à ajouter:";
            // 
            // btn_addTag
            // 
            this.btn_addTag.Location = new System.Drawing.Point(237, 102);
            this.btn_addTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_addTag.Name = "btn_addTag";
            this.btn_addTag.Size = new System.Drawing.Size(27, 23);
            this.btn_addTag.TabIndex = 5;
            this.btn_addTag.Text = "+";
            this.btn_addTag.UseVisualStyleBackColor = true;
            this.btn_addTag.Click += new System.EventHandler(this.btn_addTag_Click);
            // 
            // FormAddDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 362);
            this.Controls.Add(this.btn_addTag);
            this.Controls.Add(this.lbl_tags);
            this.Controls.Add(this.Clist_tags);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_explorateur);
            this.Controls.Add(this.tf_path);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAddDoc";
            this.Text = "E-Tagger";
            this.Activated += new System.EventHandler(this.FormAddDoc_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckedListBox Clist_tags;
        private System.Windows.Forms.Label lbl_tags;
        private System.Windows.Forms.Button btn_addTag;

        private System.Windows.Forms.Button btn_valider;

        #endregion

        private System.Windows.Forms.TextBox tf_path;
        private System.Windows.Forms.Button btn_explorateur;
    }
}