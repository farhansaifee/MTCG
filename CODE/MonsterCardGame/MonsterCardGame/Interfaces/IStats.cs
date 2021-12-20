using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
    interface IStats
    {

        int Win { get; }
        int Draw { get; }
        int Lose { get; }

    }
}