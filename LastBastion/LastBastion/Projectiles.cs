﻿using System;

namespace LastBastion
{
    internal class Projectiles
    {
        Vectors _position;
        Tower _tow;
        Unit _target;
        uint _dmg;
        readonly float _speed = 0.001f;
        
        internal Projectiles(Vectors o, Unit d, Tower c)
        {
            _position = o;
            _target = d;
            _tow = c;
            _dmg = c.Dmg;
        }

        internal Tower Context => _tow;

        internal uint Dmg => _dmg;

        internal Vectors Position
        {
            get { return _position; }
            set { _position = value; }
        }

        internal Unit Target
        {
            get { return _target; }
            set { _target = value; }
        }

        Vectors Destination => Target.Position;
        internal float Speed => _speed;

        internal void Update()
        {
            if(!Position.IsInRange(Position, Destination, 2.45f))
            {
                Position = Position.Movement(Position, Destination, 1, Speed, 0.5f);
            } else
            {
                Context.ProjList.Remove(this);                        
                if(Target.Life == 0)
                {
                    return;
                }
                Target.Life = ((Target.Life - (Dmg - Target.Armor) > 0) ? Target.Life - (Dmg - Target.Armor):0);
            }
        }
    }
}
