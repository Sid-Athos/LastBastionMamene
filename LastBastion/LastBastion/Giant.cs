using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Giant : Unit
    {
        uint _timeStamp;
        Spell _smash;

        public Giant(
            float posX,
            float posY,
            string name,
            Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
            _smash = new Spell(
                "Smash",
                this,
                base.Context.Sb);
        }

        internal Giant(
            uint life)
            : base(life)
        {

        }

        public override void Attack(Unit u)
        {
            foreach (var n in base.Context.BarList)
            {
                if (Position.IsInRange(Position, n.Position, 7.5f))
                {
                    n.Life -= (Dmg - n.Armor);
                }
            }
        }

        public override void Attack(Building u)
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

        public override void Update()
        {
            if (EnemyTarget == null)
            {
                AcquireTarget();
                return;
            }
            if (Position.IsInRange(Position, EnemyTarget.Position, Range))
            {
                Attack(EnemyTarget);
            }
        }
    }
}