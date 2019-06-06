using System;
using System.Collections.Generic;

namespace LastBastion
{
    public class Unit
    {
        Map _context;
        Vectors _position;
        readonly string _job;
        uint _lifePoints;
        uint _maxLifePoints;
        uint _dmg;
        uint _armor;
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
            Map context
            )
        {
            _job = name;
            _lifePoints = Convert.ToUInt32(context.GetVillage.Beasts.Beasts[name]["Vie"]);
            _maxLifePoints = Convert.ToUInt32(context.GetVillage.Beasts.Beasts[name]["Vie"]); ;
            _dmg = Convert.ToUInt32(context.GetVillage.Beasts.Beasts[name]["Dégâts"]); ;
            _armor = Convert.ToUInt32(context.GetVillage.Beasts.Beasts[name]["Armure"]); ;
            _isMoving = false;
            _aaCooldown = new Cooldown(Convert.ToUInt32(context.GetVillage.Beasts.Beasts[name]["Cooldown"]));
            _speed = (float)Convert.ToDouble(context.GetVillage.Beasts.Beasts[name]["Vitesse"]); ;
            _context = context;
            _range = (float)Convert.ToDouble(context.GetVillage.Beasts.Beasts[name]["Range"]); ;
            _position = new Vectors(posX, posY);
        }


        public Unit(uint life)
        {
            _lifePoints = life;
        }

        public Vectors Position
        {
            get { return _position; }
            set { _position = value; }
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

        public void Attacked(uint newLife)
        {
            Life = newLife;
        }

        public void Die()
        {

        }

        public void JoinTower()
        {
            _inTower = !_inTower;
        }

        void Move()
        {
            _isMoving = !_isMoving;
        }

        public void Burn(Building b)
        {
            b.Burn();
        }

        Vectors FindClosestEnemy(Map map)
        {
            List<Building> units = map.BuildList;

            if (units.Count == 0)
            {
                throw new IndexOutOfRangeException("Aucune unité n'est disponible!");
            }

            var magnitude = Position.X + Position.Y;
            float min = Math.Abs((units[0].Position.X + units[0].Position.Y) - magnitude);
            Vectors unitToReturn = units[0].Position;

            foreach (Building n in units)
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

        public void Moving()
        {
            _isMoving = !_isMoving;
        }

        public Building EnemyTarget
        {
            get { return _enemyTar; }
            set { _enemyTar = value; }
        }

        public Map Context => _context;

        public Unit Target => _target;

        public float Speed => _speed;

        public bool IsParalysed => _paralyzed;

        public bool IsBurned => _burned;

        public bool BurnIt { set { _burned = value; } }

        public bool IsMoving => _isMoving;

        public bool IsInTower => _inTower;

        public string Job => _job;


        public float Range => _range;

        public uint Dmg => _dmg;

        public Cooldown AaCd => _aaCooldown;

        public uint Armor => _armor;

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

        public void SwitchTarget(Dictionary<Building, Dictionary<uint, uint>> s)
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
                    if (!n.IsBurned)
                    {
                        unitToReturn = n;
                        SetTarget(n);
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

        public void AcquireTarget()
        {
            Map context = Context;
            List<Building> buildList = context.BuildList;

            if (context.BuildCount == 0)
            {
                Building b = null;
                SetTarget(b);
                return;
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