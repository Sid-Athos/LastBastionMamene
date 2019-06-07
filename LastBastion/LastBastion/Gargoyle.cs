using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    internal class Gargoyle : Unit
    {
        bool _flying = true;
        uint _timeStamp;
        Spell _howl;

        internal Gargoyle(
            float posX,
            float posY,
            string name,
            Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
            _howl = new Spell(
                "Howl",
                this,
                base.Context.Sb);
        }

        internal Gargoyle(
            uint life)
            : base(life)
        {

        }

        internal bool Flying => _flying;

        internal new Building Target
        {
            get { return base.EnemyTarget; }
            set { EnemyTarget = value; }
        }

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
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

        internal override void Update()
        {
            if (Life == 0 || Life > 2000)
            {
                Die();
                return;
            }
            AaCd.Update();
            Context.GetGame.Sprites.GetSprite("Gargole").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gargole"));
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

                if (_howl.CD.IsUsable && Position.IsInRange(Position, EnemyTarget.Position, _howl.Range))
                {
                    _howl.Update(this);
                }

                if (EnemyTarget != null && !Position.IsInRange(Position, EnemyTarget.Position, Range))
                {
                    Position = Position.Movement(Position, EnemyTarget.Position, 1, Speed, Range);
                }
            }
        }

    }
}