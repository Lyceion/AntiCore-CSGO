using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AntiCoreCheat.SDK.Classes.Enums;
using AntiCoreCheat.SDK.Memory;
using AntiCoreCheat.SDK.Offsets;

namespace AntiCoreCheat.SDK.Entities
{
    class CSPlayer
    {
        public CSPlayer(int index)
        {
            EntityIndex = index;
            BaseAddress = CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwEntityList + EntityIndex * 0x10);
        }

        public int EntityIndex { get; set; }

        public IntPtr BaseAddress {
            get
            {
                return BaseAddress;
            }
            set
            {

            }
        }

        public Team Team
        {
            get {
                return CylMemLite.CRead<Team>(BaseAddress + Netvars.m_iTeamNum);
            }
            set {
                CylMemLite.CWrite<Team>(BaseAddress + Netvars.m_iTeamNum, value);
            }
        }
    }
}
