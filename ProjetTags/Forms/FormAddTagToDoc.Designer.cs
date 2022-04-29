using System.ComponentModel;

namespace ProjetTags.Forms
{
    partial class FormAddTagToDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbl_tags = new System.Windows.Forms.Label();
            this.Clist_tags = new System.Windows.Forms.CheckedListBox();
            this.btn_addTag = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_tags
            // 
            this.lbl_tags.Location = new System.Drawing.Point(9, 15);
            this.lbl_tags.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tags.Name = "lbl_tags";
            this.lbl_tags.Size = new System.Drawing.Size(202, 19);
            this.lbl_tags.TabIndex = 5;
            this.lbl_tags.Text = "Liste des tags à ajouter au document:";
            // 
            // Clist_tags
            // 
            this.Clist_tags.FormattingEnabled = true;
            this.Clist_tags.Location = new System.Drawing.Point(9, 36);
            this.Clist_tags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Clist_tags.Name = "Clist_tags";
            this.Clist_tags.Size = new System.Drawing.Size(200, 79);
            this.Clist_tags.TabIndex = 6;
            // 
            // btn_addTag
            // 
            this.btn_addTag.Location = new System.Drawing.Point(215, 36);
            this.btn_addTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_addTag.Name = "btn_addTag";
            this.btn_addTag.Size = new System.Drawing.Size(29, 23);
            this.btn_addTag.TabIndex = 7;
            this.btn_addTag.Text = "+";
            this.btn_addTag.UseVisualStyleBackColor = true;
            this.btn_addTag.Click += new System.EventHandler(this.btn_addTag_Click);
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(148, 197);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(96, 25);
            this.btn_valider.TabIndex = 8;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // FormAddTagToDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 234);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_addTag);
            this.Controls.Add(this.Clist_tags);
            this.Controls.Add(this.lbl_tags);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAddTagToDoc";
            this.Text = "FormAddTagToDoc";
            this.Activated += new System.EventHandler(this.FormAddTagToDoc_Activated);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_valider;

        private System.Windows.Forms.Label lbl_tags;
        private System.Windows.Forms.CheckedListBox Clist_tags;
        private System.Windows.Forms.Button btn_addTag;

        #endregion
    }
}