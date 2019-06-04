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

        internal void Reset()
        {
            if(IsUsable)
            {
                return;
            }
            if ((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds >= TimeStamp + Cd)
            {
                TimeStamp = 0;
            }
        }

        internal void Update()
        {
            Reset();
        }
    }
}
