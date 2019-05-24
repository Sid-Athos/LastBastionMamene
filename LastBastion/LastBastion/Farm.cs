using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Farm : Building
    {
        public Farm(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
            : base(posX, posY, 200, 200, 20, 1, 20, 0f, 0, context, "Farm", "test")
        {

        }
    }
}

