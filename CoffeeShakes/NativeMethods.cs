using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CoffeeShakes
{
    internal class NativeMethods
    {
        [StructLayout(LayoutKind.Explicit)]
        internal struct INPUT
        {
            [FieldOffset(0)]
            public int TYPE;
#if x86
            [FieldOffset(4)]
#else
            [FieldOffset(8)]
#endif
            public MOUSEINPUT mi;

        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEINPUT
        {
            [FieldOffset(0)]
            public int dx;
            [FieldOffset(4)]
            public int dy;
            [FieldOffset(8)]
            public int mouseData;
            [FieldOffset(12)]
            public int dwFlags;
            [FieldOffset(16)]
            public int time;
            [FieldOffset(20)]
            public IntPtr dwExtraInfo;

        }

        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public const int INPUT_MOUSE = 0;
        public const int MOUSEEVENTF_MOVE = 0x0001;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

    }
}
