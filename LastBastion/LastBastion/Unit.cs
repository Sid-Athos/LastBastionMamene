using System;
using System.Collections.Generic;

namespace LastBastion
{
    public  class Unit
    {
        Map _context;
        Vectors _position;
        readonly string _job;
        uint _lifePoints;
        uint _maxLifePoints;
        readonly uint _dmg;
        readonly uint _armor;
        bool _isMoving;
        uint _aaCooldown;
        float _speed;
        bool _inTower = false;
        bool _burned = false;
        bool _paralyzed = false;
        float _range;
        Unit _target;
        Building _enemyTar;

        public Unit(
            float posX, 
            float posY
            ,float range,
            string job, 
            uint lifePoints, 
            uint dmg,
            uint armor,
            bool isMoving,
            uint attackCooldown, 
            float speed,
            Map context)
        {
            _job = job;
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _dmg = dmg;
            _armor = armor;
            _isMoving = isMoving;
            _aaCooldown = attackCooldown;
            _speed = speed;
            _context = context;
            _range = range;
            _position = new Vectors(posX, posY);
        }

        public Unit(
            float posX,
            float posY
            , float range,
            string job,
            uint lifePoints,
            uint dmg,
            uint armor,
            bool isMoving,
            uint attackCooldown,
            float speed)
        {
            _job = job;
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _dmg = dmg;
            _armor = armor;
            _isMoving = isMoving;
            _aaCooldown = attackCooldown;
            _speed = speed;
            _range = range;
            _position = new Vectors(posX, posY);
        }

        public Unit(uint life)
        {
            _lifePoints = life;
        }

        public Vectors Position
        {
            get { return _position; }
            set { _position = value;  }
        }
        
        public virtual void Attack(Unit unit)
        {
            
        }

        public virtual void Attack(Building unit)
        {

            
        }

        public uint MaxLife
        {
            get { return _maxLifePoints; }
            set { _maxLifePoints = value; }
        }

        public uint Life
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        internal void Attacked(uint newLife)
        {
            Life = newLife;
        }

         internal void Die()
        {
           
        }

        internal void JoinTower()
        {
            _inTower = !_inTower;
        }

        void Move()
        {
            _isMoving = !_isMoving;
        }

        internal void Burn(Building b)
        {
            b.Burn();
        }

        Vectors FindClosestEnemy(Map map)
        {
            List<Building> units = map.BuildList;

            if(units.Count == 0)
            {
                throw new IndexOutOfRangeException("Aucune unité n'est disponible!");
            }

            var magnitude = Position.X + Position.Y;
            float min = Math.Abs((units[0].Position.X + units[0].Position.Y) - magnitude);
            Vectors unitToReturn = units[0].Position;
            
            foreach(Building n in units)
            {
                var newMin = Math.Abs((n.Position.X + n.Position.Y) - magnitude);
                if (newMin < min)
                {
                    min = newMin;
                    unitToReturn = n.Position;
                }
            }
            return unitToReturn;
        }
        
        internal void SetTarget(Unit u)
        {
            _target = u;
        }

        internal void SetTarget(Building b)
        {
            _enemyTar = b;
        }

        public void Paralize()
        {
            _paralyzed = !_paralyzed;
        }

        public void Moving()
        {
            _isMoving = !_isMoving;
        }

        public Building EnemyTarget
        {
            get { return _enemyTar; }
            set { _enemyTar = value; }
        }

        internal Map Context => _context;

        internal Unit Target => _target;

        public float Speed => _speed;

        internal bool IsParalysed => _paralyzed;

        internal bool IsBurned => _burned;

        internal bool BurnIt { set { _burned = value; } }

        bool IsMoving => _isMoving;

        internal bool IsInTower => _inTower;

        string Job => _job;

        public float Range => _range;

        internal uint Dmg => _dmg;

        internal uint AaCd => _aaCooldown;

        internal uint Armor => _armor;

        private bool disposedValue = false; // Pour détecter les appels redondants

        public virtual void Update()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        internal void SwitchTarget(List<Building> s)
        {
            Map context = Context;
            List<Building> barbList = context.BuildList;

            if (barbList.Count > s.Count)
            {
                if (context.BarbCount == 0)
                {
                    throw new InvalidOperationException("Aucune unité n'est disponible!");
                }

                Building unitToReturn;

                barbList = Shuffle.Buildings(barbList);

                foreach (var n in barbList)
                {
                    if (!s.Contains(n))
                        if (Position.IsInRange(Position, n.Position, Range))
                        {
                            unitToReturn = n;
                            SetTarget(unitToReturn);
                            return;
                        }
                }
            } else
            {
                Building b = null;
                SetTarget(b);

            }
        }

        public void AcquireTarget()
        {
            Map context = Context;
            List<Building> buildList = context.BuildList;

            if (context.BuildCount == 0)
            {
                throw new InvalidOperationException("Aucune unité n'est disponible!");
            }

            Building unitToReturn = buildList[0];
            float min = Position.Distance(Position, buildList[0].Position);
            foreach (var n in buildList)
            {
                
                    unitToReturn = n;
                    SetTarget(unitToReturn);
                    return;
                
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~Units() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }
    }
}
