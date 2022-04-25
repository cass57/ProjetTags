namespace ProjetTags
{
    public class Lien
    {
        private int _idtDoc;
        private int _idtTag;

        public int idt_doc
        {
            get => _idtDoc;
            set => _idtDoc = value;
        }

        public int idt_tag
        {
            get => _idtTag;
            set => _idtTag = value;
        }

        public Lien() {}

        public Lien(int idtTag, int idtDoc)
        {
            idt_tag = idtTag;
            idt_doc = idtDoc;
        }
    }
}