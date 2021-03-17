using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiCoreCheat.SDK.Memory;

namespace AntiCoreCheat.SDK.Game.Offsets
{
    class OffsetsManager
    {
        public static class NetvarManager
        {
            public static Dictionary<string, Dictionary<string, int>> Table =
                new Dictionary<string, Dictionary<string, int>>();

            public static void ScanTable(IntPtr table, int level, int offset, string name)
            {
                var count = CylMemLite.CRead<int>(table + 0x4);

                for (var i = 0; i < count; i++)
                {
                    var propID = CylMemLite.CRead<IntPtr>(table) + i * 0x3C;
                    var propName = CylMemLite.ReadString(CylMemLite.CRead<int>(propID));
                    var isBaseClass = propName.IndexOf("baseclass") == 0;
                    var propOffset = offset + CylMemLite.CRead<int>(propID + 0x2C);
                    if (!isBaseClass)
                    {
                        if (!Table.ContainsKey(name))
                            Table.Add(name, new Dictionary<string, int>());

                        if (!Table[name].ContainsKey(propName)) Table[name].Add(propName, propOffset);
                    }

                    var child = CylMemLite.CRead<IntPtr>(propID + 0x28);

                    if (child == IntPtr.Zero)
                        continue;

                    if (!isBaseClass)
                        --level;

                    ScanTable(child, ++level, propOffset, name);
                }
            }

            public static void Init()
            {
                IntPtr _firstclass = CylMemLite.CRead<IntPtr>(Modules.ClientDLLAdress + Signatures.dwGetAllClasses);
                if (_firstclass == IntPtr.Zero)
                    Logger.LSDebug.PrintLine("_firstclass is NULL!", LSDebug.TextType.Failed);
                do
                {
                    var table = CylMemLite.CRead<IntPtr>(_firstclass + 0xC);
                    if (table != IntPtr.Zero)
                    {
                        var table_name = CylMemLite.ReadString(CylMemLite.CRead<int>(table + 0xC));
                        ScanTable(table, 0, 0, table_name);
                    }

                    _firstclass = CylMemLite.CRead<IntPtr>(_firstclass + 0x10);
                } while (_firstclass != IntPtr.Zero);
            }
        }
        public static void InitializeOffsetManager()
        {
            Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName(), LSDebug.TextType.Safe);
            Logger.LSDebug.PrintLine("Starting getting signatures.", LSDebug.TextType.Info);
            GetSignatures();
            Logger.LSDebug.PrintLine("Starting getting netvars.", LSDebug.TextType.Info);
            GetNetvars();
        }
        private static void GetSignatures()
        {
            try
            {
                Signatures.dwClientCmd = SigScan.ScanPatterna(Modules.EngineDLLName, "55 8B EC 8B 0D ? ? ? ? 81 F9 ? ? ? ? 75 0C A1 ? ? ? ? 35 ? ? ? ? EB 05 8B 01 FF 50 34 50 A1").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.dwClientState = SigScan.ScanPattern(Modules.EngineDLLName, "A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0", 1, 0, true);
                Signatures.dwClientState_GetLocalPlayer = SigScan.ScanPattern(Modules.EngineDLLName, "8B 80 ? ? ? ? 40 C3", 2, 0, false);
                Signatures.dwClientState_IsHLTV = SigScan.ScanPattern(Modules.EngineDLLName, "80 BF ? ? ? ? ? 0F 84 ? ? ? ? 32 DB", 2, 0, false);
                Signatures.dwClientState_Map = SigScan.ScanPattern(Modules.EngineDLLName, "05 ? ? ? ? C3 CC CC CC CC CC CC CC A1", 1, 0, false);
                Signatures.dwClientState_MapDirectory = SigScan.ScanPattern(Modules.EngineDLLName, "05 ? ? ? ? C3 CC CC CC CC CC CC CC 80 3D", 1, 0, false);
                Signatures.dwClientState_MaxPlayer = SigScan.ScanPattern(Modules.EngineDLLName, "A1 ? ? ? ? 8B 80 ? ? ? ? C3 CC CC CC CC 55 8B EC 8A 45 08", 7, 0, false);
                Signatures.dwClientState_PlayerInfo = SigScan.ScanPattern(Modules.EngineDLLName, "8B 89 ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 01", 2, 0, false);
                Signatures.dwClientState_State = SigScan.ScanPattern(Modules.EngineDLLName, "83 B8 ? ? ? ? ? 0F 94 C0 C3", 2, 0, false);
                Signatures.dwClientState_ViewAngles = SigScan.ScanPattern(Modules.EngineDLLName, "F3 0F 11 80 ? ? ? ? D9 46 04 D9 05", 4, 0, false);
                Signatures.clientstate_delta_ticks = SigScan.ScanPattern(Modules.EngineDLLName, "C7 87 ? ? ? ? ? ? ? ? FF 15 ? ? ? ? 83 C4 08", 2, 0, true);
                Signatures.clientstate_last_outgoing_command = SigScan.ScanPattern(Modules.EngineDLLName, "8B 8F ? ? ? ? 8B 87 ? ? ? ? 41", 2, 0, true);
                Signatures.clientstate_choked_commands = SigScan.ScanPattern(Modules.EngineDLLName, "8B 87 ? ? ? ? 41", 2, 0, true);
                Signatures.clientstate_net_channel = SigScan.ScanPattern(Modules.EngineDLLName, "8B 8F ? ? ? ? 8B 01 8B 40 18", 2, 0, true);
                Signatures.dwEntityList = SigScan.ScanPattern(Modules.ClientDLLName, "BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8", 1, 0, true);
                Signatures.dwForceAttack = SigScan.ScanPattern(Modules.ClientDLLName, "89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04", 2, 0, true);
                Signatures.dwForceAttack2 = SigScan.ScanPattern(Modules.ClientDLLName, "89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04", 2, 12, true);
                Signatures.dwForceBackward = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 287, 0, true);
                Signatures.dwForceForward = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 245, 0, true);
                Signatures.dwForceJump = SigScan.ScanPattern(Modules.ClientDLLName, "8B 0D ? ? ? ? 8B D6 8B C1 83 CA 02", 2, 0, true);
                Signatures.dwForceLeft = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 465, 0, true);
                Signatures.dwForceRight = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 512, 0, true);
                Signatures.dwGameDir = SigScan.ScanPattern(Modules.EngineDLLName, "68 ? ? ? ? 8D 85 ? ? ? ? 50 68 ? ? ? ? 68", 1, 0, true);
                Signatures.dwGameRulesProxy = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 85 C0 0F 84 ? ? ? ? 80 B8 ? ? ? ? ? 74 7A", 1, 0, true);
                Signatures.dwGetAllClasses = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? C3 CC CC CC CC CC CC CC CC CC CC A1 ? ? ? ? B9", 1, 0, true);
                Signatures.dwGlobalVars = SigScan.ScanPattern(Modules.EngineDLLName, "68 ? ? ? ? 68 ? ? ? ? FF 50 08 85 C0", 1, 0, true);
                Signatures.dwGlowObjectManager = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? A8 01 75 4B", 1, 4, true);
                Signatures.dwInput = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? F3 0F 11 04 24 FF 50 10", 1, 0, true);
                Signatures.dwInterfaceLinkList = SigScan.ScanPattern(Modules.ClientDLLName, "8B 35 ? ? ? ? 57 85 F6 74 ? 8B 7D 08 8B 4E 04 8B C7 8A 11 3A 10");
                Signatures.dwLocalPlayer = SigScan.ScanPattern(Modules.ClientDLLName, "8D 34 85 ? ? ? ? 89 15 ? ? ? ? 8B 41 08 8B 48 04 83 F9 FF", 3, 4, true);
                Signatures.dwMouseEnable = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? FF 50 34 85 C0 75 10", 1, 48, true);
                Signatures.dwMouseEnablePtr = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? FF 50 34 85 C0 75 10", 1, 0, true);
                Signatures.dwPlayerResource = SigScan.ScanPattern(Modules.ClientDLLName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true);
                Signatures.dwRadarBase = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 8B 0C B0 8B 01 FF 50 ? 46 3B 35 ? ? ? ? 7C EA 8B 0D", 1, 0, true);
                Signatures.dwSensitivity = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 18 35 ? ? ? ? 89 44 24 0C EB 0B", 2, 44, true);
                Signatures.dwSensitivityPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 18 35 ? ? ? ? 89 44 24 0C EB 0B", 2, 0, true);
                Signatures.dwSetClanTag = SigScan.ScanPatterna(Modules.EngineDLLName, "53 56 57 8B DA 8B F9 FF 15").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.dwViewMatrix = SigScan.ScanPattern(Modules.ClientDLLName, "0F 10 05 ? ? ? ? 8D 85 ? ? ? ? B9", 3, 176, false);
                Signatures.dwWeaponTable = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? 6A 00 FF 50 08 C3", 1, 0, true);
                Signatures.dwWeaponTableIndex = SigScan.ScanPattern(Modules.ClientDLLName, "39 86 ? ? ? ? 74 06 89 86 ? ? ? ? 8B 86", 2, 0, true);
                Signatures.dwYawPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 1C 35 ? ? ? ? 89 44 24 18 EB 0B 8B 01 8B 40 30 FF D0 D9 5C 24 18 F3 0F 10 06", 2, 0, true);
                Signatures.dwZoomSensitivityRatioPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1A F3 0F 10 05 ? ? ? ? F3 0F 11 45 ? 8B 45 F4 35 ? ? ? ? 89 45 FC EB 0A 8B 01 8B 40 30 FF D0 D9 5D FC A1", 2, 0, true);
                Signatures.dwbSendPackets = SigScan.ScanPattern(Modules.EngineDLLName, "B3 01 8B 01 8B 40 10 FF D0 84 C0 74 0F 80 BF ? ? ? ? ? 0F 84", 0, 1, true);
                Signatures.dwppDirect3DDevice9 = SigScan.ScanPattern(Modules.ShaderAPIName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true);
                Signatures.m_pStudioHdr = SigScan.ScanPattern(Modules.ClientDLLName, "8B B6 ? ? ? ? 85 F6 74 05 83 3E 00 75 02 33 F6 F3 0F 10 44 24", 2, 0, true);
                Signatures.m_yawClassPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 16 F3 0F 10 05 ? ? ? ? F3 0F 11 45 ? 81 75 ? ? ? ? ? EB 0A 8B 01 8B 40 30 FF D0 D9 5D 0C 8B 55 08", 2, 0, true);
                Signatures.m_pitchClassPtr = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 89 74 24 28", 1, 0, true);
                Signatures.interface_engine_cvar = SigScan.ScanPattern(Modules.VSTDLibDLLName, "8B 0D ? ? ? ? C7 05", 2, 0, true);
                Signatures.convar_name_hash_table = SigScan.ScanPattern(Modules.VSTDLibDLLName, "8B 3C 85", 3, 0, true);
                Signatures.m_bDormant = SigScan.ScanPattern(Modules.ClientDLLName, "8A 81 ? ? ? ? C3 32 C0", 2, 8, false);
                Signatures.model_ambient_min = SigScan.ScanPattern(Modules.EngineDLLName, "F3 0F 10 0D ? ? ? ? F3 0F 11 4C 24 ? 8B 44 24 20 35 ? ? ? ? 89 44 24 0C", 4, 0, true);
                Signatures.set_abs_angles = SigScan.ScanPatterna(Modules.ClientDLLName, "55 8B EC 83 E4 F8 83 EC 64 53 56 57 8B F1 E8").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.set_abs_origin = SigScan.ScanPatterna(Modules.ClientDLLName, "55 8B EC 83 E4 F8 51 53 56 57 8B F1 E8").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.is_c4_owner = SigScan.ScanPatterna(Modules.ClientDLLName, "56 8B F1 85 F6 74 31").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.force_update_spectator_glow = SigScan.ScanPatterna(Modules.ClientDLLName, "74 07 8B CB E8 ? ? ? ? 83 C7 10").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.anim_overlays = SigScan.ScanPattern(Modules.ClientDLLName, "8B 89 ? ? ? ? 8D 0C D1", 2, 0, true);
                Signatures.m_flSpawnTime = SigScan.ScanPattern(Modules.ClientDLLName, "89 86 ? ? ? ? E8 ? ? ? ? 80 BE ? ? ? ? ?", 2, 0, true);
                Signatures.find_hud_element = SigScan.ScanPatterna(Modules.ClientDLLName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.dwClientCmd = SigScan.ScanPatterna(Modules.EngineDLLName, "55 8B EC 8B 0D ? ? ? ? 81 F9 ? ? ? ? 75 0C A1 ? ? ? ? 35 ? ? ? ? EB 05 8B 01 FF 50 34 50 A1").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.dwClientState = SigScan.ScanPattern(Modules.EngineDLLName, "A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0", 1, 0, true);
                Signatures.dwClientState_GetLocalPlayer = SigScan.ScanPattern(Modules.EngineDLLName, "8B 80 ? ? ? ? 40 C3", 2, 0, false);
                Signatures.dwClientState_IsHLTV = SigScan.ScanPattern(Modules.EngineDLLName, "80 BF ? ? ? ? ? 0F 84 ? ? ? ? 32 DB", 2, 0, false);
                Signatures.dwClientState_Map = SigScan.ScanPattern(Modules.EngineDLLName, "05 ? ? ? ? C3 CC CC CC CC CC CC CC A1", 1, 0, false);
                Signatures.dwClientState_MapDirectory = SigScan.ScanPattern(Modules.EngineDLLName, "05 ? ? ? ? C3 CC CC CC CC CC CC CC 80 3D", 1, 0, false);
                Signatures.dwClientState_MaxPlayer = SigScan.ScanPattern(Modules.EngineDLLName, "A1 ? ? ? ? 8B 80 ? ? ? ? C3 CC CC CC CC 55 8B EC 8A 45 08", 7, 0, false);
                Signatures.dwClientState_PlayerInfo = SigScan.ScanPattern(Modules.EngineDLLName, "8B 89 ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 01", 2, 0, false);
                Signatures.dwClientState_State = SigScan.ScanPattern(Modules.EngineDLLName, "83 B8 ? ? ? ? ? 0F 94 C0 C3", 2, 0, false);
                Signatures.dwClientState_ViewAngles = SigScan.ScanPattern(Modules.EngineDLLName, "F3 0F 11 80 ? ? ? ? D9 46 04 D9 05", 4, 0, false);
                Signatures.clientstate_delta_ticks = SigScan.ScanPattern(Modules.EngineDLLName, "C7 87 ? ? ? ? ? ? ? ? FF 15 ? ? ? ? 83 C4 08", 2, 0, true);
                Signatures.clientstate_last_outgoing_command = SigScan.ScanPattern(Modules.EngineDLLName, "8B 8F ? ? ? ? 8B 87 ? ? ? ? 41", 2, 0, true);
                Signatures.clientstate_choked_commands = SigScan.ScanPattern(Modules.EngineDLLName, "8B 87 ? ? ? ? 41", 2, 0, true);
                Signatures.clientstate_net_channel = SigScan.ScanPattern(Modules.EngineDLLName, "8B 8F ? ? ? ? 8B 01 8B 40 18", 2, 0, true);
                Signatures.dwEntityList = SigScan.ScanPattern(Modules.ClientDLLName, "BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8", 1, 0, true);
                Signatures.dwForceAttack = SigScan.ScanPattern(Modules.ClientDLLName, "89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04", 2, 0, true);
                Signatures.dwForceAttack2 = SigScan.ScanPattern(Modules.ClientDLLName, "89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04", 2, 12, true);
                Signatures.dwForceBackward = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 287, 0, true);
                Signatures.dwForceForward = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 245, 0, true);
                Signatures.dwForceJump = SigScan.ScanPattern(Modules.ClientDLLName, "8B 0D ? ? ? ? 8B D6 8B C1 83 CA 02", 2, 0, true);
                Signatures.dwForceLeft = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 465, 0, true);
                Signatures.dwForceRight = SigScan.ScanPattern(Modules.ClientDLLName, "55 8B EC 51 53 8A 5D 08", 512, 0, true);
                Signatures.dwGameDir = SigScan.ScanPattern(Modules.EngineDLLName, "68 ? ? ? ? 8D 85 ? ? ? ? 50 68 ? ? ? ? 68", 1, 0, true);
                Signatures.dwGameRulesProxy = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 85 C0 0F 84 ? ? ? ? 80 B8 ? ? ? ? ? 74 7A", 1, 0, true);
                Signatures.dwGetAllClasses = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? C3 CC CC CC CC CC CC CC CC CC CC A1 ? ? ? ? B9", 1, 0, true);
                Signatures.dwGlobalVars = SigScan.ScanPattern(Modules.EngineDLLName, "68 ? ? ? ? 68 ? ? ? ? FF 50 08 85 C0", 1, 0, true);
                Signatures.dwGlowObjectManager = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? A8 01 75 4B", 1, 4, true);
                Signatures.dwInput = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? F3 0F 11 04 24 FF 50 10", 1, 0, true);
                Signatures.dwInterfaceLinkList = SigScan.ScanPattern(Modules.ClientDLLName, "8B 35 ? ? ? ? 57 85 F6 74 ? 8B 7D 08 8B 4E 04 8B C7 8A 11 3A 10");
                Signatures.dwLocalPlayer = SigScan.ScanPattern(Modules.ClientDLLName, "8D 34 85 ? ? ? ? 89 15 ? ? ? ? 8B 41 08 8B 48 04 83 F9 FF", 3, 4, true);
                Signatures.dwMouseEnable = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? FF 50 34 85 C0 75 10", 1, 48, true);
                Signatures.dwMouseEnablePtr = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? FF 50 34 85 C0 75 10", 1, 0, true);
                Signatures.dwPlayerResource = SigScan.ScanPattern(Modules.ClientDLLName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true);
                Signatures.dwRadarBase = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 8B 0C B0 8B 01 FF 50 ? 46 3B 35 ? ? ? ? 7C EA 8B 0D", 1, 0, true);
                Signatures.dwSensitivity = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 18 35 ? ? ? ? 89 44 24 0C EB 0B", 2, 44, true);
                Signatures.dwSensitivityPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 18 35 ? ? ? ? 89 44 24 0C EB 0B", 2, 0, true);
                Signatures.dwSetClanTag = SigScan.ScanPatterna(Modules.EngineDLLName, "53 56 57 8B DA 8B F9 FF 15").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.dwViewMatrix = SigScan.ScanPattern(Modules.ClientDLLName, "0F 10 05 ? ? ? ? 8D 85 ? ? ? ? B9", 3, 176, false);
                Signatures.dwWeaponTable = SigScan.ScanPattern(Modules.ClientDLLName, "B9 ? ? ? ? 6A 00 FF 50 08 C3", 1, 0, true);
                Signatures.dwWeaponTableIndex = SigScan.ScanPattern(Modules.ClientDLLName, "39 86 ? ? ? ? 74 06 89 86 ? ? ? ? 8B 86", 2, 0, true);
                Signatures.dwYawPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1D F3 0F 10 05 ? ? ? ? F3 0F 11 44 24 ? 8B 44 24 1C 35 ? ? ? ? 89 44 24 18 EB 0B 8B 01 8B 40 30 FF D0 D9 5C 24 18 F3 0F 10 06", 2, 0, true);
                Signatures.dwZoomSensitivityRatioPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 1A F3 0F 10 05 ? ? ? ? F3 0F 11 45 ? 8B 45 F4 35 ? ? ? ? 89 45 FC EB 0A 8B 01 8B 40 30 FF D0 D9 5D FC A1", 2, 0, true);
                Signatures.dwbSendPackets = SigScan.ScanPattern(Modules.EngineDLLName, "B3 01 8B 01 8B 40 10 FF D0 84 C0 74 0F 80 BF ? ? ? ? ? 0F 84", 0, 1, true);
                Signatures.dwppDirect3DDevice9 = SigScan.ScanPattern(Modules.ShaderAPIName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true);
                Signatures.m_pStudioHdr = SigScan.ScanPattern(Modules.ClientDLLName, "8B B6 ? ? ? ? 85 F6 74 05 83 3E 00 75 02 33 F6 F3 0F 10 44 24", 2, 0, true);
                Signatures.m_yawClassPtr = SigScan.ScanPattern(Modules.ClientDLLName, "81 F9 ? ? ? ? 75 16 F3 0F 10 05 ? ? ? ? F3 0F 11 45 ? 81 75 ? ? ? ? ? EB 0A 8B 01 8B 40 30 FF D0 D9 5D 0C 8B 55 08", 2, 0, true);
                Signatures.m_pitchClassPtr = SigScan.ScanPattern(Modules.ClientDLLName, "A1 ? ? ? ? 89 74 24 28", 1, 0, true);
                Signatures.interface_engine_cvar = SigScan.ScanPattern(Modules.VSTDLibDLLName, "8B 0D ? ? ? ? C7 05", 2, 0, true);
                Signatures.convar_name_hash_table = SigScan.ScanPattern(Modules.VSTDLibDLLName, "8B 3C 85", 3, 0, true);
                Signatures.m_bDormant = SigScan.ScanPattern(Modules.ClientDLLName, "8A 81 ? ? ? ? C3 32 C0", 2, 8, false);
                Signatures.model_ambient_min = SigScan.ScanPattern(Modules.EngineDLLName, "F3 0F 10 0D ? ? ? ? F3 0F 11 4C 24 ? 8B 44 24 20 35 ? ? ? ? 89 44 24 0C", 4, 0, true);
                Signatures.set_abs_angles = SigScan.ScanPatterna(Modules.ClientDLLName, "55 8B EC 83 E4 F8 83 EC 64 53 56 57 8B F1 E8").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.set_abs_origin = SigScan.ScanPatterna(Modules.ClientDLLName, "55 8B EC 83 E4 F8 51 53 56 57 8B F1 E8").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.is_c4_owner = SigScan.ScanPatterna(Modules.ClientDLLName, "56 8B F1 85 F6 74 31").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.force_update_spectator_glow = SigScan.ScanPatterna(Modules.ClientDLLName, "74 07 8B CB E8 ? ? ? ? 83 C7 10").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Signatures.anim_overlays = SigScan.ScanPattern(Modules.ClientDLLName, "8B 89 ? ? ? ? 8D 0C D1", 2, 0, true);
                Signatures.m_flSpawnTime = SigScan.ScanPattern(Modules.ClientDLLName, "89 86 ? ? ? ? E8 ? ? ? ? 80 BE ? ? ? ? ?", 2, 0, true);
                Signatures.find_hud_element = SigScan.ScanPatterna(Modules.ClientDLLName, "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7").ToInt32() - Modules.EngineDLLAdress.ToInt32();
                Logger.LSDebug.PrintLine("Signature scan success!", LSDebug.TextType.Success);
            }
            catch (Exception ex)
            {
                Logger.LSDebug.PrintLine(string.Format("Failed to get signatures. {0} \n Exception: {1}", Logger.GetCurrentMethodName(), ex), LSDebug.TextType.Failed);
            }
        }
        private static void GetNetvars()
        {
            try 
            {
                NetvarManager.Init();
                Netvars.m_vecViewOffset = NetvarManager.Table["DT_CSPlayer"]["m_vecViewOffset[0]"];
                Netvars.m_vecOrigin = NetvarManager.Table["DT_CSPlayer"]["m_vecOrigin"];
                Netvars.m_szLastPlaceName = NetvarManager.Table["DT_CSPlayer"]["m_szLastPlaceName"];
                Netvars.m_szCustomName = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_szCustomName"];
                Netvars.m_OriginalOwnerXuidHigh = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_OriginalOwnerXuidHigh"];
                Netvars.m_OriginalOwnerXuidLow = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_OriginalOwnerXuidLow"];
                Netvars.m_nFallbackStatTrak = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_nFallbackStatTrak"];
                Netvars.m_nFallbackSeed = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_nFallbackSeed"];
                Netvars.m_nFallbackPaintKit = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_nFallbackPaintKit"];
                Netvars.m_iTeamNum = NetvarManager.Table["DT_CSPlayer"]["m_iTeamNum"];
                Netvars.m_iObserverMode = NetvarManager.Table["DT_CSPlayer"]["m_iObserverMode"];
                Netvars.m_iItemIDHigh = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_iItemIDHigh"];
                Netvars.m_iItemDefinitionIndex = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_iItemDefinitionIndex"];
                Netvars.m_iHealth = NetvarManager.Table["DT_CSPlayer"]["m_iHealth"];
                Netvars.m_iFOV = NetvarManager.Table["DT_CSPlayer"]["m_iFOV"];
                Netvars.m_iEntityQuality = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_iEntityQuality"];
                Netvars.m_iCrosshairId = NetvarManager.Table["DT_CSPlayer"]["m_bHasDefuser"] + 92;
                Netvars.m_hMyWeapons = NetvarManager.Table["DT_CSPlayer"]["m_hMyWeapons"];
                Netvars.m_hActiveWeapon = NetvarManager.Table["DT_CSPlayer"]["m_hActiveWeapon"];
                Netvars.m_flFallbackWear = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_flFallbackWear"];
                Netvars.m_fFlags = NetvarManager.Table["DT_CSPlayer"]["m_fFlags"];
                Netvars.m_dwBoneMatrix = NetvarManager.Table["DT_BaseAnimating"]["m_nForceBone"] + 28;
                Netvars.m_bSpottedByMask = NetvarManager.Table["DT_CSPlayer"]["m_bSpottedByMask"];
                Netvars.m_bIsScoped = NetvarManager.Table["DT_CSPlayer"]["m_bIsScoped"];
                Netvars.m_bHasHelmet = NetvarManager.Table["DT_CSPlayer"]["m_bHasHelmet"];
                Netvars.m_ArmorValue = NetvarManager.Table["DT_CSPlayer"]["m_ArmorValue"];
                Netvars.m_aimPunchAngle = NetvarManager.Table["DT_CSPlayer"]["m_aimPunchAngle"];
                Netvars.m_iShotsFired = NetvarManager.Table["DT_CSPlayer"]["m_iShotsFired"];
                Netvars.m_flFlashMaxAlpha = NetvarManager.Table["DT_CSPlayer"]["m_flFlashMaxAlpha"];
                Netvars.m_flFlashDuration = NetvarManager.Table["DT_CSPlayer"]["m_flFlashDuration"];
                Netvars.m_bSpotted = NetvarManager.Table["DT_CSPlayer"]["m_bSpotted"];
                Netvars.m_flHealthShotBoostExpirationTime = NetvarManager.Table["DT_CSPlayer"]["m_flHealthShotBoostExpirationTime"];
                Netvars.m_iGlowIndex = NetvarManager.Table["DT_CSPlayer"]["m_flFlashDuration"] + 24;
                Netvars.m_nViewModelIndex = NetvarManager.Table["DT_PredictedViewModel"]["m_nViewModelIndex"];
                Netvars.m_nModelIndex = NetvarManager.Table["DT_CSPlayer"]["m_nModelIndex"];
                Netvars.m_iDefaultFOV = NetvarManager.Table["DT_CSPlayer"]["m_iDefaultFOV"];
                Netvars.m_zoomLevel = NetvarManager.Table["DT_WeaponCSBaseGun"]["m_zoomLevel"];
                Netvars.m_totalHitsOnServer = NetvarManager.Table["DT_CSPlayer"]["m_totalHitsOnServer"];
                Logger.LSDebug.PrintLine("Netvar scan success!", LSDebug.TextType.Success);
            }
            catch (Exception ex)
            {
                Logger.LSDebug.PrintLine(string.Format("Failed to get netvars. {0} \n Exception: {1}", Logger.GetCurrentMethodName(), ex), LSDebug.TextType.Failed);
            }
        }
    }
}
