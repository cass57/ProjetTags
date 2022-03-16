using System;
using System.Windows.Forms;

namespace ProjetTags
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            BDD.InitConnection();
            /*BDD.InsertTag("1","essai", "rouge");*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            
        }
    }
}