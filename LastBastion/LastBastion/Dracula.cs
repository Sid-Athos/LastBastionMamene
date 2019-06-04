using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Dracula : Unit
    {
        uint _spellCd = 3;
        bool _flying = true;
        uint _timeStamp;

        public Dracula(
            float posX,
            float posY,
           string name,
            Map context)
            : base(posX, posY, name, context)
        {

        }

        public bool Flying => _flying;

        public new Building Target
        {
            get { return base.EnemyTarget; }
            set { EnemyTarget = value; }
        }

        public uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public override void Update()
        {
            AcquireTarget();
        }
        public override void Attack(Unit unit)
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
