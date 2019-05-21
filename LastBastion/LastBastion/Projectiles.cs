using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Projectiles
    {
        Vectors _position;
        Unit _context;
        Unit _target;
        readonly float _speed = 0.001f;

        internal Projectiles(Vectors o,Unit d,Unit context)
        {
            _position = o;
            _target = d;
            _context = context;
            context.Context.AddProjectile(this);
        }
        
        internal Unit Context => _context;
        internal Unit Target => _target;
        internal Vectors Position => _position;
        Vectors Destination => Target.Position;
        internal float Speed => _speed;

        internal void Update()
        {
            if (Target.Life > 0)
            {
                if(!Position.IsInRange(Position, Destination, 0.5f))
                {
                    Position.Movement(Position, Destination, 1, Speed, 0.5f);
                } else
                {
                    Target.Attacked(Context.Dmg);
                }
            }
        }
    }
}
