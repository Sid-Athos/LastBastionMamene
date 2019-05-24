namespace LastBastion
{
    internal class Boulders : Projectiles
    {
        Vectors _destination;
        Unit _focus;
        float _distance;

        internal Boulders(Vectors o, Unit d,Tower c)
            :base(o, d,c)
        {
            _focus = d;
            _destination = new Vectors(d.Position.X,d.Position.Y);
        }

        Vectors Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        float Distance => Distance;

        uint BoulderSize ()
        {
            for(float i = 0.2f; i < Distance; i += 0.4f)
            {

            }
            return 3;
        }

        internal new void Update()
        {
            if (!base.Position.IsInRange(Position, Destination, 0.5f))
            {
                Position.Movement(Position, Destination, 1, Speed, 0.5f);
            }
            else
            {
                foreach(var n in base.Context.Context.BarList)
                {
                    if(Destination.IsInRange(Destination,n.Position,2.0f))
                    {
                        Target.Attacked(0);
                    }
                }
            }
        }
    }
}
