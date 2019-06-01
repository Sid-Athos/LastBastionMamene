using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Spell
    {
        readonly string _name;
        readonly string _description;
        Cooldown _cd;
        Unit _unitContext;
        Building _buildingContext;
        uint _damages;
        uint _castingTime;  // Incantation time
        uint _startCast;       // Timestamp when spell casting starts
        bool _casted = false;         // Spell was casted?

        public Spell(string name, string desc, uint dmg, uint cdVal, uint castTime,Unit con)
        {
            _name = name;
            _description = desc;
            _cd = new Cooldown(cdVal);
            _damages = dmg;
            _unitContext = con;
            _castingTime = castTime;
        }

        public Spell(string name, string desc, uint dmg, uint cdVal, uint castTime, Building con)
        {
            _name = name;
            _description = desc;
            _cd = new Cooldown(cdVal);
            _damages = dmg;
            _buildingContext = con;
            _castingTime = castTime;
        }

        public bool Casted
        {
            get { return _casted; }
            set { _casted = value; }
        }
        
        public uint CastTime => _castingTime;
    }
}
