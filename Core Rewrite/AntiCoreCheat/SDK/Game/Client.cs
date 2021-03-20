using AntiCoreCheat.SDK.Game.Offsets;
using AntiCoreCheat.SDK.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AntiCoreCheat.SDK.Classes.Structs;

namespace AntiCoreCheat.SDK.Game
{
    class Client
    {
        public static IntPtr GlowObjectManager
        {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwGlowObjectManager);
            }
        }

        public static IntPtr LocalPlayerBase
        {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwLocalPlayer);
            }
        }

    }
}
