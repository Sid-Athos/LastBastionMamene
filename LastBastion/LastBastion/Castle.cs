using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Castle : Building
    {
        static uint _lifePoints;

        public Castle(float posX, float posY, uint lifePoints, uint maxLifePoints,
                      uint armor, uint rank, Map context, string name, string desc)
            : base(posX, posY, lifePoints, maxLifePoints, armor, rank, context,"Castle","Your Residence.")
        {
            _lifePoints = lifePoints;
        }
    }
}
