using AntiCoreCheat.SDK.Game;
using AntiCoreCheat.SDK.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.SDK
{
    class SDKManager
    {
        public static Enums.InitalizeResult Initalize()
        {
            try
            {
                Process[] p = Process.GetProcessesByName("csgo");
                if (p.Length != 0)
                {
                    Process game = p.FirstOrDefault();
                    CylMemLite.OpenProcess(game.Id);
                    Modules.Initalize();
                    Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + ", Status : " + Enums.InitalizeResult.Succes, LSDebug.TextType.Success);
                    Logger.LSDebug.EnableVariableDebugger();
                    Logger.LSDebug.SetVariable("Process ID", game.Id);
                    Logger.LSDebug.SetVariable("Process Handle", CylMemLite.ProcessHandle);
                    Logger.LSDebug.SetVariable("Client Address", Modules.ClientDLLAdress);
                    Logger.LSDebug.SetVariable("Engine Address", Modules.EngineDLLAdress);
                    Game.Offsets.OffsetsManager.InitializeOffsetManager();
                    return Enums.InitalizeResult.Succes;
                }
                else
                {
                    Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + ", Error Code : " + (int)Enums.InitalizeResult.ProcessNotWorking, LSDebug.TextType.Failed);
                    return Enums.InitalizeResult.ProcessNotWorking;
                }
            } 
            catch
            {
                Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + ", Error Code : " + (int)Enums.InitalizeResult.ProcessNotWorking, LSDebug.TextType.Failed);
                return Enums.InitalizeResult.Error;
            }
        }

        public static class Enums
        {
            public enum InitalizeResult
            {
                ProcessNotWorking,
                Error,
                Succes
            }
        }
    }
}
