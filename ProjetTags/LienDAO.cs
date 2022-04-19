﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class LienDAO : DAO<Lien>
    {
        /// <summary>
        /// Trouver les tags d'un document
        /// </summary>
        /// <param name="obj">document</param>
        /// <returns>tags</returns>

        public override Lien findByIdt(int idt)
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
                    lien.setIdt_doc(int.Parse(reader.GetString(0)));
                    lien.setIdt_tag(int.Parse(reader.GetString(1)));
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return lien;
        }

        public override Lien insert(Lien obj)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"INSERT INTO liaison (idt_doc, idt_tag) VALUES (@idt_doc, @idt_tag);";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());
                cmd.Parameters.AddWithValue("@idt_tag", obj.getIdt_tag());
                
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        public override Lien update(Lien obj)
        {
            try
            {
                var cmd = new MySqlCommand();

                const string commandLine = @"UPDATE tag SET idt_tag = @idt_tag WHERE idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", obj.getIdt_tag());
                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        public override void delete(Lien obj)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine1 = @"DELETE FROM liaison WHERE idt_doc = @idt_doc AND idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine1;

                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());
                cmd.Parameters.AddWithValue("@idt_tag", obj.getIdt_tag());
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }

        public List<Tag> allTagDoc(Document doc)
        {
            var tags = new List<Tag>();
            try
            {
                var cmd = new MySqlCommand();

                const string commandLine = @"SELECT tag.idt_tag, tag.nom, tag.clr
                                       FROM liaison AS liaison 
                                            INNER JOIN tag AS tag ON liaison.idt_tag = tag.idt_tag
                                       WHERE liaison.idt_doc = @idt_doc;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;
                cmd.Parameters.AddWithValue("@idt_doc", doc.getIdt_doc());

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idtTag = int.Parse(reader.GetString(0));
                    string nom = reader.GetString(1);
                    string clr = reader.GetString(2);

                    var newTag = new Tag(idtTag, nom, clr);
                    tags.Add(newTag);
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