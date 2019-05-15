using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Villager : Unit
    {
        uint _harvestCooldown = 3;
        bool _isHarvesting;
        Tower _context;
            
        public Villager(float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _isHarvesting = false;
        }

        public void SetTower(Tower u)
        {
            _context = u;
        }

        public Tower ShowTower => _context;

        public uint HarvestCd => _harvestCooldown;
        
        public void Harvest()
        {
            _isHarvesting = ! _isHarvesting;
        }
    }
}
