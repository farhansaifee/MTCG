using MonstercardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class Packages : Interfaces.IPackage
    {

        public Packages()
        {
            AllCards = new List<Card>();
            Package = new List<Card>();
        }

        public List<Card> Package { get; set; }
        public List<Card> AllCards { get; set; }

    }
}
