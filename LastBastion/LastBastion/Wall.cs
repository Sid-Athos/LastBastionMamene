using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Wall : Building
    {
        uint _rank = 1;
        
        public Wall(float posX, float posY, uint lifePoints, uint armor,uint rank)
            : base(posX, posY, lifePoints, armor, rank)
        {

        }

        public uint Rank => _rank;

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
