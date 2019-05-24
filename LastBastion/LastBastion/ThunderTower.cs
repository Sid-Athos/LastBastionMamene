using System;
using System.Collections.Generic;

namespace LastBastion
{
    public class Thunder:Tower
    {
        List<Unit> _paralysedList;

        public Thunder(
        float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint rank,
        float range,
        uint aaCooldown,
        Map context,string name, string desc)
            : base(
         posX,
         posY,
         lifePoints,
         maxLifePoints,
         dmg,
         armor,
         rank,
         range,
         aaCooldown,
         context,name,desc)
        {
            _paralysedList = new List<Unit>();
        }

        List<Unit> ParList => _paralysedList;

        uint ParCount => (uint)_paralysedList.Count;
        
        internal void Paralyze()
        {
            if (!Target.IsParalysed)
            {
                Target.Paralize();
                ParList.Add(Target);
                base.SwitchTarget(ParList);
            }
            else
            {
                throw new InvalidCastException("La cible est déjà paralysée !");
            }
        }

        internal new void  Update()
        {
            if(ParCount > 0)
            {
                Predicate<Unit> deads = Preds.IsDead;
                ParList.RemoveAll(deads);
            }
        }
    }
}
