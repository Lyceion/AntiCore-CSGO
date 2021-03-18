using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AntiCoreCheat.Design
{
    class Shadow
    {
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public static void AddShadow(IntPtr HWnd)
        {
            SetClassLong(HWnd, GCL_STYLE, GetClassLong(HWnd, GCL_STYLE) | CS_DropSHADOW);
        }
    }
}
