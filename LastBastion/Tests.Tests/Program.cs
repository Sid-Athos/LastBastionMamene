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

            List<Unit> list = new List<Unit>();

            for(uint i = 0; i < 50; i++)
            {

                Barbar b = new Barbar(i);
                list.Add(b);
            }

            list = Shuffle.List(list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Life);

            }
            Console.ReadKey();
        }
    }
}
