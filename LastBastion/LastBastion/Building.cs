using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Building
    {
        Map _context;
        Vectors _position;
        uint _lifePoints;
        uint _maxLifePoints;
        static uint _count;
        uint _armor;
        uint _rank;

        public Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank, Map context)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _context = context;
            _context.AddBuilding(this);
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

        public uint Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public Vectors Position
        {
            get { return _position; }
            set { _position = value; }
        }

    }
}
