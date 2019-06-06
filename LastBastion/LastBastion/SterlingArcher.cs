using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Archer : Unit
    {
        static uint _count;
        Tower _context;
        bool _inTower;

        public Archer(float posX, float posY, string name, Map context)
            : base(posX, posY, name, context)
        {
            _count++;
            //context.AddArcher(this);
            _inTower = true;
        }

        internal Tower TowCont => _context;

        internal void SetTower(Tower t)
        {
            _context = t;
        }

        internal void Attack()
        {
            Projectiles p = new Projectiles(Position, Target,TowCont);
            TowCont.AddProjectile(p);
        }

        internal override void Update()
        {
            if(!_inTower)
            {

            }
        }
    }

}
