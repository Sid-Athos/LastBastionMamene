using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Mage : Unit
    {
        internal Mage(
            float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {

        }

        internal Mage(
            uint life
            )
            : base(
            life
            )
        {
            
        }
    }
}
