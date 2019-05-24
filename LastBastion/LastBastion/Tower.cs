using System;
using System.Collections.Generic;

namespace LastBastion
{
    public class Tower : Building
    {
        
        Archer [] _slots;
        uint _rank;
        uint _dmg;
        uint _aaCooldown;
        float _range = 2.0f;
        Unit _target;
        List<Projectiles> _proj;

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
         1,
         10, 0, 60, 2,
         context,"Tower", "test")
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
        uint aaCooldown)
            : base(posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         1)
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

        public Unit Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public float Range => _range;

        public int AvailableSlots => _slots.Length;

        public Archer[] Slots => _slots;

        internal List<Projectiles> ProList => _proj;

        public uint Dmg => _dmg;

        internal void AddProjectile(Projectiles p)
        {
            _proj.Add(p);
        }

        public void Attack(Unit unit)
        {
            for(int i = 0; i < _slots.Length;i++)
            {
                _slots[i].Attack();
            }

            Projectiles p = new Projectiles(Position, unit);

            foreach(var n in ProList)
            {
                if(p.Position.IsInRange(p.Position,p.Target.Position,0.3f))
                {
                    p.Target.Attacked(0);
                    if (_dmg > unit.Life)
                    {
                        p.Target.Attacked(0);
                        p.Target.Die();
                        AcquireTarget();
                        SetAllTowerUnitsTarget();
                        return;
                    }
                    p.Target.Attacked(Math.Max(p.Target.Life- (_dmg - p.Target.Armor), 0));
                }
                else
                {
                    p.Position = p.Position.Movement(p.Position, p.Target.Position, 1, 0.002f, 0.5f);
                }
            }
        }

        public void IncDamage()
        {
            _dmg *= 2;
        }


        public new void Upgrade()
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
            List<Unit> barbList = context.BarList;

            if (context.BarbCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Unit unitToReturn;
            barbList = Shuffle.Barbars(barbList);

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
            List<Unit> barbList = context.BarList;

            if (context.BarbCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Unit unitToReturn;

            barbList = Shuffle.Barbars(barbList);

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
            Target = (Target.Life == 0) ? null : Target;

            if(Target == null)
            {
                AcquireTarget();
            }

            if(Target.Position.IsInRange(Target.Position,Position,Range))
            {
                Attack(Target);
            }
        }
    }
}