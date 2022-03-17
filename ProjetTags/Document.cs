using System;

namespace ProjetTags
{
    public class Document
    {
        private int idt_doc;
        private String doc_path;
        
        public Document() {}

        public Document(int idt_doc, String doc_path)
        {
            this.idt_doc = idt_doc;
            this.doc_path = doc_path;
        }

        public int getIdt_doc()
        {
            return this.idt_doc;
        }

        public void setIdt_doc(int i)
        {
            this.idt_doc = i;
        }

        public String getDoc_path()
        {
            return this.doc_path;
        }

        public void setDoc_path(String p)
        {
            this.doc_path = p;
        }

        public String toString()
        {
            return this.doc_path;
        }
    }
}