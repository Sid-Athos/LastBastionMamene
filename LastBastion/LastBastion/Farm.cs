using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Farm : Building
    {
        uint _foodProduction;
        uint _rank = 1;

        public Farm (float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank, uint foodProduction)
            : base(posX, posY, lifePoints,maxLifePoints, armor, rank)
        {
            _foodProduction = foodProduction;
        }

        public void IncFoodProd()
        {
            _foodProduction += 2;
        }

        public void Upgrade ()
        {
            if(_rank < 3)
            {
                _rank++;
                IncFoodProd();
                IncHealth();
                IncreaseArmor();
            }

        }

        public uint FoodProduction
        {
            get { return _foodProduction; }
            set { _foodProduction = value; }
        }
    }
}