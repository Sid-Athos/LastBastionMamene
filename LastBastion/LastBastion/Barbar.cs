using System;
using System.Collections.Generic;
using System.Text;
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



        public void Update()
        {
            if (Life == 0)
            {
                Die();
            }
            if(BarbTarget == null && Context.BuildCount >= 1)
            {
                AcquireTarget();
            }
            Console.WriteLine("Origine : [{0},{1}]", base.Position.X, base.Position.Y);

            if (BarbTarget != null && !Position.IsInRange(Position,BarbTarget.Position,Range))
            {
                Console.WriteLine("Cible du barbare : {0}", BarbTarget);
                Console.WriteLine("Origine : [{0},{1}]", BarbTarget.Position.X, BarbTarget.Position.Y);
                Position = Position.Movement(Position, BarbTarget.Position, 1, Speed, Range);
            }

            if(BarbTarget != null && Position.IsInRange(Position, BarbTarget.Position, Range))
            {
                Attack(BarbTarget);
            }
            Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);

            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
        }

        public Building BarbTarget => _target;

        public void AcquireTarget()
        {
            Map context = Context;
            List<Building> buildList = context.BuildList;

            if (context.BuildCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Building unitToReturn = buildList[0];
            float min = Position.Distance(Position, buildList[0].Position) ;
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
