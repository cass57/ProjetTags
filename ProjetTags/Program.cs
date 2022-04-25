using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            /*var test = new TagDAO();
            var truc = test.AllTag();
            if (!truc.ContainsKey(6)) return;*/
            Document doc = new Document(10, "Nou");
            LienDAO dao = new LienDAO();
            //dao.insertSansPere(tag);
            /*BDD.InsertTag("1","essai", "rouge");*/
            ///**/dao.insert(tag);
            //List<Tag> tags = dao.allTagDoc(doc);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

           
        }
    }
}