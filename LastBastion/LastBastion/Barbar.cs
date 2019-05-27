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

        public new void Die()
        {
            Context.RemoveBarbar(this);
        }

        public override void Attack(Building unit)
        {

            if (Dmg > (unit.Life + unit.Armor))
            {
                unit.Life = 0;
                unit.Die();
                return;
            }
            unit.Life -= (Dmg - unit.Armor);
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
        }

        public override void Update()
        {
            if (Life == 0)
            {
                Die();
                return;
            }
            //Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);
            //Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
            if (!IsParalysed)
            {
                
                if (EnemyTarget == null && Context.BuildCount >= 1)
                {
                    AcquireTarget();
                    bool tr = Position.IsInRange(Position, EnemyTarget.Position, Range);
                }

                if (EnemyTarget.Life == 0)
                {
                    AcquireTarget();
                }

                if (EnemyTarget != null && Position.IsInRange(Position, EnemyTarget.Position, Range))
                {
                    if(_timeStamp == 0)
                    {
                        Attack(EnemyTarget);
                        TimeSt = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        return;
                    }
                    uint newTs = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    if (newTs == _timeStamp + AaCd)
                    {
                        Attack(EnemyTarget);
                        TimeSt = newTs;
                    }
                    return;
                }

                

                if (EnemyTarget != null && !Position.IsInRange(Position, EnemyTarget.Position,Range))
                {
                    Position = Position.Movement(Position, EnemyTarget.Position, 1, Speed, Range);
                }
                
            }
        }

        public Building BarbTarget
        {
            get { return _target; }
            set { _target = value; }
        }

        public uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value;}
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
