using System;

namespace LastBastion
{
    public class Building
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
        uint _woodCost;
        uint _stoneCost;
        uint _foodCost;
        uint _villagerCost;

        public Building(float posX, float posY,
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

        public Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _count++;
        }

        public void IncreaseArmor()
        {
            _armor++;
        }

        public string Description => _desc;

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

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public uint Life
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        public uint WoodCost
        {
            get { return _woodCost; }
            set { _woodCost = value; }
        }

        public uint StoneCost
        {
            get { return _stoneCost; }
            set { _stoneCost = value; }
        }

        public uint FoodCost
        {
            get { return _foodCost; }
            set { _foodCost = value; }
        }

        public uint VillagerCost
        {
            get { return _villagerCost; }
            set { _villagerCost = value; }
        }

        public bool IsDestroy()
        {
            if (_lifePoints <= 0)
            {
                return true;
            }
            return false;
        }

        public void Upgrade()
        {
            Console.WriteLine("tefzfzefzfst");
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
        
        public uint Armor => _armor;
        
        public uint Count => _count;
    }
}
