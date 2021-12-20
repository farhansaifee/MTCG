using System;
using System.Collections.Generic;
using System.Text;

namespace MonstercardGame.Interfaces
{
    // History Interface
    public interface IHistory
    {
        int Matchid { get; }
        string Winner { get; }
        string Protokol { get; }
    }
}
