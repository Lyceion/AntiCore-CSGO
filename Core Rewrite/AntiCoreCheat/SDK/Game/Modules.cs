using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.SDK.Game
{
    class Modules
    {
        public static IntPtr Client = IntPtr.Zero, Engine = IntPtr.Zero;
        public static string ClientStr = "client.dll", EngineStr = "engine.dll";

        public static void Initalize()
        {
            while (Client == IntPtr.Zero || Engine == IntPtr.Zero)
            {
                Client = GetProcessByName("csgo", ClientStr);
                Engine = GetProcessByName("csgo", EngineStr);
            }
        }

        public static IntPtr GetProcessByName(string process_name, string moduleName)
        {
            Process[] p = Process.GetProcessesByName(process_name);
            if(p.Length != 0) // On Game Working
            {
                Process game = p.FirstOrDefault();
                foreach(ProcessModule module in game.Modules)
                {
                    if(module.ModuleName == moduleName)
                    {
                        return module.BaseAddress;
                    }
                }
                return IntPtr.Zero;
            }
            else // Game not found!
            {
                return IntPtr.Zero;
            }
        }
    }
}
