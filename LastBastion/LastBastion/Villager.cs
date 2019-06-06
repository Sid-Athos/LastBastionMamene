using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Villager : Unit
    {
        uint _harvestCooldown = 3;
        bool _isHarvesting;
        Tower _context;
            
        internal Villager(float posX, float posY, string name, Map context)
            : base(posX, posY, name, context)
        {
            _isHarvesting = false;
        }

        

        internal void SetTower(Tower t)
        {
            _context = t;
        }

        internal Tower ShowTower => _context;

        internal uint HarvestCd => _harvestCooldown;
        
        internal void Harvest()
        {
            _isHarvesting = ! _isHarvesting;
        }

        internal Vectors FindClosestWorkPlace()
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



