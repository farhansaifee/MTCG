using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public class UserData : Interfaces.IUserData
    {
        // Kontruktor mit 6 Attributen
        public UserData(string name, string bio, string image, string age, string nickname, string currentcareer)
        {
            this.Name = name;
            this.Bio = bio;
            this.Image = image;
            this.Age = age;
            this.Nickname = nickname;
            this.Currentcareer = currentcareer;

        }

        // Getter Setter Methoden
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Age { get; set; }
        public string Nickname { get; set; }
        public string Currentcareer { get; set; }

        // toString Methode
        public override string ToString()
        {
            return "Name: " + Name + " Bio: " + Bio + " Image: " + Image + "Age: " + Age + " Nickname: " + Nickname + " Currentcareer: " + Currentcareer + "\n";
        }

    }
}
