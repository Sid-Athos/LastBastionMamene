using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    class Village
    {
        Map _map;
        List<Hut> _nearby;
        int _area;

        public Village(Map map)
        {
            _map = map;
            _nearby = new List<Hut>();
            _area = 3;
            SetCastle();
            SetNearby();
        }
        public void SetCastle()
        {
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 0)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(0, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(0, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, -1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(0, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 0)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, -1)].SetBuilding("Castle");
            _map.GetGame.GetGrid[new Vector2i(1, -1)].IsReveal = true;
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
            if (_nearby.Count > 0)
            {
                int _random = _map.GetGame.RandomNumber(0, _nearby.Count - 1);
                foreach (var item in _map.GetGame.GetGrid)
                {
                    if (item.Value == _nearby[_random])
                    {
                        item.Value.SetBuilding(name);
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
                    if (item.Value.GetName == "House")
                    {
                        _map.GetGame.Sprites.GetSprite("House").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("House"));
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
        public void DrawCastle()
        {
            _map.GetGame.Sprites.GetSprite("Castle").Position = _map.GetGame.GetGrid[new Vector2i(-1, -1)].GetVec2F;
            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Castle"));
        }
        public int Area => _area;
        public Map GetMap => _map;
    }
}
