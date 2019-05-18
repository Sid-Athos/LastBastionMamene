using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using Interface;

namespace LastBastion
{
    public class Map
    {
        Game _game;
        MapUI _UI;
        Village _village;
        List<Villager> _villagePeople;
        List<Barbar> _barbarians;
        List<Building> _buildings;
        List<Archer> _archers;

        public Map(Game game)
        {
            _game = game;
            _UI = new MapUI(_game.Sprites, _game.GetWindow.Render);
            CreateMap();
            _village = new Village(this);
            _villagePeople = new List<Villager>();
            _barbarians = new List<Barbar>();
            _buildings = new List<Building>();
        }

        public List<Villager> VillList => _villagePeople;

        public List<Barbar> BarList => _barbarians;

        public List<Building> BuildList => _buildings;


        public int VillCount => _villagePeople.Count;

        public int BarbCount => _barbarians.Count;

        public int BuildCount => _buildings.Count;


        public void AddVillager(Villager v)
        {
            _villagePeople.Add(v);
        }
        public void RemoveVillager(Villager n)
        {
            _villagePeople.Remove(n);

        }

        public void AddBuilding(Building T)
        {
            _buildings.Add(T);
        }

        public void RemoveBuilding(Building T)
        {
            _buildings.Remove(T);
        }

        public void AddArcher(Archer T)
        {
            _archers.Add(T);
        }

        public void rmvArcher(Archer T)
        {
            _archers.Remove(T);
        }


        public void AddBarbar(Barbar v)
        {
            _barbarians.Add(v);
        }

        public void RemoveBarbar(Barbar n)
        {
            _barbarians.Remove(n);

        }

        public Village GetVillage => _village;

        public Game GetGame => _game;

        public MapUI GetMapUI => _UI;


        public void PrintMap()
        {
            foreach (var item in _game.GetGrid)
            {
                if (_game.GetTimer > 180)
                {
                    _UI.Print("TileWinter", item.Value.GetVec2F);
                }
                else
                {
                    _UI.Print("Tile", item.Value.GetVec2F);
                }
            }
        }
        public void PrintMist()
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

        public void CreateMap()
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
                                item.Value.SetBuilding("Wood");
                            }
                            if (RDM >= 66)
                            {
                                item.Value.SetBuilding("Stone");
                            }
                            if (RDM < 66 && RDM > 33)
                            {
                                item.Value.SetBuilding("Bush");
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
                                item.Value.SetBuilding(choice);
                            }
                        }
                    }
                }
            }
        }
        public string NearbyHutOk(Hut hut)
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
        public void ZoneReveal()
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
        public void SamourailDeCoke()
        {
            foreach (var item in _game.GetGrid)
            {
                _UI.Print("HideFont",item.Value.GetVec2F,true);
            }
        }
    }
}
