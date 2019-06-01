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
        uint _dotFrequency;
        float _range;

        public Spell(string name, Unit con,SpellBook spells)
        {
            _name = name;
            _cd = new Cooldown(cdVal);
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _unitContext = con;
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _range = (float)Convert.ToDouble(spells.SpellList[name]["Range"]);
        }

        public Spell(string name, Building con, SpellBook spells)
        {
            _buildingContext = con;
            _cd = new Cooldown(cdVal);
            _name = name;
            _description = spells.SpellList[name]["Description"];
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["CastTime"]);
            _dotFrequency = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _range = (float)Convert.ToDouble(spells.SpellList[name]["Range"]);

        }

        public Spell(string name, uint dmg, uint cdVal, uint castTime, Building con,SpellBook spells)
        {
            _name = name;
            _cd = new Cooldown(cdVal);
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _buildingContext = con;
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _dotFrequency = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
        }

        public Spell(string name, string desc, uint dmg, uint cdVal, uint castTime, Unit con, string type, uint dotRate,SpellBook spells)
        {
            _name = name;
            _description = desc;
            _cd = new Cooldown(cdVal);
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _unitContext = con;
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _dotFrequency = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
        }

        public bool Casted
        {
            get { return _casted; }
            set { _casted = value; }
        }

        public Cooldown CD => _cd;

        public uint CastTime => _castingTime;

        public void Cast(Unit u)
        {
            if(CD.IsUsable && !Casted)
            {
                Casted = !Casted;
                CD.TimeStamp =(uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }
            else if(CD.IsUsable && Casted)
            {

            }
            else if(!CD.IsUsable && Casted)
            {
                CD.TimeStamp = 0;
                Casted = !Casted;
            }
        }

        public void Cast(Building b)
        {
            if (CD.IsUsable)
            {

            }
        }

        public void CastDot(Unit u)
        {
            if (CD.IsUsable && !Casted)
            {
                Casted = !Casted;
                CD.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }
            else if (CD.IsUsable && Casted)
            {

            }
            else if (!CD.IsUsable && Casted)
            {
                CD.TimeStamp = 0;
                Casted = !Casted;
            }
        }

        public void CastDot(Building b)
        {
            if (CD.IsUsable)
            {

            }
        }
    }
}
