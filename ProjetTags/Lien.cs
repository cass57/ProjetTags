namespace ProjetTags
{
    public class Lien
    {
        private int idt_doc;
        private int idt_tag;

        public Lien()
        {
        }

        public Lien(int idt_tag, int idt_doc)
        {
            this.idt_tag = idt_tag;
            this.idt_doc = idt_doc;
        }

        public int getIdt_tag()
        {
            return idt_tag;
        }

        public void setIdt_tag(int i)
        {
            idt_tag = i;
        }

        public int getIdt_doc()
        {
            return idt_doc;
        }

        public void setIdt_doc(int i)
        {
            idt_doc = i;
        }
    }
}