using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using ProjetTags.Model;

namespace ProjetTags.DAO
{
    public class TagDAO : DAO<Tag>
    {
        public IDictionary<int, List<Tag>> AllTag()
        {
            IDictionary<int, List<Tag>> tags = new Dictionary<int, List<Tag>>();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT * FROM tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idtTag = int.Parse(reader.GetString(0));
                    string nom = reader.GetString(1);
                    string clr = reader.GetString(2);
                    int idtPere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;

                    var newTag = new Tag(idtTag, nom, clr, idtPere);

                    if (tags.ContainsKey(idtPere))
                    {
                        var enfants = tags[idtPere];
                        enfants.Add(newTag);
                        tags[idtPere] = enfants;
                    }
                    else
                        tags.Add(idtPere, new List<Tag> {newTag});
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

        public List<Tag> AllListTag()
        {
            var tags = new List<Tag>();
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT * FROM tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idtTag = int.Parse(reader.GetString(0));
                    string nom = reader.GetString(1);
                    string clr = reader.GetString(2);
                    int idtPere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;

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
                var cmd = new MySqlCommand();
                const string commandLine = @"SELECT * FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@idt_tag", idt);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idtTag = int.Parse(reader.GetString(0));
                    string nom = reader.GetString(1);
                    string clr = reader.GetString(2);
                    int idtPere = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0;

                    // TODO : à voir : est-ce qu'on recréé vraiment un DTO?
                    tag = new Tag(idtTag, nom, clr, idtPere);
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
        /// <param name="tag">Tag à insérer</param>
        /// <returns>Le tag</returns>
        public override Tag Insert(Tag tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                var commandLine = tag.idt_pere != 0
                    ? @"INSERT INTO tag (nom, clr, idt_pere) VALUES (@nom, @clr, @idt_pere);"
                    : @"INSERT INTO tag (nom, clr) VALUES (@nom, @clr);";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine;

                cmd.Parameters.AddWithValue("@nom", tag.nom);
                cmd.Parameters.AddWithValue("@clr", tag.clr);
                if(tag.idt_pere!=0)cmd.Parameters.AddWithValue("@idt_pere", tag.idt_pere);

                // TODO : les idt sont en auto-incrémente, donc on doit le mettre à jour sur le DTO ? donc à la création du DTO pas de idt_tag ?

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(Environment.StackTrace);
            }

            return tag;
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
                var cmd = new MySqlCommand();
                var commandLine = tag.idt_pere != 0
                    ? @"UPDATE tag SET nom = @nom, clr = @clr, idt_pere = @idt_pere WHERE idt_tag = @idt_tag;"
                    : @"UPDATE tag SET nom = @nom, clr = @clr WHERE idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
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

        /// <summary>
        /// Delete le tag
        /// </summary>
        /// <param name="tag">le tag a supprimer</param>
        public override void Delete(Tag tag)
        {
            try
            {
                var cmd = new MySqlCommand();
                const string commandLine1 = @"DELETE FROM liaison WHERE idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
                cmd.CommandText = commandLine1;

                cmd.Parameters.AddWithValue("@idt_tag", tag.idt_tag);
                cmd.ExecuteNonQuery();

                const string commandLine2 = @"DELETE FROM tag WHERE idt_tag = @idt_tag;";

                cmd.Connection = BDD.get_Connection();
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