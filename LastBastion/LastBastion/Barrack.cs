using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion.Model
{
    public class Barrack : Buildings
    {
        uint _rank = 1;

        public Barrack(float posX, float posY, uint lifePoints, uint armor, uint rank)
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

        public void UpgradeUnit()
        {

        }

    }
}