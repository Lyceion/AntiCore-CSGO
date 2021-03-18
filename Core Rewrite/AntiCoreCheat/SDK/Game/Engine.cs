using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiCoreCheat.SDK.Memory;
using static AntiCoreCheat.SDK.Classes.Enums;
using static AntiCoreCheat.SDK.Classes.Structs;

namespace AntiCoreCheat.SDK.Game
{
    class Engine
    {
        public static IntPtr ClientState
        {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.EngineDLLAdress + Offsets.Signatures.dwClientState);
            }
        }
        public static int MaxPlayer
        {
            get
            {
                return CylMemLite.CRead<int>(ClientState + Offsets.Signatures.dwClientState_MaxPlayer);
            }
        }
        public static GlobalVars GlobalVars
        {
            get
            {
                return CylMemLite.CRead<GlobalVars>(Modules.EngineDLLAdress + Offsets.Signatures.dwGlobalVars);
            }
        }
        public static GameState GameState
        {
            get
            {
                return (GameState)CylMemLite.CRead<int>(ClientState + Offsets.Signatures.dwClientState_State);
            }
        }
        public static int GetLocalPlayer
        {
            get{
                return CylMemLite.CRead<int>(ClientState + Offsets.Signatures.dwClientState_GetLocalPlayer);
            }
        }
        public static ClassID GetClassId(IntPtr EntBase)
        {
            return CylMemLite.CRead<ClassID>(CylMemLite.CRead<IntPtr>(CylMemLite.CRead<IntPtr>(CylMemLite.CRead<IntPtr>(EntBase + 8) + 2 * 4) + 1) + 20);
        }
        public static int EntityCount
        {
            get
            {
                var pCount = CylMemLite.CRead<int>(Modules.ClientDLLAdress + Offsets.Signatures.dwEntityList + 0x24);
                if (pCount != -1)
                    return pCount;
                else
                    return MaxPlayer;
            }
        }
        public static void ForceUpdate()
        {
            CylMemLite.CWrite<int>(ClientState + Offsets.Signatures.clientstate_delta_ticks, -1);
        }
        public static bool SendPackets
        {
            set
            {
                CylMemLite.CWrite<bool>(Modules.EngineDLLAdress +Offsets.Signatures.dwbSendPackets, value);
            }
        }
    }
}
