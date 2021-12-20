using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class UserData : Interfaces.IUserData
    {
        // Kontruktor mit 3 Attributen
        public UserData(string name, string bio, string image)
        {
            this.Name = name;
            this.Bio = bio;
            this.Image = image;

        }

        // Getter Setter Methoden
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }

        // toString Methode
        public override string ToString()
        {
            return "Name: " + Name + " Bio: " + Bio + " Image: " + Image + "\n";
        }

    }
}
