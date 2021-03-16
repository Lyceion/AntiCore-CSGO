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
                    Logger.Log.PrintLine(Logger.GetCurrentMethodName() + ", Status Code : " + (int)Enums.InitalizeResult.Succes, LSDebug.TextType.Success);
                    Logger.Log.PrintLine(" Status Information ");
                    Logger.Log.PrintLine(" Process Id => " + game.Id);
                    Logger.Log.PrintLine(" Process Handle => 0x" + CylMemLite.ProcessHandle.ToString("X"));
                    Logger.Log.PrintLine(" Client => 0x" + Modules.Client.ToString("X"));
                    Logger.Log.PrintLine(" Engine => 0x" + Modules.Engine.ToString("X"));
                    Logger.Log.PrintLine(" -------------------------------------------------------- ");
                    return Enums.InitalizeResult.Succes;
                }
                else
                {
                    Logger.Log.PrintLine(Logger.GetCurrentMethodName() + ", Error Code : " + (int)Enums.InitalizeResult.ProcessNotWorking, LSDebug.TextType.Failed);
                    return Enums.InitalizeResult.ProcessNotWorking;
                }
            } 
            catch
            {
                Logger.Log.PrintLine(Logger.GetCurrentMethodName() + ", Error Code : " + (int)Enums.InitalizeResult.ProcessNotWorking, LSDebug.TextType.Failed);
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
