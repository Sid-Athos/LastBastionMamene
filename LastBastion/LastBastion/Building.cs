using System;

namespace LastBastion
{
    public class Building
    {
        Map _context;
        Vectors _position;
        uint _lifePoints;
        uint _maxLifePoints;
        uint _armor;
        uint _rank = 1;
        uint _count;
        uint _woodCost;
        uint _stoneCost;
        uint _foodCost;
        uint _villagerCost;

        public Building(float posX, float posY, 
            uint lifePoints, uint maxLifePoints, 
            uint armor, uint rank, 
            uint woodCost, uint foodCost, uint stoneCost, uint villagerCost, 
            Map context)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _woodCost = woodCost;
            _stoneCost = stoneCost;
            _foodCost = foodCost;
            _villagerCost = villagerCost;
            _context = context;
            _count++;
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
            Console.WriteLine("test");
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
