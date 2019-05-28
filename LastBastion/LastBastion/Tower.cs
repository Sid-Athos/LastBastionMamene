using SFML.System;
using System;
using System.Collections.Generic;

namespace LastBastion
{
    public class Tower : Building
    {

        Archer[] _slots;
        uint _rank;
        uint _dmg;
        uint _aaCooldown;
        float _range = 26.0f;
        Unit _target;
        List<Projectiles> _proj;
        uint _timeStamp;
        bool _attacked = false;


        public Tower(float posX,
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
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _slots = new Archer[2];
            context.AddBuilding(this);
            for (int i = 0; i < 2; i++)
            {
                Archer sut = new Archer(posX, posY, 2.0f, "Archer", 50, 2, 1, false, 2, 2.3f, context);
                _slots[i] = sut;
                sut.SetTower(this);
            }
            _proj = new List<Projectiles>();
        }

        public Tower(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint dmg,
        uint armor,
        uint aaCooldown,
        Map context)
            : base(posX,
         posY,
         lifePoints,
         maxLifePoints,
         armor,
         5,
         context)
        {
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _slots = new Archer[2];
            for (int i = 0; i < 2; i++)
            {
                Archer sut = new Archer(posX, posY, 2.0f, "Archer", 80, Dmg, 1, false, 2, 0.002f, true);
                _slots[i] = sut;
                sut.SetTower(this);
            }
            _proj = new List<Projectiles>();

        }

        internal uint AaCd => _aaCooldown;

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

        internal List<Projectiles> ProjList => _proj;

        public override Unit Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public float Range => _range;

        public int AvailableSlots => _slots.Length;

        internal Archer[] Slots => _slots;

        public uint Dmg => _dmg;

        internal void AddProjectile(Projectiles p)
        {
            _proj.Add(p);
        }

        public void Attack(Unit unit)
        {
            if(unit.Life == 0)
            {
                SwitchTarget(base.Context.BarList);
            }
            if(Target != null)
            {
                uint newTs = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (_timeStamp == 0 && Attacked == false)
                {
                    for (int i = 0; i < _slots.Length; i++)
                    {
                        _slots[i].Attack();
                    }
                    Projectiles p = new Projectiles(Position, unit,this);
                    _proj.Add(p);
                    TimeSt = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    Attacked = true;
                }
                if (newTs < (_timeStamp + AaCd) && newTs > _timeStamp)
                {
                    Attacked = false;
                }
                else if (newTs == _timeStamp + AaCd && Attacked == false)
                {
                    for (int i = 0; i < _slots.Length; i++)
                    {
                        _slots[i].Attack();
                    }
                    Projectiles p = new Projectiles(Position, unit,this);
                    Console.WriteLine("Proj 153 " + ProjList.Count);
                    _proj.Add(p);
                    Attacked = true;
                }
                if(newTs > TimeSt+ AaCd)
                {
                    TimeSt = 0;
                    Attacked = !Attacked;
                }
            }
            if(ProjList.Count > 0)
            {
                try
                {
                    foreach (var n in ProjList)
                    {

                        n.Update();
                    }

                }
                catch(InvalidOperationException)
                {

                }

            }
        }

        internal bool Attacked
        {
            get { return _attacked; }
            set { _attacked = value; }
        }

        public uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
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

        internal void AddArcher(Archer u)
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
                return;
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
                    return;
                }
            }
        }
        
        internal void SwitchTarget(List<Unit> s)
        {
            Map context = base.Context;
            List<Unit> barbList = context.BarList;

            if (context.BarbCount == 0)
            {
                return;
            }

            Unit unitToReturn;

            barbList = Shuffle.Barbars(barbList);

            foreach (var n in barbList)
            {
                if(!s.Contains(n))
                    if (Position.IsInRange(Position, n.Position, Range))
                    {
                        unitToReturn = n;
                        Target = unitToReturn;
                        SetAllTowerUnitsTarget();
                        //SetAllProjUnitsTarget();
                        return;
                    }
            }
            unitToReturn = null;
            Target = unitToReturn;
            SetAllTowerUnitsTarget();
        }

        internal override void Update()
        {
            Context.GetGame.Sprites.GetSprite("Tower").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Tower"));
            if(base.Life == 0)
            {
                Die();
                Context.GetGame.GetGrid[new Vector2i((((int)Position.X - 375)/ 15), ((int)Position.Y - 375) / 15)].SetName = "Empty";
                Context.GetGame.GetGrid[new Vector2i((((int)Position.X - 375) / 15), ((int)Position.Y - 375) / 15)].Building = null;
                return;
            }

            if(Target == null)
            {
                if(Context.BarbCount > 0)
                {
                    AcquireTarget();

                }
                return;
            }

            if(!Target.Position.IsInRange(Target.Position, Position, Range))
            {
                Target = null;
                AcquireTarget();
                if(Target == null)
                {
                    return;
                }
            }
            if(base.Position.IsInRange(Position, Target.Position,Range))
            {
                Attack(Target);

                Target = (Target.Life == 0) ? null : Target;
                AcquireTarget();
            }
        }
    }
}