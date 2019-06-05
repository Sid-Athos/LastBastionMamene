using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class LavaWall : Wall
    {
        uint _rank = 1;
        uint _dmg = 10;
        uint _aaCooldown = 2;
        float _range = 1.0f;
        int _lastAttack;

        public LavaWall(float posX, float posY, uint dmg, float range, uint aaCooldown, Map context)
            : base(posX, posY ,context)
        {
            _lastAttack = Context.GetGame.GetTimer;
            _dmg = dmg;
            _aaCooldown = aaCooldown;
            _range = range;
            Name = "Lava Wall";
            Description = "Better wall and useful for \n showering enemies with lava.";
        }

        public float Range => _range;
        public uint Dmg => _dmg;
        public uint Cooldown => _aaCooldown;
        
        public void Attack(Unit unit)
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

        public void Update()
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
