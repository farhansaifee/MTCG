using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public class Card : Interfaces.ICard
    {

        // Constructor with parameters
        public Card(int id, string name, int damage, string element, string type)
        {
            this.id = id;
            this.name = name;
            this.damage = damage;
            this.element = element;
            this.type = type;

        }

        // Setter Getter Methods
        public int id { get; set; }
        public string name { get; set; }
        public int damage { get; set; }
        public string element { get; set; }
        public string type { get; set; }

        // Should return CardInfo
        public string CardInfo()
        {
            return "ID: " + id + " Card: " + name + " Damage: " + damage + " Element: " + element + " Type: " + type + "\n";
        }

        // toString Method
        public override string ToString()
        {
            //return "ID: " + id + " Card: " + name + " Damage: " + damage + " Element: " + element + " Type: " + type + "\n";
            return "" + id + " ";
        }

    }
}
