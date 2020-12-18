using log4net;
using log4net.Config;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy_Client
{
    public partial class MainMenu : MetroForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainMenu()
        {
            InitializeComponent();

        
        }

        private void btn_Hierarchy_Click(object sender, EventArgs e)
        {
            //log the menu item selected
            LogWhichButtonWasClicked("Hierarchy");



            //hide this form
            this.Hide();

            //if there isn't any user info then show login screen

            if (KitInfo.Instance.UAPID.ToString() == string.Empty)
            {
                //go to login page
                Login login = new Login();
                login.ShowDialog();
            }


            MaterialNumberValidator mnv = new MaterialNumberValidator();
            mnv.ShowDialog();
        }

        private void btn_CableKits_Click(object sender, EventArgs e)
        {
            //log the menu item selected
            LogWhichButtonWasClicked("Cable Kits");

            //hide this form
            this.Hide();

            if (KitInfo.Instance.UAPID.ToString() == string.Empty)
            {
                //go to login page
                Login login = new Login();
                login.ShowDialog();
            }

            if(string.IsNullOrEmpty(KitInfo.Instance.MaterialNumber))
            {

                MaterialNumberValidator mnv = new MaterialNumberValidator();
                mnv.ShowDialog();
            }

            CableKits ck = new CableKits();
            ck.ShowDialog();
        }

        private void btn_UDI_Barcode_Click(object sender, EventArgs e)
        {
            //log the menu item selected
            LogWhichButtonWasClicked("(UDI Barcode)-Migo Goods Issue");

            //hide this form
            this.Hide();

            SAP_Barcode_Form.Parse_UDI_Barcode udi = new SAP_Barcode_Form.Parse_UDI_Barcode();
            udi.ShowDialog();
        }

        private void btn_Inspection_Click(object sender, EventArgs e)
        {

            //log the menu item selected
            LogWhichButtonWasClicked("Inspection");

            //hide this form
            this.Hide();

            Forms.Remote_Inspection ri = new Forms.Remote_Inspection();
            ri.ShowDialog();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            //log the menu item selected
            LogWhichButtonWasClicked("Test");

            this.Hide();

            TestForm tf = new TestForm();
            tf.ShowDialog();
        }

        private void LogWhichButtonWasClicked(string buttonName)
        {
            logger.Debug($"Main menu action clicked : {buttonName}");


        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //get app version from appconfig and display on form
            label_Version.Text = $"Version {ConfigurationManager.AppSettings["Version"].ToString()}";
        }
    }
}
