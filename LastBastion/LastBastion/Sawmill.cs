using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Sawmill : Building
    {
        public Sawmill(float posX,
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
         context, "Tower", "test")
        { }

        uint _rank = 1;

        public Sawmill(float posX, float posY, Map context)
            : base(posX, posY, 100, 100, 5, 1, 50, 0, 10, 2, context,"Sawmill", "Increase your wood recolt \n by 5 per rank.")
        {
        }
    }
}