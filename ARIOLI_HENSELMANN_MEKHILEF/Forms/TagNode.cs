using System.Drawing;
using System.Windows.Forms;
using ARIOLI_HENSELMANN_MEKHILEF.Model;

namespace ARIOLI_HENSELMANN_MEKHILEF.Forms
{
    public class TagNode : TreeNode
    {
        private Tag _tag;

        public TagNode(Tag tag)
        {
            _tag = tag;
            Text = tag.nom;
            Name = tag.idt_tag.ToString();
            BackColor = ColorTranslator.FromHtml("#" + _tag.clr);
            ForeColor = Utils.Contrast(BackColor, Color.Black) > Utils.Contrast(BackColor, Color.White) ? Color.Black : Color.White;
        }

        public Tag GetTag() => _tag;
    }
}