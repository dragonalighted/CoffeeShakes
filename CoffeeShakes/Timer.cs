using System;
using System.Threading;

namespace CoffeeShakes
{
    public class Timer : IDisposable
    {


        private readonly System.Threading.Thread timer;
        private readonly AutoResetEvent bide;
        public int SleepDuration = 500;//5 * 60 * 1000;

        public event EventHandler OnTick;
        public event EventHandler OnStop;
        public event EventHandler OnStart; 


        private bool doWork;
        
        private bool doRun = true;
        
        public Timer()
        {
            bide = new AutoResetEvent(false);
            timer = new Thread(new ThreadStart(this.Run));
            timer.Start();
        }

        public void Dispose()
        {
            doRun = false;
            doWork = false;
            bide.Set();
            Thread.Sleep(100);
        }

        private void Run()
        {
            while (doRun)
            {
                try
                {
                    if (doWork && doRun)
                    {
                        Tick();
                    }
                    bide.WaitOne(SleepDuration);
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
            bide.Close();
        }

        public void Poke()
        {
            bide.Set();
        }
        private void Tick()
        {
            OnTick?.Invoke(this, EventArgs.Empty);
        }
        public void Start()
        {
            doWork = true;
            bide.Set();
            OnStart?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            doWork = false;
            bide.Set();
            OnStop?.Invoke(null, null);
        }
    }

}
