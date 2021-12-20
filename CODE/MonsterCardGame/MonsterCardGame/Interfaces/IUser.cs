﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MonsterCardGame.Interfaces
{
    interface IUser
    {

        string Username { get; }
        string Password { get; }
        ArrayList Cards { get; }
        int Coins { get; }

    }
}