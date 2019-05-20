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
        uint _armor;
        uint _rank;
        uint _count;

        public Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank, Map context)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _context = context;
            _context.AddBuilding(this);
            _count++;
        }

        public uint Armor => _armor;


        public uint Count => _count;

        public void IncreaseArmor()
        {
            _armor++;
        }

        public void IncHealth()
        {
            _maxLifePoints  *= 2;
            _lifePoints *= 2;

        }


        public void Die()
        {
            return;
        }

        public uint MaxLife
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        public uint Life
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

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

        public Map Context => _context;

    }
}
