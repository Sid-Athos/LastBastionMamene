using System;
using System.Collections.Generic;
using SFML.System;

namespace LastBastion
{
    public class Barbar : Unit
    {
        static uint _count;
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

        internal new void Update()
        {
            if (Life == 0)
            {
                Die();
                return;
            }

            if (BarbTarget != null && Position.IsInRange(Position, BarbTarget.Position, Range))
            {
                Attack(BarbTarget);
                return;
            }

            if(BarbTarget == null && Context.BuildCount >= 1) AcquireTarget();
            
            if (BarbTarget != null && !Position.IsInRange(Position,BarbTarget.Position,Range))
                Position = Position.Movement(Position, BarbTarget.Position, 1, Speed, Range);
            
            Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
        }

        internal Building BarbTarget => _target;

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
