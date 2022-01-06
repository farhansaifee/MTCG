using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public class User : Interfaces.IUser
    {
        // Kontruktor
        // Creates new ArrayList Objekt of Cards
        public User()
        {
            Cards = new ArrayList();

        }
        // Setter Getter Methoden
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public ArrayList Cards { get; set; }

    }
}