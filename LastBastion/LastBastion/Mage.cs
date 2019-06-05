using SFML.System;
using System;
using System.Collections.Generic;

namespace LastBastion
{
    public class Mage : Unit
    {
        List<Building> _burned;
        uint _timeStamp;
        Spell _ignite;

        public Mage(
            float posX, float posY, string name, Map context)
            : base(posX, posY, name, context)
        {
            context.AddBarbar(this);
            _ignite = new Spell
                (
                "Ignite",
                this,
                base.Context.GetVillage.Spells
                );
        }

        public List<Building> BurList => _burned;

        public Mage(
            uint life
            )
            : base(
            life
            )
        {

        }

        public Spell Ignite => _ignite;

        public new void Die()
        {
            Context.RemoveBarbar(this);
        }

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
            AaCd.Update();

            if (Life == 0 || Life > Convert.ToUInt16(Context.GetVillage.Beasts.Beasts["Mage"]["Vie"]))
            {
                Die();
                return;
            }
            //Context.GetGame.Sprites.GetSprite("Mage").Position = new Vector2f(Position.X, Position.Y);
            //Context.GetGame.GetWindow.Render.Draw(Context.GetGame.Sprites.GetSprite("Mage"));
            if (EnemyTarget == null)
            {
                AcquireTarget();
            }
            if (AaCd.IsUsable && EnemyTarget.Position.IsInRange(this.Position,EnemyTarget.Position,base.Range))
            {
                Attack(EnemyTarget);
            }
            if(EnemyTarget.IsBurned)
            {
                SwitchTarget(Ignite.DotBuildList);
            }
            Ignite.Update(this);
        }

        public List<Building> BurnList => _burned;

        public override void Attack(Unit unit)
        {

        }

        public override void Attack(Building unit)
        {

            if (Dmg > (unit.Life + unit.Armor))
                {
                    unit.Life = 0;
                    unit.Die();
                    return;
                }
            unit.Life -= (Dmg - unit.Armor);
            AaCd.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}