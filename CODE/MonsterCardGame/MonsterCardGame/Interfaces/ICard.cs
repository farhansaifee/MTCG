using System;
using System.Collections.Generic;
using System.Text;


namespace MonsterCardGame.Interfaces
{
    interface ICard
    {

        int id { get; }
        string name { get; }
        int damage { get; }
        string element { get; }
        string type { get; }

    }
}