using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Wall : Building
    {
        uint _rank = 1;

        internal Wall(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
            : base(posX, posY, lifePoints, maxLifePoints, armor, rank, dmg, 0f, 0, context,"Wall", "test") { }
        internal Wall(float posX, float posY,
                      uint lifePoints, uint maxLifePoints,
                      uint armor, uint rank,
                      uint woodCost, uint foodCost, uint stoneCost, uint villagerCost,
                      Map context)
            : base(posX, posY, 200, 200, 20, 1, 10, 0, stoneCost, 0, context,"Wall", "Protect the kingdom from \n incessant waves of enemies")
        {

        }
    }
}
