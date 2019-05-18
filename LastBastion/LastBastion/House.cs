﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class House : Building
    {
        uint _population = 5;
        uint _rank = 1;

        public House(float posX,float posY,uint lifePoints,uint maxLifePoints, uint armor, uint rank, uint population, Map context)
            :base(posX,posY,lifePoints,maxLifePoints, armor,rank,context)
        {
            _population = population;
        }

        public uint Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public void Upgrade()
        {
            if(_rank < 3)
            {
                _rank++;
                IncPop();
                IncreaseArmor();
                IncHealth();
            }
        }

        public void IncPop()
        {
            _population += 2;
        }

    }
}
