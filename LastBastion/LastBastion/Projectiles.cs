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
            context.Context.AddProjectile(this);
        }


        Unit Context => _context;
        Unit Target => _target;
        Vectors Position => _position;
        Vectors Destination => Target.Position;
        float Speed => _speed;

        public void Update()
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
            return;
        }
    }
}
