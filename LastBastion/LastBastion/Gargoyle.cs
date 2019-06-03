﻿using System;
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
            float range,
            string job,
            uint lifePoints,
            uint dmg,
            uint armor,
            bool isMoving,
            uint attackCooldown,
            float speed,
            Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
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
            Context.GetGame.Sprites.GetSprite("Gobelin").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Gobelin"));
            if (EnemyTarget == null)
                AcquireTarget();
        }


    }
}