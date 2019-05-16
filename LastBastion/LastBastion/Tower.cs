using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Tower : Building
    {
        
        Villager [] _slots;
        uint _rank = 1;
        uint _dmg;
        uint _aaCooldown;
        

        public Tower(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint aaCooldown,
        uint rank)
            :base( posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         rank)
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _slots = new Villager[2];
        }

        public int AvailableSlots => _slots.Length;

        public uint Dmg => _dmg;

        public void Attack(Unit unit)
        {
            if (_dmg > unit.Life)
            {
                unit.Attacked(0);
                unit.Die();
                return;
            }
            unit.Attacked(Math.Max(unit.Life - (_dmg - unit.Armor), 0));
        }

        public void IncDamage()
        {
            _dmg *= 2;
        }


        public void Upgrade()
        {
            if (_rank < 3)
            {
                _rank++;
                Villager[] newSlots = new Villager[_slots.Length * 2];
                for (int i = 0; i < _slots.Length; i++)
                {
                    newSlots[i] = _slots[i];
                }

                IncreaseArmor();
                IncDamage();
                IncHealth();
                _slots = newSlots;
            }
        }

        public void AddArcher(Villager u)
        {
            if(!u.IsInTower)
            {
                if(ShowArchers() == _slots.Length)
                {
                    throw new InvalidOperationException("La tour est déjà remplie...");
                }
                _slots.SetValue(u,ShowArchers());
                u.JoinTower();
                u.SetTower(this);
            } else
            {
                throw new InvalidOperationException("This villager is already into a tower!");
            }
        }

        public uint ShowArchers()
        {
            uint compteur = 0;

            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i] != null )
                {
                    compteur++;
                }
            }

            return compteur;
        }
    }
}