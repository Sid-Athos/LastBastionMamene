using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    public class Unit
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

        public Unit(float posX, float posY,float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
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

        public Vectors Position
        {
            get { return _position; }
            set { _position = value;  }
        }

        public Building EnemyTarget => _enemyTar;

        public float Speed => _speed;

        public void Attack(Unit unit)
        {

            if (_dmg > (unit._lifePoints + unit._armor))
            {
                unit.Life = 0;
                unit.Die();
                return;
            }
            unit.Life = Math.Max(unit.Life - (_dmg - unit._armor), 0);
        }

        public void Attack(Building unit)
        {

            if (_dmg > (unit.Life + unit.Armor))
            {
                unit.Life = 0;
                unit.Die();
                return;
            }
            unit.Life = Math.Max(unit.Life - (_dmg - unit.Armor), 0);
        }

        public float Range => _range;

        public uint Dmg => _dmg;

        public uint Armor => _armor;

        public uint Life
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        public bool IsMoving => _isMoving;

        public bool IsInTower => _inTower;

        public string Job => _job;

        

        public void Attacked(uint newLife)
        {
            _lifePoints = newLife;
        }

        public void Die()
        {
            //Remove();
        }

        public Map Context => _context;

        public void JoinTower()
        {
            _inTower = !_inTower;
        }

        public void Move()
        {
            _isMoving = !_isMoving;
        }

        private bool disposedValue = false; // Pour détecter les appels redondants

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

        public Vectors FindClosestEnemy(Map map)
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

        

        public void SetTarget(Unit u)
        {
            _target = u;
        }

        public void SetTarget(Building b)
        {
            _enemyTar = b;
        }

        public void Paralize()
        {
            _paralyzed = !_paralyzed;
        }

        public bool IsParalysed => _paralyzed;
    }
}
