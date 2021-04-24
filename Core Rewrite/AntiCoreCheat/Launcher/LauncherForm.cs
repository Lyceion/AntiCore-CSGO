using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUI;

namespace AntiCoreCheat.Launcher
{
    public partial class LauncherForm : WinForm
    {
        public LauncherForm() : base()
        {
            InitializeComponent();
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
        }
        
        public static Pages.PgVersions Versions = new Pages.PgVersions();
        private void LauncherForm_Shown(object sender, EventArgs e)
        {
        #if DEBUG
                    Logger.LSDebug.Debug();
                    Logger.LSDebug.Icon = Icon;
        #endif
            Logger.LSDebug.PrintLine("This debugger is powered by LSDebugger. github/lysep-corp", Color.DarkOrange);
            Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + " has been invoked! Client Hello.", LSDebug.TextType.Safe);
            Versions.Dock = DockStyle.Fill;
            plMain.Controls.Add(Versions);
            BringToFront();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void LauncherForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
