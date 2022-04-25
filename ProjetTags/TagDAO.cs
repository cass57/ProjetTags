using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class TagDAO : DAO<Tag>
    {
        public IDictionary<int, List<Tag>> AllTag()
        {
            IDictionary<int, List<Tag>> tags = new Dictionary<int, List<Tag>>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"SELECT * FROM tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idt_tag = int.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);
                    int idt_pere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;
                    Tag newTag = new Tag(idt_tag, nom, clr, idt_pere);

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
                        tags.Add(idt_pere, noms);
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

        public List<Tag> allListTag()
        {
            List<Tag> tags = new List<Tag>();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"SELECT * FROM tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idt_tag = int.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);
                    int idt_pere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;
                    Tag newTag = new Tag(idt_tag, nom, clr, idt_pere);
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


        /// <summary>
        /// Infos d'un tag par son identifiant
        /// </summary>
        /// <param name="idt">identifiant</param>
        /// <returns>Tag</returns>
        public override Tag FindByIdt(int idt)
        {
            var tag = new Tag();
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"SELECT * FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", idt);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idt_tag = Int32.Parse(reader.GetString(0));
                    String nom = reader.GetString(1);
                    String clr = reader.GetString(2);
                    int idt_pere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;

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
        public override Tag Insert(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"INSERT INTO tag (nom, clr, idt_pere) VALUES (@nom, @clr, @idt_pere);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@nom", obj.nom);
                cmd.Parameters.AddWithValue("@clr", obj.clr);
                cmd.Parameters.AddWithValue("@idt_pere", obj.idt_pere);

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

                const string commandLine = @"INSERT INTO tag (nom, clr) VALUES (@nom, @clr);";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@nom", obj.nom);
                cmd.Parameters.AddWithValue("@clr", obj.clr);

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
        /// <param name="tag">le tag avec les valeurs a update</param>
        /// <returns>le tag</returns>
        public override Tag Update(Tag tag)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                var commandLine = tag.idt_pere != 0
                    ? @"UPDATE tag SET nom = @nom, clr = @clr, idt_pere = @idt_pere WHERE idt_tag = @idt_tag;"
                    : @"UPDATE tag SET nom = @nom, clr = @clr WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", tag.idt_tag);
                cmd.Parameters.AddWithValue("@clr", tag.clr);
                cmd.Parameters.AddWithValue("@nom", tag.nom);
                
                if (tag.idt_pere != 0) cmd.Parameters.AddWithValue("@idt_pere", tag.idt_pere);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tag;
        }

        public Tag updateSansPere(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine = @"UPDATE tag SET nom = @nom, clr = @clr WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", obj.idt_tag);
                cmd.Parameters.AddWithValue("@clr", obj.clr);
                cmd.Parameters.AddWithValue("@nom", obj.nom);

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
        public override void Delete(Tag obj)
        {
            try
            {
                MySqlConnection co = BDD.get_Connection();
                MySqlCommand cmd = new MySqlCommand();

                const string commandLine1 = @"DELETE FROM liaison WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine1;

                cmd.Parameters.AddWithValue("@idt_tag", obj.idt_tag);
                cmd.ExecuteNonQuery();

                const string commandLine2 = @"DELETE FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = co;
                cmd.CommandText = commandLine2;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }
        }

        public void DeleteTagWithChildren(Tag tag)
        {
            var allTags = AllTag();
            if (!allTags.ContainsKey(tag.idt_tag))
            {
                Delete(tag);
                return;
            }

            foreach (var child in allTags[tag.idt_tag]) DeleteTagWithChildren(child);
            Delete(tag);
        }
    }
}