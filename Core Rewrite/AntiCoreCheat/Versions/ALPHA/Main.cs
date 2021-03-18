using AntiCoreCheat.Features;
using AntiCoreCheat.SDK.Game;
using AntiCoreCheat.SDK.Game.Offsets;
using AntiCoreCheat.SDK.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AntiCoreCheat.SDK.Classes.Structs;

namespace AntiCoreCheat.Versions.ALPHA
{
    public partial class Main : Form
    {
        static List<SDK.Entities.CSPlayer> PlayerList = new List<SDK.Entities.CSPlayer>();

        private bool mouseDown;
        private Point lastLocation;
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
            Design.Aero.ChangeAccent(Handle, new Design.Aero.AccentPolicy { GradientColor = 0xFD70000, AccentState = Design.Aero.AccentState.ACCENT_DISABLED }, false);
            Opacity = 0.85f;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Design.Aero.ChangeAccent(Handle, new Design.Aero.AccentPolicy { GradientColor = 0xFD70000, AccentState = Design.Aero.AccentState.ACCENT_ENABLE_ACRYLIC});
            Opacity = 1.0f;
        }

        public Main()
        {
            InitializeComponent();
            Design.Shadow.AddShadow(this.Handle);
        }

        //static Thread UpdatePlayersThrd = new Thread(new ThreadStart(UpdatePlayers));
        //static Thread UpdateDebuggerGridThrd = new Thread(new ThreadStart(UpdateDebuggerGrid));

        //static SDK.Entities.CSLocalPlayer LocalPlayer;

        private void Main_Load(object sender, EventArgs e)
        {
            Design.Aero.ChangeAccent(Handle, new Design.Aero.AccentPolicy { GradientColor = 0xFD70000, AccentState = Design.Aero.AccentState.ACCENT_ENABLE_ACRYLIC });
            SDK.SDKManager.Enums.InitalizeResult Result = SDK.SDKManager.SDK_Initalize();
            if(Result == SDK.SDKManager.Enums.InitalizeResult.Succes)
            {
                Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + " has been invoked!", LSDebug.TextType.Safe);
            }
            else
            {
                MessageBox.Show("Error : " + Result.ToString(), "AntiCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            Logger.LSDebug.ClearAllVariables();
            //UpdatePlayersThrd.Start();
            ThreadsCore.CoreThread.Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LSDebug.SaveLog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        //public static void UpdatePlayers()
        //{
        //    while(true)
        //    {
        //        Logger.LSDebug.PrintLine("Started player loop...", LSDebug.TextType.Info);
        //        if (Engine.GameState == SDK.Classes.Enums.GameState.FULL)
        //        {
        //            var sw = new Stopwatch();
        //            sw.Start();
        //            for (int i = 0; i <= SDK.Game.Engine.MaxPlayer; i++)
        //            {
        //                SDK.Entities.CSPlayer Player = new SDK.Entities.CSPlayer(i);
        //                if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != LocalPlayer.EntityIndex && Player.Name != LocalPlayer.Name && LocalPlayer.BaseAddress != Player.BaseAddress)
        //                {
        //                    PlayerList.Add(Player);
        //                }
        //            }
        //            sw.Stop();
        //            Logger.LSDebug.PrintLine(string.Format("Updated Players. ({0} Players in list.) - Elapsed time: {1}ms", PlayerList.Count, sw.ElapsedMilliseconds), LSDebug.TextType.Success);
        //            UpdateDebuggerGrid();
        //        }
        //    }
        //}

        //public static void UpdateDebuggerGrid()
        //{
        //    Logger.LSDebug.PrintLine("Started datagrid loop...", LSDebug.TextType.Info);
        //    while (true)
        //    {
        //        foreach (var Player in PlayerList)
        //        {
        //            Logger.LSDebug.SetVariable(Player.Name, Player.Health);
        //            Player.Glow(255f, 0, 0f);
        //        }
        //        Thread.Sleep(300);
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(69);
        }
    }
}
