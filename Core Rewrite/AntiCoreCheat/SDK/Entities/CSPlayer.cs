using System;
using static AntiCoreCheat.SDK.Classes.Enums;
using static AntiCoreCheat.SDK.Classes.Structs;
using AntiCoreCheat.SDK.Memory;
using AntiCoreCheat.SDK.Game.Offsets;
using AntiCoreCheat.SDK.Game;
using System.Text;

namespace AntiCoreCheat.SDK.Entities
{
    class CSPlayer
    {
        public CSPlayer()
        {

        }

        public CSPlayer(int index)
        {
            EntityIndex = index;
        }

        public int EntityIndex;

        public string Name
        {
            get
            {
                return CylMemLite.ReadString((CylMemLite.CRead<int>(CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwRadarBase) + 0x78) + (EntityIndex + 2) * 0x174) + 0x18);
            }
        }

        public IntPtr BaseAddress {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwEntityList + EntityIndex * 0x10);
            }
        }

        public Team Team
        {
            get {
                return (Team)CylMemLite.CRead<int>(BaseAddress + Netvars.m_iTeamNum);
            }
        }

        public bool isDormant
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Signatures.m_bDormant);
            }
        }
        public int Health
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_iHealth);
            }
        }
        public bool IsScoped
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Netvars.m_bIsScoped);
            }
        }
        public IntPtr ActiveWeapon
        {
            get
            {
                return CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwEntityList + ((CylMemLite.CRead<int>(BaseAddress + Netvars.m_hActiveWeapon) & 0xFFF) - 1) * 0x10);
            }
        }
        public short ActiveWeaponID
        {
            get
            {
                return CylMemLite.CRead<short>(ActiveWeapon + Netvars.m_iItemDefinitionIndex);
            }
        }
        public string WeaponName
        {
            get
            {
                return Functions.Parsers.ParseItemName(ActiveWeaponID);
            }
        }
        public bool IsCloseRangeWeapon
        {
            get
            {
                return (WeaponName == "Bump Mine" || WeaponName == "Bayonet" || WeaponName == "Flip Knife" || WeaponName == "Gut Knife" || WeaponName == "Karambit" || WeaponName == "M9 Bayonet" || WeaponName == "Huntsman Knife" || WeaponName == "Falchion Knife" || WeaponName == "Bowie Knife" || WeaponName == "Butterfly Knife" || WeaponName == "Shadow Daggers" || WeaponName == "Ursus Knife" || WeaponName == "Navaja Knife" || WeaponName == "Stiletto Knife" || WeaponName == "Talon Knife" || WeaponName == "Terrorist Knife" || WeaponName == "Knife" || WeaponName == "Meele" || WeaponName == "Axe" || WeaponName == "Hammer" || WeaponName == "Wrench" || WeaponName == "Breach Charge" || WeaponName == "Hands" || WeaponName == "Medi-Shot" || WeaponName == "Defuse Kit" || WeaponName == "Rescue Kit" || WeaponName == "Ballistick Shield" || WeaponName == "KnifeGG" || WeaponName == "C4 Explosive");
            }
        }
        public bool IsSniperWeapon
        {
            get
            {
                return (WeaponName == "AWP" || WeaponName == "SSG 08" || WeaponName == "G3SG1" || WeaponName == "SCAR-20");
            }
        }
        public bool IsHeavyWeapon
        {
            get
            {
                return (WeaponName == "M249" || WeaponName == "Negev");
            }
        }
        public bool IsScopedWeapon
        {
            get
            {
                return (IsSniperWeapon || WeaponName == "SG 553" || WeaponName == "AUG");
            }
        }
        public bool IsPistolWeapon
        {
            get
            {
                return (WeaponName == "Desert Eagle" || WeaponName == "Dual Barettas" || WeaponName == "Fives-SeveN" || WeaponName == "Glock-18" || WeaponName == "Tec-9" || WeaponName == "Zeus x27" || WeaponName == "P2000" || WeaponName == "P250" || WeaponName == "USP-S" || WeaponName == "CZ75-Auto" || WeaponName == "R8 Revolver" || WeaponName == "USP-S");
            }
        }
        public bool IsThrowableWeapon
        {
            get
            {
                return (WeaponName == "HE Granade" || WeaponName == "Flashbang" || WeaponName == "Smoke Granade" || WeaponName == "Molotov" || WeaponName == "Decoy Granade" || WeaponName == "Incendiary Granade" || WeaponName == "Fire Bomb" || WeaponName == "Frag Granade" || WeaponName == "Snowball");
            }
        }
        //public static Vector3 Position(int entB)
        //{
        //    return CylMem.CRead<Vector3>(entB + m_vecOrigin);
        //}
        public string lastPlaceName
        {
            get
            {
                return CylMemLite.ReadString((int)BaseAddress + Netvars.m_szLastPlaceName);
            }
        }
        public int ArmorValue
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_ArmorValue);
            }
        }
        public bool hasHelmet
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Netvars.m_bHasHelmet);
            }
        }
        public bool hasArmor
        {
            get
            {
                return (ArmorValue > 0);
            }
        }
        
        public bool isDead
        {
            get
            {
                return (Health <= 0);
            }
        }
        public string GetModelName
        {
            get
            {
                return CylMemLite.ReadString(ModelIndex + 0x4);
            }
        }
        public int ModelIndex
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_nModelIndex);
            }
        }
        public bool SpottedByMask
        {
            get
            {
                return CylMemLite.CRead<bool>(BaseAddress + Netvars.m_bSpottedByMask);
            }
            set
            {
                CylMemLite.CWrite<bool>(BaseAddress + Netvars.m_bSpottedByMask, value);
            }
        }
        public ScopeLevels ScopeLevel
        {
            get
            {
                return CylMemLite.CRead<ScopeLevels>(ActiveWeapon + Netvars.m_zoomLevel);
            }
        }
        public ObsMode ObsMode
        {
            get
            {
                return CylMemLite.CRead<ObsMode>(BaseAddress + Netvars.m_iObserverMode);
            }
        }
        public int TotalHits
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_totalHitsOnServer);
            }
        }
        public float HealthShotBoostTime
        {
            get
            {
                return Engine.GlobalVars.curtime - CylMemLite.CRead<float>(BaseAddress + Netvars.m_flHealthShotBoostExpirationTime);
            }
        }
        public float FlashMaxAlpha
        {
            get
            {
                return CylMemLite.CRead<float>(BaseAddress + Netvars.m_flFlashMaxAlpha);
            }
        }
        public float FlashDuration
        {
            get
            {
                return CylMemLite.CRead<float>(BaseAddress + Netvars.m_flFlashDuration);
            }
        }
        public int GlowIndex
        {
            get
            {
                return CylMemLite.CRead<int>(BaseAddress + Netvars.m_iGlowIndex);
            }
        }

        public int GlowObject
        {
            get
            {
                return CylMemLite.CRead<int>(Modules.ClientDLLAdress + Signatures.dwGlowObjectManager);
            }
        }
        //public GlowObject GlowObject
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //    set
        //    {
        //        CylMemLite.CWrite<GlowObject>((CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwGlowObjectManager)) + ((GlowIndex * 0x38)), value);
        //    }
        //}
        //private static readonly IntPtr GlowObject = CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwGlowObjectManager);
        //public static void Glow(int GlowIndex)
        //{
        //    CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x4), 255f);
        //    CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x8), 0f);
        //    CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0xC), 0f);
        //    CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x10), 255f);
        //    CylMemLite.CWrite<bool>(GlowObject + ((GlowIndex * 0x38) + 0x24), true);
        //    CylMemLite.CWrite<bool>(GlowObject + ((GlowIndex * 0x38) + 0x25), false);
        //}

        public void Glow(float r, float g, float b, float a = 1.0f)
        {
            CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x4), r);
            CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x8), g);
            CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0xC), b);
            CylMemLite.CWrite<float>(GlowObject + ((GlowIndex * 0x38) + 0x10), a);
            CylMemLite.CWrite<bool>(GlowObject + ((GlowIndex * 0x38) + 0x24), true);
            CylMemLite.CWrite<bool>(GlowObject + ((GlowIndex * 0x38) + 0x25), false);
        }

        //public static Vector3 GetBonePos(int entB, int bone)
        //{
        //    float x = CylMem.ReadFloat(entB + m_dwBoneMatrix + 0x30 * bone + 0x0C);
        //    float y = CylMem.ReadFloat(entB + m_dwBoneMatrix + 0x30 * bone + 0x1C);
        //    float z = CylMem.ReadFloat(entB + m_dwBoneMatrix + 0x30 * bone + 0x2C);

        //    Vector3 BonePos = new Vector3(x, y, z);
        //    return BonePos;
        //}
    }
}
