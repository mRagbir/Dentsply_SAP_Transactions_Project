using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SensorDataAccess.Windows.SAPService
{
    static class Program
    {
        private static SensorDataAccessWindowsSAPService m_svc = null;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            // If this app is already running, activate the existing instance
            Boolean bMutexCreated;
            Mutex mutexSingleInstance = new Mutex(true, "SensorSAPService", out bMutexCreated);
            bool runAsAService = SensorDataAccess.Utility.General.GetAppSettingsConfigValue<bool>("RunAsService", false);

            if (!bMutexCreated)
            {
                if (!runAsAService)
                {
                    Process curr = Process.GetCurrentProcess();
                    Process[] procs = Process.GetProcessesByName(curr.ProcessName);
                    foreach (Process p in procs)
                    {
                        if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                            SetForegroundWindow(p.MainWindowHandle);
                    }
                }

                return;
            }

            if (runAsAService)
            {
                ServiceBase[] ServicesToRun;
                m_svc = new SensorDataAccessWindowsSAPService();
                ServicesToRun = new ServiceBase[] { m_svc };
                ServiceBase.Run(ServicesToRun);
                m_svc = null;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SensorSAPServiceForm());

            }
        }
    }
}
