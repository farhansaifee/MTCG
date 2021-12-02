using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MonsterCardGame
{
    class Database
    {

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"server=localhost;Port=5050");
        }

    }
}