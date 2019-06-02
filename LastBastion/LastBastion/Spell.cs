using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Spell
    {
        readonly string _name;
        readonly string _description;
        readonly Cooldown _cd;
        readonly Unit _unitContext;
        readonly Building _buildingContext;
        readonly uint _damages;
        readonly uint _duration;
        readonly uint _castingTime;  // Incantation time
        readonly uint _startCast;       // Timestamp when spell casting starts
        bool _casted = false;         // Spell was casted?
        readonly uint _dotFrequency;
        readonly float _range;
        uint _castTimeTS;
        Dictionary<Unit, Dictionary<uint, uint>> _dotUnit = new Dictionary<Unit, Dictionary<uint, uint>>();
        Dictionary<Building, Dictionary<uint, uint>> _dotBuild = new Dictionary<Building, Dictionary<uint, uint>>();



        internal Spell(string name, Building con, SpellBook spells)
        {
            _buildingContext = con;
            _cd = new Cooldown(Convert.ToUInt16(spells.SpellList[name]["Cooldown"]));
            _name = name;
            _description = spells.SpellList[name]["Description"];
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["CastTime"]);
            _dotFrequency = Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _range = (float)Convert.ToDouble(spells.SpellList[name]["Range"]);
            _duration = Convert.ToUInt16(spells.SpellList[name]["Durée"]);
        }

        internal bool Casted
        {
            get { return _casted; }
            set { _casted = value; }
        }

        internal Cooldown CD => _cd;

        internal uint Duration => _duration;

        internal Dictionary<Unit, Dictionary<uint, uint>> DotUnitList => _dotUnit;

        internal Dictionary<Building, Dictionary<uint, uint>> DotBuildList => _dotBuild;


        internal uint CastTime => _castingTime;

        internal void Cast(Unit u)
        {
            if (u != null)
                if (u.Life > 0)
                    if (CD.IsUsable && !Casted)
                    {
                        Casted = !Casted;
                        CD.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        if (CastTime == 0)
                        {
                            Dictionary<uint, uint> dotTarget = new Dictionary<uint, uint>();
                            dotTarget.Add((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, 0);
                            DotUnitList.Add(u, dotTarget);
                            Hit(u);
                        }
                        else
                        {
                            _castTimeTS = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        }
                    }
                    else if (CD.IsUsable && Casted)
                    {
                        if (_castTimeTS + CastTime == (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                        {
                            Dictionary<uint, uint> dotTarget = new Dictionary<uint, uint>();
                            dotTarget.Add((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, 0);
                            DotUnitList.Add(u, dotTarget);
                            Hit(u);
                            _castTimeTS = 0;
                        }
                    }
                    else if (!CD.IsUsable && Casted)
                    {
                        if (CD.TimeStamp + CD.Cd == (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                            CD.TimeStamp = 0;
                        Casted = !Casted;
                    }
        }

        internal void UpdateDots(Dictionary<Unit, Dictionary<uint, uint>> u)
        {
            if (u.Count > 0)
            {
                uint ts = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                foreach (var n in u)
                {
                    foreach (var b in n.Value)
                    {
                        if (b.Value == 0)
                        {
                            if (ts == b.Key + _dotFrequency)
                            {
                                Hit(n.Key);
                                u[n.Key][b.Value] = ts;
                            }
                        }
                        else
                        {
                            if (n.Key.Life > 0)
                            {
                                if (b.Value <= b.Value + Duration)
                                {
                                    if (ts == b.Key + _dotFrequency)
                                    {
                                        Hit(n.Key);
                                        u[n.Key][b.Value] = ts;
                                        DotUnitList.Remove(n.Key);
                                    }
                                }
                            }
                            else
                            {
                                DotUnitList.Remove(n.Key);
                            }
                        }
                    }
                }
            }
        }

        internal void UpdateDots(Dictionary<Building, Dictionary<uint, uint>> u)
        {
            if (u.Count > 0)
            {
                uint ts = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                foreach (var n in u)
                {
                    foreach (var b in n.Value)
                    {
                        if (b.Value == 0)
                        {
                            if (ts == b.Key + _dotFrequency)
                            {
                                Hit(n.Key);
                                u[n.Key][b.Value] = ts;
                            }
                        }
                        else
                        {
                            if (n.Key.Life > 0)
                            {
                                if (b.Value <= b.Value + Duration)
                                {
                                    if (ts == b.Key + _dotFrequency)
                                    {
                                        Hit(n.Key);
                                        u[n.Key][b.Value] = ts;
                                        DotBuildList.Remove(n.Key);
                                    }
                                }
                            }
                            else
                            {
                                DotBuildList.Remove(n.Key);
                            }
                        }
                    }
                }
            }
        }

        internal void Hit(Unit u)
        {
            u.Life -= _damages;
        }

        internal void Hit(Building u)
        {
            u.Life -= _damages;
        }

        internal void Cast(Building u)
        {
            if (u != null)
                if (u.Life > 0)
                    if (CD.IsUsable && !Casted)
                    {
                        Casted = !Casted;
                        CD.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        if (CastTime == 0)
                        {
                            Dictionary<uint, uint> dotTarget = new Dictionary<uint, uint>();
                            dotTarget.Add((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, 0);
                            DotBuildList.Add(u, dotTarget);
                            Hit(u);
                        }
                        else
                        {
                            _castTimeTS = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        }
                    }
                    else if (CD.IsUsable && Casted)
                    {
                        if (_castTimeTS + CastTime == (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                        {
                            Dictionary<uint, uint> dotTarget = new Dictionary<uint, uint>();
                            dotTarget.Add((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, 0);
                            DotBuildList.Add(u, dotTarget);
                            Hit(u);
                            _castTimeTS = 0;
                        }
                    }
                    else if (!CD.IsUsable && Casted)
                    {
                        if (CD.TimeStamp + CD.Cd == (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                            CD.TimeStamp = 0;
                        Casted = !Casted;
                    }
        }
    }
}