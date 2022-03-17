using System;

namespace ProjetTags
{
    public class Tag
    {
        private int idt_tag;
        private String nom;
        private String clr;
        private int idt_pere;

        public Tag() {}

        public Tag(int idt_tag, String nom, String clr)
        {
            this.idt_tag = idt_tag;
            this.nom = nom;
            this.clr = clr;
        }
        
        public Tag(int idt_tag, String nom, String clr, int idt_pere)
        {
            this.idt_tag = idt_tag;
            this.nom = nom;
            this.clr = clr;
            this.idt_pere = idt_pere;
        }

        public int getIdt_tag()
        {
            return this.idt_tag;
        }

        public void setIdt_tag(int i)
        {
            this.idt_tag = i;
        }

        public String getNom()
        {
            return this.nom;
        }

        public void setNom(String n)
        {
            this.nom = n;
        }

        public String getClr()
        {
            return this.clr;
        }

        public void setClr(String c)
        {
            this.clr = c;
        }

        public int getIdt_pere()
        {
            return this.idt_pere;
        }

        public void setIdt_pere(int p)
        {
            this.idt_pere = p;
        }

        public String toString()
        {
            return this.nom;
        }
    }
}