﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion.Model
{
    public class Forge : Building
    {
        uint _rank = 1;

        public Forge(float posX, float posY, uint lifePoints, uint armor, uint rank)
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

        public void IncUnitArmor()
        {
            
        }

        public void IncUnitDmg()
        {

        }

    }
}
