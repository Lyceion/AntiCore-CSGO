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
        public static IntPtr ClientDLLAdress = IntPtr.Zero, EngineDLLAdress = IntPtr.Zero, ShaderAPIAdress = IntPtr.Zero, VSTDLibDLLAdress = IntPtr.Zero;
        public static string GameName = "csgo", ClientDLLName = "client.dll", EngineDLLName = "engine.dll", ShaderAPIName = "shaderapidx9.dll", VSTDLibDLLName = "vstdlib.dll";
        public static Process GameProcess;

        public static void Initalize()
        {
            do
            {
                try
                {
                    GameProcess = Process.GetProcessesByName(GameName).FirstOrDefault();
                }
                catch {}
            } while (Process.GetProcessesByName(GameName).Length <= 0);
            while (ClientDLLAdress == IntPtr.Zero || EngineDLLAdress == IntPtr.Zero)
            {
                ClientDLLAdress = GetModuleByName(ClientDLLName);
                EngineDLLAdress = GetModuleByName(EngineDLLName);
                ShaderAPIAdress = GetModuleByName(ShaderAPIName);
                VSTDLibDLLAdress = GetModuleByName(VSTDLibDLLName);
            }
        }

        private static IntPtr GetModuleByName(string moduleName)
        {
            foreach(ProcessModule module in GameProcess.Modules)
            {
                if(module.ModuleName == moduleName)
                {
                    return module.BaseAddress;
                }
            }
                return IntPtr.Zero;
        }
    }
}
