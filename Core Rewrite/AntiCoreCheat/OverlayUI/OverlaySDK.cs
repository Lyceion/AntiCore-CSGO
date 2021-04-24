using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace AntiCoreCheat.OverlayUI
{
    class OverlaySDK : Form
    {
        #region Structures And Enumerations
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        internal enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x1,
            CreateThread = 0x2,
            VMOperation = 0x8,
            VMRead = 0x10,
            VMWrite = 0x20,
            DupHandle = 0x40,
            SetInformation = 0x200,
            QueryInformation = 0x400,
            Synchronize = 0x100000
        }
        #endregion
        #region WinAPI Imports
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
        #endregion
        #region Function Layer 1
        IntPtr GetProcessHandle(string name)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process item in processes)
            {
                if (item.ProcessName == name) 
                    return OpenProcess(ProcessAccessFlags.All,false,item.Id);
            }
            return IntPtr.Zero;

        }
        #endregion
        #region Function Layer 2
        void InitializeComponents(object sender, EventArgs e)
        {
            BackColor = Color.Wheat;
            TransparencyKey = Color.Wheat;
            //TransparencyKey = Color.Wheat;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            refreshInterval = new Timer
            {
                Interval = 20,

            };
            refreshInterval.Tick += IntervalTick;
            refreshInterval.Start();
            Paint += PaintObjects;

        }
        private void IntervalTick(object sender, EventArgs e)
        {
            RECT wRect = new RECT();
            if (!GetWindowRect(TargetHandle, ref wRect))
            {
                failed = true;
                return;
            }
            displayRect = new Rectangle(
                wRect.Left + 3,
                wRect.Top + 26,
                wRect.Right - wRect.Left - 6,
                wRect.Bottom - wRect.Top - 29
            );

            if (!MoveWindow(
                    this.Handle,
                    displayRect.X,
                    displayRect.Y,
                    displayRect.Width,
                    displayRect.Height,
                    true
                    )) failed = true;
            Logger.LSDebug.SetVariable("Top", wRect.Top, "CSGO Rectangle");
            Logger.LSDebug.SetVariable("Right", wRect.Right, "CSGO Rectangle");
            Logger.LSDebug.SetVariable("Bottom", wRect.Bottom, "CSGO Rectangle");
            Logger.LSDebug.SetVariable("Left", wRect.Left, "CSGO Rectangle");
        }
        private void PaintObjects(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen selPen = new Pen(Color.Blue,5))
            {
                g.DrawRectangle(selPen, 0, 0, displayRect.Width, displayRect.Height);
            }
        }
        #endregion
        #region Variable Layer 1
        private IntPtr TargetHandle;
        Rectangle displayRect;
        public bool isReady = false;
        private bool failed_ = false;
        public bool failed {
            get
            {
                return failed_;
            }
            set
            {
                if (value)
                {
                    Logger.LSDebug.PrintLine("Failed", LSDebug.TextType.Danger);
                    refreshInterval.Stop();
                    this.Hide();
                }
                failed_ = value;
            }
        }
        #endregion
        #region Variable Layer 2
        private Timer refreshInterval;
        
        #endregion
        public OverlaySDK() : base()
        {
            //Logger.LSDebug.PrintLine(String.Format("{0} Searching...", targetProcess), LSDebug.TextType.Success);
            IntPtr hWnd = SDK.Memory.CylMemLite.hProcess.MainWindowHandle;//GetProcessHandle(targetProcess);
            if (hWnd != IntPtr.Zero)
            {
                isReady = true;
                TargetHandle = hWnd;
                Logger.LSDebug.PrintLine(String.Format("Valid handle for overlay => {0:X}",TargetHandle), LSDebug.TextType.Success);
                Load += new System.EventHandler(InitializeComponents);
                this.Show();
            }
            else
            {
                Logger.LSDebug.PrintLine("Invalid handle", LSDebug.TextType.Danger);
                failed = true;
            }
        }
        
        
    }
}
