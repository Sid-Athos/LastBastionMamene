using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class LavaWall : Wall
    {
        uint _rank = 1;
        uint _dmg = 10;
        uint _aaCooldown = 2;
        float _range = 1.0f;
        int _lastAttack;

        internal LavaWall(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
            : base(posX, posY, 200, 200, 0, 1, 20, 0f, 40, context, "LavaWall", "test") { }

        internal LavaWall(float posX, float posY, uint dmg, float range, uint aaCooldown, Map context)
            : base(posX, posY, 200, 200, 20, 1, 10, 0, 30, 0, context)
        {
            _lastAttack = Context.GetGame.GetTimer;
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _range = range;
            Name = "Lava Wall";
            Description = "Better wall and useful for \n showering enemies with lava.";
        }

        internal float Range => _range;
        internal uint Dmg => _dmg;
        internal uint Cooldown => _aaCooldown;
        
        internal void Attack(Unit unit)
        {
            if (unit.Position.IsInRange(unit.Position,unit.Target.Position,Range))
            {
                if(unit.Life < (Dmg - unit.Armor))
                {
                    unit.Die();
                }
                else
                {
                    unit.Life -= (Dmg - unit.Armor);
                }
            }
        }

        internal override void Update()
        {
            if (Context.GetTimer != _lastAttack && Context.GetTimer % Cooldown == 0)
            {
                foreach(var unit in Context.BarList)
                {
                    Attack(unit);
                    if(unit.Life < (Dmg - unit.Armor))
                    {
                        unit.Die();
                    }
                }
            }
        }


    }
}
