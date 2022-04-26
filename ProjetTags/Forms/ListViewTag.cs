using System.Drawing;
using System.Windows.Forms;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public class ListViewTag : ListViewItem
    {
        private Tag _tag;

        public ListViewTag(Tag tag)
        {
            _tag = tag;
            Text = tag.nom;
            Name = tag.idt_tag.ToString();
            BackColor = ColorTranslator.FromHtml("#" + _tag.clr);
        }
    }
}