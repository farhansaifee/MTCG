using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
    interface ITrading
    {

        int Tradingid { get; }
        string Karte { get; }
        int MinDamage { get; }
        string Typ { get; }

    }
}