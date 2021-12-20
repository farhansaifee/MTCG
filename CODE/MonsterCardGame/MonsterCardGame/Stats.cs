using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class Stats : Interfaces.IStats
    {

        // Kontruktor mit 3 Attributen
        public Stats(int win, int draw, int lose)
        {
            this.Win = win;
            this.Draw = draw;
            this.Lose = lose;

        }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }

        public override string ToString()
        {
            return "Wins: " + Win + " Draw: " + Draw + " Lose: " + Lose + "\n";
        }

    }
}
