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
        Spell _howl;

        public Gargoyle(
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

        public Gargoyle(
            uint life)
            : base(life)
        {

        }

        public bool Flying => _flying;

        public new Building Target
        {
            get { return base.EnemyTarget; }
            set { EnemyTarget = value; }
        }

        public uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public override void Update()
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