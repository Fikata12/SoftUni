﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public int Power { get; protected set; }
        public abstract string CastAbility();
    }
}
