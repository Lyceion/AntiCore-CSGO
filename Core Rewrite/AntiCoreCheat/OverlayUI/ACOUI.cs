using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCoreCheat.OverlayUI
{
    class ACOUI
    {
        private OverlaySDK root;
        public ACOUI()
        {
            Logger.LSDebug.PrintLine("Overlay initializing",LSDebug.TextType.Info);
            this.root = new OverlaySDK();
            Logger.LSDebug.PrintLine("Overlay initialized", LSDebug.TextType.Info);
        }
    }
}
