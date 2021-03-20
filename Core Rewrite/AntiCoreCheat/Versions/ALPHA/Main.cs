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
            WindowsUI.Design.Aero.ChangeAccent(Handle, new WindowsUI.Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = WindowsUI.Enums.AccentState.ACCENT_DISABLED }, false);
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
            WindowsUI.Design.Aero.ChangeAccent(Handle, new WindowsUI.Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = WindowsUI.Enums.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND }, false);
            Opacity = 1.0f;
        }

        public Main()
        {
            InitializeComponent();
            WindowsUI.Design.Shadow.AddShadow(this.Handle);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WindowsUI.Design.Aero.ChangeAccent(Handle, new WindowsUI.Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = WindowsUI.Enums.AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND }, false);
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
            Logger.LSDebug.PrintLine(string.Format("{0} -> 0x{1}", nameof(Signatures.force_update_spectator_glow), Signatures.force_update_spectator_glow.ToString("X")));
            ThreadsCore.PlayerThread.Start();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            do
            {
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            } while (CylMemLite.CRead<byte>(Modules.ClientDLLAdress + Signatures.force_update_spectator_glow) != 116);
            Environment.Exit(69);
        }
    }
}
