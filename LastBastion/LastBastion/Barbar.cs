﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Barbar : Unit
    {
        static uint _count;
        Unit _target;

        public Barbar(float posX, float posY,
            string job, uint lifePoints, uint dmg, uint armor, bool isMoving,
            uint attackCooldown, float speed, Map context)
            : base(posX, posY,
            job, lifePoints, dmg, armor, isMoving,
            attackCooldown, speed, context)
        {
            _count++;
        }  
        
        /**public Building AquireTarget()
        {
            Map context = base.Context;
            List<Building> buildings = Context.BuildList;

            foreach(var n in buildings)
            {

            }
            return;
        }*/
    }
}
