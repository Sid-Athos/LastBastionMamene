﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public static class Preds
    {
        public static bool IsDead(Unit n)
        {
            return n.Life == 0;
        }
    }
}
