using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
    interface IScore
    {

        string Username { get; }
        int Win { get; }
        int Draw { get; }
        int Lose { get; }

    }
}