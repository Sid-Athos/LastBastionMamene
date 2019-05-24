using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Sawmill : Building
    {
        uint _rank = 1;

        public Sawmill(float posX, float posY, Map context)
            : base(posX, posY, 100, 100, 5, 1, 50, 0, 10, 2, context,"Sawmill", "test")
        {
        }

        public new void Upgrade()
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
