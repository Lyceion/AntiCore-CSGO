using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.SDK.Functions
{
    class Helpers
    {
        [VMProtect.BeginUltra]
        public static async Task Sleep(double msec)
        {
            for (var since = DateTime.Now; (DateTime.Now - since).TotalMilliseconds < msec;)
            {
                Application.DoEvents();
                await Task.Delay(TimeSpan.FromTicks(10));
            }
        }
    }
}
