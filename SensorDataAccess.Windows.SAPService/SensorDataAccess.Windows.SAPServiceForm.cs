using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using SchickTech.Utility;
using System.ServiceModel.Channels;
using System.Threading;
using System.ServiceModel.Description;
using SensorDataClasses.classes.helper;
using System.Diagnostics;
using WcfSAPService;
using Dentsply_SAP_Transactions_Service;

namespace SensorDataAccess.Windows.SAPService
{
    public partial class SensorSAPServiceForm : Form
    {
        private static readonly ILog _log = Log.GetLogger(typeof(SensorDataAccessWindowsSAPService));
        private ServiceHost _serviceHost = null;
        private int _maxItemsInList = 1000;
        private bool _IsExiting = false;

        public delegate void MonitorMessageDelegate(string aMessage);

        public SensorSAPServiceForm()
        {
            InitializeComponent();
            SapService svc = new SapService();
#pragma warning disable 219
            bool bIsCreated = false;
#pragma warning restore 219
            svc.Messages += new SapService.MonitorMessageDelegate(Svc_Messages);
            try
            {
                _serviceHost = new ServiceHost(typeof(SapService));
                _serviceHost.OpenTimeout = _serviceHost.CloseTimeout = new TimeSpan(0, 10, 0);
                foreach (ServiceEndpoint se in _serviceHost.Description.Endpoints)
                {
                    se.Binding.OpenTimeout = se.Binding.ReceiveTimeout = se.Binding.SendTimeout = new TimeSpan(0, 10, 0);
                    if (se.Binding.Scheme == "net.tcp")
                    {
                        WcfServiceHelper<ISapService>.SetDefaultBinding((NetTcpBinding)se.Binding, false);
                    }
                }
                _serviceHost.Open();
                bIsCreated = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                _log.Error($"Error : {e.StackTrace}");
            }
            Log.ConfigureAppConfig();
            _log.Infof("SensorDataAccess.Windows.SAPService Service listening on {0}", EndpointAddressesString(_serviceHost));
            ShowMonitorMessageDelegate($"SensorDataAccess.Windows.SAPService Service listening on {EndpointAddressesString(_serviceHost)}");
        }

        void Svc_Messages(string aMessage)
        {
            ShowMonitorMessageDelegate(aMessage);
        }

        static string EndpointAddressesString(ServiceHost host)
        {
            return string.Join(", ", host.Description.Endpoints.Select(e => e.Address.ToString()).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SensorDataAccessServiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_IsExiting;
            this.Visible = false;
        }


        private void Killme()
        {
            Thread.Sleep(10000); //wait for 10 seconds then kill me
            SensorDataClasses.classes.control.ProcessControl.KillProcessTree.KillAllProcesses(
               SensorDataClasses.classes.general.ApplicationLoader.AssemblyName);
            SensorDataClasses.classes.control.ProcessControl.KillProcessTree.KillAllProcesses(
                SensorDataClasses.classes.general.ApplicationLoader.AssemblyName + ".vshost");
        }

        private void ExitApp()
        {
            try
            {
                //if we cannot stop then killme
                Thread thread = new Thread(new ThreadStart(Killme));
                thread.Name = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                thread.IsBackground = true;
                thread.Start();
                if (_serviceHost != null)
                    _serviceHost.Close();
                _log.Infof("Dentsply_SAP_Transactions_Service.SapService Closed on {0}", EndpointAddressesString(_serviceHost));
            }
            catch (Exception ex)
            {
                try //if i can't log then i can't
                {
                    _log.Errorf(ex, "Error closing host {0} {1}", _serviceHost.BaseAddresses.ToString().Trim(), EndpointAddressesString(_serviceHost));
                }
                catch { }
            }
            _IsExiting = true;
            try
            {
                this.Close();
            }
            catch (Exception e)
            {
                _log.Infof(e.StackTrace);
            }
        }

        public void ShowMonitorMessageDelegate(string aMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MonitorMessageDelegate(ShowMonitorMessageDelegate), new object[] { aMessage });
                return;
            }
            while (lstMessages.Items.Count > _maxItemsInList)
            {
                lstMessages.Items.RemoveAt(lstMessages.Items.Count - 1);
            }

            string insertMe = DateTime.Now.ToString("MM/dd hh:mm:ss tt") + " " + aMessage; // + ", " + Source();
            this.lstMessages.Items.Insert(0, insertMe);
            if (insertMe.ToUpper().Contains("CLIENT:"))
                lstClientMessages.Items.Insert(0, insertMe);
            else if (insertMe.ToUpper().Contains("STATUS:"))
                lstStatusMessages.Items.Insert(0, insertMe);
            else
                lstMessages.Items.Insert(0, insertMe);
        }

        /// <summary>
        /// This can return an IPv6 address and the port
        /// </summary>
        /// <returns></returns>
        public string Source()
        {
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties properties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                return string.Format("Connected from {0}:{1}", endpoint.Address, endpoint.Port);
            }
            catch (Exception e)
            {
                _log.Error($"Error : {e.StackTrace}");
            }
            return String.Empty;
        }

        private ListBox _lastListBox = null;
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lastListBox.Items.Clear();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            timer1.Enabled = false;
        }

        private void lstClientMessages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = lstClientMessages.PointToScreen(e.Location);
                _lastListBox = lstClientMessages;
                contextMenuStrip1.Show(pt);
            }
        }

        private void lstMessages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = lstMessages.PointToScreen(e.Location);
                _lastListBox = lstMessages;
                contextMenuStrip1.Show(pt);
            }
        }

        private void lstStatusMessages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = lstStatusMessages.PointToScreen(e.Location);
                _lastListBox = lstStatusMessages;
                contextMenuStrip1.Show(pt);
            }

        }
    }
}