using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Tower : Building
    {
        
        Archer [] _slots;
        uint _rank = 1;
        uint _dmg;
        uint _aaCooldown;
        float _range = 0.3f;
        Unit _target;

        public Tower(float posX,
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
         armor,
         rank,
         10, 0, 60, 2,
         context)
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _slots = new Archer[2];
            context.AddBuilding(this);
            for(int i = 0;i<2;i++)
            {
                Archer sut = new Archer(posX, posY, 2.0f, "Archer", 50, 5, 1, false, 2, 0.2f, context);
                AddArcher(sut);
                sut.SetTower(this);
            }
        }

        public Tower(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint aaCooldown,
        uint rank)
            : base(posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         rank)
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _slots = new Archer[2];
            for (int i = 0; i < 2; i++)
            {
                Archer sut = new Archer(posX, posY, 2.0f, "Archer", 50, 5, 1, false, 2, 0.2f,false);
                AddArcher(sut);
                sut.SetTower(this);
            }
        }

        public void SetAllTowerUnitsTarget()
        {
            if (_slots[0] != null)
            {
                for (int i = 0; i < _slots.Length; i++)
                {
                    _slots[i].SetTarget(Target);
                }
            }
        }

        public Unit Target => _target;

        public float Range => _range;

        public int AvailableSlots => _slots.Length;

        public Archer[] Slots => _slots;


        public uint Dmg => _dmg;

        public void Attack(Unit unit)
        {
            if (_dmg > unit.Life)
            {
                unit.Attacked(0);
                unit.Die();
                _target = null;
                AcquireTarget();
                SetAllTowerUnitsTarget();
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

                int compteur = 0;
                Archer[] newSlots = new Archer[_slots.Length * 2];
                for (int i = 0; i < _slots.Length; i++)
                {
                    newSlots[i] = _slots[i];
                    compteur++;
                }
                IncreaseArmor();
                IncDamage();
                IncHealth();
                _slots = newSlots;
                for (int i = compteur; i < newSlots.Length;i++)
                {
                    Archer sut = new Archer(this.Position.X, this.Position.Y, 2.0f, "Archer", 50, 5, 1, false, 2, 0.2f, Context);
                    AddArcher(sut);
                    sut.SetTower(this);
                }
            }
        }

        public void AddArcher(Archer u)
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

        public void AcquireTarget()
        {
            Map context = base.Context;
            List<Barbar> barbList = context.BarList;

            if (context.BarbCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Barbar unitToReturn;

            foreach (var n in barbList)
            {
                if (Position.IsInRange(Position,n.Position,Range))
                {
                    unitToReturn = n;
                    _target = unitToReturn;
                    SetAllTowerUnitsTarget();
                    break;
                }
            }
        }

        internal void SwitchTarget(List<Unit> s)
        {
            Map context = base.Context;
            List<Barbar> barbList = context.BarList;

            if (context.BarbCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Barbar unitToReturn;

            foreach (var n in barbList)
            {
                if(!s.Contains(n))
                {
                    if (Position.IsInRange(Position, n.Position, Range))
                    {
                        unitToReturn = n;
                        _target = unitToReturn;
                        SetAllTowerUnitsTarget();
                        break;
                    }
                }
            }
        }

        internal void Update()
        {

        }
    }
}