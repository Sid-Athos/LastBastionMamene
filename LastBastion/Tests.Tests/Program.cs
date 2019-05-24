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


            Game sid = new Game();
            sid.Run();
            Map m = new Map(sid);

            var grid = sid.GetGrid;
            List<Vector2f> vecs = new List<Vector2f>();
            Random r = new Random();

            foreach(KeyValuePair<Vector2i,Hut> pair in grid)
            {
                if(!pair.Value.IsReveal)
                {
                    vecs.Add(pair.Value.GetVec2F);
                }
                Console.WriteLine("Position : [{0},{1}]",pair.Value.GetVec2F.X, pair.Value.GetVec2F.Y);
            }
            Console.WriteLine(vecs.Count);
            int c = r.Next(vecs.Count);
            Console.WriteLine(c);
            Console.WriteLine("Position : [{0},{1}]", vecs[c].X,vecs[c].Y);
            
            Console.ReadKey();
        }
    }
}
