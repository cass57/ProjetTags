namespace ProjetTags.Model
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

        public Tag(int idtTag, string nom, string clr)
        {
            idt_tag = idtTag;
            this.nom = nom;
            this.clr = clr;
        }

        public Tag(int idtTag, string nom, string clr, int idtPere)
        {
            idt_tag = idtTag;
            this.nom = nom;
            this.clr = clr;
            idt_pere = idtPere;
        }
        
        public override string ToString() => nom;
    }
}