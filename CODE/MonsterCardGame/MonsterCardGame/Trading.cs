using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class Trading : Interfaces.ITrading
    {

        // Kontruktor mit 4 Attributen
        public Trading(int id, string card, int minDamage, string type)
        {
            this.Tradingid = id;
            this.Karte = card;
            this.MinDamage = minDamage;
            this.Typ = type;

        }

        // Getter Setter
        public int Tradingid { get; set; }
        public string Karte { get; set; }
        public int MinDamage { get; set; }
        public string Typ { get; set; }

        // toString Methode
        public override string ToString()
        {
            return "TradingId: " + Tradingid + " Card: " + Karte + " MinDamage: " + MinDamage + " Type: " + Typ + "\n";
        }

    }
}
