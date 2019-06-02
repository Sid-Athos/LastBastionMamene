using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Giant : Unit
    {
        uint _timeStamp;

        public Giant(
            float posX,
            float posY,
            float range,
            string job,
            uint lifePoints,
            uint dmg,
            uint armor,
            bool isMoving,
            uint attackCooldown,
            float speed,
            Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            context.AddBarbar(this);
        }

        internal Giant(
            uint life)
            : base(life)
        {

        }

        internal override void Attack(Unit u)
        {
            foreach (var n in base.Context.BarList)
            {
                if (Position.IsInRange(Position, n.Position, 7.5f))
                {
                    n.Life -= (Dmg - n.Armor);
                }
            }
        }

        internal override void Attack(Building u)
        {
            foreach (var n in base.Context.BarList)
            {
                if (Position.IsInRange(Position, n.Position, 7.5f))
                {
                    n.Life -= (Dmg - n.Armor);
                }
            }
        }

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        internal override void Update()
        {
            if (EnemyTarget == null)
            {
                AcquireTarget();
            }
            if (Position.IsInRange(Position, EnemyTarget.Position, Range))
            {
                Attack(EnemyTarget);
            }
        }
    }
}