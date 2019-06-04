using SFML.System;
using System;
using System.Collections.Generic;

namespace LastBastion
{
    internal class Mage : Unit
    {
        List<Building> _burned;
        uint _timeStamp;
        Spell _ignite;
        
        internal Mage(
            float posX, float posY, string name, Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
            _ignite = new Spell
                (
                "Ignite", 
                this, 
                base.Context.Vill.Spells
                );
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
            AaCd.Update();
            if (Life == 0 || Life > Convert.ToUInt16(Context.Vill.Beasts.Beasts.["Mage"]["Vie"]))
            {
                Die();
                return;
            }
            Context.GetGame.Sprites.GetSprite("Mage").Position = new Vector2f(Position.X, Position.Y);
            Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Mage"));
            if(EnemyTarget == null)
            {
                AcquireTarget();
            }
            if(AaCd.IsUsable)
            {
                Attack(EnemyTarget);
            }
        }
    }
}
