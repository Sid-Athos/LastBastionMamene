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
        bool _burned;

        public Building(float posX, float posY,
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

        public Building(float posX, float posY, uint lifePoints, uint maxLifePoints, uint armor, uint rank)
        {
            _position = new Vectors(posX, posY);
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _armor = armor;
            _rank = rank;
            _count++;
        }

        public bool IsBurned
        {
            get { return _burned; }
            set { _burned = value; }
        }

        public void Burn()
        {
            IsBurned = !IsBurned; ;
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
            get { return _maxLifePoints; }
            set { _maxLifePoints = value; }
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

        public bool IsDestroy()
        {
            // un uint en dessous de 0 c'est plusieurs milliards
            // return Life == 0;
            if (_lifePoints <= 0)
            {
                return true;
            }
            return false;
        }

        public void Upgrade()
        {
            Rank++;
            IncHealth();
            IncreaseArmor();
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

        internal virtual void Update()
        {

        }

    }
}
