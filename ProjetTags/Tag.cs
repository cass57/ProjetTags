namespace ProjetTags
{
    public class Tag
    {
        public string clr
        {
            get => _clr;
            set => _clr = value;
        }

        public int idt_pere
        {
            get => _idtPere;
            set => _idtPere = value;
        }

        public int idt_tag
        {
            get => _idtTag;
            set => _idtTag = value;
        }

        public string nom
        {
            get => _nom;
            set => _nom = value;
        }

        private int _idtPere;
        private int _idtTag;
        private string _nom;
        private string _clr;

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
        
        public override string ToString() => nom;
    }
}