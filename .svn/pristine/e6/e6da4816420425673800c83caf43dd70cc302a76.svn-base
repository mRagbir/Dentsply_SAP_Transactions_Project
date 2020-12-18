using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using SchickTech.Utility;
using System.ServiceModel;
using WcfSAPService;
using Dentsply_SAP_Transactions_Service;

namespace SensorDataAccess.Windows.SAPService
{
    public partial class SensorDataAccessWindowsSAPService : ServiceBase
    {
        private static readonly ILog log = Log.GetLogger(typeof(SapService));
        private List<ServiceHost> hostList = null; //We may support multiple NIC's in the future

        public SensorDataAccessWindowsSAPService()
        {
            InitializeComponent();
            Log.ConfigureAppConfig();
            hostList = new List<ServiceHost>();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ServiceHost serviceHost = new ServiceHost(typeof(SapService));
                serviceHost.Open();
                hostList.Clear();
                hostList.Add(serviceHost);
                log.Infof("SensorDataAccessWindowsSAPService Service listening on {0}", EndpointAddressesString(serviceHost));
            }
            catch (Exception e)
            {
                log.Errorf("SensorDataAccessWindowsSAPService Service error {0}", e.Message);
            }
        }

        static string EndpointAddressesString(ServiceHost host)
        {
            return string.Join(", ", host.Description.Endpoints.Select(e => e.Address.ToString()).ToArray());
        }

        protected override void OnStop()
        {
            foreach (ServiceHost closeHost in hostList)
            {
                try
                {
                    closeHost.Close();
                    log.Info("SensorDataAccessWindowsSAPService Service Stopped");
                }
                catch (Exception ex)
                {
                    log.Errorf(ex, "Error closing host {0} {1}",
                        closeHost.BaseAddresses.ToString().Trim(),
                        EndpointAddressesString(closeHost));
                }
            }
        }
    }
}
