using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
        // History Interface
        public interface IHistory
        {
            int Matchid { get; }
            string Winner { get; }
            string Protokol { get; }
        }
}