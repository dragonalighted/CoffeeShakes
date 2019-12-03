using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CoffeeShakes
{
    public class JitterBug : IDisposable
    {

        public class JitterEventArg : EventArgs
        {
            public int DeltaX;
            public int DeltaY; 

            public DateTime Time;
            public int Pause;

            public JitterEventArg()
            {
                Time = DateTime.Now;
                
            }

            public JitterEventArg(int x, int y, int pause) : this()
            {
                DeltaX = x;
                DeltaY = y;
                Pause = pause;
            }

        }
        public event EventHandler<JitterEventArg> OnJitter;
        public event EventHandler OnRelax;

        private readonly System.Threading.Thread bug;

        private AutoResetEvent bide; 

        public int SleepDuration = 500;//5 * 60 * 1000;

        private int SleepDurationStart = 500;
        public readonly int SleepDurationEnd = 1 * 60 * 1000;
        
        private bool DoJitter;

        public Vector3 InitDeltaX = new Vector3(20, 0, 4);
        public Vector3 InitDeltaY = new Vector3(20, 0, 4);
        
        public int DeltaX = 10;
        public int DeltaY = 10;


        private bool doRun = true;
        public static bool zig = true;

        public bool IsRunning => DoJitter;

        public JitterBug()
        {
            bide = new AutoResetEvent(false);
            bug = new Thread(new ThreadStart(this.Run));
            bug.Start();
        }

        public void Dispose()
        {
            doRun = false;
            this.Relax();
         
        }

        private void Run()
        {
            while (doRun)
            {
                try
                {
                    if (DoJitter)
                    {
                        Jiggle(DeltaX, DeltaY);
                        OnJitter?.Invoke(this, new JitterEventArg(DeltaX, DeltaY, SleepDuration));
                        if (DeltaX > InitDeltaX.Y)
                            DeltaX = (int) Math.Max(InitDeltaX.Y, DeltaX - InitDeltaX.Z);
                        if (DeltaY > InitDeltaY.Y)
                            DeltaY = (int)Math.Max(InitDeltaY.Y, DeltaY - InitDeltaY.Z);
                    }

                    bide.WaitOne(SleepDuration);
                    if ((DeltaX <= InitDeltaX.Y || DeltaY <= InitDeltaY.Y) && SleepDuration < SleepDurationEnd)
                        SleepDuration = SleepDurationEnd; 
                }
                catch (ThreadAbortException)
                {
                    doRun = false;
                    return;
                }
                catch (ThreadInterruptedException)
                {
                    doRun = false;
                    return;
                }
            }
        }

        public static void Jiggle(int dx, int dy)
        {

            var inp = new NativeMethods.INPUT
            {
                TYPE = NativeMethods.INPUT_MOUSE,
                mi = new NativeMethods.MOUSEINPUT()
                {
                    dx = zig ? dx : -1 * dx,
                    dy = zig ? dy : -1 * dy,
                    mouseData = 0,
                    dwFlags = NativeMethods.MOUSEEVENTF_MOVE,
                    time = 0,
                    dwExtraInfo = (IntPtr)0
                }
            };

            var retval = NativeMethods.SendInput(1, ref inp, Marshal.SizeOf(typeof(NativeMethods.INPUT)));

            if (retval != 1)
            {
                var errcode = Marshal.GetLastWin32Error();
                Debugger.Log(1, "Jiggle", $"failed to insert event to input stream; retval={retval}, errcode={errcode:x}");
            }

            zig = !zig;
        }

        public void Poke()
        {
            bide.Set();
        }

        public void Jitter(bool reset = true)
        {
            if (reset)
            {
                SleepDuration = SleepDurationStart;
                DeltaX = (int)InitDeltaX.X;
                DeltaY = (int)InitDeltaY.X;
            }

            DoJitter = true;
            bide.Set(); 
        }

        public void Relax()
        {
            DoJitter = false;
            bide.Set();
            OnRelax?.Invoke(null, null);
        }
    }

}
