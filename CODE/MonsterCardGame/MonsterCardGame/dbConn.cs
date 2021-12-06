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

        public string cs = "Host=localhost;Username=postgres;Password=postgres;Database=mctg4";
        
        public void Cards()
        {
            using var connection = new NpgsqlConnection(cs);
            connection.Open();


        }

        public void Register()
        {
            using var connection = new NpgsqlConnection(cs);
            connection.Open();


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
