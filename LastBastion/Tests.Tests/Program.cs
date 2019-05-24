using System;
using System.Collections.Generic;
using LastBastion;

namespace Tests.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Unit> list = new List<Unit>();

            for(uint i = 0; i < 50; i++)
            {
                Unit b;
                if(i < 20)
                {
                    b = new Unit(0);

                } else
                {
                     b = new Unit(i);

                }
                list.Add(b);
            }

            list = Shuffle.Barbars(list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Life);

            }
                var l = list[0].GetType().ToString();
            Console.WriteLine("Type " + l);

            Predicate<Unit> dead = Preds.IsDead;
            list.RemoveAll(dead);
            Console.WriteLine("Compteur " + list.Count);

            Console.ReadKey();
        }
    }
}
