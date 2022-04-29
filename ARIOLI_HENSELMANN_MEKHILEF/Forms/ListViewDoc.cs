using System.Drawing;
using System.Windows.Forms;
using ARIOLI_HENSELMANN_MEKHILEF.Model;

namespace ARIOLI_HENSELMANN_MEKHILEF.Forms
{
    public class ListViewDoc : ListViewItem
    {
        private Document _doc1;

        public Document _doc
        {
            get => _doc1;
            set => _doc1 = value;
        }

        public ListViewDoc(Document doc)
        {
            _doc = doc;
            Text = doc.ToString();
            Name = doc.ToString();
            ImageIndex = doc.doc_path.Substring(doc.doc_path.Length - 3) == "pdf" ? 1 : 0;
        }
    }
}