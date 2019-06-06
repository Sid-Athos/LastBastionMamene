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
            GobAmount = Round * 4;

            for (int i = 0; i < GobAmount; i++)
            {
                Vectors placeToSpawn = SpawnLocation();
                Barbar v1 = new Barbar(
                    placeToSpawn.X,
                    placeToSpawn.Y, 
                    WavesContext.Vill.Beasts.Beasts["Gobelin"]["Nom"],WavesContext
                    );
            }

            uint magesToSpawn;

            if (Round >= 4)
            {
                magesToSpawn = Round;
                for(int i = 0;  i < magesToSpawn;i++)
                {
                    Vectors placeToSpawn = SpawnLocation();
                    Mage m = new Mage(
                        placeToSpawn.X,
                        placeToSpawn.Y,
                        WavesContext.Vill.Beasts.Beasts["Mage"]["Nom"], WavesContext
                    );
                }
            }

            if(Round >= 8)
            {
                uint gargoylesToSpawn = (uint)Math.Ceiling((double)Round/2);

                for (int i = 0; i < gargoylesToSpawn; i++)
                {
                    Vectors placeToSpawn = SpawnLocation();
                    Gargoyle g = new Gargoyle(
                        placeToSpawn.X,
                        placeToSpawn.Y,
                        WavesContext.Vill.Beasts.Beasts["Gargoyle"]["Nom"], WavesContext
                    );
                }
            }

            if(Round >= 12)
            {
                uint giantsToSpawn = (uint)Math.Ceiling((double)Round/2);

                for (int i = 0; i < giantsToSpawn; i++)
                {
                    Vectors placeToSpawn = SpawnLocation();
                    Giant g = new Giant(
                        placeToSpawn.X,
                        placeToSpawn.Y,
                        WavesContext.Vill.Beasts.Beasts["Giant"]["Nom"], WavesContext
                        );
                }
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

        internal void Update()
        {
                SpawnWave();
        }
    }
}
