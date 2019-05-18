﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Building
    {
        float _posX;
        float _posY;
        uint _lifePoints;
        uint _maxLifePoints;
        uint _armor;
        uint _rank;

        public Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank)
        {
            _posX = posX;
            _posY = posY;
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
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
