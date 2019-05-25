using System;
using System.Collections.Generic;
using LastBastion;
using SFML.System;

namespace Tests.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            float calc = (float)(Math.Pow((0f - 19f),2) + Math.Pow((0f-15f),2));
            float range = (float)Math.Pow(25f, 2);
            Console.WriteLine(calc);
            Console.WriteLine(range);
            
            
            Console.ReadKey();
        }
    }
}
