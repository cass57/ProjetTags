using System.ComponentModel;

namespace ProjetTags.Forms
{
    partial class FormUpdateTag
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
            this.lbl_tag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_couleur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ouvrirPalette = new System.Windows.Forms.Button();
            this.btn_createTag = new System.Windows.Forms.Button();
            this.textBox_nomTag = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_tag
            // 
            this.lbl_tag.Location = new System.Drawing.Point(12, 9);
            this.lbl_tag.Name = "lbl_tag";
            this.lbl_tag.Size = new System.Drawing.Size(152, 23);
            this.lbl_tag.TabIndex = 0;
            this.lbl_tag.Text = "Nouveau nom du tag:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nouvelle couleur du tag:";
            // 
            // textBox_couleur
            // 
            this.textBox_couleur.Location = new System.Drawing.Point(191, 55);
            this.textBox_couleur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_couleur.Name = "textBox_couleur";
            this.textBox_couleur.Size = new System.Drawing.Size(227, 22);
            this.textBox_couleur.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(170, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "#";
            // 
            // btn_ouvrirPalette
            // 
            this.btn_ouvrirPalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ouvrirPalette.Location = new System.Drawing.Point(424, 52);
            this.btn_ouvrirPalette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ouvrirPalette.Name = "btn_ouvrirPalette";
            this.btn_ouvrirPalette.Size = new System.Drawing.Size(56, 26);
            this.btn_ouvrirPalette.TabIndex = 10;
            this.btn_ouvrirPalette.Text = "C";
            this.btn_ouvrirPalette.UseVisualStyleBackColor = true;
            this.btn_ouvrirPalette.Click += new System.EventHandler(this.btn_ouvrirPalette_Click);
            // 
            // btn_createTag
            // 
            this.btn_createTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_createTag.Location = new System.Drawing.Point(12, 109);
            this.btn_createTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_createTag.Name = "btn_createTag";
            this.btn_createTag.Size = new System.Drawing.Size(83, 36);
            this.btn_createTag.TabIndex = 11;
            this.btn_createTag.Text = "Valider";
            this.btn_createTag.UseVisualStyleBackColor = true;
            this.btn_createTag.Click += new System.EventHandler(this.btn_createTag_Click);
            // 
            // textBox_nomTag
            // 
            this.textBox_nomTag.Location = new System.Drawing.Point(191, 11);
            this.textBox_nomTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_nomTag.Name = "textBox_nomTag";
            this.textBox_nomTag.Size = new System.Drawing.Size(289, 22);
            this.textBox_nomTag.TabIndex = 12;
            // 
            // FormUpdateTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 166);
            this.Controls.Add(this.textBox_nomTag);
            this.Controls.Add(this.btn_createTag);
            this.Controls.Add(this.btn_ouvrirPalette);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_couleur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_tag);
            this.Name = "FormUpdateTag";
            this.Text = "Modifier le tag";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btn_createTag;
        private System.Windows.Forms.TextBox textBox_nomTag;

        private System.Windows.Forms.Button btn_ouvrirPalette;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox textBox_couleur;

        private System.Windows.Forms.Label lbl_tag;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}