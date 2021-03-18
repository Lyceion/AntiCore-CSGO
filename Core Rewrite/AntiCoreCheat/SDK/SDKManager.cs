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
        public static Enums.InitalizeResult SDK_Initalize()
        {
            try
            {
                Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + " has been invoked!", LSDebug.TextType.Safe);
                Process[] p = Process.GetProcessesByName("csgo");
                if (p.Length != 0)
                {
                    Application.DoEvents();
                    Process game = p.FirstOrDefault();
                    CylMemLite.OpenProcess(game.Id);
                    Modules.Initalize();
                    Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + ", Status : " + Enums.InitalizeResult.Succes, LSDebug.TextType.Success);
                    Logger.LSDebug.EnableVariableDebugger();
                    Application.DoEvents();
                    Logger.LSDebug.SetVariable("Process ID", game.Id);
                    Logger.LSDebug.PrintLine(string.Format("Process ID Found! ({0}) -> {1}", string.Format("{0}.exe",game.ProcessName), game.Id.ToString()), LSDebug.TextType.Info);
                    Application.DoEvents();
                    Logger.LSDebug.SetVariable("Process Handle", CylMemLite.ProcessHandle);
                    Logger.LSDebug.PrintLine(string.Format("Process Handle Opened. (0x{0})", CylMemLite.ProcessHandle.ToString("X")), LSDebug.TextType.Info);
                    Application.DoEvents();
                    Logger.LSDebug.SetVariable("Client Address", Modules.ClientDLLAdress);
                    Logger.LSDebug.PrintLine("Client module found!", LSDebug.TextType.Info);
                    Application.DoEvents();
                    Logger.LSDebug.SetVariable("Engine Address", Modules.EngineDLLAdress);
                    Logger.LSDebug.PrintLine("Engine module found!", LSDebug.TextType.Info);
                    Application.DoEvents();
                    Game.Offsets.OffsetsManager.InitializeOffsetManager();
                    Application.DoEvents();
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
