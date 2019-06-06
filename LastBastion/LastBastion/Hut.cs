using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    internal class Hut
    {
        Vector2f _pos;
        Vector2i _posG;
        internal string _name;
        string _buildingName;
        bool _isReveal;
        Building building;
        Game _game;

        internal Hut(Game game, Vector2f pos, string name, Vector2i posG)
        {
            _game = game;
            _posG = posG;
            _pos = pos;
            _buildingName = "Empty";
            _name = name;
            _isReveal = false;
            building = null;
        }
        internal Vector2i GetVec2I { get { return _posG; } }
        internal Vector2f GetVec2F { get { return _pos; } }
        internal String GetName { get { return _buildingName; } }
        internal String SetName { set { _buildingName = value; } }
        internal String StringVec => _name;

        internal bool IsBusy()
        {
            if (_buildingName != "Empty")
            {
                return true;
            }
            return false;
        }
        internal bool IsReveal
        {
            get { return _isReveal; }
            set { _isReveal = value; }
        }

        internal Building Building
        {
            get { return building; }
            set { building = value; }
        }
    }
}