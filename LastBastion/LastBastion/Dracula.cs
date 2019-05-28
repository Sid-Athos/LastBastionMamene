using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Dracula : Unit
    {
        uint _spellCd = 3;
        bool _flying = true;
        uint _timeStamp;

        internal Dracula(
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

        }

        internal bool Flying => _flying;

        internal new Building Target
        {
            get { return base.EnemyTarget; }
            set { EnemyTarget = value; }
        }

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        internal override void Update()
        {
            AcquireTarget();
        }
        internal override void Attack(Unit unit)
        {
            if (Dmg > (unit.Life + unit.Armor))
            {
                unit.Life = 0;
                unit.Die();
                return;
            }
            
            unit.Life -= (Dmg - unit.Armor);
            Life += Dmg;
        }
    }
}
