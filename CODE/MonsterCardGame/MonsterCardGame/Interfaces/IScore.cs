using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame.Interfaces
{
    class IScore
    {
        string Username { get; }
        int Win { get; }
        int Draw { get; }
        int Lose { get; }
    }
}
