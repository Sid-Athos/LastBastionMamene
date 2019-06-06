using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class House : Building
    {
        public House(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
            : base(posX, posY, 200, 200, 20, 1, 20, 0f, 0, context, "House", "test")
        { }

        public House(float posX, float posY, uint villager, uint rent, Map context)
            : base(posX, posY, 100, 100, 5, 1, 30, 50, 10, 0, context,"House", "Userfull increase your maximum \n population by 5 per rank.")
        {
        }

        public void IncPop()
        {
            Context.GetVillage.MaxVillager += 5;
            Context.GetVillage.Villager += 5;
        }

        override internal void Upgrade()
        {
            Rank++;
            IncHealth();
            IncreaseArmor();
            IncPop();
        }
    }
}
