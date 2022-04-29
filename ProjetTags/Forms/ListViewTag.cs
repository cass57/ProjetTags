using System.Drawing;
using System.Windows.Forms;
using ProjetTags.Model;

namespace ProjetTags.Forms
{
    public class ListViewTag : ListViewItem
    {
        private Tag _tag1;

        public Tag _tag
        {
            get => _tag1;
            set => _tag1 = value;
        }

        public ListViewTag(Tag tag)
        {
            _tag = tag;
            Text = tag.nom;
            Name = tag.idt_tag.ToString();
            BackColor = ColorTranslator.FromHtml("#" + _tag.clr);
            ForeColor = Utils.Contrast(BackColor, Color.Black) > Utils.Contrast(BackColor, Color.White) ? Color.Black : Color.White;
        }
    }
}