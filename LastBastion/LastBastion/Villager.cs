using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Villager : Unit
    {
        uint _harvestCooldown = 3;
        bool _isHarvesting;


        public Villager(float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed)
            : base(posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed)
        {
            _isHarvesting = false;
        }

        public uint HarvestCd => _harvestCooldown;
        
        public void Harvest()
        {
            _isHarvesting = ! _isHarvesting;
        }
    }
}
