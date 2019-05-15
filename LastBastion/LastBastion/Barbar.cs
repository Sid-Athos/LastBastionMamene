using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Barbar : Unit
    {
        static uint _count;

        public Barbar(float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
        }       
    }
}
