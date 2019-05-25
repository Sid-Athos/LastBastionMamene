using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Waves
    {
        Map _context;
        uint _round;
        uint _gobAmount;
        uint _timeStamp;
        bool _spawnStatus = false;

        internal Waves(Map context)
        {
            _context = context;
            _round = 1;
        }

        internal Map WavesContext => _context;

        public uint Round
        {
            get { return _round; }
            set { _round = value; }
        }

        public bool Spawned
        {
            get { return _spawnStatus; }
            set { _spawnStatus = value; }
        }

        internal uint TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        internal uint GobAmount
        {
            get { return _gobAmount; }
            set { _gobAmount = value; }
        }

        internal void SpawnWave()
        {
            Vectors placeToSpawn = SpawnLocation();
            GobAmount = Round * 4;
            var calc = GobAmount/ Round;

            for (int i = 0; i < calc; i++)
            {
                Barbar v1 = new Barbar(placeToSpawn.X, placeToSpawn.Y, 2.25f, "Barbare", 150, 3, 1, false, 3, 0.001f, WavesContext);
                
            }

            uint magesToSpawn;

            if (Round >= 4)
            {
                magesToSpawn = (uint)Math.Ceiling((double)calc);
                for(int i = 0;  i < magesToSpawn;i++)
                {
                    Mage m = new Mage(50);
                }
                calc = magesToSpawn;
            }

            if(Round >= 8)
            {
                calc = GobAmount / calc;
                uint gargoylesToSpawn = (uint)Math.Ceiling((double)calc);

                for (int i = 0; i < gargoylesToSpawn; i++)
                {
                    Gargoyle g = new Gargoyle(50);
                    WavesContext.AddBarbar(g);
                }
                calc = gargoylesToSpawn;
            }

            if(Round >= 12)
            {
                
            }
                Round++;
        }
        
        internal Vectors SpawnLocation()
        {
            var grid = _context.GetGame.GetGrid;
            List<Vector2f> vecs = new List<Vector2f>();
            Random r = new Random();

            foreach (KeyValuePair<Vector2i, Hut> pair in grid)
            {
                if (!pair.Value.IsReveal)
                {
                    vecs.Add(pair.Value.GetVec2F);
                }
            }
            int c = r.Next(vecs.Count);
            return  new Vectors(vecs[c].X, vecs[c].Y);
        }

        public void Update()
        {
                SpawnWave();
        }
    }
}
