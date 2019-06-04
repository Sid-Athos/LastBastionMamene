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
        Cooldown _aaCooldown;
        float _speed;
        bool _inTower = false;
        bool _burned = false;
        bool _paralyzed = false;
        float _range;
        Unit _target;
        Building _enemyTar;

        public Unit(
            float posX, 
            float posY,
            string name,
            Map context)
        {
            _job = name;
            _lifePoints = Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Vie"]);
            _maxLifePoints = Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Vie"]); ;
            _dmg = Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Dégâts"]); ;
            _armor = Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Armure"]); ;
            _isMoving = false;
            _aaCooldown = new Cooldown(Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Cooldown"])) ;
            _speed = Convert.ToUInt16(context.Vill.Beasts.Beasts[name]["Vitesse"]); ;
            _context = context;
            _range = (float)Convert.ToDouble(context.Vill.Beasts.Beasts[name]["Range"]); ;
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
        
        internal virtual void Attack(Unit unit)
        {
            
        }

        internal virtual void Attack(Building unit)
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
            BurnIt = !IsBurned;
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

        internal bool IsMoving => _isMoving;

        internal bool IsInTower => _inTower;

        internal string Job => _job;

        internal float Range => _range;

        internal uint Dmg => _dmg;

        internal Cooldown AaCd => _aaCooldown;

        internal uint Armor => _armor;

        private bool disposedValue = false; // Pour détecter les appels redondants

        internal virtual void Update()
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
            }
            else
            {
                Building b = null;
                SetTarget(b);

            }
        }

        internal void AcquireTarget()
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
