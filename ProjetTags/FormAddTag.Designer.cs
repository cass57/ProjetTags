using System.ComponentModel;

namespace ProjetTags
{
    partial class FormAddTag
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
            this.labelNomTag = new System.Windows.Forms.Label();
            this.textBox_nomTag = new System.Windows.Forms.TextBox();
            this.labelCouleurTag = new System.Windows.Forms.Label();
            this.btn_createTag = new System.Windows.Forms.Button();
            this.btn_ouvrirPalette = new System.Windows.Forms.Button();
            this.textBox_couleur = new System.Windows.Forms.TextBox();
            this.comboBox_parent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNomTag
            // 
            this.labelNomTag.Location = new System.Drawing.Point(5, 10);
            this.labelNomTag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNomTag.Name = "labelNomTag";
            this.labelNomTag.Size = new System.Drawing.Size(68, 12);
            this.labelNomTag.TabIndex = 0;
            this.labelNomTag.Text = "Nom :";
            this.labelNomTag.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_nomTag
            // 
            this.textBox_nomTag.Location = new System.Drawing.Point(76, 9);
            this.textBox_nomTag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_nomTag.Name = "textBox_nomTag";
            this.textBox_nomTag.Size = new System.Drawing.Size(218, 20);
            this.textBox_nomTag.TabIndex = 1;
            // 
            // labelCouleurTag
            // 
            this.labelCouleurTag.Location = new System.Drawing.Point(7, 46);
            this.labelCouleurTag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCouleurTag.Name = "labelCouleurTag";
            this.labelCouleurTag.Size = new System.Drawing.Size(66, 17);
            this.labelCouleurTag.TabIndex = 2;
            this.labelCouleurTag.Text = "Couleur :";
            this.labelCouleurTag.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_createTag
            // 
            this.btn_createTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_createTag.Location = new System.Drawing.Point(130, 111);
            this.btn_createTag.Margin = new System.Windows.Forms.Padding(2);
            this.btn_createTag.Name = "btn_createTag";
            this.btn_createTag.Size = new System.Drawing.Size(62, 29);
            this.btn_createTag.TabIndex = 3;
            this.btn_createTag.Text = "Valider";
            this.btn_createTag.UseVisualStyleBackColor = true;
            this.btn_createTag.Click += new System.EventHandler(this.btn_createTag_Click);
            // 
            // btn_ouvrirPalette
            // 
            this.btn_ouvrirPalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ouvrirPalette.Location = new System.Drawing.Point(252, 43);
            this.btn_ouvrirPalette.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ouvrirPalette.Name = "btn_ouvrirPalette";
            this.btn_ouvrirPalette.Size = new System.Drawing.Size(42, 21);
            this.btn_ouvrirPalette.TabIndex = 4;
            this.btn_ouvrirPalette.Text = "C";
            this.btn_ouvrirPalette.UseVisualStyleBackColor = true;
            this.btn_ouvrirPalette.Click += new System.EventHandler(this.btn_ouvrirPalette_Click);
            // 
            // textBox_couleur
            // 
            this.textBox_couleur.Location = new System.Drawing.Point(91, 43);
            this.textBox_couleur.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_couleur.Name = "textBox_couleur";
            this.textBox_couleur.Size = new System.Drawing.Size(157, 20);
            this.textBox_couleur.TabIndex = 5;
            // 
            // comboBox_parent
            // 
            this.comboBox_parent.FormattingEnabled = true;
            this.comboBox_parent.Location = new System.Drawing.Point(76, 79);
            this.comboBox_parent.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_parent.Name = "comboBox_parent";
            this.comboBox_parent.Size = new System.Drawing.Size(218, 21);
            this.comboBox_parent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tag parent :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(76, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "#";
            // 
            // FormAddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 151);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_parent);
            this.Controls.Add(this.textBox_couleur);
            this.Controls.Add(this.btn_ouvrirPalette);
            this.Controls.Add(this.btn_createTag);
            this.Controls.Add(this.labelCouleurTag);
            this.Controls.Add(this.textBox_nomTag);
            this.Controls.Add(this.labelNomTag);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAddTag";
            this.Text = "FormAddTag";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox comboBox_parent;

        private System.Windows.Forms.Button btn_ouvrirPalette;
        private System.Windows.Forms.TextBox textBox_couleur;

        private System.Windows.Forms.Button btn_createTag;

        private System.Windows.Forms.TextBox textBox_nomTag;
        private System.Windows.Forms.Label labelCouleurTag;

        private System.Windows.Forms.Label labelNomTag;

        #endregion
    }
}