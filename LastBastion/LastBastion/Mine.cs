using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Mine : Building
    {
        uint _rank = 1;

        public Mine(float posX, float posY, Map context)
            : base(posX, posY, 100, 100, 5, 1, 40, 0, 20, 2, context,"Mine", "test")
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