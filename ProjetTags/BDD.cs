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
            }
            catch (NullReferenceException e)
            {
                Console.Write("Erreur : {0}", e.ToString());
                throw e;
            }
        }

        /*public static void InsertTag(String argidt, String argnom, String argclr)
        {
            _commandeLine = @"INSERT INTO tag (idt, nom, clr) VALUES (@argidt, @argnom, @argclr);";

            _commande.CommandText = _commandeLine;
            
            _commande.Parameters.AddWithValue(@argidt, 1);
            _commande.Parameters.AddWithValue(@argnom, argnom);
            _commande.Parameters.AddWithValue(@argclr, argclr);

            _commande.ExecuteNonQuery();
        }*/

    }
}