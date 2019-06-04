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

        public Waves(Map context)
        {
            _context = context;
            _round = 1;
        }

        public Map WavesContext => _context;

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

        public uint TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public uint GobAmount
        {
            get { return _gobAmount; }
            set { _gobAmount = value; }
        }

        public void SpawnWave()
        {
            GobAmount = Round * 4;

            for (int i = 0; i < GobAmount; i++)
            {
                Vectors placeToSpawn = SpawnLocation();
                Barbar v1 = new Barbar(
                    WavesContext.GetGame.GetWindow.GetView.Render.Center.X, 
                    WavesContext.GetGame.GetWindow.GetView.Render.Center.Y, 
                    WavesContext.GetVillage.Beasts.Beasts["Gobelin"]["Nom"],WavesContext
                    );


            }

            uint magesToSpawn;

            if (Round >= 4)
            {
                magesToSpawn = Round;
                for(int i = 0;  i < magesToSpawn;i++)
                {
                    Mage m = new Mage(
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.X,
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.Y,
                        WavesContext.GetVillage.Beasts.Beasts["Mage"]["Nom"], WavesContext
                    );
                }
            }

            if(Round >= 8)
            {
                uint gargoylesToSpawn = (uint)Math.Ceiling((double)Round/2);

                for (int i = 0; i < gargoylesToSpawn; i++)
                {
                    Gargoyle g = new Gargoyle(
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.X,
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.Y,
                        WavesContext.GetVillage.Beasts.Beasts["Gargoyle"]["Nom"], WavesContext
                    );
                }
            }

            if(Round >= 12)
            {
                uint giantsToSpawn = (uint)Math.Ceiling((double)Round/2);

                for (int i = 0; i < giantsToSpawn; i++)
                {
                    Giant g = new Giant(
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.X,
                        WavesContext.GetGame.GetWindow.GetView.Render.Center.Y,
                        WavesContext.GetVillage.Beasts.Beasts["Giant"]["Nom"], WavesContext
                        );
                }
            }
            Round++;
        }
        
        public Vectors SpawnLocation()
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
