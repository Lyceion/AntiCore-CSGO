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
    public partial class Main : WindowsUI.WinForm
    {
        public Main()
        {
            InitializeComponent();
        }
        private void LoadOverlay()
        {
            AntiCoreCheat.SDK.SDKGlobals.oui = new AntiCoreCheat.OverlayUI.ACOUI();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            SDK.SDKManager.Enums.InitalizeResult Result = SDK.SDKManager.SDK_Initalize();
            LoadOverlay();
            if (Result == SDK.SDKManager.Enums.InitalizeResult.Succes)
                Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + " has been invoked!", LSDebug.TextType.Safe);
            else
                MessageBox.Show("Error : " + Result.ToString(), "AntiCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Logger.LSDebug.ClearAllVariables();
            Logger.LSDebug.PrintLine(string.Format("{0} -> 0x{1}", nameof(Signatures.force_update_spectator_glow), Signatures.force_update_spectator_glow.ToString("X")));
            Globals.version_Alpha.PlayerThread.Start();
            Globals.version_Alpha.CoreThread.Start();
            foreach(var x in Enum.GetValues(typeof(WindowsUI.Enums.AccentState)))
                comboBox1.Items.Add(x);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LSDebug.SaveLog();
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            Signatures.force_update_spectator_glow = SigScan.ScanPatterna(Modules.ClientDLLName, "EB 07 8B CB E8 ? ? ? ? 83 C7 10").ToInt32() - Modules.ClientDLLAdress.ToInt32();
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            Signatures.force_update_spectator_glow = SigScan.ScanPatterna(Modules.ClientDLLName, "EB 07 8B CB E8 ? ? ? ? 83 C7 10").ToInt32() - Modules.ClientDLLAdress.ToInt32();
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            Environment.Exit(0);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            Signatures.force_update_spectator_glow = SigScan.ScanPatterna(Modules.ClientDLLName, "EB 07 8B CB E8 ? ? ? ? 83 C7 10").ToInt32() - Modules.ClientDLLAdress.ToInt32();
            for (int i = 0; i < 50; i++)
                CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 116);
            Environment.Exit(0);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFormAccentState((WindowsUI.Enums.AccentState)comboBox1.SelectedItem);
        }
    }
}
