using System;
using System.Collections.Generic;
using System.Text;


namespace MonsterCardGame.Interfaces
{
    public interface IBattle
    {

        public List<Card> Fighter1 { get; }
        public string Fighter1name { get; }
        public List<Card> Fighter2 { get; }
        public string Fighter2name { get; }

    }
}