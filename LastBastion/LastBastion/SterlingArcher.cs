using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Archer : Unit
    {
        static uint _count;
        Tower _context;

        public Archer(float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
            context.AddArcher(this);
        }

        public void SetTower(Tower t)
        {
            _context = t;
        }

    }
}
