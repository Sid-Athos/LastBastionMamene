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
            var calc = GobAmount/ Round;

            for (int i = 0; i < calc; i++)
            {
                Barbar b = new Barbar(50);
                WavesContext.AddBarbar(b);
            }

            uint magesToSpawn;

            if (Round >= 4)
            {
                magesToSpawn = (uint)Math.Ceiling((double)calc);
                for(int i = 0;  i < magesToSpawn;i++)
                {
                    Mage m = new Mage(50);
                    WavesContext.AddBarbar(m);
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
        
        public void Update()
        {
                SpawnWave();
        }
    }
}
