using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Versions
{
    class Globals
    {
        public struct CheatInfoTemplate
        {
            public string name;
            public Version version;
            public Form CheatForm;
        };
        public class version_Alpha
        {
            public static CheatInfoTemplate VersionAlphaInfo = new CheatInfoTemplate
            {
                name = "ALPHA",
                version = new Version(0, 1, 8, 0),
                CheatForm = new ALPHA.Main()
            };
            public static Thread CoreThread = new Thread(new ThreadStart(Features.ThreadsCore.AntiCore));
            public static Thread PlayerThread = new Thread(new ThreadStart(Features.ThreadsCore.PlayerLoop));
        }

    }
}
