using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ProjetTags
{
    public class DocumentDAO : DAO<Document>
    {
        public List<Document> allDoc()
        {
            List<Document> docs = new List<Document>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                
                String commandLine = @"SELECT * FROM document;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_doc = Int32.Parse(reader.GetString(0));
                    String doc_path = reader.GetString(1);

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
        public override Document findByIdt(int idt)
        {
            var doc = new Document();

            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;

                String commandLine = @"SELECT * FROM document WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@idt_doc", idt);

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_doc = Int32.Parse(reader.GetString(0));
                    String doc_path = reader.GetString(1);

                    // TODO : à voir : est-ce qu'on recréé vraiment un DTO?
                    doc = new Document(idt_doc, doc_path);
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

        public override Document insert(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                
                String commandLine = @"INSERT INTO document (doc_path) VALUES (@doc_path);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@doc_path", obj.getDoc_path());

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

        public override Document update(Document obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                String commandLine =
                    @"UPDATE document SET doc_path = @doc_path WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());
                cmd.Parameters.AddWithValue("@doc_path", obj.getDoc_path());

                cmd.ExecuteNonQuery();
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
                MySqlCommand cmd = new MySqlCommand();

                String commandLine = @"DELETE FROM document WHERE idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());

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