using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Thunder:Tower
    {
        public Thunder(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint aaCooldown,
        uint rank,
        Map context)
            : base(posX,
         posY,
         lifePoints,
         maxLifePoints,
         dmg,
         armor,
         aaCooldown,
         rank,
         context)
        {

        }

        public void Paralyze()
        {
            if (!Target.IsParalysed)
                Target.Paralize();
            else
                throw new InvalidCastException("La cible est déjà paralysée !");
        }
    }
}
