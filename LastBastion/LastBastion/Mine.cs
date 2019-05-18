using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Mine : Building
    {
        uint _rank = 1;

        public Mine(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank,Map context)
            : base(posX, posY, lifePoints, maxLifePoints, armor, rank, context)
        {
        }

        public void Upgrade()
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