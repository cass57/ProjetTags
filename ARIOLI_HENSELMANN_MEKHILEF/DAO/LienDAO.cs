using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ARIOLI_HENSELMANN_MEKHILEF.Model;
using MySql.Data.MySqlClient;

namespace ARIOLI_HENSELMANN_MEKHILEF.DAO
{
    public class LienDAO : DAO<Lien>
    {
        public override Lien FindByIdt(int idt)
        {
            var lien = new Lien();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT liaison.idt_doc, liaison.idt_tag
                                       FROM liaison AS liaison
                                       WHERE liaison.idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", idt);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lien.idt_doc = int.Parse(reader.GetString(0));
                    lien.idt_tag = int.Parse(reader.GetString(1));
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return lien;
        }
        
        /// <summary>
        /// Renvoie tous les documents liés à l'identifiant d'un tag
        /// </summary>
        /// <param name="idt"></param>
        /// <returns></returns>
        public List<int> FindAllDocByIdtTag(int idt)
        {
            var docs = new List<int>();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT liaison.idt_doc
                                       FROM liaison AS liaison
                                       WHERE liaison.idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", idt);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    docs.Add(int.Parse(reader.GetString(0)));
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return docs;
        }

        public override Lien Insert(Lien tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"INSERT INTO liaison (idt_doc, idt_tag) VALUES (@idt_doc, @idt_tag);";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_doc", tag.idt_doc);
                cmd.Parameters.AddWithValue("@idt_tag", tag.idt_tag);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tag;
        }

        public override Lien Update(Lien tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"UPDATE tag SET idt_tag = @idt_tag WHERE idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", tag.idt_tag);
                cmd.Parameters.AddWithValue("@idt_doc", tag.idt_doc);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tag;
        }

        public override void Delete(Lien tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine1 = @"DELETE FROM liaison WHERE idt_doc = @idt_doc AND idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine1;

                cmd.Parameters.AddWithValue("@idt_doc", tag.idt_doc);
                cmd.Parameters.AddWithValue("@idt_tag", tag.idt_tag);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }

        /// <summary>
        /// Renvoie tous les tags d'un document
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<Tag> AllTagDoc(Document doc)
        {
            var tags = new List<Tag>();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine =
                    @"SELECT tag.idt_tag, tag.nom, tag.clr, tag.idt_pere FROM tag, liaison WHERE liaison.idt_tag = tag.idt_tag AND liaison.idt_doc = @idt_doc";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;
                cmd.Parameters.AddWithValue("@idt_doc", doc.idt_doc);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idtTag = int.Parse(reader.GetString(0));
                    string nom = reader.GetString(1);
                    string clr = reader.GetString(2);
                    var idtPere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;

                    tags.Add(new Tag(idtTag, nom, clr, idtPere));
                }

                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tags;
        }
    }
}