using System;
using Interface;
using LastBastion;

namespace Tests.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            float foa = 0.5f + 0.5f;

            Console.WriteLine("{0}", foa);
            Console.ReadKey();
            Game sid = new Game();
            sid.Run();

            Map var = new Map(sid);

            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(0.9f, 5.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            for(float i = 0.2f;i < 1.5f;i += 0.1f )
            {
                Barbar v2 = new Barbar((0.7f+i), (0.7f+i), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);

            }
            Barbar v3 = new Barbar(0.7f, (0.7f), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);

            Tower sido = new Tower(0.5f, 0.5f, 250, 250, 30, 5, 5, 1, var);
            Barrack b = new Barrack(0.9f, 1.5f, 150, 150, 1, 1, var);
            Mine m = new Mine(1.9f, 1.5f, 150, 150, 1, 1, var);
            Sawmill s = new Sawmill(1.9f, 1.5f, 150, 150, 1, 1, var);
            Forge f = new Forge(1.9f, 1.5f, 150, 150, 1, 1, var);

            var list = var.BarList;

            //v1.Attack(v2);
            sido.AcquireTarget();

            Unit tar = sido.Target;
            //Console.WriteLine("Unité la plus proche : {0}" ,tar.GetType());

            sido.AcquireTarget();

            if(sido.Target != null)
            {
                Console.WriteLine("Position of enemy is : [{0},{1}] !", sido.Target.Position.X, sido.Target.Position.Y);
                Console.WriteLine("Type of enemy is : {0} !", sido.Target.GetType());
            }
            
            foreach(var n in list)
            {
                Console.WriteLine("Position of enemy is : [{0},{1}] !", n.Position.X, n.Position.Y);
                Console.WriteLine("Type of enemy is : {0} !", n.GetType());
            }


            Console.WriteLine("{0}", foa);
            Console.ReadKey();
        }
    }
}
