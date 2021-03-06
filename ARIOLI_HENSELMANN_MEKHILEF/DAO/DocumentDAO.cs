using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ARIOLI_HENSELMANN_MEKHILEF.Model;
using MySql.Data.MySqlClient;

namespace ARIOLI_HENSELMANN_MEKHILEF.DAO
{
    public class DocumentDAO : DAO<Document>
    {
        /// <summary>
        /// Renvoie une liste avec tous les documents
        /// </summary>
        /// <returns></returns>
        public List<Document> AllDoc()
        {
            var docs = new List<Document>();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT * FROM document;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idtDoc = int.Parse(reader.GetString(0));
                    string docPath = reader.GetString(1);

                    docs.Add(new Document(idtDoc, docPath));
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

        /// <summary>
        /// Renvoie le document avec le plus grand identifiant (le dernier créé)
        /// </summary>
        /// <returns></returns>
        public int LastIdtDoc()
        {
            int idtDoc = 0;
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT MAX(idt_doc) FROM document;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();
                while (reader.Read()) idtDoc = int.Parse(reader.GetString(0));

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
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT * FROM document WHERE idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", idt);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doc.idt_doc = int.Parse(reader.GetString(0));
                    doc.doc_path = reader.GetString(1);
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

        public override Document Insert(Document tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"INSERT INTO document (doc_path) VALUES (@doc_path);";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

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

        public override Document Update(Document tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"UPDATE document SET doc_path = @doc_path WHERE idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
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

        public override void Delete(Document tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"DELETE FROM liaison WHERE idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", tag.idt_doc);

                cmd.ExecuteNonQuery();

                var cmd2 = new MySqlCommand();
                const string commandLine2 = @"DELETE FROM document WHERE idt_doc = @idt_doc;";

                cmd2.Connection = BDD.get_Connection();
                cmd2.CommandText = commandLine2;

                cmd2.Parameters.AddWithValue("@idt_doc", tag.idt_doc);

                cmd2.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }
    }
}