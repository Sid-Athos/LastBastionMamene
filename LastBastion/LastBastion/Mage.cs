using System.Collections.Generic;

namespace LastBastion
{
    public class Mage : Unit
    {
        List<Building> _burned;
        uint _timeStamp;
        float _spellRange = 28f;
        uint _spellCd = 5;
        
        public Mage(
            float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _burned = new List<Building>();
            context.AddBarbar(this);

        }

        public List<Building> BurList => _burned;

        internal Mage(
            uint life
            )
            : base(
            life
            )
        {
        }

        public void Ignite()
        {
            if(EnemyTarget != null)
            {
                if(EnemyTarget.IsBurned)
                {
                    base.SwitchTarget(BurList);
                    return;
                }
                Burn(EnemyTarget);
                BurList.Add(EnemyTarget);
            }
            base.SwitchTarget(BurList);
        }

        internal new void Die()
        {
            Context.RemoveBarbar(this);
        }

        public new Building Target
        {
            get { return base.EnemyTarget; }
            set { EnemyTarget = value; }
        }

        internal uint TimeSt
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public override void Update()
        {
            AcquireTarget();
        }
    }
}
