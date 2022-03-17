using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetTags
{
    public class TagDAO : DAO<Tag>
    {
        public override Tag select(int idt)
        {
            Tag tag = new Tag();
            
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

            return tag;
        }

        public override Tag insert(Tag obj)
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

        public override Tag update(Tag obj)
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

        public override void delete(Tag obj)
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