using System;

namespace ProjetTags
{
    public class Document
    {
        private string doc_path;
        private int idt_doc;

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

        public int getIdt_doc()
        {
            return idt_doc;
        }

        public void setIdt_doc(int i)
        {
            idt_doc = i;
        }

        public string getDoc_path()
        {
            return doc_path;
        }

        public void setDoc_path(string p)
        {
            doc_path = p;
        }

        public override string ToString()
        {
            String[] nom = doc_path.Split('\\');
            return nom[nom.Length-1];
        }
    }
}