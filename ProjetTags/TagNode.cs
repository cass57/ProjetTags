using System.Drawing;

namespace ProjetTags
{
    public class TagNode : System.Windows.Forms.TreeNode {
        Tag tag;

        public TagNode(Tag tag)
        {
            this.tag = tag;
            this.Text = tag.getNom();
            this.Name = tag.getIdt_tag().ToString();
            Color color = (Color) ColorTranslator.FromHtml("#"+this.tag.getClr());
            this.BackColor = color;
        }

        public Tag getTag()
        {
            return (this.tag);

        }
    }
}