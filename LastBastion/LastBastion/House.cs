using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class House : Building
    {
        public House(float posX, float posY, uint villager, uint rent, Map context)
            : base(posX, posY, 100, 100, 5, 1, 30, 50, 10, 0, context,"House", "Userfull increase your maximum \n population by 5 per rank.")
        {
        }

        public void IncPop()
        {
            Context.GetVillage.MaxVillager += 5;
            Context.GetVillage.Villager += 5;
        }

        override public void Upgrade()
        {
            Rank++;
            IncHealth();
            IncreaseArmor();
            IncPop();
            Console.WriteLine("Inc Pop House" + Rank);
        }

    }
}
