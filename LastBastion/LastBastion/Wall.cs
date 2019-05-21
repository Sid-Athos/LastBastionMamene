using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Wall : Building
    {
        uint _rank = 1;

        public Wall(float posX, float posY, Map context)
            : base(posX, posY, 200, 200, 20, 1, 10, 0, 20, 0, context)
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
