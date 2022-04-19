namespace ProjetTags
{
    public class Lien
    {
        private int _idtDoc;
        private int _idtTag;

        public Lien() {}

        public Lien(int idtTag, int idtDoc)
        {
            _idtTag = idtTag;
            _idtDoc = idtDoc;
        }

        public int getIdt_tag() => _idtTag;

        public void setIdt_tag(int i) => _idtTag = i;

        public int getIdt_doc() => _idtDoc;

        public void setIdt_doc(int i) => _idtDoc = i;
    }
}