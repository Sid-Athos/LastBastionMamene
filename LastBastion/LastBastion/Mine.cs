using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Mine : Building
    {
        uint _stoneProduction;
        uint _rank = 1;

        public Mine(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank, uint stoneProduction)
            : base(posX, posY, lifePoints, maxLifePoints, armor, rank)
        {
            _stoneProduction = stoneProduction;
        }

        public uint Rank => _rank;

        public void Upgrade()
        {
            if(_rank < 3)
            {
                _rank++;
                IncStoneProd();
                IncHealth();
                IncreaseArmor();
            }
        }

        public void IncStoneProd()
        {
            _stoneProduction += 2;
        }

        public uint StoneProduction
        {
            get { return _stoneProduction; }
            set { _stoneProduction = value; }
        }
    }
}