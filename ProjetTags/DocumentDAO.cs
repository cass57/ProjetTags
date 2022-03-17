using System;
using System.Data.SqlClient;

namespace ProjetTags
{
    public class DocumentDAO : DAO<Document>
    {
        public override Document select(int idt)
        {
            Document doc = new Document();
            
            try
            {
                BDD.InitConnection();
                // Script select ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(System.Environment.StackTrace);
            }

            return doc;
        }

        public override Document insert(Document obj)
        {
            try
            {
                BDD.InitConnection();
                // Script insert ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(System.Environment.StackTrace);
            }

            return obj;
        }

        public override Document update(Document obj)
        {
            try
            {
                BDD.InitConnection();
                // Script update ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(System.Environment.StackTrace);
            }

            return obj;
        }

        public override void delete(Document obj)
        {
            try
            {
                BDD.InitConnection();
                // Script delete ?
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(System.Environment.StackTrace);
            }
        }
    }
}