using System.Drawing;
using System.Windows.Forms;

namespace ProjetTags
{
    public class TagNode : TreeNode {
        private Tag tag;

        public TagNode(Tag tag)
        {
            this.tag = tag;
            Text = tag.nom;
            Name = tag.idt_tag.ToString();
            Color color = ColorTranslator.FromHtml("#"+this.tag.clr);
            BackColor = color;
        }

        public Tag GetTag() => tag;
    }
}