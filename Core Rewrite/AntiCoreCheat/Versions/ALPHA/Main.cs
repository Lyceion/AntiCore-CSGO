using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Versions.ALPHA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SDK.SDKManager.Enums.InitalizeResult Result = SDK.SDKManager.Initalize();
            if(Result == SDK.SDKManager.Enums.InitalizeResult.Succes)
            {
                Logger.Log.PrintLine(Logger.GetCurrentMethodName() + " has been invoked!", LSDebug.TextType.Info);
            }
            else
            {
                MessageBox.Show("Error : " + Result.ToString(), "AntiCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Log.SaveLogs();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
