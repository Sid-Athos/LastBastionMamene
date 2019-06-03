using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    public class Gargoyle : Unit
    {
        bool _flying = true;
        uint _timeStamp;

        internal Gargoyle(
            float posX,
            float posY,
            string name,
            Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
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

        internal override void Update()
        {
            if (Life == 0)
            {
                Die();
                return;
            }
            Context.GetGame.Sprites.GetSprite("Gargoyle").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gargoyle"));
            if (EnemyTarget == null)
                AcquireTarget();
        }


    }
}