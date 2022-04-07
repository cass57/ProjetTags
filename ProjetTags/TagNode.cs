namespace ProjetTags
{
    public class TagNode : System.Windows.Forms.TreeNode {
        Tag tag;

        public TagNode(Tag tag)
        {
            this.tag = tag;
            this.Text = tag.getNom();
            this.Name = tag.getIdt_tag().ToString();
        }

        public Tag getTag()
        {
            return (this.tag);

        }
    }
}