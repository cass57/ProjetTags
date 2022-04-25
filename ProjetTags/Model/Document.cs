using System.Linq;

namespace ProjetTags.Model
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

        public Document(int idtDoc, string docPath)
        {
            idt_doc = idtDoc;
            doc_path = docPath;
        }

        public Document(string docPath)
        {
            doc_path = docPath;
        }

        public override string ToString() => doc_path.Split('\\').Last();
    }
}