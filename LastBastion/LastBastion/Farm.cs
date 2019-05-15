using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Farm : Building
    {
        uint _rank = 1;

        public Farm (float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank)
            : base(posX, posY, lifePoints,maxLifePoints, armor, rank)
        {
        }

        public void Upgrade ()
        {
            if(_rank < 3)
            {
                _rank++;
                IncHealth();
                IncreaseArmor();
            }

        }
    }
}