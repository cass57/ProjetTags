using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class LienDAO : DAO<Lien>
    {
        /// <summary>
        /// TRouver les tags d'un document
        /// </summary>
        /// <param name="obj">document</param>
        /// <returns>tags</returns>
        public List<Tag> allTagDoc(Document obj)
        {
            List<Tag> tags = new List<Tag>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;

                String commandLine = @"SELECT tag.idt_tag, tag.nom, tag.clr
                                       FROM liaison AS liaison 
                                            INNER JOIN tag AS tag ON liaison.idt_tag = tag.idt_tag
                                       WHERE liaison.idt_doc = @idt_doc;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@idt_doc", obj.getIdt_doc());

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_tag = Int32.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);

                    Tag newTag = new Tag(idt_tag, nom, clr);
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

        public override Lien findByIdt(int idt)
        {
            throw new NotImplementedException();
        }

        public override Lien insert(Lien obj)
        {
            throw new System.NotImplementedException();
        }

        public override Lien update(Lien obj)
        {
            throw new System.NotImplementedException();
        }

        public override void delete(Lien obj)
        {
            throw new System.NotImplementedException();
        }
    }
}