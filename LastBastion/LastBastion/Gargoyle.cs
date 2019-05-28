using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Gargoyle : Unit
    {
        bool _flying = true;
        uint _timeStamp;

        public Gargoyle(
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

        internal Gargoyle(
            uint life)
            : base(life)
        {

        }

        public bool Flying => _flying;

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

        public override void Update()
        {
            AcquireTarget();
        }
    }
}
