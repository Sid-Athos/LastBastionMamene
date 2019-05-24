using System;
using System.Collections.Generic;
using SFML.System;



namespace LastBastion
{
    public class Barbar : Unit
    {
        static uint _count;
        uint _timeStamp;
        Building _target = null;

        public Barbar(float posX, float posY,float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY,range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
            context.AddBarbar(this);
        }

        public Barbar(float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed)
        {
            _count++;
        }

        public Barbar(uint life)
            : base(life)
        {
            _count++;
        }

        internal new void Die()
        {
            Context.RemoveBarbar(this);
        }

        internal override void Attack(Building unit)
        {

            if (Dmg > (unit.Life + unit.Armor))
            {
                unit.Life = 0;
                unit.Die();
                return;
            }
            unit.Life -= (Dmg - unit.Armor);
        }

        internal override void Update()
        {
            if (Life == 0)
            {
                Die();
                return;
            }
            Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
            if (!IsParalysed)
            {
                if (BarbTarget == null && Context.BuildCount >= 1)
                {
                    AcquireTarget();
                    bool tr = base.Position.IsInRange(Position, BarbTarget.Position, Range);
                }

                if (BarbTarget != null && Position.IsInRange(Position, BarbTarget.Position, Range))
                {
                    if(_timeStamp == 0)
                    {
                        Attack(BarbTarget);
                        TimeSt = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        return;
                    }
                    uint newTs = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    if (newTs == _timeStamp + AaCd)
                    {
                        Attack(BarbTarget);
                        TimeSt = newTs;
                    }
                    return;
                }


               if (BarbTarget != null && !Position.IsInRange(Position,BarbTarget.Position,Range))
                {
                    Position = Position.Movement(Position, BarbTarget.Position, 1, Speed, Range);
                }
            }
            
        }

        internal Building BarbTarget => _target;

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value;}
        }

        void AcquireTarget()
        {
            Map context = Context;
            List<Building> buildList = context.BuildList;

            if (context.BuildCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Building unitToReturn = buildList[0];
            float min = Position.Distance(Position, buildList[0].Position);
            foreach (var n in buildList)
            {
                if (Position.Distance(Position, n.Position) < min)
                {
                    unitToReturn = n;
                }
            }
            SetTarget(unitToReturn);
            _target = unitToReturn;
        }

        /**public Building AquireTarget()
        {
            Map context = base.Context;
            List<Building> buildings = Context.BuildList;

            foreach(var n in buildings)
            {

            }
            return;
        }*/
    }
}
