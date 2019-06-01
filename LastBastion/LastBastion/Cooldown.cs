using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Cooldown
    {
        Spell _con;             // Context
        uint _tS;                 // Timestamp
        bool _cdStat;         // Cooldown Status
        uint _cdValue;        // Cooldown value in seconds

        public Cooldown(uint cdValue)
        {
            _cdValue = cdValue;
        }

        public uint TimeStamp
        {
            get { return _tS; }
            set { _tS = value;  }
        }

        public uint Cd => _cdValue;

        public bool IsUsable => TimeStamp == 0;

        public void Cast()
        {
            
        }
    }
}
