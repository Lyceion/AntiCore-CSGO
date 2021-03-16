using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Logger
{
    public static LSDebug.LSDebugUI Log = new LSDebug.LSDebugUI { Text = "AntiCore Debug Console", StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen, TimeBool = false, ControlBox = false  /*, Symbolizator = true*/ };
    public static StackTrace Tracer = new StackTrace();

    public static string GetCurrentMethodName()
    {
        return Tracer.GetFrame(1).GetMethod().Name;
    }
}
