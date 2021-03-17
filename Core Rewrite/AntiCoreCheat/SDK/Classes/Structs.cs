using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AntiCoreCheat.SDK.Classes
{
    class Structs
    {
		[StructLayout(LayoutKind.Sequential)]
		public struct GlobalVars
		{
			public float realtime;                     // 0x0000
			public int simulationTicks;              // 0x0004
			public float absoluteframetime;            // 0x0008
			float idkWut;                    // 0x000C
			public float curtime;                      // 0x0010
			public float frametime;                    // 0x0014
			public int maxClients;                   // 0x0018
			int highASFInt;                // 0x001C
			public float interval_per_tick;            // 0x0020
			public float testicularSpacingDelta;       // 0x0024
			int junk69;                 // 0x0028
			public int network_protocol;             // 0x002C
			IntPtr junk1;                    // 0x0030
			bool junk2;                       // 0x0031
			 bool junk3;                 // 0x0032
		}
	}
}
