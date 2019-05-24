using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{

    internal class Waves
    {
        Game _context;
        uint _round;
        uint _gobAmount;
        uint _timeStamp;

        internal Waves(Game context)
        {
            _context = context;
            _round = 1;
        }

        public Game WavesContext => _context;

        public uint Round
        {
            get { return _round; }
            set { _round = value; }
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

        internal void SpawnWave()
        {
            GobAmount = Round * 4;
            var calc = GobAmount/ Round;

            for (int i = 0; i < calc; i++)
            {
                //Barbar b = new Barbar();
            }

            uint magesToSpawn;

            if (Round >= 4)
            {
                magesToSpawn = (uint)Math.Ceiling((double)calc);
                for(int i = 0;  i < magesToSpawn;i++)
                {
                    Mage m = new Mage();
                }
                calc = magesToSpawn;
            }

            if(Round >= 8)
            {
                calc = GobAmount / calc;
                uint gargoylesToSpawn = (uint)Math.Ceiling((double)calc);

                for (int i = 0; i < gargoylesToSpawn; i++)
                {
                    Gargoyle g = new Gargoyle();
                }
                calc = gargoylesToSpawn;
            }

            if(Round >= 12)
            {
                
            }


                Round++;
        }


        internal void Update()
        {

        }
    }
}
