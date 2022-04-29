using System;
using MySql.Data.MySqlClient;

namespace ARIOLI_HENSELMANN_MEKHILEF
{
    public class BDD
    {
        private static MySqlConnection _connection;
        private static MySqlCommand _commande;

        private static void InitConnection()
        {
            const string connectionString = "SERVER=localhost; DATABASE=etagger; UID=root; PASSWORD=;";

            _connection = new MySqlConnection(connectionString);
            _commande = new MySqlCommand();

            try
            {
                _commande.Connection = _connection;
                _commande.Connection.Open();
            }
            catch (NullReferenceException e)
            {
                Console.Write($@"Erreur : {e}");
                throw;
            }
        }

        public static MySqlConnection get_Connection()
        {
            if (_connection == null) InitConnection();
            return _connection;
        }
    }
}