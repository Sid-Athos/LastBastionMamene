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
            Villager v1 = new Villager(0.9f, 5.2f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Villager v2 = new Villager(19.5f, 8.2f, job2, 150, 10, 3, false, 2, 1.5f, var);
            var position = v1.Position;
            Console.WriteLine("Coordonnées du vecteur : [{0},{1}]", position.X, position.Y);
            Console.WriteLine("Norme du vecteur : [{0}]", position.Magnitude());
            var initPos = position;
            Vectors arrivalPos = v2.Position;
            Vectors destination = initPos.Movement(initPos, arrivalPos, 5, 0.2f,v1.Range);
            Vectors finalPlace = destination.AddVecs(position, destination);
            Console.WriteLine("Coordonnées du vecteur : [{0},{1}]", finalPlace.X, finalPlace.Y);
            Console.ReadKey();
        }
    }
}
