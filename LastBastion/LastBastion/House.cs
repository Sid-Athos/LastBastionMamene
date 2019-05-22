using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class House : Building
    {
        uint _villager = 5;
        uint _rent = 1;

        public House(float posX, float posY, uint villager, uint rent, Map context)
            : base(posX, posY, 100, 100, 5, 1, 30, 50, 10, 0, context)
        {
            _villager = villager;
            _rent = rent;
        }

        public uint Rent
        {
            get { return _rent; }
            set { _rent = value; }
        }

        public uint Villager
        {
            get { return _villager; }
            set { _villager = value; }
        }

        new public void Upgrade()
        {
            if (Rank < 3)
            {
                Rank++;
                IncPop();
                IncreaseArmor();
                IncHealth();
            }
        }

        public void IncPop()
        {
            _villager += 2;
        }

    }
}
