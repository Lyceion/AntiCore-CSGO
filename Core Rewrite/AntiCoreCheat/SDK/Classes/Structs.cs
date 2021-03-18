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

        [StructLayout(LayoutKind.Explicit)]
        public struct Color
        {
            [FieldOffset(0x0)]
            public float r;
            [FieldOffset(0x4)]
            public float g;
            [FieldOffset(0x8)]
            public float b;
            [FieldOffset(0xC)]
            public float a;
        }

        //Credits Dude719
        [StructLayout(LayoutKind.Explicit)]
        public struct GlowObject
        {
            [FieldOffset(0)]
            public int entity; //0x0
            [FieldOffset(0x4)]
            public Color color; //0x4
            [FieldOffset(0x14)]
            public double fill1; //0x14
            [FieldOffset(0x1C)]
            public float bloomAmount; //0x1C
            [FieldOffset(0x20)]
            public int fill2; //0x20
            [FieldOffset(0x24)]
            public bool renderWhenOccluded; //0x24
            [FieldOffset(0x25)]
            public bool renderWhenUnoccluded; //0x25
            [FieldOffset(0x26)]
            public bool fullBloomRender; // 0x26
            [FieldOffset(0x27)]
            public int fullBloomStencilTestValue; //0x27
            [FieldOffset(0x2B)]
            public int splitScreenSlot; //0x2B
            [FieldOffset(0x2F)]
            public int nextFreeSlot; //0x2F
            [FieldOffset(0x33)]
            public int fill3;
        }
    }
}
