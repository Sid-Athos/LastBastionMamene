using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Mine : Building
    {
        uint _rank = 1;

        public Mine(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint rank,
        float range,
        uint aaCooldown,
        Map context, string name, string desc)
            : base(posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         rank,
         dmg,
         range,
         aaCooldown,
         context, "Mine", "test")
        {
        }
    }
}