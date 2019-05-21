using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Projectiles
    {
        Vectors _position;
        Unit _context;
        Unit _target;
        readonly float _speed = 0.001f;

        public Projectiles(Vectors o,Unit d,Unit context)
        {
            _position = o;
            _target = d;
            _context = context;
        }

        public void Attack()
        {
            Target.Attacked(Target.Life - (Context.Dmg + Target.Armor));
        }

        Unit Context => _context;
        Unit Target => _target;

    }
}
