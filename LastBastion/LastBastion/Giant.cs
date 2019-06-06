using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    internal class Giant : Unit
    {
        uint _timeStamp;
        Spell _smash;

        internal Giant(
            float posX,
            float posY,
            string name,
            Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
            _smash = new Spell(
                "Smash",
                this,
                base.Context.Sb);
        }

        internal Giant(
            uint life)
            : base(life)
        {

        }

        internal override void Attack(Unit u)
        {
            foreach (var n in base.Context.BarList)
            {
                if (Position.IsInRange(Position, n.Position, 7.5f))
                {
                    n.Life -= (Dmg - n.Armor);
                }
            }
        }

        internal override void Attack(Building u)
        {
            foreach (var n in base.Context.BarList)
            {
                if (Position.IsInRange(Position, n.Position, 7.5f))
                {
                    n.Life -= (Dmg - n.Armor);
                }
            }
        }

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
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

                if (EnemyTarget == null)
                {
                    return;
                }
                if (EnemyTarget.Life == 0 || EnemyTarget.Life > 2000)
                {
                    AcquireTarget();
                }

                if (EnemyTarget != null && Position.IsInRange(Position, EnemyTarget.Position, Range))
                {
                    if (AaCd.IsUsable)
                    {
                        Attack(EnemyTarget);
                        AaCd.SetTs();
                    }
                }

                if(_smash.CD.IsUsable && Position.IsInRange(Position,EnemyTarget.Position,_smash.Range))
                {
                    _smash.Update(this);
                }

                if (EnemyTarget != null && !Position.IsInRange(Position, EnemyTarget.Position, Range))
                {
                    Position = Position.Movement(Position, EnemyTarget.Position, 1, Speed, Range);
                }
            }
        }
    }
}