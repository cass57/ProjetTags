using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace ProjetTags
{
    public class DocumentDAO : DAO<Document>
    {
        public List<Document> AllDoc()
        {
            List<Document> docs = new List<Document>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"SELECT * FROM document;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_doc = Int32.Parse(reader.GetString(0));
                    string doc_path = reader.GetString(1);

                    Document newDoc = new Document(idt_doc, doc_path);

                    docs.Add(newDoc);
                }
                
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return docs;
        }
        
        public int LastIdtDoc()
        {
            int idtDoc = 0;
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                
                const string commandLine = @"SELECT MAX(idt_doc) FROM document;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    idtDoc = int.Parse(reader.GetString(0));
                }
                
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return idtDoc;
        }
        public override Document FindByIdt(int idt)
        {
            var doc = new Document();

            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"SELECT * FROM document WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@idt_doc", idt);

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_doc = int.Parse(reader.GetString(0));
                    string doc_path = reader.GetString(1);

                    // TODO : à voir : est-ce qu'on recréé vraiment un DTO?
                    doc.idt_doc = idt_doc;
                    doc.doc_path = doc_path;
                }
                
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return doc;
        }

        public override Document Insert(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                
                const string commandLine = @"INSERT INTO document (doc_path) VALUES (@doc_path);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@doc_path", obj.doc_path);

                // TODO : les idt sont en auto-incrémente, donc on doit le mettre à jour sur le DTO ? donc à la création du DTO pas de idt_doc ?

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        public override Document Update(Document tag)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"UPDATE document SET doc_path = @doc_path WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", tag.idt_doc);
                cmd.Parameters.AddWithValue("@doc_path", tag.doc_path);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tag;
        }

        public override void Delete(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"DELETE FROM document WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", obj.idt_doc);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }
    }
}