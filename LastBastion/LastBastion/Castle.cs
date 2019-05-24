using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Castle : Building
    {
        public Castle(
        float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint armor,
        uint rank,
        Map context)
            : base(
        posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         rank,
         10, 0, 60, 2,
         context,"Castle","Your Residence.")
        {
        }
    }
}
