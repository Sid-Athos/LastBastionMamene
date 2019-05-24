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
            SetCastle();
            SetNearby();
        }

        public void RessourceProd()
        {
            foreach(var item in _map.GetGame.GetGrid )
            {
                if(item.Value.GetName == "Farm")
                {
                    _foodStock += (5 * item.Value.Building.Rank);
                    if (_foodStock > 9999)
                    {
                        _foodStock = 9999;
                    }
                }
                if (item.Value.GetName == "Sawmill")
                {
                    _woodStock += (5 * item.Value.Building.Rank);
                    if (_woodStock > 9999)
                    {
                        _woodStock = 9999;
                    }
                }
                if (item.Value.GetName == "Mine")
                {
                    _stoneStock += (5 * item.Value.Building.Rank);
                    if(_stoneStock > 9999)
                    {
                        _stoneStock = 9999;
                    }
                }
                if (item.Value.GetName == "House")
                {
                    _villagerStock += (5 * item.Value.Building.Rank);
                    if(item.Value.Building.Rank <= 2)
                    {
                        _foodStock -= 1;
                    }
                    else
                    {
                        _foodStock -= 2;
                    }
                    if (_foodStock > 9999)
                    {
                        _foodStock = 9999;
                    }
                }
            }
        }

        /*public bool IsEnoughRessource(string building)
        {
            if (building == "Wall" && _woodStock >= 10 && _stoneStock >= 20)
            {
                _woodStock -= 10;
                _stoneStock -= 20;
                return true;
            }
            if (building == "House" && _woodStock >= 30 && _stoneStock >= 10)
            {
                _woodStock -= 30;
                _stoneStock -= 10;
                return true;
            }
            if (building == "Mine" && _woodStock >= 40 && _stoneStock >= 20)
            {
                _woodStock -= 40;
                _stoneStock -= 20;
                return true;
            }
            if (building == "Farm" && _woodStock >= 40 && _stoneStock >= 10)
            {
                _woodStock -= 40;
                _stoneStock -= 10;
                return true;
            }
            if (building == "Sawmill" && _woodStock >= 50 && _stoneStock >= 10)
            {
                _woodStock -= 50;
                _stoneStock -= 10;
                return true;
            }
            if (building == "Tower" && _woodStock >= 10 && _stoneStock >= 60)
            {
                _woodStock -= 10;
                _stoneStock -= 60;
                return true;
            }
            return false;
        }*/

        public void SetCastle()
        {
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, -1)].IsReveal = true;
            GetMap.Castle(new Castle(0f, 0f, 750, 750, 3, 1, GetMap)) ;
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

        public void CreateBuilding(string name)
        {
            _buildingName = name;

            if (_map.GetGame.SamplerBuilding[_buildingName].WoodCost <= _woodStock &&
                _map.GetGame.SamplerBuilding[_buildingName].StoneCost <= _stoneStock &&
                _map.GetGame.SamplerBuilding[_buildingName].FoodCost <= _foodStock &&
                _map.GetGame.SamplerBuilding[_buildingName].VillagerCost <= _villagerStock)
            {
                _woodStock -= _map.GetGame.SamplerBuilding[_buildingName].WoodCost;
                _stoneStock -= _map.GetGame.SamplerBuilding[_buildingName].StoneCost;
                _foodStock -= _map.GetGame.SamplerBuilding[_buildingName].FoodCost;
                _villagerStock -= _map.GetGame.SamplerBuilding[_buildingName].VillagerCost;

                switch (_buildingName)
                {
                    case "House":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = _buildingName;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = new House(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 5, 1, _map);
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
                }
            }
        }
        public void DrawCastle()
        {
            _map.GetGame.Sprites.GetSprite("Castle").Position = _map.GetGame.GetGrid[new Vector2i(-1, -1)].GetVec2F;
            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Castle"));
        }

        public uint FoodStock => _foodStock;
        public uint WoodStock => _woodStock;
        public uint StoneStock => _stoneStock;
        public int Area => _area;
        public Map GetMap => _map;
    }
}
