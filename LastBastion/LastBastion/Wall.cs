using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Wall : Building
    {
        uint _rank = 1;

        public Wall(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            uint woodCost, uint foodCost, uint stoneCost, uint villagerCost,
            Map context, string name, string desc)
            : base(posX, posY, 200, 200, 20, 1, 10, 0, 20, 0, context,"Wall", "test")
        {

        }
    }
}
