using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    class Hut
    {
        Vector2f _pos;
        Vector2i _posG;
        string _name;
        string _building;
        bool _isReveal;

        public Hut(Vector2f pos, string name, Vector2i posG)
        {
            _posG = posG;
            _pos = pos;
            _building = "Empty";
            _name = name;
            _isReveal = false;
        }
        public Vector2i GetVec2I { get { return _posG; } }
        public Vector2f GetVec2F { get { return _pos; } }
        public String GetName { get { return _building; } }
        public String StringVec => _name;
        public bool IsBusy()
        {
            if (_building != "Empty")
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
        public void SetBuilding(string a) { _building = a; }
    }
}
