using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCoreCheat.SDK.Classes
{
    public class Enums
    {
        public enum ObsMode
        {
            None = 0,
            Deathcam,
            Freezecam,
            Fixed,
            InEye,
            Chase,
            Roaming
        };

        public enum Team
        {
            None = 0,
            Spectators,
            Terrorist,
            CounterTerrorist
        };
    }
}
