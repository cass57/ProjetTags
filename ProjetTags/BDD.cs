using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class BDD
    {
        private static MySqlConnection _connection;
        private static MySqlCommand _commande;

        public static void InitConnection()
        {
            String connextionString = "SERVER=localhost; DATABASE=etagger; UID=root; PASSWORD=;";

            _connection = new MySqlConnection(connextionString);

            _commande = new MySqlCommand();

            try
            {
                _commande.Connection = _connection;
                _commande.Connection.Open();
            }
            catch (NullReferenceException e)
            {
                Console.Write("Erreur : {0}", e.ToString());
                throw e;
            }
        }

    }
}