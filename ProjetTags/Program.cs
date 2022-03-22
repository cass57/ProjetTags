using System;
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
           
            Tag tag = new Tag(4, "NouveauAuto", "ffffff", 1);
            TagDAO dao = new TagDAO();
            //dao.insertSansPere(tag);
            /*BDD.InsertTag("1","essai", "rouge");*/
            ///**/dao.insert(tag);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

           
        }
    }
}