namespace LastBastion
{
    internal class Projectiles
    {
        Vectors _position;
        Archer _context;
        Unit _target;
        readonly float _speed = 0.001f;

        internal Projectiles(Vectors o,Unit d,Archer context)
        {
            _position = o;
            _target = d;
            _context = context;
            Context.Context.AddProjectile(this);
        }

        internal Projectiles(Vectors o, Unit d)
        {
            _position = o;
            _target = d;
            Context.Context.AddProjectile(this);
        }

        internal Unit Context => _context;
        internal Unit Target => _target;

        internal Vectors Position
        {
            get { return _position; }
            set { _position = value; }
        }

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
