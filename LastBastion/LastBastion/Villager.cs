using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Villager : Unit
    {
        uint _harvestCooldown = 3;
        bool _isHarvesting;
        Unit _tar;
        Tower _context;
            
        public Villager(float posX, float posY,float range,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY,range,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _isHarvesting = false;
            context.AddVillager(this);
        }

        

        public void SetTower(Tower t)
        {
            _context = t;
        }

        public Tower ShowTower => _context;

        public uint HarvestCd => _harvestCooldown;
        
        public void Harvest()
        {
            _isHarvesting = ! _isHarvesting;
        }

        public Vectors FindClosestWorkPlace()
        {
            List<Building> buildList = base.Context.BuildList;
            
            if (buildList.Count == 0)
            {
                throw new IndexOutOfRangeException("Aucune unité n'est disponible!");
            }

            var magnitude = Position.X + Position.Y;
            float min = Math.Abs((buildList[0].Position.X + buildList[0].Position.Y) - magnitude);
            Vectors unitToReturn = buildList[0].Position;

            foreach (Building n in buildList)
            {
                if(n.GetType() != typeof(Tower))
                {
                    var newMin = Math.Abs((n.Position.X + n.Position.Y) - magnitude);
                    if (newMin < min)
                    {
                        min = newMin;
                        unitToReturn = n.Position;
                    }
                }
            }
            return null;
        }
    }
}
