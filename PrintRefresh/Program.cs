using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace PrintRefresh
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stop the spooler.
            ServiceController service = new ServiceController("Spooler");
            if ((!service.Status.Equals(ServiceControllerStatus.Stopped)) &&
                (!service.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            // Start the spooler.
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);

            MessageBox.Show("프린터 새로고침 완료.");
        }
    }
}
