using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame.Interfaces
{
    class IUser
    {
        int Id { get; }
        string Username { get; }
        string Password { get; }
        ArrayList Cards { get; }
        int Coins { get; }
    }
}
