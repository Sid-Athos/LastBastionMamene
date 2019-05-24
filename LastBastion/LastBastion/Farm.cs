using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Farm : Building
    {
        uint _rank = 1;

        public Farm(float posX, float posY, Map context)
            : base(posX, posY, 100, 100, 5, 1, 40, 0, 20, 2, context,"Farm","test")
        {
        }
    }
}