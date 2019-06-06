using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly float _areaOfEffect;

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
            _dotFrequency = (uint)Convert.ToUInt16(spells.SpellList[name]["Durée"]) / Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _range = (float)Convert.ToDouble(spells.SpellList[name]["Range"]);
            _duration = Convert.ToUInt16(spells.SpellList[name]["Durée"]);
            _areaOfEffect = (float)Convert.ToDouble(spells.SpellList[name]["Zone d'effet"]);

        }

        internal Spell(string name, Unit con, SpellBook spells)
        {
            _unitContext = con;
            _cd = new Cooldown(Convert.ToUInt16(spells.SpellList[name]["Cooldown"]));
            _name = name;
            _description = spells.SpellList[name]["Description"];
            _damages = Convert.ToUInt16(spells.SpellList[name]["Dégâts"]);
            _castingTime = Convert.ToUInt16(spells.SpellList[name]["CastTime"]);
            _dotFrequency = (uint)Convert.ToUInt16(spells.SpellList[name]["Durée"]) / Convert.ToUInt16(spells.SpellList[name]["Fréquence"]);
            _range = (float)Convert.ToDouble(spells.SpellList[name]["Range"]);
            _duration = Convert.ToUInt16(spells.SpellList[name]["Durée"]);
            _areaOfEffect = (float)Convert.ToDouble(spells.SpellList[name]["Zone d'effet"]);
        }

        internal bool Casted
        {
            get { return _casted; }
            set { _casted = value; }
        }

        internal Cooldown CD => _cd;

        internal uint Duration => _duration;

        internal uint Frequency => _dotFrequency;

        internal float Range => _range;

        internal float AoERange => _areaOfEffect;

        internal uint Damages => _damages;


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
                foreach (var n in u.ToList())
                {
                    foreach (var b in n.Value.ToList())
                    {


                        if (b.Value == 0)
                        {
                            if (ts == b.Key + _dotFrequency)
                            {
                                Hit(n.Key);
                                u[n.Key][b.Key] = ts;
                            }
                        }
                        else
                        {
                            if (n.Key.Life > 0)
                            {
                                if (b.Value <= b.Key + Duration)
                                {

                                    if (ts == b.Value + _dotFrequency)
                                    {
                                        Hit(n.Key);
                                        u[n.Key][b.Key] = ts;
                                    }
                                }
                                else
                                {
                                    DotBuildList.Remove(n.Key);
                                    n.Key.IsBurned = !n.Key.IsBurned;
                                }
                            }
                            else
                            {
                                DotBuildList.Remove(n.Key);
                                n.Key.IsBurned = !n.Key.IsBurned;
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

                        if (CastTime == 0)
                        {
                            if (SpellName == "Ignite")
                            {
                                _unitContext.Life = 30;
                                Dictionary<uint, uint> dotTarget = new Dictionary<uint, uint>();
                                dotTarget.Add((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, 0);
                                DotBuildList.Add(u, dotTarget);
                                CD.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                                u.IsBurned = true;
                                Hit(u);
                                _unitContext.SwitchTarget(DotBuildList);
                                return;
                            }
                            Hit(u);
                            Casted = !Casted;
                        }
                        else
                        {
                            _castTimeTS = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        }
                    }
            if (_castTimeTS == _castTimeTS + _castingTime)
            {
                if (_castTimeTS + CastTime == (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
                {
                    Hit(u);
                    if(SpellName == "Smash")
                    {
                        if(_unitContext.Context.BuildCount > 1)
                        {
                            for(int i =0; i < _unitContext.Context.BuildCount;i++)
                            {
                                if(_unitContext.Context.BuildList[i] != u && u.Position.IsInRange(u.Position, _unitContext.Context.BuildList[i].Position,Range))
                                {
                                    Hit(_unitContext.Context.BuildList[i]);
                                    Archer[] arch = _unitContext.Context.BuildList[i].Slots();
                                    for (int j = 0; i < arch.Length;j++)
                                    {
                                        Hit(arch[j]);
                                    }
                                }
                            }
                        }
                    }
                    _castTimeTS = 0;
                    Casted = !Casted;
                }
            }
        }

        internal string SpellName => _name;

        internal void Update(Unit b)
        {
            CD.Update();
            if (SpellName == "Ignite")
            {
                if (b != null && !b.IsBurned)
                {
                    Cast(b.EnemyTarget);
                }
                if (DotBuildList.Count > 0)
                {
                    UpdateDots(DotBuildList);
                }
            }
            if (SpellName == "Smash")
            {
                if (b != null)
                {
                    Cast(b.EnemyTarget);
                }
            }
        }

        internal void Update(Building b)
        {

        }
    }
}