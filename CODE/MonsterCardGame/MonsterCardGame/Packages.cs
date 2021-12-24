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

        // Adds 5 Cards to the package
        public string randomOrder()
        {
            string pack = "";
            int index;
            do
            {
                Random random = new Random();
                index = random.Next(0, AllCards.Count - 1);
                Card c1 = AllCards[index];
                if (!Package.Contains(c1))
                    Package.Add(c1);
            } while (Package.Count != 5);

            foreach (Object obj in Package)
                //Console.Write("   {0}", obj);
                pack = pack + obj;
            Console.WriteLine();
            
            Package.Clear();
            return pack;
        }

        public List<Card> Package { get; set; }
        public List<Card> AllCards { get; set; }

    }
}
