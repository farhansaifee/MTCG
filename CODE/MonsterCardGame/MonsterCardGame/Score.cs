using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public class Score : Interfaces.IScore
    {
        // Kontruktor mit 4 Attributen
        public Score(string username, int win, int draw, int lose)
        {
            this.Username = username;
            this.Win = win;
            this.Draw = draw;
            this.Lose = lose;

        }
        public string Username { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }

        public override string ToString()
        {
            return "Username: " + Username + " Wins: " + Win + " Draw: " + Draw + " Lose: " + Lose + "\n";
        }

    }
}
