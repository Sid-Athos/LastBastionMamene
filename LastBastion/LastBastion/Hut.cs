using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    public class Hut
    {
        Vector2f _pos;
        Vector2i _posG;
        public string _name;
        string _buildingName;
        bool _isReveal;
        Building building;
        Game _game;

        public Hut(Game game, Vector2f pos, string name, Vector2i posG)
        {
            _game = game;
            _posG = posG;
            _pos = pos;
            _buildingName = "Empty";
            _name = name;
            _isReveal = false;
            building = null;
        }
        public Vector2i GetVec2I { get { return _posG; } }
        public Vector2f GetVec2F { get { return _pos; } }
        public String GetName { get { return _buildingName; } }
        public String SetName { set { _buildingName = value; } }
        public String StringVec => _name;

        public bool IsBusy()
        {
            if (_buildingName != "Empty")
            {
                return true;
            }
            return false;
        }
        public bool IsReveal
        {
            get { return _isReveal; }
            set { _isReveal = value; }
        }

        public Building Building
        {
            get { return building; }
            set { building = value; }
        }
        
        public void SetBuilding(string a)
        {
            Console.WriteLine(a);
            _buildingName = a;
            switch (_buildingName)
            {
                case "House":
                    building = new House(GetVec2F.X, GetVec2F.Y,150,150,0,1,0,0f,0, _game.Map,a,_game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                case "Sawmill":
                    building = new Sawmill(GetVec2F.X, GetVec2F.Y, 150, 150, 0, 1, 0, 0f, 0, _game.Map, a, _game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                case "Mine":
                    building = new Mine(GetVec2F.X, GetVec2F.Y, 150, 150, 0, 1, 0, 0f, 0, _game.Map, a, _game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                case "Farm":
                    building = new Farm(GetVec2F.X, GetVec2F.Y, 150, 150, 0, 1, 0, 0f, 0, _game.Map, a, _game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                case "Tower":
                    building = new Tower(GetVec2F.X, GetVec2F.Y, 350, 350, 5, 2, 1 ,2.0f, 0, _game.Map, a, _game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                case "Wall":
                    building = new Wall(GetVec2F.X, GetVec2F.Y, 150, 150, 0, 10, 0, 0f, 0, _game.Map, a, _game.GetMap.Vill.Costs[a]["Description"]);
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
        }
    }
}