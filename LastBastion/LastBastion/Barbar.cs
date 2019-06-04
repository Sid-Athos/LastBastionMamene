using System;
using System.Collections.Generic;
using SFML.System;



namespace LastBastion
{
    public class Barbar : Unit
    {
        static uint _count;
        Building _target = null;

        public Barbar(float posX, float posY,string name, Map context)
            : base(posX, posY,name,  context)
        {
            _count++;
            context.AddBarbar(this);
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

        internal override void Attack(Unit unit)
        {
            if (unit.Job != "Gargoyle")

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
            if (Life == 0 || Life > 2000)
            {
                Die();
                return;
            }
            AaCd.Update();
            Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
            if (!IsParalysed)
            {
                
                if (EnemyTarget == null && Context.BuildCount >= 1)
                {
                    AcquireTarget();
                    bool tr = Position.IsInRange(Position, EnemyTarget.Position, Range);
                }

                if (EnemyTarget.Life == 0 || EnemyTarget.Life > 2000)
                {
                    AcquireTarget();
                }

                if (EnemyTarget != null && Position.IsInRange(Position, EnemyTarget.Position, Range))
                {
                    if(AaCd.IsUsable)
                    {
                        Attack(EnemyTarget);
                        return;
                    }
                    return;
                }

                

                if (EnemyTarget != null && !Position.IsInRange(Position, EnemyTarget.Position,Range))
                {
                    Position = Position.Movement(Position, EnemyTarget.Position, 1, Speed, Range);
                }
                
            }
        }

        internal Building BarbTarget
        {
            get { return _target; }
            set { _target = value; }
        }
    }
}
