using System.Diagnostics;
using System.Runtime.CompilerServices;

class Logger
{
    public static LSDebug.LSDebugUI LSDebug = new LSDebug.LSDebugUI { Text = "AntiCore Debug Console", StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen, TimeBool = false, ControlBox = false  /*, Symbolizator = true*/ };
    public static StackTrace Tracer = new StackTrace();

    public static string GetCurrentMethodName([CallerMemberName] string memberName = "")
    {
        return memberName;
    }
}
