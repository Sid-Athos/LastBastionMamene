using System;
using Interface;
using LastBastion;

namespace Tests.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Game sid = new Game();
            sid.Run();

            Map var = new Map(sid);

            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(0.9f, 5.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Barbar v2 = new Barbar(0.5f, 0.5f, 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            Tower sido = new Tower(0.5f, 0.5f, 250, 250, 30, 5, 5, 1, var);
            Barrack b = new Barrack(0.9f, 1.5f, 150, 150, 1, 1, var);
            Mine m = new Mine(1.9f, 1.5f, 150, 150, 1, 1, var);
            Sawmill s = new Sawmill(1.9f, 1.5f, 150, 150, 1, 1, var);
            Forge f = new Forge(1.9f, 1.5f, 150, 150, 1, 1, var);
            var.AddBarbar(v2);

            var list = var.BuildList;

            //v1.Attack(v2);
            sido.AcquireTarget();

            Unit tar = sido.Target;
            Console.WriteLine("Unité la plus proche : {0}" ,tar.GetType());

            foreach(var n in list)
            {
                Console.WriteLine("Position of building is : [{0},{1}] !", n.Position.X,n.Position.Y);
                Console.WriteLine("Type of building is : {0} !", n.GetType());
            }
            Console.ReadKey();
        }
    }
}
