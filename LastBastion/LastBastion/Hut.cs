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
        string _name;
        string _buildingName;
        bool _isReveal;
        Building building;
        Game _game;

        public Hut(Game game, Vector2f pos, string name, Vector2i posG)
        {
            _game = game;
            _posG = posG;
            _pos = pos;
            _buildingName= "Empty";
            _name = name;
            _isReveal = false;
        }
        public Vector2i GetVec2I { get { return _posG; } }
        public Vector2f GetVec2F { get { return _pos; } }
        public String GetName { get { return _buildingName; } }
        public String StringVec => _name;
        public bool IsBusy()
        {
            if (_buildingName!= "Empty")
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
            _buildingName = a;
            switch (_buildingName)
            {
                case "House":
                    House _house = new House(GetVec2F.X,GetVec2F.Y,100,100,10,1,5);

                    break;
                case "Sawmill":
                    Sawmill _sawmill = new Sawmill(GetVec2F.X,GetVec2F.Y,100,100,10,1,2);
                    break;
                case "Mine":
                    Mine _mine = new Mine(GetVec2F.X, GetVec2F.Y, 100, 100, 10, 1, 2);
                    break;
                case "Forge":
                    Forge _forge = new Forge(GetVec2F.X, GetVec2F.Y, 100, 100, 10, 1);
                    break;
                case "Market":
                    Market _market = new Market(GetVec2F.X, GetVec2F.Y, 100, 100, 10, 1, 2);
                    break;
                case "Tower":
                    Tower _tower = new Tower(GetVec2F.X,GetVec2F.Y,200,200,10,20,1,1);
                    break;
                case "Wall":
                    Wall _wall = new Wall(GetVec2F.X, GetVec2F.Y, 300, 300, 30, 1);
                    break;
                case "Barrack":
                    Barrack _barrack = new Barrack(GetVec2F.X, GetVec2F.Y, 150, 150, 15, 1);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
