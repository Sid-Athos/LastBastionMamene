﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Unit
    {
        //Map _context;
        float _posX;
        float _posY;
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

        public Unit(float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed)
        {
            _posX = posX;
            _posY = posY;
            _job = job;
            _lifePoints = lifePoints;
            _maxLifePoints = _lifePoints;
            _dmg = dmg;
            _armor = armor;
            _isMoving = isMoving;
            _aaCooldown = attackCooldown;
            _speed = speed;
        }

        public void Attack(Unit unit)
        {

            if (_dmg > (unit._lifePoints + unit._armor))
            {
                unit._lifePoints = 0;
                unit.Die();
                return;
            }

            unit._lifePoints = Math.Max(unit._lifePoints - (_dmg - unit._armor), 0);
        }


        public uint Dmg => _dmg;

        public uint Armor => _armor;

        public uint Life => _lifePoints;

        public bool IsMoving => _isMoving;

        public bool IsInTower => _inTower;

        public string Job => _job;

        public void Update()
        {
            if (_lifePoints == 0)
            {
                Die();
            }
        }

        public void Attacked(uint newLife)
        {
            _lifePoints = newLife;
        }

        public void Die()
        {
            //Remove();
        }

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
    }
}
