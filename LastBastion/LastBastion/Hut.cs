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
    }
}