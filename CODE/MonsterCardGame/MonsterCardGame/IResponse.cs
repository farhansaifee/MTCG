﻿using System.Collections.Generic;

namespace MonsterCardGame
{
    public interface IResponse
    {
        Dictionary<int, string> msg { get; }
        byte[] sendBytes { get; }
        string lastPart { get; }
        int msgCounter { get; }
        string responseMsg { get; }
    }
}