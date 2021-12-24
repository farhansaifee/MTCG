using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MonsterCardGame
{
    class DbConn
    {

        public string cs = "Host=localhost;Username=postgres;Password=postgres;Database=mctg";

        // Creates new Card with following attributes
        public void Card(int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO card VALUES (@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Registers new user with username & password
        public void Register(string username, string password)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO users VALUES (@username, @password, @coins)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("coins", 20);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddCard()
        {
            using var connection = new NpgsqlConnection(cs);
            connection.Open();


        }

        public void CreateUser()
        {
            using var connection = new NpgsqlConnection(cs);
            connection.Open();


        }

        public void CreateUserstats()
        {
            using var connection = new NpgsqlConnection(cs);
            connection.Open();


        }
    }
}
