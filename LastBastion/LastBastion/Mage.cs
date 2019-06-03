using SFML.System;
using System.Collections.Generic;

namespace LastBastion
{
    internal class Mage : Unit
    {
        List<Building> _burned;
        uint _timeStamp;
        float _spellRange = 28f;
        uint _spellCd = 5;
        
        internal Mage(
            float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            context.AddBarbar(this);
        }

        internal List<Building> BurList => _burned;

        internal Mage(
            uint life
            )
            : base(
            life
            )
        {
            
        }

        internal void Ignite()
        {
            if (EnemyTarget != null)
                if (EnemyTarget.IsBurned)
                {
                    base.SwitchTarget(BurList);
                    return;
                }
                Burn(EnemyTarget);
                BurList.Add(EnemyTarget);
        }

        internal new void Die()
        {
            Context.RemoveBarbar(this);
        }

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
            Context.GetGame.Sprites.GetSprite("Mage").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Mage"));
            if(EnemyTarget == null)
            AcquireTarget();
        }
    }
}
