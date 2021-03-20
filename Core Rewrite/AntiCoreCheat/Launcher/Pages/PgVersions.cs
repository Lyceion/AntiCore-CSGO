using AntiCoreCheat.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Launcher.Pages
{
    public partial class PgVersions : UserControl
    {
        public PgVersions()
        {
            InitializeComponent();
        }

        private void PgVersions_Load(object sender, EventArgs e)
        {
            MicrosoftGrabber.GetUserPicturePath(null, out var temp);
            pbUserInfo.ImageLocation = temp;
            lblWelcome.Text = string.Format("Welcome, {0}!", Environment.UserName);
        }

        private void btnLoadCheat_Click(object sender, EventArgs e)
        {
            Parent.Parent.Hide();
            Application.DoEvents();
            Versions.Globals.VersionMainCheatForm.Show();
        }
    }
}
