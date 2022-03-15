using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class BDD
    {
        private static MySqlConnection _connection;
        private static MySqlCommand _commande;
        private static string _commandeLine;

        public static void InitConnection()
        {
            String connextionString = "SERVER=localhost; DATABASE=etagger; UID=root; PASSWORD=;";

            _connection = new MySqlConnection(connextionString);

            _commande = new MySqlCommand();

            try
            {
                _commande.Connection = _connection;
                _commande.Connection.Open();
                Console.Write("Connection établie.");
            }
            catch (NullReferenceException e)
            {
                Console.Write("Erreur : {0}", e.ToString());
                throw e;
            }
        }

        public static void InsertTag()
        {
            _commandeLine = @"INSERT INTO tag
                            (nom, clr)
                            VALUES
                            (@nom, @clr);";

            _commande.CommandText = _commandeLine;

            _commande.Parameters.AddWithValue(@nom, inputNom);
            _commande.Parameters.AddWithValue(@clr, inputClr);

            _commande.ExecuteNonQuery();
        }

        public static void Main(string[] args)
        {
            Console.Write("ici");
            InitConnection();

            try
            {
                Console.Write("MySQL version : " + _commande.Connection.ServerVersion);
            }
            finally
            {
                _commande.Connection.Close();
                Console.Write("Connection terminée");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        
        
    }
}