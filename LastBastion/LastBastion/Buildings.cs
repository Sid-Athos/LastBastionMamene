using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion.Model
{
    public class Buildings
    {
        float _posX;
        float _posY;
        uint _lifePoints;
        uint _maxLifePoints;
        static uint _count;
        uint _armor;
        uint _rank;

        public Buildings(float posX, float posY, uint lifePoints, uint armor, uint rank)
        {
            _posX = posX;
            _posY = posY;
            _lifePoints = lifePoints;
            _maxLifePoints = lifePoints;
            _armor = armor;
            _rank = rank;
            _count++;
        }

        public uint Armor => _armor;

        public void IncreaseArmor()
        {
            _armor++;
        }

        public void IncHealth()
        {
            _maxLifePoints  *= 2;
            _lifePoints *= 2;

        }

        public uint MaxLife => _maxLifePoints;

        public uint Life => _lifePoints;

        public bool IsDestroy()
        {
            if (_lifePoints <= 0)
            {
                return true;
            }
            return false;
        }

        public float Xpos
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public float Ypos
        {
            get { return _posY; }
            set { _posY = value; }
        }

    }
}
