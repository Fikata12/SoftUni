﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; set; }
        void BuyFood();
    }
}
