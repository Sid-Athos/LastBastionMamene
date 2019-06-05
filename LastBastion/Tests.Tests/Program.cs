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
            Game sid = new Game();
            sid.Run();
            sid.Close();
            Map map = new Map(sid);
            Tower sido = new Tower(0f, 0f, 250, 250, 30, 0, 1, 25.0f, 5, map, "Tower", "tour");

            Mage m = new Mage(0f, 0f, "Mage", map);
            m.Update();
            Console.WriteLine("Cd AA remaining: " + m.AaCd.RemainingCd());

            m.Update();
            Console.WriteLine("Cd AA remaining: " + m.AaCd.RemainingCd());

            m.Update();

            m.Update();

            Console.WriteLine("Cd AA remaining: " + m.AaCd.RemainingCd());
            Console.WriteLine("Target : " + m.EnemyTarget);
            Console.WriteLine("Spell Damages : " + m.Ignite.Damages);
            Console.WriteLine("Durée : " + m.Ignite.Duration);
            Console.WriteLine("TS : " + (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Console.WriteLine("TS + durée : " + ((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds+ m.Ignite.Duration));



            Console.WriteLine("Fréquences : " + m.Ignite.Frequency);

            Console.WriteLine("Unit Damages : " + m.Dmg);
            Console.WriteLine("Target Life : " + sido.Life);




            Console.ReadKey();
            Console.WriteLine("Cd AA remaining: " + m.AaCd.RemainingCd());

            while(true)
            {
                m.Update();
            }
            Console.ReadKey();
        }
    }
}
