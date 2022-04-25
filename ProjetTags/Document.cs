using System.Linq;

namespace ProjetTags
{
    public class Document
    {
        private int _idtDoc;
        private string _docPath;

        public string doc_path
        {
            get => _docPath;
            set => _docPath = value;
        }

        public int idt_doc
        {
            get => _idtDoc;
            set => _idtDoc = value;
        }

        public Document()
        {
        }

        public Document(int idt_doc, string doc_path)
        {
            this.idt_doc = idt_doc;
            this.doc_path = doc_path;
        }

        public Document(string doc_path)
        {
            this.doc_path = doc_path;
        }

        public override string ToString() => doc_path.Split('\\').Last();
    }
}