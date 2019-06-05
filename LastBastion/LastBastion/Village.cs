using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    public class Village
    {
        Map _map;
        Building _castle;
        List<Hut> _nearby;
        string _buildingName;
        int _area;
        uint _foodStock;
        uint _stoneStock;
        uint _woodStock;
        uint _villagerStock;
        uint _maxVillager;

        public Village(Map map)
        {
            _map = map;
            _nearby = new List<Hut>();
            _buildingName = "Empty";
            _area = 3;
            _woodStock = 150;
            _foodStock = 150;
            _stoneStock = 150;
            _villagerStock = 5;
            _maxVillager = _villagerStock;
            SetCastle();
            SetNearby();
        }

        public int Area => _area;
        public Map GetMap => _map;
        public uint MaxVillager
        {
            get { return _maxVillager; }
            set { _maxVillager = value; }
        }
        public uint Villager
        {
            get { return _villagerStock; }
            set { _villagerStock = value; }
        }
        public uint Wood
        {
            get { return _woodStock; }
            set { _woodStock = value; }
        }
        public uint Food
        {
            get { return _foodStock; }
            set { _foodStock = value; }
        }
        public uint Stone
        {
            get { return _stoneStock; }
            set { _stoneStock = value; }
        }
        public void RessourceProd()
        {
            foreach(var item in _map.GetGame.GetGrid )
            {
                if(item.Value.GetName == "Farm")
                {
                    if (_map.GetGame.Event == "AFood")
                    {
                        Food += (uint)((5 * item.Value.Building.Rank) * 1.15f / 1);
                    }
                    else if (_map.GetGame.Event == "PFood")
                    {
                        Food += (uint)((5 * item.Value.Building.Rank) * 0.85f / 1);
                    }
                    else
                    {
                        Food += (5 * item.Value.Building.Rank);
                    }
                    if (Food > 9999)
                    {
                        Food = 9999;
                    }
                }
                if (item.Value.GetName == "Sawmill")
                {
                    if (_map.GetGame.Event == "AWood")
                    {
                        Wood += (uint)((5 * item.Value.Building.Rank) * 1.15f / 1);
                    }
                    else if (_map.GetGame.Event == "PWood")
                    {
                        Wood += (uint)((5 * item.Value.Building.Rank) * 0.85f / 1);
                    }
                    else
                    {
                        Wood += (5 * item.Value.Building.Rank);
                    }
                    if (Wood > 9999)
                    {
                        Wood = 9999;
                    }
                }
                if (item.Value.GetName == "Mine")
                {
                    if (_map.GetGame.Event == "AStone")
                    {
                        Stone += (uint)((5 * item.Value.Building.Rank) * 1.15f / 1);
                    }
                    else if (_map.GetGame.Event == "PStone")
                    {
                        Stone += (uint)((5 * item.Value.Building.Rank) * 0.85f / 1);
                    }
                    else
                    {
                        Stone += (5 * item.Value.Building.Rank);
                    }
                    if(Stone > 9999)
                    {
                        Stone = 9999;
                    }
                }
                if (item.Value.GetName == "House")
                {
                    if(item.Value.Building.Rank <= 2)
                    {
                        Food -= 1;
                    }
                    else
                    {
                        Food -= 2;
                    }
                    if (Food > 9999)
                    {
                        Food = 9999;
                    }
                }
            }
        }

        public void CreateCastle(int posX, int posY)
        {
            _map.GetGame.GetGrid[new Vector2i(posX, posY)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(posX, posY)].Building = new Castle(-1, 0, 750, 750, 30, 1, _map, "Castle", "Your residence");
        }

        public void SetCastle()
        {
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].IsReveal = true;
            CreateCastle(-1, 0);
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].IsReveal = true;
            CreateCastle(-1, 1);
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].IsReveal = true;
            CreateCastle(-1, -1);
            _map.GetGame.GetGrid[new Vector2i(0, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 0)].IsReveal = true;
            CreateCastle(0, 0);
            _map.GetGame.GetGrid[new Vector2i(0, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 1)].IsReveal = true;
            CreateCastle(0, 1);
            _map.GetGame.GetGrid[new Vector2i(0, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, -1)].IsReveal = true;
            CreateCastle(0, -1);
            _map.GetGame.GetGrid[new Vector2i(1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 0)].IsReveal = true;
            CreateCastle(1, 0);
            _map.GetGame.GetGrid[new Vector2i(1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 1)].IsReveal = true;
            CreateCastle(1, 1);
            _map.GetGame.GetGrid[new Vector2i(1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, -1)].IsReveal = true;
            CreateCastle(1, -1);
        }

        public void SetNearby()
        {
            for (int i = -1 * _area + 1; i < _area; i++)
            {
                for (int j = -1 * _area + 1; j < _area; j++)
                {
                    if (!_map.GetGame.GetGrid[new Vector2i(i, j)].IsBusy())
                    {
                        _nearby.Add(_map.GetGame.GetGrid[new Vector2i(i, j)]);
                    }
                }
            }
        }

        public bool BuildingCost(string name)
        {
            if(_map.GetGame.SamplerBuilding[name].WoodCost <= Wood && _map.GetGame.SamplerBuilding[name].StoneCost <= Stone &&
                _map.GetGame.SamplerBuilding[name].FoodCost <= Food && _map.GetGame.SamplerBuilding[name].VillagerCost <= Villager)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuildingPayement()
        {
            Wood -= _map.GetGame.SamplerBuilding[_buildingName].WoodCost;
            Stone -= _map.GetGame.SamplerBuilding[_buildingName].StoneCost;
            Food -= _map.GetGame.SamplerBuilding[_buildingName].FoodCost;
            Villager -= _map.GetGame.SamplerBuilding[_buildingName].VillagerCost;
        }

        public void CreateBuilding(string name)
        {
            _buildingName = name;

            if (BuildingCost(_buildingName))
            {
                BuildingPayement();
                switch (_buildingName)
                {
                    case "House":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new House(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 5, 1, _map);
                        MaxVillager += 5;
                        Villager += 5;
                    break;
                    case "Sawmill":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new Sawmill(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, _map);
                    break;
                    case "Mine":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new Mine(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, _map);
                    break;
                    case "Farm":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new Farm(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, _map);
                    break; 
                    case "Tower":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new Tower(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y,300,300,0,30,0,1, _map);
                    break;
                    case "Wall":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new Wall(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, _map);
                    break;
                    case "LavaWall":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new LavaWall(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 10,1.0f,1, _map);
                        break;
                    case "House Lv2":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                        break;
                    case "House Lv3":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                        break;
                    default:
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                    break;
                }
            }
            if (_nearby.Count > 0)
            {
                int _random = _map.GetGame.RandomNumber(0, _nearby.Count - 1);
                foreach (var item in _map.GetGame.GetGrid)
                {
                    if (item.Value == _nearby[_random])
                    {

                        //item.Value.SetBuilding(name);

                        /*
                        item.Value.SetBuilding(name);
                        */

                    }
                }
                _nearby.Remove(_nearby[_random]);
                _nearby = RebuildeMegaGreatConstructor();
            }
            if (_nearby.Count == 0)
            {
                _area++;
                SetNearby();
            }
            Console.WriteLine(_nearby.Count);
        }

        public List<Hut> RebuildeMegaGreatConstructor()
        {
            List<Hut> newList = new List<Hut>();
            foreach (var item in _nearby)
            {
                newList.Add(item);
            }
            return newList;
        }

        public void DrawBuilding()
        {
            foreach (var item in _map.GetGame.GetGrid)
            {
                if (item.Value.IsBusy())
                {
                    if (item.Value.GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("Wall").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Wall"));
                    }
                    if (item.Value.GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWall").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWall"));
                    }
                    if (item.Value.GetName == "Mine")
                    {
                        _map.GetGame.Sprites.GetSprite("Mine").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Mine"));
                    }
                    if (item.Value.GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("Tower").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Tower"));
                    }
                    if (item.Value.GetName == "House")
                    {
                        _map.GetGame.Sprites.GetSprite("House").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("House"));
                    }
                    if (item.Value.GetName == "Farm")
                    {
                        _map.GetGame.Sprites.GetSprite("Farm").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Farm"));
                    }
                    if (item.Value.GetName == "Sawmill")
                    {
                        _map.GetGame.Sprites.GetSprite("Sawmill").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Sawmill"));
                    }
                    if (item.Value.GetName == "Stone")
                    {
                        _map.GetGame.Sprites.GetSprite("Stone").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Stone"));
                    }
                    if (item.Value.GetName == "Wood")
                    {
                        if (_map.GetGame.GetTimer >= 180)
                        {
                            _map.GetGame.Sprites.GetSprite("WoodWinter").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WoodWinter"));
                        }
                        else
                        {
                            _map.GetGame.Sprites.GetSprite("Wood").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Wood"));
                        }
                    }
                    if (item.Value.GetName == "Bush")
                    {
                        if (_map.GetGame.GetTimer >= 180)
                        {
                            _map.GetGame.Sprites.GetSprite("BushWinter").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("BushWinter"));
                        }
                        else
                        {
                            _map.GetGame.Sprites.GetSprite("Bush").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Bush"));
                        }
                    }
                }
            }
        }
        public void WallRenderer()
        {
            foreach (var item in _map.GetGame.GetGrid)
            {
                if (item.Value.GetName == "Wall")
                {
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X-1,item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallLeft"));
                    }
                    if(_map.GetGame.GetGrid[new Vector2i(item.Key.X -1, item.Key.Y)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y+1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y-1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallUp"));
                    }
                }

                if (item.Value.GetName == "LavaWall")
                {
                    if(_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("LavaWallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("LavaWallUp"));
                    }
                }

                if (item.Value.GetName == "Tower")
                {
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y )].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerBot").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerBot"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerBot").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerBot"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerBot").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerBot"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "LavaWall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerUp"));
                    }
                }
            }
        }
        public void DrawCastle()
        {
            _map.GetGame.Sprites.GetSprite("Castle").Position = _map.GetGame.GetGrid[new Vector2i(-1, -1)].GetVec2F;
            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Castle"));
        }
    }
}
