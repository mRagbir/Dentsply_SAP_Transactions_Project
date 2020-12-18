using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy_Client.SAP_Barcode_Form
{
    public partial class Parse_UDI_Barcode : MetroFramework.Forms.MetroForm
    {
       // const string RemoteFile = @"C:\Users\mragbir\Documents\Remote_Serials.txt";
        //const string SensorFile = @"C:\Users\mragbir\Documents\Sensor_Serials.txt";

        List<string> lRemoteSerials = new List<string>();
        List<string> lSensorSerials = new List<string>();


        public Parse_UDI_Barcode()
        {
            InitializeComponent();

         
        }

        public List<string> ParseUDIBarcode(string _barcode)
        {
            List<string> lResults = new List<string>();
            List<string> lSpecialCases = new List<string>();

            try
            {

                lSpecialCases.Add("6404177");
                lSpecialCases.Add("6404185");
                lSpecialCases.Add("B1209155");
                lSpecialCases.Add("B1209156");
                lSpecialCases.Add("B1209157");


                //step 1 remove all special characters
                string removeSpecialChars = Regex.Replace(_barcode, @"[+%$]", "");

                //step 2 remove the first 4 characters of string
                string removeFirst4 = removeSpecialChars.Remove(0, 4);

                //step 3 split string by the '/'
                string[] tempSpl = removeFirst4.Split('/');

                //step 4 remove last char from tempSpl[0]
                tempSpl[0] = tempSpl[0].Substring(0, tempSpl[0].Length - 1);

                //step 5 determine if the serial has an extra identifier according to the lSpecialCases
                if (lSpecialCases.Any(s => s.Contains(tempSpl[0])))
                {
                    tempSpl[1] = tempSpl[1].Substring(1);
                }


                lResults = tempSpl.ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            return lResults;
        }

      
        private void tb_Barcode_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    string barcode = tb_Barcode.Text;

                    List<string> getVals = ParseUDIBarcode(barcode);

                    string currentSerial = getVals[1].ToString();

                    if (!lb_Serials.Items.Contains(currentSerial))
                    {

                        lb_Serials.Items.Add(getVals[1].ToString());

                        string itemSelectedText = cb_TypeOfMaterial.SelectedItem.ToString();

                        if(itemSelectedText.ToUpper() == "REMOTE")
                        {
                            lRemoteSerials.Add(getVals[1].ToString());
                        }
                        else
                        {
                            lSensorSerials.Add(getVals[1].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Serial Already Scanned!");
                    }

                    tb_Barcode.Text = string.Empty;

                    lbl_Qty.Text = lb_Serials.Items.Count.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btn_PerformCopy_Click_1(object sender, EventArgs e)
        {
            if (cb_TypeOfMaterial.SelectedItem == null)
            {
                MessageBox.Show("Please select a type of material!");
                return;
            }


            string itemSelectedText = cb_TypeOfMaterial.SelectedItem.ToString();

            string fileToUse = string.Empty;

            string remoteFile = ConfigurationManager.AppSettings["RemoteFile"];
            string sensorFile = ConfigurationManager.AppSettings["SensorFile"];

            fileToUse = (itemSelectedText.ToUpper() == "REMOTE") ? remoteFile : sensorFile;

            using (StreamWriter sw = new StreamWriter(fileToUse, false))
            {
                foreach (var serial in lb_Serials.Items)
                {
                    sw.WriteLine(serial);
                }
            }

            MessageBox.Show("All serials have been copied!");


            lb_Serials.Items.Clear();

            lbl_Qty.Text = lb_Serials.Items.Count.ToString();

            tb_Barcode.Focus();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            lb_Serials.Items.Clear();
            lbl_Qty.Text = lb_Serials.Items.Count.ToString();

            lSensorSerials.Clear();
            lRemoteSerials.Clear();

        }

        private void btn_SAPSerials_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tb_PickLocation.Text) || string.IsNullOrEmpty(tb_OrderNumber.Text))
                {
                    MessageBox.Show("Check Order # or Pick location field!", "Error - Missing data!", MessageBoxButtons.OK);
                    return;
                }

                string orderNumber = tb_OrderNumber.Text;
                string pickLocation = tb_PickLocation.Text;



                var status = MessageBox.Show("Have you scanned all serials?", "Perform Migo Goods Issue", MessageBoxButtons.YesNo);

                if(status == DialogResult.Yes)
                {
                    string bPerformMigo = SAP_CONNECTION.Migo_Goods_Issue.PerformGoodsIssueForRemotesAndSensors(orderNumber, lRemoteSerials.ToArray(), lSensorSerials.ToArray(), pickLocation).ToString();

                    if (bPerformMigo.ToUpper().Contains("TRUE")){
                        MessageBox.Show("Migo transaction complete!");
                    }
                    else
                    {
                        MessageBox.Show($"Error performing migo : {bPerformMigo}");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            //close this form
            this.Hide();

            this.Close();


            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();

            //reopen the material number form
            //MaterialNumberValidator mn = new MaterialNumberValidator();
            //mn.ShowDialog();
            //Login login = new Login();
            //login.ShowDialog();

            MainMenu mm = new MainMenu();
            mm.ShowDialog();
        }

        private void Parse_UDI_Barcode_Load(object sender, EventArgs e)
        {
            //get app version from appconfig and display on form
            label_Version.Text = ConfigurationManager.AppSettings["Version"].ToString();
        }
    }
}
