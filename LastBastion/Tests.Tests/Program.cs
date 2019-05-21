using System;
using System.Collections.Generic;
using Interface;
using LastBastion;

namespace Tests.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Barbar> list = new List<Barbar>();

            for(uint i = 0; i < 50; i++)
            {
                Barbar b;
                if(i < 20)
                {
                    b = new Barbar(0);

                } else
                {
                     b = new Barbar(i);

                }
                list.Add(b);
            }

            list = Shuffle.Barbars(list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Life);

            }
            Console.WriteLine("Compteur " + list.Count);

            Predicate<Barbar> dead = Preds.IsDead;
            list.RemoveAll(dead);
            Console.WriteLine("Compteur " + list.Count);

            Console.ReadKey();
        }
    }
}
