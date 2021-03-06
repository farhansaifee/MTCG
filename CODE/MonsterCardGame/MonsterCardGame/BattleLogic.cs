using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public class BattleLogic : Interfaces.IBattle
    {

        DbConn dbc = new DbConn();

        public BattleLogic()
        {
            Fighter1 = new List<Card>();
            Fighter2 = new List<Card>();
        }

        public List<Card> Fighter1 { get; set; }
        public List<Card> Fighter2 { get; set; }
        public string Fighter1name { get; set; }
        public string Fighter2name { get; set; }

        //returns Winner
        public string SetWinner(string username1, string username2, string name1, string typ1, string ele1, int dam1, string name2, string typ2, string ele2, int dam2)
        {
            if (name1 == "Goblin" && name2 == "Dragon")
            {
                Console.WriteLine("Dragon Wins");
                return username2;
            }
            else if (name1 == "Dragon" && name2 == "Goblin")
            {
                Console.WriteLine("Dragon Wins");
                return username1;
            }
            else if (name1 == "Wizzard" && name2 == "Ork")
            {
                Console.WriteLine("Wizzard Wins");
                return username1;
            }
            else if (name1 == "Ork" && name2 == "Wizzard")
            {
                Console.WriteLine("Wizzard Wins");
                return username2;
            }
            else if (name1 == "Knight" && name2 == "Wizzard")
            {
                Console.WriteLine("Wizzard Wins");
                return username2;
            }
            else if (name1 == "Wizzard" && name2 == "Knight")
            {
                Console.WriteLine("Wizzard Wins");
                return username2;
            }
            else if (name1 == "Knight" && typ2 == "spell" && ele2 == "water")
            {
                Console.WriteLine("Spell & Water Wins");
                return username2;
            }
            else if (name2 == "Knight" && typ1 == "spell" && ele1 == "water")
            {
                Console.WriteLine("Spell & Water Wins");
                return username1;
            }
            else if (name1 == "Kraken" && name2 == "Kraken")
            {
                Console.WriteLine("draw");
                return "draw";
            }
            else if (name1 == "Kraken" && typ2 == "spell")
            {
                Console.WriteLine("Kraken Wins");
                return username1;
            }
            else if (typ1 == "spell" && name2 == "Kraken")
            {
                Console.WriteLine("Kraken Wins");
                return username2;
            }
            else if (name1 == "Elves" && ele1 == "fire" && name2 == "Dragon")
            {
                Console.WriteLine("Elves (fire) Wins");
                return username1;
            }
            else if (name1 == "Dragon" && name2 == "Elves" && ele2 == "fire")
            {
                Console.WriteLine("Dragon Wins");
                return username1;
            }
            
            // Spell Section
            else if (typ1 == "spell" && ele1 == "water" && typ2 == "spell" && ele2 == "fire")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "fire" && typ2 == "spell" && ele2 == "water")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "fire" && typ2 == "spell" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "water" && typ2 == "spell" && ele2 == "water")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "water" && typ2 == "spell" && ele2 == "water")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "water" && typ2 == "monster" && ele2 == "water")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "spell" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "fire" && typ2 == "monster" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "spell" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "monster" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "fire" && typ2 == "spell" && ele2 == "normal")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "water" && typ2 == "spell" && ele2 == "normal")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "spell" && ele2 == "fire")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "spell" && ele2 == "water")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }

            // Mixed Section
            else if (typ1 == "spell" && ele1 == "water" && typ2 == "monster" && ele2 == "fire")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "spell" && ele2 == "water")
            {
                dam2 = dam2 * 2;
                dam1 = dam1 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "monster" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "fire" && typ2 == "monster" && ele2 == "normal")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "spell" && ele2 == "fire")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            //Normal
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "spell" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "monster" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "spell" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "monster" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "spell" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "water" && typ2 == "monster" && ele2 == "water")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "monster" && ele2 == "normal")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "monster" && ele2 == "fire")
            {
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "monster" && ele2 == "normal")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "monster" && ele2 == "fire")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "water" && typ2 == "monster" && ele2 == "fire")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }

            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "monster" && ele2 == "water")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "spell" && ele1 == "normal" && typ2 == "monster" && ele2 == "fire")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "spell" && ele2 == "normal")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "normal" && typ2 == "monster" && ele2 == "fire")
            {
                dam1 = dam1 / 2;
                dam2 = dam2 * 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else if (typ1 == "monster" && ele1 == "fire" && typ2 == "monster" && ele2 == "normal")
            {
                dam1 = dam1 * 2;
                dam2 = dam2 / 2;
                Console.WriteLine("Dam1 is {0}, Dam2 is {1}", dam1, dam2);
                if (dam1 == dam2)
                {
                    return "draw";
                }
                else if (dam1 > dam2)
                {
                    return username1;
                }
                else
                {
                    return username2;
                }
            }
            else
            {
                Console.WriteLine("FALSCH");
                return "FALSCH";
            }
        }

        // Returns the FightType "spell"/"monster"/"mixed"
        public string FightType(string card1, string card2)
        {
            if (String.Compare(card1, card2) == 0)
            {
                return card1;  //returns "spell" or "monster"
            }
            return "mixed";    //returns "mixed"
        }

        // Fighter füllen
        public void FillDeckFigther(string user, List<Card> Fig)
        {
            string deck = dbc.GetUserDeck(user);
            //read line by line
            using (StringReader reader = new StringReader(deck))
            {
                string line;        //line
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    if (line.Contains(','))
                    {
                        int id = Int32.Parse(line.Split(',')[0]);
                        string name = line.Split(',')[1];
                        int damage = Int32.Parse(line.Split(',')[2]);
                        string element = line.Split(',')[3];
                        string type = line.Split(',')[4];

                        Fig.Add(new Card(id, name, damage, element, type));

                    }
                }
            }
        }

    }
}