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

namespace Hierarchy_Client.Forms
{
    public partial class Remote_Inspection : MetroFramework.Forms.MetroForm
    {
        private bool qtyIsSame = false;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Remote_Inspection()
        {
            InitializeComponent();
            tb_ListQty.Text = 0.ToString();
        }

        private void tb_Barcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!qtyIsSame)
                    {
                        if (string.IsNullOrEmpty(tb_Qty.Text))
                        {
                            MessageBox.Show("Enter qty!");
                            return;
                        }
                    }


                    string inspectionNumber = tb_Barcode.Text;
                    string qty = tb_Qty.Text;


                    if (lb_InspectionLotNumber.Items.Contains(inspectionNumber))
                    {
                        MessageBox.Show($"Already scanned {inspectionNumber}");
                        return;
                    }
                    else
                    {
                        lb_InspectionLotNumber.Items.Add($"{inspectionNumber},{qty}");
                        tb_ListQty.Text = lb_InspectionLotNumber.Items.Count.ToString();

                    }

                    if (!qtyIsSame)
                    {
                        tb_Qty.Text = string.Empty;
                    }

                    tb_Barcode.Text = string.Empty;
                    tb_Barcode.Focus();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void checkbox_QtyisSame_CheckedChanged(object sender, EventArgs e)
        {
            if (qtyIsSame)
            {
                qtyIsSame = false;
            }
            else
            {
                qtyIsSame = true;
            }
        }

        private void btn_PerformInspection_Click(object sender, EventArgs e)
        {

           // if(tb_StorageLocation.Text == string.Empty)

            DialogResult result = MessageBox.Show("Are you ready !??", "Perform sap transaction", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //perform sap transaction for each item

                try
                {
                    foreach (string lotInfo in lb_InspectionLotNumber.Items)
                    {
                        label_Waiting.Text = "Performing inspection operation please wait!";

                        string[] tempInfo = lotInfo.Split(',');

                        SAP_CONNECTION.Inspection.PerformSAPInspection(tempInfo[0], tempInfo[1]);

                        label_Waiting.Text = "SAP Inspection Complete!";

                        var areYouReady = MessageBox.Show("Click OK to generate SU barcode", "Mobisys transaction", MessageBoxButtons.OKCancel);

                        if (areYouReady != DialogResult.OK)
                        {
                            return; ;
                        }
                        else
                        {
                            try
                            {
                                //call mobisys dll and perform transaction
                                // Mobysis_DLL.ConnectToMobysis.Mobysis_SU_Creator("SR04");

                                Mobisys_Automation.Tests.MobisysTest1();

                                DialogResult mobisysTransaction = MessageBox.Show("Grab barcode :) ", "Mobisys transaction completed", MessageBoxButtons.OK);

                                if (mobisysTransaction != DialogResult.OK)
                                {
                                    return;
                                }

                                label_Waiting.Text = string.Empty;

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show($"Mobisys dll error : {ex.InnerException.ToString()}");
                                return;
                            };
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"error found : {ex.Message}");
                }

            }

        }

        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            lb_InspectionLotNumber.Items.Clear();
        }

        private void btn_DeleteLast_Click(object sender, EventArgs e)
        {
            lb_InspectionLotNumber.Items.RemoveAt(lb_InspectionLotNumber.Items.Count - 1);
        }

        private void btn_BypassInspection_Click(object sender, EventArgs e)
        {
            try
            {
                //call mobisys dll and perform transaction
                //Mobysis_DLL.ConnectToMobysis.Mobysis_SU_Creator("SR04");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error : {ex.InnerException.ToString()}");
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();

            MainMenu mm = new MainMenu();
            mm.ShowDialog();
        }

        private void Remote_Inspection_Load(object sender, EventArgs e)
        {
            //get app version from appconfig and display on form
            label_Version.Text = $"Version {ConfigurationManager.AppSettings["Version"].ToString()}";
        }
    }
}
