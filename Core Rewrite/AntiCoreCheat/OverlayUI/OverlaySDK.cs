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
            public int Left;       
            public int Top;        
            public int Right;      
            public int Bottom;    
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

        enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,

            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,

            WS_CAPTION = WS_BORDER | WS_DLGFRAME,
            WS_TILED = WS_OVERLAPPED,
            WS_ICONIC = WS_MINIMIZE,
            WS_SIZEBOX = WS_THICKFRAME,
            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_CHILDWINDOW = WS_CHILD,


            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,


            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,

            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,

            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,

            WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
            WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

            WS_EX_LAYERED = 0x00080000,

            WS_EX_NOINHERITLAYOUT = 0x00100000,
            WS_EX_LAYOUTRTL = 0x00400000, 

            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_NOACTIVATE = 0x08000000

        }

        public enum GetWindowLongConst
        {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2,
        }
        #endregion
        #region WinAPI Imports
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);
        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
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
        class RectStater{
            public RectStater(int i,Rectangle r)
            {
                Entity = i;
                rect = r;
            }
            public int Entity;
            public Rectangle rect;
        }
        List<RectStater> rects = new List<RectStater>();
        int counto = 0;
        void InitializeComponents(object sender, EventArgs e)
        {
            BackColor = Color.Wheat;
            TransparencyKey = Color.Wheat;
            FormBorderStyle = FormBorderStyle.None;
            //int csgoWindowLong = GetWindowLong(SDK.Memory.CylMemLite.hProcess.MainWindowHandle, (int)GetWindowLongConst.GWL_STYLE);
            //Logger.LSDebug.PrintLine(String.Format("WindowLong : {0:X}", csgoWindowLong), LSDebug.TextType.Info);
            //if((csgoWindowLong & (int)WindowStyles.WS_MAXIMIZE) > 0)
            //{
            //    Logger.LSDebug.PrintLine("Screen mode : Borderless",LSDebug.TextType.Info);
            //}
            //else
            //{
            //    Logger.LSDebug.PrintLine("Screen mode : Window", LSDebug.TextType.Info);
            //}
            //oldWindowLong = GetWindowLong(Handle, (int)GetWindowLongConst.GWL_EXSTYLE);
            SetWindowLong(
                Handle,
                (int)GetWindowLongConst.GWL_EXSTYLE,
                Convert.ToInt32(
                    oldWindowLong | 
                    (uint)WindowStyles.WS_EX_LAYERED |
                    (uint)WindowStyles.WS_EX_TRANSPARENT)
                );
            //SetLayeredWindowAttributes(Handle, (uint)Color.Wheat.ToArgb(), 125, 0x2);
            TopMost = true;
            
            refreshInterval = new Timer
            {
                Interval = 13,

            };
            refreshInterval.Enabled = true;
            refreshInterval.Tick += IntervalTick;
            refreshInterval.Start();
            Paint += PaintObjects;
            


        }
        private void IntervalTick(object sender, EventArgs e)
        {
            //RECT wRect = new RECT();
            //if (!GetWindowRect(TargetHandle, ref wRect))
            //{
            //    failed = true;
            //    return;
            //}
            //displayRect = new Rectangle(
            //    wRect.Left,
            //    wRect.Top,
            //    wRect.Right - wRect.Left,
            //    wRect.Bottom - wRect.Top
            //);
            //Logger.LSDebug.SetVariable("W-Top", wRect.Top, "CSGO Display");
            //Logger.LSDebug.SetVariable("W-Right", wRect.Right, "CSGO Display");
            //Logger.LSDebug.SetVariable("W-Bottom", wRect.Bottom, "CSGO Display");
            //Logger.LSDebug.SetVariable("W-Left", wRect.Left, "CSGO Display");
            TopMost = GetForegroundWindow() == TargetHandle; 
            RECT cRect = new RECT();
            clientPos = new Point(0, 0);
            if (!GetClientRect(TargetHandle, ref cRect))
            {
                failed = true;
                return;
            }
            if (!ClientToScreen(TargetHandle, ref clientPos))
            {
                failed = true;
                return;
            }
            
            clientRect = new Rectangle(
                clientPos.X,
                clientPos.Y,
                cRect.Right - cRect.Left,
                cRect.Bottom - cRect.Top
            );
            if (!MoveWindow(
                    this.Handle,
                    clientRect.X,
                    clientRect.Y,
                    clientRect.Width,
                    clientRect.Height,
                    true
                    )) failed = true;
            Invalidate();
            //float[,] viewMatrix = SDK.SDKGlobals.LocalPlayer.ViewMatrix;
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        //Logger.LSDebug.PrintLine(String.Format("V{0}{1} : {2}", i + 1, j + 1, viewMatrix[i, j]), LSDebug.TextType.Success);
            //        //Logger.LSDebug.SetVariable(String.Format("V{0}{1}", i + 1, j + 1), viewMatrix[i, j], "ViewMatrix");
            //    }
            //}

            //for (int i = 0; i < SDK.Game.Engine.EntityCount; i++)
            //{
            //    SDK.Entities.CSPlayer player = new SDK.Entities.CSPlayer(i);
            //}
            //try
            //{


            //for (int i = 0; i < 64; i++)
            //{
            //    SDK.Entities.CSPlayer Player = new SDK.Entities.CSPlayer(i);
            //    if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != Features.ThreadsCore.LocalPlayer.EntityIndex && Player.Name != Features.ThreadsCore.LocalPlayer.Name && Features.ThreadsCore.LocalPlayer.BaseAddress != Player.BaseAddress)
            //    {
            //        float[] Position = Player.Position();
            //        float[] screenPos = { clientRect.X, clientRect.Y };
            //        SDK.Functions.Parsers.WorldToScreen(viewMatrix, ref Position, ref screenPos, clientRect);

            //        //Logger.LSDebug.SetVariable("SX",screenPos[0],player.Name);
            //        //Logger.LSDebug.SetVariable("SY", screenPos[1], player.Name);
            //        bool iF = false;

            //        foreach (RectStater r in rects)
            //        {
            //            if (Player.EntityIndex == r.Entity)
            //            {
            //                iF = true;
            //                r.rect.X = (int)screenPos[0];
            //                r.rect.Y = (int)screenPos[1];
            //                r.rect.Width = 20;
            //                r.rect.Height = 20;
            //                break;
            //            }
            //        }
            //        if (!iF) rects.Add(new RectStater(Player.EntityIndex, new Rectangle(new Point((int)screenPos[0], (int)screenPos[1]), new Size(20, 20))));
            //    counto = rects.Count;
            //    }
            //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //Logger.LSDebug.SetVariable("CX", clientPos.X, "CSGO Display");
            //Logger.LSDebug.SetVariable("CY", clientPos.Y, "CSGO Display");
            //Logger.LSDebug.SetVariable("Player Count", AntiCoreCheat.Features.ThreadsCore.PlayerList.Count, "CSGO Ingame");
            //Logger.LSDebug.SetVariable("C-Top", cRect.Top, "CSGO Client");
            //Logger.LSDebug.SetVariable("C-Right", cRect.Right, "CSGO Client");
            //Logger.LSDebug.SetVariable("C-Bottom", cRect.Bottom, "CSGO Client");
            //Logger.LSDebug.SetVariable("C-Left", cRect.Left, "CSGO Client");

        }
        private void PaintObjects(object sender, PaintEventArgs e)
        {
            try
            {


                Graphics g = e.Graphics;
                g.Clear(Color.Wheat);

                using (Pen selPen = new Pen(Color.Red, 1))
                {

                    g.DrawRectangle(selPen, 0, 0, clientRect.Width-1, clientRect.Height-1);
                    float[,] viewMatrix = SDK.SDKGlobals.LocalPlayer.ViewMatrix;
                    for (int i = 0; i < 64; i++)
                    {
                        SDK.Entities.CSPlayer Player = new SDK.Entities.CSPlayer(i);
                        if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != Features.ThreadsCore.LocalPlayer.EntityIndex && Player.Name != Features.ThreadsCore.LocalPlayer.Name && Features.ThreadsCore.LocalPlayer.BaseAddress != Player.BaseAddress)
                        {
                            float[] Position = Player.Position();
                            float[] screenPos = { clientRect.X, clientRect.Y };
                            if(SDK.Functions.Parsers.WorldToScreen(viewMatrix, ref Position, ref screenPos, clientRect)) { 
                            g.DrawRectangle(selPen, screenPos[0], screenPos[1], 20, 20);

                            Logger.LSDebug.SetVariable("SX", Position[0], Player.Name);
                            Logger.LSDebug.SetVariable("SY", Position[1], Player.Name);
                            Logger.LSDebug.SetVariable("SZ", Position[2], Player.Name);
                            }
                            //bool iF = false;

                            //foreach (RectStater r in rects)
                            //{
                            //    if (Player.EntityIndex == r.Entity)
                            //    {
                            //        iF = true;
                            //        r.rect.X = (int)screenPos[0];
                            //        r.rect.Y = (int)screenPos[1];
                            //        r.rect.Width = 20;
                            //        r.rect.Height = 20;
                            //        break;
                            //    }
                            //}
                            //if (!iF) rects.Add(new RectStater(Player.EntityIndex, new Rectangle(new Point((int)screenPos[0], (int)screenPos[1]), new Size(20, 20))));
                            //counto = rects.Count;
                        }
                    }
                    //    Logger.LSDebug.SetVariable("Rect Count", rects.Count, "CSGO Display");
                    //    if (rects.Count > 0) {
                    //        List<RectStater> rr = new List<RectStater>(rects);
                    //        for (int i = 0; i < counto; i++)
                    //        {
                    //            RectStater rect = rects[i];
                    //            Logger.LSDebug.SetVariable("CSGO WTS", rect.rect.X, "X" + rect.Entity.ToString());
                    //            Logger.LSDebug.SetVariable("CSGO WTS".ToString(), rect.rect.Y, "Y" + rect.Entity.ToString());
                    //            g.DrawRectangle(selPen, rect.rect.X, rect.rect.Y, rect.rect.Width, rect.rect.Height);

                    //        }
                    //}
                }
                //Logger.LSDebug.SetVariable("dwViewMatrix", String.Format("0x{0:X}", SDK.Game.Offsets.Signatures.dwViewMatrix-(int)SDK.Game.Modules.ClientDLLAdress), "Signatrues");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        #endregion
        #region Variable Layer 1
        private int oldWindowLong;
        private IntPtr TargetHandle;
        //Rectangle displayRect;
        Rectangle clientRect;
        Point clientPos = new Point();
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
