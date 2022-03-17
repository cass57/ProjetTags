namespace ProjetTags
{
    public class Lien
    {
        private int idt_tag;
        private int idt_doc;
        
        public Lien() {}

        public Lien(int idt_tag, int idt_doc)
        {
            this.idt_tag = idt_tag;
            this.idt_doc = idt_doc;
        }

        public int getIdt_tag()
        {
            return this.idt_tag;
        }

        public void setIdt_tag(int i)
        {
            this.idt_tag = i;
        }

        public int getIdt_doc()
        {
            return this.idt_doc;
        }

        public void setIdt_doc(int i)
        {
            this.idt_doc = i;
        }
    }
}