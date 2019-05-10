using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    class Villager : Unit
    {
        uint _harvestCooldown = 3;


        public Villager(bool flying, float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed)
            : base(flying, posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed)
        {
        }

        public uint HarvestCd => _harvestCooldown;
    }
}
