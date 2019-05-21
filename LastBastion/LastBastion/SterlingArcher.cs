using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Archer : Unit
    {
        static uint _count;
        Tower _context;
        bool _inTower;

        public Archer(float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
            context.AddArcher(this);
            _inTower = true;
        }

        internal Archer(float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed,bool inTower, Map context)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
            context.AddArcher(this);
            _inTower = inTower;
        }

        internal Archer(float posX, float posY, float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, bool inTower)
            : base(posX, posY, range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed)
        {
            _count++;
            _inTower = inTower;
        }

        internal void SetTower(Tower t)
        {
            _context = t;
        }

        internal void Attack()
        {
            new Projectiles(Position, Target, this);
        }

        internal void Update()
        {
        }
    }

}
