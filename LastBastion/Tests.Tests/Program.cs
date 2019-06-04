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
            Map m = new Map();
            SpellBook s = new SpellBook();
            Tower t = new Tower(5.0f, 5f, 150, 150, 20, 0, 2, m);
            Spell sp = new Spell("Ignite", t, s);

            var dico = s.SpellList;

            foreach(var n in dico)
            {
                Console.WriteLine(n.Key);
                foreach(var b in n.Value)
                {
                    Console.WriteLine(b.Key + " : " + b.Value +".");
                }
                Console.WriteLine();

            }

            Console.WriteLine("Les cooldowns et fréquences sont exprimés en secondes");
            
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
