using System;
using System.Collections.Generic;

namespace LastBastion
{
    internal class Building
    {
        Map _context;
        string _name;
        string _desc;
        Vectors _position;
        uint _lifePoints;
        uint _maxLifePoints;
        uint _armor;
        uint _rank;
        uint _count;
        bool _burned;
        uint _woodCost;
        uint _stoneCost;
        uint _foodCost;
        uint _villagerCost;
        Unit _target;
        Archer[] _archers;

        internal Building(float posX, float posY,
    uint lifePoints, uint maxLifePoints,
    uint armor, uint rank,
    uint woodCost, uint foodCost, uint stoneCost, uint villagerCost,
    Map context, string name, string desc)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = 1;
            _woodCost = woodCost;
            _stoneCost = stoneCost;
            _foodCost = foodCost;
            _villagerCost = villagerCost;
            _context = context;
            _count++;
            _name = name;
            _desc = desc;
        }

        internal Building(float posX, float posY,
            uint lifePoints, uint maxLifePoints,
            uint armor, uint rank, uint dmg, float range, uint aaCooldown,
            Map context, string name, string desc)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = 1;
            _context = context;
            _count++;
            IsBurned = false;
            _name = name;
            _desc = desc;
        }
        internal Building(float posX,
        float posY,
        uint lifePoints,
        uint maxLifePoints,
        uint armor,
        uint aaCooldown,Map context)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = 1;
            _context = context;
            _count++;
        }

        internal Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank, Map context, string name, string desc)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _context = context;
            _name = name;
            _desc = desc;
        }

        internal Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _count++;
        }

        internal uint WoodCost
        {
            get { return _woodCost; }
            set { _woodCost = value; }
        }

        internal uint StoneCost
        {
            get { return _stoneCost; }
            set { _stoneCost = value; }
        }

        internal uint FoodCost
        {
            get { return _foodCost; }
            set { _foodCost = value; }
        }

        internal uint VillagerCost
        {
            get { return _villagerCost; }
            set { _villagerCost = value; }
        }

        internal bool IsBurned
        {
            get { return _burned; }
            set { _burned = value; }
        }

        internal void Burn()
        {
            IsBurned = !IsBurned; ;
        }

        internal void IncreaseArmor()
        {
            _armor++;
        }

        internal virtual Unit Target
        {
            get { return _target; }
            set { _target = value; }
        }

        internal string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        internal void IncHealth()
        {
            _maxLifePoints  *= 2;
            _lifePoints *= 2;
        }

        internal void Die()
        {
            Context.BuildList.Remove(this);
        }

        internal uint MaxLife
        {
            get { return _maxLifePoints; }
            set { _maxLifePoints = value; }
        }

        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal uint Life
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        internal bool IsDestroy()
        {
            if (Life <= 0)
            {
                if(Name == "Castle")
                {
                    //EndGame(); A ajouter quand le EndGame sera fait
                }
                return true;
            }
            return false;
        }
        
        virtual internal void Upgrade()
        {
            Rank++;
            IncHealth();
            IncreaseArmor();
        }

        internal virtual Archer[] Slots()
        {
            return _archers;
        }

        internal uint Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        internal Vectors Position
        {
            get { return _position; }
            set { _position = value; }
        }

        internal Map Context => _context;
        
        internal uint Armor => _armor;
        
        internal uint Count => _count;

        internal virtual void Update()
        {

        }

    }
}