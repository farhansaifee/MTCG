using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
    interface IPackage
    {
        public List<Card> Package { get; }
        public List<Card> AllCards { get; }

    }
}