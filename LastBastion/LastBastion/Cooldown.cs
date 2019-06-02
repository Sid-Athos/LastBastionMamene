using System;
using System.Collections.Generic;
using System.Text;


namespace LastBastion
{
    internal class Cooldown
    {
        Spell _con;             // Context
        uint _tS;                 // Timestamp
        bool _cdStat;         // Cooldown Status
        uint _cdValue;        // Cooldown value in seconds

        internal Cooldown(uint cdValue)
        {
            _cdValue = cdValue;
        }

        internal uint TimeStamp
        {
            get { return _tS; }
            set { _tS = value; }
        }

        internal uint Cd => _cdValue;

        internal bool IsUsable => TimeStamp == 0;  
    }
}

