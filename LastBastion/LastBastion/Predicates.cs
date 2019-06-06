using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal static class Preds
    {
        internal static bool IsDead(Unit n)
        {
            return n.Life == 0;
        }
    }
}
