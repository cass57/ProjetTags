using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class DocumentDAO : DAO<Document>
    {
        public override Document findByIdt(int idt)
        {
            var doc = new Document();

            try
            {
                MySqlConnection co = BDD.get_Connection();
                // Script select ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return doc;
        }

        public override Document insert(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                // Script insert ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        public override Document update(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                // Script update ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        public override void delete(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                // Script delete ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }
    }
}