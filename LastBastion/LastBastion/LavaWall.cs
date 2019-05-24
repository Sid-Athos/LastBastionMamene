using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class LavaWall : Wall
    {
        uint _rank = 1;
        uint _dmg;
        uint _aaCooldown;
        float _range = 1.0f;

        public LavaWall(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
            : base(posX, posY, 200, 200,0,1, 20, 0f, 40, context, "LavaWall", "test")
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _range = range;
        }
    }
}
