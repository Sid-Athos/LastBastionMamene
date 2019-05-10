using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Sawmill : Building
    {
        uint _woodProduction;
        uint _rank = 1;

        public Sawmill (float posX, float posY, uint lifePoints, uint armor, uint rank, uint woodProduction)
            : base(posX, posY, lifePoints, armor, rank)
        {
            _woodProduction = woodProduction;
        }

        public uint Rank => _rank;

        public void Upgrade()
        {
            if(_rank < 3)
            {
                _rank++;
                IncWoodProd();
                IncHealth();
                IncreaseArmor();
            }
        }

        public void IncWoodProd()
        {
            _woodProduction += 2;
        }

        public uint WoodProduction
        {
            get { return _woodProduction; }
            set { _woodProduction = value; }
        }
    }
}
