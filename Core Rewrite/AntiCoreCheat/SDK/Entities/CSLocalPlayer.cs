using System;
using static AntiCoreCheat.SDK.Classes.Enums;
using AntiCoreCheat.SDK.Memory;
using AntiCoreCheat.SDK.Game.Offsets;
using AntiCoreCheat.SDK.Game;

namespace AntiCoreCheat.SDK.Entities
{
    class CSLocalPlayer : CSPlayer
    {
#pragma warning disable CS0108
        public IntPtr BaseAddress
        {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwLocalPlayer);
            }
        }
        public int EntityIndex
        {
            get
            {
                return Engine.GetLocalPlayer;
            }
        }
        public Team Team
        {
            get
            {
                return (Team)CylMemLite.CRead<int>(BaseAddress + Netvars.m_iTeamNum);
            }
            set
            {
                CylMemLite.CWrite<int>(BaseAddress + Netvars.m_iTeamNum, (int)value);
            }
        }
        public bool IsScoped
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Netvars.m_bIsScoped);
            }
            set
            {
                CylMemLite.CWrite<bool>(BaseAddress + Netvars.m_bIsScoped, value);
            }
        }
        public short ActiveWeaponID
        {
            get
            {
                return CylMemLite.CRead<short>(ActiveWeapon + Netvars.m_iItemDefinitionIndex);
            }
            set
            {
                CylMemLite.CWrite<short>(ActiveWeapon + Netvars.m_iItemDefinitionIndex, value);
            }
        }
        public int ModelIndex
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_nModelIndex);
            }
            set
            {
                CylMemLite.CWrite<int>(BaseAddress + Netvars.m_nModelIndex, value);
            }
        }
        public bool SpottedByMask
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Netvars.m_bSpottedByMask);
            }
        }
        public ScopeLevels ScopeLevel
        {
            get
            {
                return (ScopeLevels)CylMemLite.CRead<int>(ActiveWeapon + Netvars.m_zoomLevel);
            }
            set
            {
                CylMemLite.CWrite<int>(ActiveWeapon + Netvars.m_zoomLevel, (ScopeLevels)value);
            }
        }
        public ObsMode ObsMode
        {
            get
            {
                return (ObsMode)CylMemLite.CRead<int>(BaseAddress + Netvars.m_iObserverMode);
            }
            set
            {
                CylMemLite.CWrite<int>(BaseAddress + Netvars.m_iObserverMode, (ObsMode)value);
            }
        }
        public float HealthShotBoostTime
        {
            get
            {
                return Engine.GlobalVars.curtime - CylMemLite.CRead<float>(BaseAddress + Netvars.m_flHealthShotBoostExpirationTime);
            }
            set
            {
                CylMemLite.CWrite<float>(BaseAddress + Netvars.m_flHealthShotBoostExpirationTime, Engine.GlobalVars.curtime + value);
            }
        }
        public float FlashMaxAlpha
        {
            get
            {
                return CylMemLite.CRead<float>(BaseAddress + Netvars.m_flFlashMaxAlpha);
            }
            set
            {
                CylMemLite.CWrite<float>(BaseAddress + Netvars.m_flFlashMaxAlpha, value);
            }
        }
        public float FlashDuration
        {
            get
            {
                return CylMemLite.CRead<float>(BaseAddress + Netvars.m_flFlashDuration);
            }
            set
            {
                CylMemLite.CWrite<float>(BaseAddress + Netvars.m_flFlashDuration, value);
            }
        }
#pragma warning restore CS0108
    }
}
