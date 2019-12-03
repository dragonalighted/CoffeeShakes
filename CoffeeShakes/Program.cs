using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShakes
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{179e8a62-1507-11ea-8d71-362b9e155667}");
        
        [STAThread]
        static void Main()
        {

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                //                MessageBox.Show("Only one instance of CoffeeShakes at a time.");
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);

            }
        }
    }
}
