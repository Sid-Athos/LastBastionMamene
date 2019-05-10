using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    class Barbar : Unit
    {
        static uint _count;

        public Barbar(bool flying, float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed)
            : base(flying, posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed)
        {
            _count++;
        }


        /**public void Move(double x, double Y)
        {
            _isMoving = !isMoving;
        }*/
    }
}
