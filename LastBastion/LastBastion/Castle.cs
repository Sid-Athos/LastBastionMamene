using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Castle : Building
    {
        static uint _lifePoints;
        uint _dmg;
        float _range;
        static uint _aCooldown;
        Unit _target;
        List<Projectiles> _proj;

        public Castle(float posX, float posY, uint lifePoints, uint maxLifePoints,
                      uint armor, uint rank, Map context, string name, string desc,
                      uint dmg, float range, uint aCooldown)
            : base(posX, posY, lifePoints, maxLifePoints, armor, rank, context,"Castle","Your Residence.")
        {
            _lifePoints = lifePoints;
            _dmg = dmg;
            _range = range;
            _aCooldown = aCooldown;
        }

        public Unit Target
        {
            get { return _target; }
            set { _target = value; }
        }
        internal List<Projectiles> ProList => _proj;
        public float Range => _range;

        new public bool IsDestroy()
        {
            if (Life <= 0)
            {
                if (Name == "Castle")
                {
                    //EndGame(); A ajouter quand le EndGame sera fait
                }
                return true;
            }
            return false;
        }

        public void Attack(Unit unit)
        {
            Projectiles p = new Projectiles(Position, unit);

            foreach (var n in ProList)
            {
                if (p.Position.IsInRange(p.Position, p.Target.Position, 3.0f))
                {
                    p.Target.Attacked(0);
                    if (_dmg > unit.Life)
                    {
                        p.Target.Attacked(0);
                        p.Target.Die();

                        //------------------------------
                        Map context = base.Context;
                        List<Barbar> barbList = context.BarList;

                        if (context.BarbCount == 0)
                        {
                            throw new InvalidOperationException("Aucune unité n'est disponible!");
                        }

                        Barbar unitToReturn;
                        barbList = Shuffle.Barbars(barbList);

                        foreach (var u in barbList)
                        {
                            if (Position.IsInRange(Position, n.Position, Range))
                            {
                                unitToReturn = u;
                                _target = unitToReturn;
                                //SetAllTowerUnitsTarget();
                                break;
                            }
                        }
                        //-------------------------------

                        //SetAllTowerUnitsTarget();

                        return;
                    }
                    p.Target.Attacked(Math.Max(p.Target.Life - (_dmg - p.Target.Armor), 0));
                }
                else
                {
                    p.Position = p.Position.Movement(p.Position, p.Target.Position, 1, 0.002f, 0.5f);
                }
            }
        }
    }
}
