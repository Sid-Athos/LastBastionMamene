using System;
using System.Collections.Generic;

namespace LastBastion
{
    public static class Shuffle
    {
        public static List<Building> Buildings(List<Building> list)
        {

            Random r = new Random();
            Building swap;

            for (int i = list.Count - 1; i > 0; i--)
            {
                int n = r.Next(i);
                swap = list[n];
                list[n] = list[i];
                list[i] = swap;
            }
            return list;
        }
        
        public static List<Unit> Barbars(List<Unit> list)
        {

            Random r = new Random();

            for (int i = list.Count - 1; i > 0; i--)
            {
                int n = r.Next(i);
                Unit swap = list[n];
                list[n] = list[i];
                list[i] = swap;
            }
            return list;
        }  
    }
}

