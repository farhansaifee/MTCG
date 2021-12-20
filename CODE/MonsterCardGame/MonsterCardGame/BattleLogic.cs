using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class BattleLogic : Interfaces.IBattle
    {

        public BattleLogic()
        {
            Fighter1 = new List<Card>();
            Fighter2 = new List<Card>();
        }

        public List<Card> Fighter1 { get; set; }
        public List<Card> Fighter2 { get; set; }
        public string Fighter1name { get; set; }
        public string Fighter2name { get; set; }
    }
}
