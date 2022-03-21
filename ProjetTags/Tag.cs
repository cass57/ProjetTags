namespace ProjetTags
{
    public class Tag
    {
        private string clr;
        private int idt_pere;
        private int idt_tag;
        private string nom;

        public Tag()
        {
        }

        public Tag(int idt_tag, string nom, string clr)
        {
            this.idt_tag = idt_tag;
            this.nom = nom;
            this.clr = clr;
        }

        public Tag(int idt_tag, string nom, string clr, int idt_pere)
        {
            this.idt_tag = idt_tag;
            this.nom = nom;
            this.clr = clr;
            this.idt_pere = idt_pere;
        }

        public int getIdt_tag()
        {
            return idt_tag;
        }

        public void setIdt_tag(int i)
        {
            idt_tag = i;
        }

        public string getNom()
        {
            return nom;
        }

        public void setNom(string n)
        {
            nom = n;
        }

        public string getClr()
        {
            return clr;
        }

        public void setClr(string c)
        {
            clr = c;
        }

        public int getIdt_pere()
        {
            return idt_pere;
        }

        public void setIdt_pere(int p)
        {
            idt_pere = p;
        }

        public string toString()
        {
            return nom;
        }
    }
}