using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class TagDAO : DAO<Tag>
    {
        public IDictionary<int,List<Tag>> allTag()
        {
            IDictionary<int, List<Tag>> tags = new Dictionary<int, List<Tag>>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;
                
                String commandLine = @"SELECT * FROM tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int idt_tag = Int32.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);
                    int idt_pere = 0;
                    if (!reader.IsDBNull(3))
                    {
                        idt_pere = Int32.Parse(reader.GetString(3));
                    }
                    Tag newTag = new Tag(idt_tag, nom, clr,idt_pere);

                    if (tags.ContainsKey(idt_pere))
                    {
                        List<Tag> Enfants = new List<Tag>();
                        Enfants = tags[idt_pere];
                        Enfants.Add(newTag);
                        tags[idt_pere] = Enfants;
                    }
                    else
                    {
                        List<Tag> noms = new List<Tag>();
                        noms.Add(newTag);
                        tags.Add(idt_pere,noms);
                    }
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
        
        
        /// <summary>
        /// Infos d'un tag par son identifiant
        /// </summary>
        /// <param name="idt">identifiant</param>
        /// <returns>Tag</returns>
        public override Tag findByIdt(int idt)
        {
            var tag = new Tag();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;

                String commandLine = @"SELECT * FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@idt_tag", idt);

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int idt_tag = Int32.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);
                    int idt_pere = Int32.Parse(reader.GetString(3));

                    // TODO : à voir : est-ce qu'on recréé vraiment un DTO?
                    tag = new Tag(idt_tag, nom, clr, idt_pere);
                }
                
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
            
            return tag;
        }

        /// <summary>
        /// Insert un tag avec tous les attributs
        /// </summary>
        /// <param name="obj">Tag à insérer</param>
        /// <returns>Le tag</returns>
        public override Tag insert(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                
                String commandLine = @"INSERT INTO tag (nom, clr, idt_pere) VALUES (@nom, @clr, @idt_pere);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@nom", obj.getNom());
                cmd.Parameters.AddWithValue("@clr", obj.getClr());
                cmd.Parameters.AddWithValue("@idt_pere", obj.getIdt_pere());
                
                // TODO : les idt sont en auto-incrémente, donc on doit le mettre à jour sur le DTO ? donc à la création du DTO pas de idt_tag ?

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }
        
        /// <summary>
        /// Insert un tag sans idt_pere
        /// </summary>
        /// <param name="obj">Tag à insérer</param>
        /// <returns>Le tag</returns>
        public Tag insertSansPere(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();
                
                String commandLine = @"INSERT INTO tag (nom, clr) VALUES (@nom, @clr);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;
                
                cmd.Parameters.AddWithValue("@nom", obj.getNom());
                cmd.Parameters.AddWithValue("@clr", obj.getClr());
                
                // TODO : les idt sont en auto-incrémente, donc on doit le mettre à jour sur le DTO ? donc à la création du DTO pas de idt_tag ?

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        /// <summary>
        /// Update le tag
        /// </summary>
        /// <param name="obj">le tag avec les valeurs a update</param>
        /// <returns>le tag</returns>
        public override Tag update(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                String commandLine =
                    @"UPDATE tag SET nom = @nom, clr = @clr, idt_pere = @idt_pere WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", obj.getIdt_tag());
                cmd.Parameters.AddWithValue("@clr", obj.getClr());
                cmd.Parameters.AddWithValue("@nom", obj.getNom());
                // TODO : ça marche pas quand idt_pere est nul car getIdt_pere renvoie 0 ???
                cmd.Parameters.AddWithValue("@idt_pere", obj.getIdt_pere());

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return obj;
        }

        /// <summary>
        /// Delete le tag
        /// </summary>
        /// <param name="obj">le tag a supprimer</param>
        public override void delete(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                String commandLine1 = @"DELETE FROM liaison WHERE idt_tag = @idt_tag;";
                
                cmd.Connection = co;
                cmd.CommandText = commandLine1;

                cmd.Parameters.AddWithValue("@idt_tag", obj.getIdt_tag());
                cmd.ExecuteNonQuery();
                
                String commandLine = @"DELETE FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

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