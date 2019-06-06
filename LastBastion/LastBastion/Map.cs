using System;
using System.Collections.Generic;
using SFML.System;
using Interface;

namespace LastBastion
{
    internal class Map
    {
        Game _game;
        MapUI _UI;
        Castle _castle;
        Village _village;
        List<Unit> _barbarians;
        List<Building> _buildings;
        List<Projectiles> _projectiles;
        Dictionary<Building, Unit> _buildingHasTarget;
        Waves _waves;
        readonly SpellBook _book = new SpellBook();
        readonly Bestiary _beasts = new Bestiary();
        int _countTimer;
        int _sec;
        bool MinutePass = true;

        internal Map(Game game)
        {
            _game = game;
            _countTimer = 0;
            _sec = DateTime.Now.Second;
            _UI = new MapUI(_game.Sprites, _game.GetWindow.Render);
            CreateMap();
            _village = new Village(this);
            _barbarians = new List<Unit>();
            _buildings = new List<Building>();
            _projectiles = new List<Projectiles>();
            _projectiles = new List<Projectiles>();
            _waves = new Waves(this);

        }

        internal Waves Wave => _waves;

        internal Village Vill => _village;

        internal Map()
        {
            //_village = new Village(this);
            _barbarians = new List<Unit>();
            _buildings = new List<Building>();
            _projectiles = new List<Projectiles>();
            _waves = new Waves(this);
        }
        

        internal List<Unit> BarList => _barbarians;

        internal List<Building> BuildList => _buildings;

        internal int BarbCount => _barbarians.Count;

        internal int BuildCount => _buildings.Count;

        internal int GetTimer => _countTimer;

        /*internal void AddVillager(Villager v)
        {
            VillList.Add(v);
        }
        internal void RemoveVillager(Villager n)
        {
            _villagePeople.Remove(n);

        }*/

        internal void AddProjectile(Projectiles v)
        {
            _projectiles.Add(v);
        }
        internal void RemoveProjectile(Projectiles n)
        {
            _projectiles.Remove(n);
        }

        internal void AddBuilding(Building T)
        {
            BuildList.Add(T);
        }

        internal void Castle(Castle c)
        {
            _castle = c;
        }

        internal void RemoveBuilding(Building T)
        {
            _buildings.Remove(T);
        }
        

        internal void AddBarbar(Unit u)
        {
            _barbarians.Add(u);
        }

        internal void RemoveBarbar(Unit u)
        {
            _barbarians.Remove(u);

        }

        internal Village GetVillage => _village;

        internal Game GetGame => _game;

        internal Castle GetCastle => _castle;


        internal MapUI GetMapUI => _UI;


        internal void PrintMap()
        {
            foreach (var item in _game.GetGrid)
            {
                if (_game.Turn == "WaveTurn")
                {
                    _UI.Print("TileWinter", item.Value.GetVec2F);
                }
                else
                {
                    _UI.Print("Tile", item.Value.GetVec2F);
                }
            }
        }
        internal void PrintMist()
        {
            foreach (var item in _game.GetGrid)
            {
                if (!item.Value.IsReveal)
                {
                    _UI.Print("HideFont", item.Value.GetVec2F,true);
                    _UI.Print("Cloud",item.Value.GetVec2F);
                }
            }
        }

        internal void CreateMap()
        {
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.GetName == "Empty")
                {
                    string choice = NearbyHutOk(item.Value);
                    int spawnC = 15;
                    int RDM = _game.RandomNumber(0, 100);
                    if (choice == "Empty")
                    {
                        if (RDM <= spawnC)
                        {
                            RDM = _game.RandomNumber(0, 100);
                            if (RDM <= 33)
                            {
                                item.Value.SetName = "Wood";
                            }
                            if (RDM >= 66)
                            {
                                item.Value.SetName = "Stone";
                            }
                            if (RDM < 66 && RDM > 33)
                            {
                                item.Value.SetName = "Bush";
                            }
                        }
                    }
                    else
                    {
                        if (choice != "Bad")
                        {
                            RDM = _game.RandomNumber(0, 100);
                            if (RDM <= spawnC + spawnC / 2)
                            {
                                item.Value.SetName = choice;
                            }
                        }
                    }
                }
            }
        }
        internal string NearbyHutOk(Hut hut)
        {
            string result = "Empty";
            if (_game.GetGrid.ContainsKey(new Vector2i(hut.GetVec2I.X - 1, hut.GetVec2I.Y)) && _game.GetGrid[new Vector2i(hut.GetVec2I.X - 1, hut.GetVec2I.Y)].GetName != "Empty")
            {
                result = _game.GetGrid[new Vector2i(hut.GetVec2I.X - 1, hut.GetVec2I.Y)].GetName;
            }
            if (_game.GetGrid.ContainsKey(new Vector2i(hut.GetVec2I.X + 1, hut.GetVec2I.Y)) && _game.GetGrid[new Vector2i(hut.GetVec2I.X + 1, hut.GetVec2I.Y)].GetName != "Empty")
            {
                if (result != _game.GetGrid[new Vector2i(hut.GetVec2I.X + 1, hut.GetVec2I.Y)].GetName && result != "Empty")
                {
                    return "Bad";
                }
                else
                {
                    result = _game.GetGrid[new Vector2i(hut.GetVec2I.X + 1, hut.GetVec2I.Y)].GetName;
                }
            }
            if (_game.GetGrid.ContainsKey(new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y - 1)) && _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y - 1)].GetName != "Empty")
            {
                if (result != _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y - 1)].GetName && result != "Empty")
                {
                    return "Bad";
                }
                else
                {
                    result = _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y - 1)].GetName;
                }
            }
            if (_game.GetGrid.ContainsKey(new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y + 1)) && _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y + 1)].GetName != "Empty")
            {
                if (result != _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y + 1)].GetName && result != "Empty")
                {
                    return "Bad";
                }
                else
                {
                    result = _game.GetGrid[new Vector2i(hut.GetVec2I.X, hut.GetVec2I.Y + 1)].GetName;
                }
            }
            return result;
        }
        internal void ZoneReveal()
        {
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.GetVec2I.X < _village.Area + 5 && item.Value.GetVec2I.X > -1 * _village.Area - 5)
                {
                    if (item.Value.GetVec2I.Y < _village.Area + 5 && item.Value.GetVec2I.Y > -1 * _village.Area - 5)
                    {
                        item.Value.IsReveal = true;
                    }
                }
            }
        }
        internal void SamouraïDeCoke()
        {
            foreach (var item in _game.GetGrid)
            {
                _UI.Print("HideFont",item.Value.GetVec2F,true);
            }
        }

        internal SpellBook Sb => _book;

        internal Bestiary Beasts => _beasts;
        internal void TimerUpdate()
        {
            if (DateTime.Now.Second == 1 && MinutePass == true)
            {
                _sec = 1;
                _countTimer += 2;
                MinutePass = false;
            }
            else
            {
                if (_sec < DateTime.Now.Second)
                {
                    _sec = DateTime.Now.Second;
                    _countTimer++;
                }
                if (DateTime.Now.Second == 2 && MinutePass == false)
                {
                    MinutePass = true;
                }
            }
        }
    }
}
