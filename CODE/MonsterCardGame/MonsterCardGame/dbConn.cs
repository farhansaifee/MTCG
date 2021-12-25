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

        public string data = "Host=localhost;Username=postgres;Password=postgres;Database=mctg";

        // Creates new Card with following attributes
        public void Card(int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(data);
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
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO users VALUES (@username, @password, @coins)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("coins", 20);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Get Usercards
        public string GetUserCards(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id,name,damage,element,type FROM usercards WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + " " + rdr.GetString(4) + "\n";
            }
            con.Close();
            return output;
        }

        // Add Usercards
        public void AddUserCard(string username, int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO usercards VALUES (@username ,@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Add Userdata
        public void CreateUserdata(string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO userdata VALUES (@username, @name, @bio, @image)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("name", "undefined");
            cmd.Parameters.AddWithValue("bio", "undefined");
            cmd.Parameters.AddWithValue("image", "undefined");
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}