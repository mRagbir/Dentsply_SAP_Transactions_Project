﻿using MetroFramework.Forms;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hierarchy_Client
{
    public partial class CreateHierarchy : MetroForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public CreateHierarchy()
        {
            InitializeComponent();
        }

        #region Form Load
        private void CreateHierarchy_Load(object sender, EventArgs e)
        {

            try
            {
                //check which controls are available
                TextboxEnabledOrDisabledPlusDefaultColors();

                lbl_MaterialNumber.Text = KitInfo.Instance.MaterialNumber;
                lbl_Description.Text = KitInfo.Instance.Description;
                label_CurrentUser.Text = "Current User : " + KitInfo.Instance.Username;

                //get all material info
                KitInfo.Instance.dsMaterialInfo = Helper.GetAllMaterialMatchingInformation();

                //load storage locations into storage location combo box
                cb_StorageLocations.Items.Add("");
                DataTable dtWhLocations = KitInfo.Instance.dsMaterialInfo.Tables["Warehouse_Locations"];

                if (dtWhLocations != null && dtWhLocations.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtWhLocations.Rows)
                    {
                        string storageLoc = dr["STORAGE_LOCATION"].ToString();
                        cb_StorageLocations.Items.Add(storageLoc);
                    }
                }

                label_LastEnteredSerial.Text = "Last Entered Serial : ";
                tb_OrderNumber.Focus();

                //choose default option in GR type combo box
                cb_TypeOfHierarchy.SelectedIndex = 1;

                //get app version from app config and display on form
                label_Version.Text = $"Version {ConfigurationManager.AppSettings["Version"].ToString()}";
            }
            catch (Exception ex)
            {
                //log error
                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");
            }

        }

        #endregion

        #region Reset Textbox and colors
        private void ResetTextboxColors()
        {
            tb_KitSerial.BackColor = Color.White;
            tb_SensorSerial.BackColor = Color.White;
            tb_SensorSerial_2.BackColor = Color.White;
            tb_CableSerial.BackColor = Color.White;
            tb_SpareCableSerial.BackColor = Color.White;
            tb_RemoteSerial.BackColor = Color.White;
        }

        private void TextboxEnabledOrDisabledPlusDefaultColors()
        {
            ResetTextboxColors();

            if (KitInfo.Instance.bIsAEcomboKit)
            {
                //for AE combo kit you need 2 sensors and a remote
                EnableControlsForAEComboKit();
            }
            else
            {
                tb_SensorSerial_2.Enabled = false;
                checkBox_Sensor_2.Enabled = false;
                lbl_SensorSerial_2.Text = "N/A";

                if (KitInfo.Instance.bIsSensorNeeded == false)
                {
                    tb_SensorSerial.Enabled = false;
                    checkBox_Sensor.Enabled = false;
                    lbl_SensorSerial.Text = "N/A";
                };
                if (KitInfo.Instance.bIsCableOnSensorNeeded == false)
                {
                    tb_CableSerial.Enabled = false;
                    checkBox_Cable.Enabled = false;
                    lbl_MainCableSerial.Text = "N/A";
                };
                if (KitInfo.Instance.bIsSpareCableNeeded == false)
                {
                    tb_SpareCableSerial.Enabled = false;
                    checkBox_SpareCable.Enabled = false;
                    lbl_SpareCableSerial.Text = "N/A";
                };
                if (KitInfo.Instance.bIsStarterKit == false)
                {
                    tb_RemoteSerial.Enabled = false;
                    checkBox_Remote.Enabled = false;
                    lbl_RemoteSerial.Text = "N/A";
                };
            }
        }


        #endregion

        #region Controls
        private void EnableControlsForAEComboKit()
        {

            //AE Combo kit uses a S1 & S2 Sensor kit + Remote

            //main cable
            tb_CableSerial.Enabled = false;
            checkBox_Cable.Enabled = false;
            lbl_MainCableSerial.Text = "N/A";

            //spare cable
            tb_SpareCableSerial.Enabled = false;
            checkBox_SpareCable.Enabled = false;
            lbl_SpareCableSerial.Text = "N/A";

            //change the text associated with the 2 sensors
            lbl_SensorSerial.Text = lbl_SensorSerial.Text + " S2";
            lbl_SensorSerial_2.Text = lbl_SensorSerial_2.Text + " S1";

        }

        #endregion

        #region Check Values before submit
        private bool CheckAllTextboxValuesBeforeSubmit()
        {
            bool isPassed = false;

            try
            {
                //Order number check
                if (string.IsNullOrWhiteSpace(tb_OrderNumber.Text))
                {
                    MessageBox.Show("Enter Order number"); isPassed = false;
                    return isPassed;
                }
                else
                {
                    KitInfo.Instance.OrderNumber = tb_OrderNumber.Text;
                }


                //Kit check
                if (string.IsNullOrWhiteSpace(tb_KitSerial.Text))
                {
                    MessageBox.Show("Enter a valid Kit Serial");
                    return isPassed;
                }



                //Sensor check
                if (KitInfo.Instance.bIsAEcomboKit)
                {
                    if (KitInfo.Instance.bIsSensorNeeded == true && (string.IsNullOrWhiteSpace(tb_SensorSerial.Text) || tb_SensorSerial.BackColor != Color.LightGreen))
                    { MessageBox.Show("Enter a valid Sensor 1 Serial number"); return isPassed; };

                    if (KitInfo.Instance.bIsSensorNeeded == true && (string.IsNullOrWhiteSpace(tb_SensorSerial_2.Text) || tb_SensorSerial_2.BackColor != Color.LightGreen))
                    { MessageBox.Show("Enter a valid Sensor 2 Serial number"); return isPassed; };
                }
                else
                {
                    if (KitInfo.Instance.bIsSensorNeeded == true && (string.IsNullOrWhiteSpace(tb_SensorSerial.Text) || tb_SensorSerial.BackColor != Color.LightGreen))
                    { MessageBox.Show("Enter a valid Sensor Serial number"); return isPassed; };
                }

                //Cable check
                if (KitInfo.Instance.bIsCableOnSensorNeeded == true && (string.IsNullOrWhiteSpace(tb_CableSerial.Text) || tb_CableSerial.BackColor != Color.LightGreen))
                { MessageBox.Show("Enter a valid Cable Serial number"); return isPassed; };

                //Spare Cable check
                if (KitInfo.Instance.bIsSpareCableNeeded == true && (string.IsNullOrWhiteSpace(tb_SpareCableSerial.Text) || tb_SpareCableSerial.BackColor != Color.LightGreen))
                { MessageBox.Show("Enter Spare Cable serial number"); return isPassed; };

                //Remote check
                if (KitInfo.Instance.bIsStarterKit == true && (string.IsNullOrWhiteSpace(tb_RemoteSerial.Text) || tb_RemoteSerial.BackColor != Color.LightGreen))
                { MessageBox.Show("Enter Remote Serial number"); return isPassed; };

                //Storage Location check
                if (string.IsNullOrWhiteSpace(cb_StorageLocations.Text))
                {
                    MessageBox.Show("Enter Storage Location");
                    return isPassed;
                }
                else
                {
                    KitInfo.Instance.StorageLocation = cb_StorageLocations.Text;
                }

                isPassed = true;
            }
            catch (Exception up)
            {
                //log error
                logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");

                MessageBox.Show($"Error : {up.StackTrace}");
            }

            return isPassed;
        }

        #endregion

        #region Clear Textboxes
        private void ClearTextboxes(Control.ControlCollection ctrlCollection, bool bIsSubmit)
        {
            //tb_KitSerial.Text = string.Empty;
            //tb_SensorSerial.Text = string.Empty;
            //tb_CableSerial.Text = string.Empty;
            //tb_SpareCableSerial.Text = string.Empty;
            //tb_RemoteSerial.Text = string.Empty;


            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    var name = ctrl.Name;

                    if (bIsSubmit && name == "tb_OrderNumber") { continue; };
                    ctrl.Text = String.Empty;
                }
                else
                {
                    //ClearTextboxes(ctrl.Controls);
                }
            }

        }

        #endregion

        #region Change Textbox back color
        private void ChangeTextboxBackcolor(TextBox textbox, bool bIsFailed = true)
        {
            //determine if you need a failed color or passed color in textbox
            if (bIsFailed)
            {
                textbox.BackColor = Color.LightPink;
            }
            else
            {
                textbox.BackColor = Color.LightGreen;
            }
        }

        #endregion

        #region Form Buttons


        /// <summary>
        /// Main Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                //make a new wait form but don't show it till text boxes are evaluated
                WaitForm wf = new WaitForm();

                //make a new connection to SAP service running on local machine
                // SAPConnectionClient client = new SAPConnectionClient("SAPTCP");

                //assign the check box bypass states



                try
                {
                    //check the values
                    bool isPassed = CheckAllTextboxValuesBeforeSubmit();
                    if (!isPassed)
                    {  //close the waiting form
                        wf.Close();
                        return; 
                    };

                    //open the waiting form
                    wf.Show();


                    //check if we are going to do a SAP transaction or not


                    if (KitInfo.Instance.HierarchyType < 4)
                    {

                        //perform SAP transaction 
                        var sapTrans = Helper.PerformSapHierarchy
                           (
                           KitInfo.Instance.OrderNumber,
                           KitInfo.Instance.MaterialNumber,
                           KitInfo.Instance.KitSerial,
                           KitInfo.Instance.StorageLocation,
                           KitInfo.Instance.HierarchyType.ToString(),
                           KitInfo.Instance.bIsSensorNeeded.ToString(),
                           KitInfo.Instance.bIsSpareCableNeeded.ToString(),
                           KitInfo.Instance.bIsAEcomboKit.ToString(),
                           KitInfo.Instance.bIsStarterKit.ToString(),
                           KitInfo.Instance.bIsEliteBasicKit.ToString(),
                           KitInfo.Instance.bIsCableOnSensorNeeded.ToString(),
                           KitInfo.Instance.bIsChild1Checked.ToString(),
                           KitInfo.Instance.bIsChild2Checked.ToString(),
                           KitInfo.Instance.bIsChild3Checked.ToString(),
                           KitInfo.Instance.Sensor1MaterialNumber,
                           KitInfo.Instance.Sensor1Serial,
                           KitInfo.Instance.Sensor2MaterialNumber,
                           KitInfo.Instance.Sensor2Serial,
                           KitInfo.Instance.CableMaterialNumber,
                           KitInfo.Instance.CableSerial,
                           KitInfo.Instance.SpareCableSerial,
                           KitInfo.Instance.RemoteMaterialNumber,
                           KitInfo.Instance.RemoteSerial
                           );

                        wf.Hide();

                        //check if everything went smoothly with the SAP transaction
                        bool bcheckTrans = Convert.ToBoolean(sapTrans);
                        if (!bcheckTrans)
                        {

                            MessageBox.Show($"Error processing SAP Hierarchy transaction...look at SAP screen for further details and try again.");

                            //set the focus back to the Kit serial textbox
                            tb_KitSerial.Focus();

                            //close the waiting form
                            wf.Close();

                            return;
                        }
                    }
                   

                    //set the last entered serial text
                    label_LastEnteredSerial.Text = string.Empty;

                    //If everything went good then enter all hierarchy info into Production_Utilities database!
                    bool bInsertDataToDB = InsertKitInfoToDB();

                    //check if the DB insert went OK
                    if (!bInsertDataToDB)
                    {
                        MessageBox.Show($"Error adding Kit info into the Database..." + Environment.NewLine + "Please contact a database admin ASAP and do not continue");

                        //close the waiting form
                        wf.Close();


                        return;
                    }

                }
                catch (Exception ex)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");


                    wf.Close();
                    MessageBox.Show(ex.StackTrace);
                }

                //close the waiting form
                wf.Close();

                //clear the text boxes
                ClearTextboxes(this.Controls, true);

                //set the last entered serial text
                label_LastEnteredSerial.Text = $"Last entered serial : {KitInfo.Instance.KitSerial}";

                //set the focus back to the Kit serial textbox
                tb_KitSerial.Focus();

                //return all text boxes to default color

                TextboxEnabledOrDisabledPlusDefaultColors();

            }
            catch (Exception ex)
            {
                //log error
                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");

                MessageBox.Show(ex.StackTrace);
            }
        }

        private void metroButton_Clear_Click(object sender, EventArgs e)
        {

            ClearTextboxes(this.Controls, false);

            TextboxEnabledOrDisabledPlusDefaultColors();

            //focus back on kit serial text box
            tb_KitSerial.Focus();

        }

        private void metroButton_Home_Click(object sender, EventArgs e)
        {
            //close this form
            this.Hide();
            this.Close();

            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();


            MainMenu mm = new MainMenu();
            mm.ShowDialog();
        }

        private void metroButton_HierarchyReport_Click(object sender, EventArgs e)
        {
            //send material number to vb script and print report
            bool bIsPrinted = Helper.PrintReport(KitInfo.Instance.MaterialNumber);

            if (!bIsPrinted)
            {
                logger.Error($"Error printing Hierarchy report for {KitInfo.Instance.MaterialNumber} ");

                //MessageBox.Show("Error printing Hierarchy report.. please try again or manually print report using SAP");
                if (MessageBox.Show("Error printing Hierarchy report.. please try again or manually print report using SAP " + Environment.NewLine + "Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                }
                return;
            }

        }

        #endregion

        #region DB Inserts

        public bool InsertKitInfoToDB()
        {

            bool bIsPassed = false;
            int tryInsert = -1;

            try
            {

                if (KitInfo.Instance.MaterialFamily.ToUpper() == "SCHICK33")
                {

                    if (KitInfo.Instance.bIsComboKit)
                    {
                        //not currently used for schick33!!
                    }
                    else if (KitInfo.Instance.bIsStarterKit)
                    {
                        tryInsert = Helper.InsertStarterKit(KitInfo.Instance.MaterialNumber,
                                                            KitInfo.Instance.KitSerial,
                                                            KitInfo.Instance.Sensor1MaterialNumber,
                                                            KitInfo.Instance.Sensor1SerialKitID,
                                                            KitInfo.Instance.RemoteMaterialNumber,
                                                            KitInfo.Instance.RemoteSerial,
                                                            KitInfo.Instance.OrderNumber,
                                                            KitInfo.Instance.UAPID,
                                                            KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsSensorShipKit)
                    {
                        tryInsert = Helper.InsertShipKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.Sensor1Serial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.SpareCableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsRmaKit)
                    {
                        tryInsert = Helper.InsertRmaKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.Sensor1Serial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);
                    }

                }
                else if (KitInfo.Instance.MaterialFamily.ToUpper() == "AE")
                {

                    if (KitInfo.Instance.bIsComboKit)
                    {

                        tryInsert = Helper.InsertAEComboKit(KitInfo.Instance.MaterialNumber,
                                                            KitInfo.Instance.KitSerial,
                                                            KitInfo.Instance.Sensor2MaterialNumber,
                                                            KitInfo.Instance.Sensor2SerialKitID,
                                                            KitInfo.Instance.Sensor1MaterialNumber,
                                                            KitInfo.Instance.Sensor1SerialKitID,
                                                            KitInfo.Instance.RemoteMaterialNumber,
                                                            KitInfo.Instance.RemoteSerial,
                                                            KitInfo.Instance.OrderNumber,
                                                            Convert.ToInt32(KitInfo.Instance.UAPID),
                                                            KitInfo.Instance.NoteForBypass);

                    }
                    else if (KitInfo.Instance.bIsStarterKit)
                    {
                        tryInsert = Helper.InsertAEStarterKit(KitInfo.Instance.MaterialNumber,
                                                            KitInfo.Instance.KitSerial,
                                                            KitInfo.Instance.Sensor1MaterialNumber,
                                                            KitInfo.Instance.Sensor1SerialKitID,
                                                            KitInfo.Instance.RemoteMaterialNumber,
                                                            KitInfo.Instance.RemoteSerial,
                                                            KitInfo.Instance.OrderNumber,
                                                            Convert.ToInt32(KitInfo.Instance.UAPID),
                                                            KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsSensorShipKit)
                    {
                        tryInsert = Helper.InsertAESensorShipKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.SpareCableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        Convert.ToInt32(KitInfo.Instance.UAPID),
                                                        KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsRmaKit)
                    {
                        tryInsert = Helper.InsertAERmaKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        Convert.ToInt32(KitInfo.Instance.UAPID),
                                                        KitInfo.Instance.NoteForBypass);
                    }



                }
                else if (KitInfo.Instance.MaterialFamily.ToUpper() == "ELITE")
                {
                    if (KitInfo.Instance.bIsComboKit)
                    {
                        //not currently used for elite!!
                    }
                    else if (KitInfo.Instance.bIsStarterKit)
                    {
                        tryInsert = Helper.InsertStarterKit(KitInfo.Instance.MaterialNumber,
                                                            KitInfo.Instance.KitSerial,
                                                            KitInfo.Instance.Sensor1MaterialNumber,
                                                            KitInfo.Instance.Sensor1SerialKitID,
                                                            KitInfo.Instance.RemoteMaterialNumber,
                                                            KitInfo.Instance.RemoteSerial,
                                                            KitInfo.Instance.OrderNumber,
                                                            KitInfo.Instance.UAPID,
                                                            KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsEliteBasicKit)
                    {
                        tryInsert = Helper.InsertBasicKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsSensorShipKit)
                    {
                        tryInsert = Helper.InsertShipKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.Sensor1Serial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.SpareCableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);
                    }
                    else if (KitInfo.Instance.bIsRmaKit)
                    {
                        tryInsert = Helper.InsertRmaKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.KitSerial,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.Sensor1Serial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);
                    }




                }
                else if (KitInfo.Instance.MaterialFamily.ToUpper() == "XIOSAE")
                {

                    tryInsert = Helper.InsertXiosAeKit(KitInfo.Instance.MaterialNumber,
                                                        KitInfo.Instance.Sensor1MaterialNumber,
                                                        KitInfo.Instance.Sensor1Serial,
                                                        KitInfo.Instance.CableMaterialNumber,
                                                        KitInfo.Instance.CableSerial,
                                                        KitInfo.Instance.OrderNumber,
                                                        KitInfo.Instance.UAPID,
                                                        KitInfo.Instance.NoteForBypass);

                }
                else if (KitInfo.Instance.MaterialFamily.ToUpper() == "XG_SUP_SEL")
                {

                    tryInsert = Helper.InsertXgSupSelShipKit(KitInfo.Instance.MaterialNumber,
                                                             KitInfo.Instance.Sensor1MaterialNumber,
                                                             KitInfo.Instance.Sensor1Serial,
                                                             KitInfo.Instance.CableMaterialNumber,
                                                             KitInfo.Instance.CableSerial,
                                                             KitInfo.Instance.OrderNumber,
                                                             KitInfo.Instance.UAPID,
                                                             KitInfo.Instance.NoteForBypass);
                }


                bIsPassed = (tryInsert < 1) ? false : true;
            }
            catch (Exception ex)
            {
                //log error
                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");

                MessageBox.Show($"Error in InsertKitInfoToDB : {ex.StackTrace}");
            }

            return bIsPassed;

        }

        #endregion

        #region Textbox evaluations

        #region Order Number
        private void tb_OrderNumber_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                //add the order number
                KitInfo.Instance.OrderNumber = tb_OrderNumber.Text;

                //move to next active control
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        #endregion

        #region Validate Kit Serial
        private void tb_KitSerial_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataSet dsCheckSerialUse = new DataSet();

                    //create a new instance of barcode info class
                    BarcodeInfo bi = new BarcodeInfo();
                    bi.FullString = tb_KitSerial.Text;

                    if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                    {
                        //split the barcode
                        List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                        //get the material number and serial from the previous list
                        bi.MaterialNumber = BarcodeSplit[0];
                        bi.SerialNumber = BarcodeSplit[1];

                        //compare the scanned Kit material to the kit info Kit material , return error if the material doesn't match
                        if (bi.MaterialNumber != KitInfo.Instance.MaterialNumber)
                        {
                            MessageBox.Show($"Wrong material is being used - {bi.MaterialNumber}");
                            //change textbox color
                            ChangeTextboxBackcolor(tb_KitSerial);
                            return;
                        };
                    }
                    else
                    {
                        //get the kit identifier
                        string subKitIdentifier = string.Empty;// bi.FullString.Substring(0, 3);

                        if (bi.FullString.Substring(0, 2) == "00")
                        {
                            subKitIdentifier = bi.FullString.Substring(2, 2);
                        }
                        else
                        {
                            subKitIdentifier = bi.FullString.Substring(0, 3);
                        }


                        //compare the scanned Kit identifier to the database identifier , return error if the material doesn't match
                        if (subKitIdentifier != KitInfo.Instance.Identifier)
                        {
                            MessageBox.Show($"Wrong Kit is being used - {bi.MaterialNumber}");
                            //change textbox color
                            ChangeTextboxBackcolor(tb_KitSerial);
                            return;
                        };

                        // assign to the barcode info class
                        bi.MaterialNumber = KitInfo.Instance.MaterialNumber;
                        bi.SerialNumber = bi.FullString;
                    }

                    //delete double 0's in front of serial
                    if (bi.SerialNumber.Substring(0, 2) == "00")
                    {
                        bi.SerialNumber = bi.SerialNumber.Substring(2);
                    }


                    DataTable dtTemp = new DataTable();
                    //check if sensor is needed 
                    //if not then that means this kit serial is the sensor serial
                    //so check the sensor part number table to determine if sensor was already used instead of if kit was used
                    if (!KitInfo.Instance.bIsSensorNeeded)
                    {
                        string sensorMaterialNumber = KitInfo.Instance.Sensor1MaterialNumber;

                        if (sensorMaterialNumber.Contains("10000"))
                            sensorMaterialNumber = $"_{sensorMaterialNumber}";

                        //determine if a sensor serial was already used
                        dtTemp = Helper.dtWasSensorSerialAlreadyUsed(sensorMaterialNumber, bi.SerialNumber);
                    }
                    else
                    {
                        //determine if kit serial was already used
                        dtTemp = Helper.dtWasKitSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    }




                    if (dtTemp.Rows.Count < 1)
                    {
                        //assign the serial number to the textbox
                        tb_KitSerial.Text = bi.SerialNumber;

                        //assign to KitInfo
                        KitInfo.Instance.KitSerial = tb_KitSerial.Text;

                        //change textbox color
                        ChangeTextboxBackcolor(tb_KitSerial, false);

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    else
                    {
                        //assign the serial number to the textbox
                        tb_KitSerial.Text = bi.SerialNumber;

                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0][0];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************

                        //change textbox color
                        ChangeTextboxBackcolor(tb_KitSerial);


                        MessageBox.Show($"Kit serial {bi.SerialNumber} was already used!");

                        //set flag to show we found a duplicate kit serial
                        //we set the flag because we DO NOT want the user to be able to duplicate or over ride Kit serials!
                        KitInfo.Instance.bKitSerialDuplicate = true;

                        KitInfo.Instance.ErrorDescription = "Duplicate KIT serial found !";

                        //show the WasAlreadyUsed form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {
                            //assign to KitInfo
                            KitInfo.Instance.KitSerial = tb_KitSerial.Text;

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                        else
                        {
                            tb_KitSerial.Text = string.Empty;
                        }

                        //change textbox color
                        ChangeTextboxBackcolor(tb_KitSerial);
                    }


                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }
            }
        }

        #endregion

        //Calls Validate Sensor 1
        #region Sensor 1
        private void tb_SensorSerial_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ValidateSensor();
                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }
            }
        }

        #endregion

        //Calls Validate Sensor 2
        #region Sensor 2
        private void tb_SensorSerial_2_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    ValidateSensor2();
                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }
            }
        }

        #endregion

        #region Cable Serial
        private void tb_CableSerial_KeyUp(object sender, KeyEventArgs e)
        {

            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataSet dsCheckSerialUse = new DataSet();

                    //create a new instance of barcode info class
                    BarcodeInfo bi = new BarcodeInfo();
                    bi.FullString = tb_CableSerial.Text;

                    if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                    {

                        //split the barcode
                        List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                        //get the material number and serial from the previous list
                        bi.MaterialNumber = BarcodeSplit[0];
                        bi.SerialNumber = BarcodeSplit[1];

                        //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                        if (bi.MaterialNumber != KitInfo.Instance.CableMaterialNumber) { MessageBox.Show($"Wrong cable is being used - {bi.MaterialNumber}"); return; };


                    }
                    else
                    {
                        //get the cable identifier
                        string subCableIdentifier = bi.FullString.Substring(0, 2);

                        //get the identifier from the database
                        DataRow[] dbIdentifier = KitInfo.Instance.dsMaterialInfo.Tables["Cables"].Select($"Identifier = '{subCableIdentifier}'");

                        //grab only the part number from the returned info from database
                        string dbPartNum = dbIdentifier[0][2].ToString();

                        //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                        if (dbPartNum != KitInfo.Instance.CableMaterialNumber) { MessageBox.Show($"Wrong cable is being used - {bi.MaterialNumber}"); return; };

                        //assign to the barcode info class
                        bi.MaterialNumber = dbPartNum;
                        bi.SerialNumber = bi.FullString;

                    }

                    //check if the cable serial is the same as spare cable serial
                    if (bi.SerialNumber == tb_SpareCableSerial.Text)
                    {
                        MessageBox.Show($"This serial was already scanned as a spare cable !!");
                        return;
                    }


                    //check if the cable was already used
                    DataTable dtTemp = Helper.dtWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    //dsCheckSerialUse = Helper.dsWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);

                    //show user if cable was already used
                    if (dtTemp.Rows.Count < 1)
                    {
                        //assign the serial number to the textbox
                        tb_CableSerial.Text = bi.SerialNumber;

                        //assign to KitInfo
                        KitInfo.Instance.CableSerial = tb_CableSerial.Text;

                        //change textbox color
                        ChangeTextboxBackcolor(tb_CableSerial, false);

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    else
                    {

                        //assign the serial number to the textbox
                        tb_CableSerial.Text = bi.SerialNumber;

                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0][0];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************

                        //change textbox color
                        ChangeTextboxBackcolor(tb_CableSerial);

                        //assign the error message
                        KitInfo.Instance.ErrorDescription = ($"Cable Serial { bi.SerialNumber} was already used");

                        //show the wasalreadyused form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {
                            //assign to KitInfo
                            KitInfo.Instance.CableSerial = tb_CableSerial.Text;

                            //change textbox color
                            ChangeTextboxBackcolor(tb_CableSerial, false);

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                        else
                        {
                            tb_CableSerial.Text = string.Empty;
                        }
                    }

                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }
            }

        }

        #endregion

        #region Spare Cable
        private void tb_SpareCableSerial_KeyUp(object sender, KeyEventArgs e)
        {

            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataSet dsCheckSerialUse = new DataSet();

                    //create a new instance of barcode info class
                    BarcodeInfo bi = new BarcodeInfo();
                    bi.FullString = tb_SpareCableSerial.Text;

                    if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                    {

                        //split the barcode
                        List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                        //get the material number and serial from the previous list
                        bi.MaterialNumber = BarcodeSplit[0];
                        bi.SerialNumber = BarcodeSplit[1];

                        //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                        if (bi.MaterialNumber != KitInfo.Instance.CableMaterialNumber) { MessageBox.Show($"Wrong cable is being used - {bi.MaterialNumber}"); return; };

                        //check if duplicate cable as scanned ( same as first cable)
                        if (bi.SerialNumber == tb_CableSerial.Text)
                        {
                            MessageBox.Show($"Duplicate cable is being scanned in the same kit- { bi.SerialNumber}");
                            tb_SpareCableSerial.Text = string.Empty;
                            return;
                        }
                    }
                    else
                    {
                        //get the cable identifier
                        string subCableIdentifier = bi.FullString.Substring(0, 2);

                        //get the identifier from the database
                        DataRow[] dbIdentifier = KitInfo.Instance.dsMaterialInfo.Tables["Cables"].Select($"Identifier = '{subCableIdentifier}'");

                        //grab only the part number from the returned info from database
                        string dbPartNum = dbIdentifier[0][2].ToString();

                        //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                        if (dbPartNum != KitInfo.Instance.CableMaterialNumber) { MessageBox.Show($"Wrong cable is being used - {bi.MaterialNumber}"); return; };

                        //assign to the barcode info class
                        bi.MaterialNumber = dbPartNum;
                        bi.SerialNumber = bi.FullString;

                        //check if duplicate cable as scanned ( same as first cable)
                        if (bi.SerialNumber == tb_CableSerial.Text)
                        {
                            MessageBox.Show($"Duplicate cable is being scanned in the same kit- { bi.SerialNumber}");
                            tb_SpareCableSerial.Text = string.Empty;
                            return;
                        }

                    }

                    //check if the cable serial is the same as spare cable serial
                    if (bi.SerialNumber == tb_CableSerial.Text)
                    {
                        MessageBox.Show($"This serial was already scanned as Cable Serial 1 !!");
                        return;
                    }


                    //check if the cable was already used
                    DataTable dtTemp = Helper.dtWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);

                    //show user if cable was already used
                    if (dtTemp.Rows.Count < 1)
                    {

                        //assign the serial number to the textbox
                        tb_SpareCableSerial.Text = bi.SerialNumber;

                        //change textbox color
                        ChangeTextboxBackcolor(tb_SpareCableSerial, false);

                        //assign to KitInfo
                        KitInfo.Instance.SpareCableSerial = tb_SpareCableSerial.Text;

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);

                    }
                    else
                    {
                        //assign the serial number to the textbox
                        tb_SpareCableSerial.Text = bi.SerialNumber;

                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0][0];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************


                        //change textbox color
                        ChangeTextboxBackcolor(tb_SpareCableSerial);

                        //assign the error message
                        KitInfo.Instance.ErrorDescription = ($"Cable Serial { bi.SerialNumber} was already used");

                        //show the wasalreadyused form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {

                            //assign to KitInfo
                            KitInfo.Instance.SpareCableSerial = tb_SpareCableSerial.Text;

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                        else
                        {
                            tb_SpareCableSerial.Text = string.Empty;
                        }
                    }

                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");

                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }

            }
        }

        #endregion

        #region Remote Serial
        private void tb_RemoteSerial_KeyUp(object sender, KeyEventArgs e)
        {

            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    DataSet dsCheckSerialUse = new DataSet();

                    //create a new instance of barcode info class
                    BarcodeInfo bi = new BarcodeInfo();
                    bi.FullString = tb_RemoteSerial.Text;

                    if (bi.FullString.Count() > 12) //<~~~~ A UDI barcode was scanned
                    {

                        //split the barcode
                        List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                        //get the material number and serial from the previous list
                        bi.MaterialNumber = BarcodeSplit[0];
                        bi.SerialNumber = BarcodeSplit[1];

                        //get the remote material number from db
                        DataRow[] getRemotePN = KitInfo.Instance.dsMaterialInfo.Tables["Remote_Types"].Select($"RemotePartNumber = '{bi.MaterialNumber}'");

                        KitInfo.Instance.RemoteMaterialNumber = getRemotePN[0][1].ToString();

                        //compare the scanned remote material to the kit info remote material , return error if the material doesn't match
                        if (bi.MaterialNumber != KitInfo.Instance.RemoteMaterialNumber) { MessageBox.Show($"Wrong Remote is being used - {bi.MaterialNumber}"); return; };

                        //assign to the barcode info class
                        bi.MaterialNumber = KitInfo.Instance.RemoteMaterialNumber;
                        bi.SerialNumber = bi.SerialNumber;
                    }
                    else
                    {
                        //get the remote material number from db
                        DataRow[] getRemotePN = KitInfo.Instance.dsMaterialInfo.Tables["Remote_Types"].Select($"RemotePartNumber = '{bi.MaterialNumber}'");

                        KitInfo.Instance.RemoteMaterialNumber = getRemotePN[0][1].ToString();

                        //assign to the barcode info class
                        bi.MaterialNumber = KitInfo.Instance.RemoteMaterialNumber;
                        bi.SerialNumber = bi.FullString;

                    }


                    //check if the remote was already used
                    DataTable dtTemp = Helper.dtWasRemoteSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasRemoteSerialAlreadyUsed(bi.SerialNumber, bi.MaterialNumber);


                    //show user if remote was already used
                    if (dtTemp.Rows.Count < 1)
                    {

                        //assign the serial number to the textbox
                        tb_RemoteSerial.Text = bi.SerialNumber;

                        //change textbox color
                        ChangeTextboxBackcolor(tb_RemoteSerial, false);

                        //assign to KitInfo
                        KitInfo.Instance.RemoteSerial = tb_RemoteSerial.Text;

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    else
                    {
                        //assign the serial number to the textbox
                        tb_RemoteSerial.Text = bi.SerialNumber;

                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0][0];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************


                        //change textbox color
                        ChangeTextboxBackcolor(tb_RemoteSerial);

                        //assign the error message
                        KitInfo.Instance.ErrorDescription = ($"Remote Serial { bi.SerialNumber} was already used");

                        //show the wasalreadyused form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {
                            //assign to KitInfo
                            KitInfo.Instance.RemoteSerial = tb_RemoteSerial.Text;

                            //change textbox color
                            ChangeTextboxBackcolor(tb_RemoteSerial, false);

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);

                        }
                        else
                        {
                            tb_RemoteSerial.Text = string.Empty;

                        }

                    }

                }
                catch (Exception up)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                    // MessageBox.Show($"Error : Please check log for error");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }
                }
            }
        }

        #endregion

        #region Validate Sensor 1
        private void ValidateSensor()
        {
            try
            {
                //create a new instance of barcode info class
                BarcodeInfo bi = new BarcodeInfo();

                bi.FullString = tb_SensorSerial.Text;


                //get text info
                string barcodeSize2KitMaterial = string.Empty;

                //misc variables
                string dbSub = string.Empty;
                string dbPartNumber = string.Empty;
                string subSensorIdentifier = string.Empty;
                DataSet dsCheckSerialUse = new DataSet();


                #region check if a UDI barcode was scanned


                if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                {
                    //split the barcode
                    List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                    //get the material number and serial from the previous list
                    bi.MaterialNumber = BarcodeSplit[0];
                    bi.SerialNumber = BarcodeSplit[1];

                }
                else // <~~~ Not a UDI code
                {

                    if (KitInfo.Instance.bIsStarterKit || KitInfo.Instance.bIsAEcomboKit)
                    {
                        string senIdentifier = string.Empty;

                        //use the sensor part number and get the identifier for that part number within the Material_Matching table
                        DataTable dtSensorKitInfo = Helper.dtGetMaterialInfoUsingMaterialNumber(KitInfo.Instance.Sensor1MaterialNumber);

                        if (dtSensorKitInfo.Rows.Count > 0)
                        {
                            //get the identifier from db
                            senIdentifier = dtSensorKitInfo.Rows[0]["Material_Number"].ToString();

                            if (KitInfo.Instance.Sensor1MaterialNumber != senIdentifier)
                            {
                                MessageBox.Show($"Wrong sensor is being used , we need to use a {KitInfo.Instance.Sensor1MaterialNumber}!");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error identifying the sensor being used");
                            return;
                        }


                        //assign to the barcode info class
                        bi.MaterialNumber = senIdentifier;
                        bi.SerialNumber = bi.FullString;

                    }
                    else
                    {
                        //get the sensor identifier
                        subSensorIdentifier = bi.FullString.Substring(0, 2);
                        if (subSensorIdentifier == "00") { subSensorIdentifier = bi.FullString.Substring(0, 4); };

                        //get the identifier from the database
                        DataRow[] dbIdentifier = KitInfo.Instance.dsMaterialInfo.Tables["Sensor_Identifications"].Select($"Identifier = '{subSensorIdentifier}'");

                        //grab the identifier from the returned info from database
                        dbSub = dbIdentifier[0][1].ToString();

                        //grab the part number from database
                        dbPartNumber = dbIdentifier[2].ToString();

                        //assign to the barcode info class
                        bi.MaterialNumber = dbPartNumber;
                        bi.SerialNumber = bi.FullString;
                    }

                }

                #endregion

                //check if correct sensor is being used
                if (KitInfo.Instance.bIsStarterKit || KitInfo.Instance.bIsAEcomboKit)
                {
                    //if AE combo , check for correct sensor kit size
                    if (KitInfo.Instance.bIsAEcomboKit)
                    {
                        //this sensor kit MUST be a size 2 matching the Combo KIT

                        //first check the scanned barcode
                        barcodeSize2KitMaterial = bi.MaterialNumber;

                        //get the size 2 sensor part number ( Sensor1MaterialNumber should be a size 2 part number)
                        string size2ShipKitMaterial = KitInfo.Instance.Sensor1MaterialNumber;

                        //this is a AE Combo kit so make sure the sensor being scanned here is a Size 2 Sensor Kit (with correct cable size)
                        if (barcodeSize2KitMaterial != size2ShipKitMaterial)
                        {
                            MessageBox.Show($"Wrong material is being used ! \n \nKit needs a : {size2ShipKitMaterial}  \n \nbut you scanned a : {barcodeSize2KitMaterial}");
                            tb_SensorSerial.Text = string.Empty;
                            return;
                        };

                    }
                    else if (KitInfo.Instance.bIsStarterKit)
                    {
                        //check if correct sensor part number is being used for the starter kit
                        var drTemp = KitInfo.Instance.dsMaterialInfo.Tables["Material_Matching"].Select($"Material_Number = '{ KitInfo.Instance.MaterialNumber}'");
                        if (drTemp.Any())
                        {
                            string materialNeeded = drTemp[0]["Sensor_Material_Number"].ToString().TrimEnd();

                            if (bi.MaterialNumber != materialNeeded)
                            {
                                MessageBox.Show($"Wrong material is being used ! \n \nKit needs a : {materialNeeded}  \n \nbut you scanned a : { bi.MaterialNumber }");
                                tb_SensorSerial.Text = string.Empty;
                                return;
                            }
                        }
                    }
                    else
                    {
                        //compare the scanned sensor material to the kit info sensor material , return error if the material doesn't match
                        if (!KitInfo.Instance.Sensor1MaterialNumber.Contains(bi.MaterialNumber)) { MessageBox.Show($"Wrong material is being used - {  bi.MaterialNumber}"); return; };
                    }

                    //get and assign the kit row id from database
                    KitInfo.Instance.Sensor1SerialKitID = Helper.GetKitID(bi.MaterialNumber, bi.SerialNumber);

                    if (KitInfo.Instance.Sensor1SerialKitID < 1)
                    {

                        //store original Material info from Kit Info
                        string originalKitMaterial = KitInfo.Instance.MaterialNumber;

                        string originalKitSerial = (String.IsNullOrEmpty(KitInfo.Instance.KitSerial)) ? string.Empty : KitInfo.Instance.KitSerial;

                        string originalOrderNumber = (string.IsNullOrEmpty(KitInfo.Instance.OrderNumber)) ? string.Empty : KitInfo.Instance.OrderNumber;
                        

                        //*************************************************************************************************************************
                        //try to get the sensor kit info from sap so we can enter it automatically
                        string message = $"Sensor Kit {bi.MaterialNumber} - {bi.SerialNumber} WAS NOT entered using this system " +
                                        Environment.NewLine +
                                        "Do you want to enter the kit before you can use it in another bundle?";

                        string title = "Kit Info Missing";

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            //Try to get the material info
                            DataTable dtSapInfo = Helper.dtSAP_PerformSerialLookup(bi.MaterialNumber, bi.SerialNumber);
                            if (dtSapInfo.Rows.Count > 0)
                            {

                                //we have material info from SAP ! 
                           

                                //check if its a valid material number            
                                DataTable dtTempMaterial = Helper.dtGetMaterialInfoUsingMaterialNumber(bi.MaterialNumber);

                                if (dtTempMaterial != null && dtTempMaterial.Rows.Count > 0)
                                {
                                    //material is valid add it to the Kit info class
                                    string _description = dtTempMaterial.Rows[0]["Description"].ToString();

                                    KitInfo.Instance.MaterialNumber = bi.MaterialNumber;
                                    KitInfo.Instance.Description = _description;
                                }

                                bool isValid = Helper.bGetAndAssignMaterialInfo(dtTempMaterial);

                                //get all info from datatable
                                string sensorMaterial = string.Empty;
                                string sensorSerial = string.Empty;
                                string cableSerial1 = string.Empty;
                                string cableSerial2 = string.Empty;

                                //get row count
                                int rowCount = dtSapInfo.Rows.Count;

                                if (dtSapInfo.Rows[0][1].ToString().Contains("200"))
                                {
                                    sensorMaterial = dtSapInfo.Rows[1]["Material"].ToString();
                                    sensorSerial = dtSapInfo.Rows[1]["Serial"].ToString();
                                    cableSerial1 = dtSapInfo.Rows[2]["Serial"].ToString();

                                    if (KitInfo.Instance.bIsSpareCableNeeded)
                                    {
                                        cableSerial2 = dtSapInfo.Rows[3]["Serial"].ToString();
                                    }
                                }

                                //assign all kit info variables to automatically enter kit
                                KitInfo.Instance.MaterialNumber = bi.MaterialNumber;
                                KitInfo.Instance.KitSerial = bi.SerialNumber;
                                KitInfo.Instance.Sensor1Serial = sensorSerial;
                                KitInfo.Instance.CableSerial = cableSerial1;
                                if (KitInfo.Instance.bIsSpareCableNeeded)
                                    KitInfo.Instance.SpareCableSerial = cableSerial2;

                                KitInfo.Instance.OrderNumber = "Check SAP";

                                //enter kit info into database ( NOT SAP!)
                                bool bInsertDataToDB = InsertKitInfoToDB();

                                if (bInsertDataToDB)
                                {

                                    dtTempMaterial = null;

                                    // reassign original kit info to kitinfo class
                                    dtTempMaterial = new DataTable();

                                    //clear KitInfo class and repopulate
                                    KitInfo.Instance.ClearAll();

                                    //check if its a valid material number            
                                    dtTempMaterial = Helper.dtGetMaterialInfoUsingMaterialNumber(originalKitMaterial);

                                    if (dtTempMaterial != null && dtTempMaterial.Rows.Count > 0)
                                    {
                                        //material is valid add it to the Kit info class
                                        string _description = dtTempMaterial.Rows[0]["Description"].ToString();

                                        KitInfo.Instance.MaterialNumber = originalKitMaterial;
                                        KitInfo.Instance.Description = _description;

                                        KitInfo.Instance.OrderNumber = (!string.IsNullOrEmpty(originalOrderNumber)) ? originalOrderNumber : string.Empty;

                                        KitInfo.Instance.KitSerial = (!string.IsNullOrEmpty(originalKitSerial)) ? originalKitSerial : string.Empty;
                                    }

                                    isValid = Helper.bGetAndAssignMaterialInfo(dtTempMaterial);

                                    if (!isValid)
                                    {
                                        MessageBox.Show("Error reassign Material info please contact admin ASAP!");

                                        tb_SensorSerial.Focus();

                                        //change textbox color
                                        ChangeTextboxBackcolor(tb_SensorSerial);

                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {                   
                            tb_SensorSerial.Text = bi.SerialNumber;
                            tb_SensorSerial.Focus();

                            //change textbox color
                            ChangeTextboxBackcolor(tb_SensorSerial);

                            return;
                        }
                    }
                }
                else
                {
                    //compare the scanned cable identifier to the database identifier , return error if the material doesn't match
                    if (subSensorIdentifier != dbSub) { MessageBox.Show($"Wrong Sensor is being used - {dbPartNumber}"); return; };
                }

                //check is sensor was already used
                DataTable dtTemp = new DataTable();

                if (KitInfo.Instance.bIsStarterKit || KitInfo.Instance.bIsAEcomboKit)
                {
                    dtTemp = Helper.dtWasSensorShipKitAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasSensorShipKitAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);  //Helper.dsWasSensorUsedInStarterKit(KitInfo.Instance.MaterialNumber, bi.SerialNumber);
                }
                else
                {
                    dtTemp = Helper.dtWasSensorSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasSensorSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                }

                if (dtTemp.Rows.Count < 1)
                {
                    //assign the serial number to the textbox
                    tb_SensorSerial.Text = bi.SerialNumber;

                    //assign to KitInfo
                    KitInfo.Instance.Sensor1Serial = tb_SensorSerial.Text;

                    //change textbox color
                    ChangeTextboxBackcolor(tb_SensorSerial, false);

                    //move to next active control
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else
                {
                    //assign the serial number to the textbox
                    tb_SensorSerial.Text = bi.SerialNumber;

                    string whereUsed = string.Empty;
                    whereUsed = dtTemp.Rows[0]["WHERE_USED"].ToString();

                    if (!string.IsNullOrEmpty(whereUsed))
                    {
                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0]["WHERE_USED_ID"];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************

                        //change textbox color
                        ChangeTextboxBackcolor(tb_SensorSerial);

                        //assign the error message
                        KitInfo.Instance.ErrorDescription = ($"Sensor Serial { bi.SerialNumber} was already used");

                        //show the WasAlreadyUsed form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {
                            //assign to KitInfo
                            KitInfo.Instance.Sensor1Serial = tb_SensorSerial.Text;

                            //change textbox color
                            ChangeTextboxBackcolor(tb_SensorSerial, false);

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);

                        }
                        else
                        {
                            tb_SensorSerial.Text = string.Empty;
                        }

                        return;
                    }
                    else
                    {
                        //change textbox color
                        ChangeTextboxBackcolor(tb_SensorSerial, false);

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }

                }

            }
            catch (Exception ex)
            {
                //change textbox color
                ChangeTextboxBackcolor(tb_SensorSerial);

                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");

                // MessageBox.Show($"Error : Please check log for error");
                if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                }
            }


        }

        #endregion

        #region Validate Sensor 2
        private void ValidateSensor2()
        {

            try
            {
                //create a new instance of barcode info class
                BarcodeInfo bi = new BarcodeInfo();

                bi.FullString = tb_SensorSerial_2.Text;


                //get text info
                string barcodeSize1KitMaterial = string.Empty;

                //misc variables
                string dbSub = string.Empty;
                string dbPartNumber = string.Empty;
                string subSensorIdentifier = string.Empty;
                DataSet dsCheckSerialUse = new DataSet();


                #region check if a UDI barcode was scanned


                if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                {
                    //split the barcode
                    List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                    //get the material number and serial from the previous list
                    bi.MaterialNumber = BarcodeSplit[0];
                    bi.SerialNumber = BarcodeSplit[1];

                }
                else // <~~~ Not a UDI code
                {

                    //get the sensor identifier
                    subSensorIdentifier = bi.FullString.Substring(0, 2);
                    if (subSensorIdentifier == "00") { subSensorIdentifier = bi.FullString.Substring(0, 4); };

                    //get the identifier from the database
                    DataRow[] dbIdentifier = KitInfo.Instance.dsMaterialInfo.Tables["Sensor_Identifications"].Select($"Identifier = '{subSensorIdentifier}'");

                    //grab the identifier from the returned info from database
                    dbSub = dbIdentifier[0][1].ToString();

                    //grab the part number from database
                    dbPartNumber = dbIdentifier[2].ToString();

                    //assign to the barcode info class
                    bi.MaterialNumber = dbPartNumber;
                    bi.SerialNumber = bi.FullString;

                }

                #endregion

                //check if correct sensor is being used
                if (KitInfo.Instance.bIsStarterKit || KitInfo.Instance.bIsAEcomboKit)
                {
                    //if AE combo , check for correct sensor kit size
                    if (KitInfo.Instance.bIsAEcomboKit)
                    {
                        //this sensor kit MUST be a Size 1 matching the Combo KIT

                        //first check the scanned barcode
                        barcodeSize1KitMaterial = bi.MaterialNumber;

                        //get the size 1 sensor part number ( Sensor2MaterialNumber should be a size 1 part number)
                        var size1ShipKitMaterial = KitInfo.Instance.Sensor2MaterialNumber;

                        //this is a AE Combo kit so make sure the sensor being scanned here is a Size 1 Sensor Kit (with correct cable size)
                        if (barcodeSize1KitMaterial != size1ShipKitMaterial)
                        {
                            MessageBox.Show($"Wrong material is being used ! \n \nKit needs a : {size1ShipKitMaterial}  \n \nbut you scanned a : {barcodeSize1KitMaterial}");
                            tb_SensorSerial_2.Text = string.Empty;
                            return;
                        };
                    }

                    //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                    if (!KitInfo.Instance.Sensor2MaterialNumber.Contains(bi.MaterialNumber)) { MessageBox.Show($"Wrong material is being used - {  bi.MaterialNumber}"); return; }

                    else if (KitInfo.Instance.bIsStarterKit)
                    {
                        //check if correct sensor part number is being used for the starter kit
                        var drTemp = KitInfo.Instance.dsMaterialInfo.Tables["Material_Matching"].Select($"Material_Number = '{ KitInfo.Instance.MaterialNumber}'");
                        if (drTemp.Any())
                        {
                            string materialNeeded = drTemp[0]["Sensor_Material_Number"].ToString().TrimEnd();

                            if (bi.MaterialNumber != materialNeeded)
                            {
                                MessageBox.Show($"Wrong material is being used ! \n \nKit needs a : {materialNeeded}  \n \nbut you scanned a : { bi.MaterialNumber }");
                                tb_SensorSerial_2.Text = string.Empty;
                                return;
                            }
                        }
                    }
                    else
                    {
                        //compare the scanned sensor material to the kit info sensor material , return error if the material doesn't match
                        if (!KitInfo.Instance.Sensor2MaterialNumber.Contains(bi.MaterialNumber)) { MessageBox.Show($"Wrong material is being used - {  bi.MaterialNumber}"); return; };
                    }

                    //get and assign the kit row id from database
                    KitInfo.Instance.Sensor2SerialKitID = Helper.GetKitID(bi.MaterialNumber, bi.SerialNumber);

                    if (KitInfo.Instance.Sensor2SerialKitID < 1)
                    {
                        MessageBox.Show($"Sensor Kit {bi.MaterialNumber} - {bi.SerialNumber} WAS NOT entered using this system " +
                                       Environment.NewLine +
                                       "Please enter Sensor Kit info before it can be used in another kit");

                        tb_SensorSerial_2.Text = bi.SerialNumber;
                        tb_SensorSerial_2.Focus();

                        //change textbox color
                        ChangeTextboxBackcolor(tb_SensorSerial_2);

                        return;

                    }
                }

                //regular sensor kit
                else
                {
                    //compare the scanned cable identifier to the database identifier , return error if the material doesn't match
                    if (subSensorIdentifier != dbSub) { MessageBox.Show($"Wrong Sensor is being used - {dbPartNumber}"); return; };
                }


                //check is sensor was already used
                DataTable dtTemp = new DataTable();

                //check is sensor was already used
                if (KitInfo.Instance.bIsStarterKit || KitInfo.Instance.bIsAEcomboKit)
                {
                    dtTemp = Helper.dtWasSensorShipKitAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasSensorShipKitAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);  //Helper.dsWasSensorUsedInStarterKit(KitInfo.Instance.MaterialNumber, bi.SerialNumber);
                }
                else
                {
                    dtTemp = Helper.dtWasSensorSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                    // dsCheckSerialUse = Helper.dsWasSensorSerialAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                }


                if (dtTemp.Rows.Count < 1)
                {

                    //assign the serial number to the textbox
                    tb_SensorSerial_2.Text = bi.SerialNumber;

                    //assign to KitInfo
                    KitInfo.Instance.Sensor2Serial = tb_SensorSerial_2.Text;

                    //change textbox color
                    ChangeTextboxBackcolor(tb_SensorSerial_2, false);

                    //move to next active control
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                else
                {
                    //assign the serial number to the textbox
                    tb_SensorSerial_2.Text = bi.SerialNumber;

                    string whereUsed = string.Empty;
                    whereUsed = dtTemp.Rows[0][0].ToString();

                    if (!string.IsNullOrEmpty(whereUsed))
                    {
                        //************************************************************************************

                        //use the rowID from dtTemp and get the full material info using the ID
                        int rowID = (int)dtTemp.Rows[0][0];

                        DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                        //assign the datatable to the where used data set                      
                        KitInfo.Instance.dsSerialUsed = new DataSet();
                        KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                        //************************************************************************************

                        //change textbox color
                        ChangeTextboxBackcolor(tb_SensorSerial_2);

                        //assign the error message
                        KitInfo.Instance.ErrorDescription = ($"Sensor Serial { bi.SerialNumber} was already used");

                        //show the WasAlreadyUsed form
                        WasAlreadyUsed wau = new WasAlreadyUsed();
                        wau.ShowDialog();

                        if (KitInfo.Instance.Bypass)
                        {
                            //assign to KitInfo
                            KitInfo.Instance.Sensor2Serial = tb_SensorSerial_2.Text;

                            //change textbox color
                            ChangeTextboxBackcolor(tb_SensorSerial_2, false);

                            //move to next active control
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                        else
                        {
                            tb_SensorSerial_2.Text = string.Empty;
                        }
                        return;
                    }
                    else
                    {
                        //change textbox color
                        ChangeTextboxBackcolor(tb_SensorSerial_2, false);

                        //move to next active control
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }

                }

            }
            catch (Exception ex)
            {
                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");
                MessageBox.Show($"Error : {ex.StackTrace}");
            }

        }

        #endregion

        #endregion

        #region Combo Boxes

        private void Cb_TypeOfHierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelectedText = cb_TypeOfHierarchy.SelectedItem.ToString();

            if (!itemSelectedText.Contains("Select"))
            {
                KitInfo.Instance.HierarchyType = cb_TypeOfHierarchy.SelectedIndex;
            }

        }

        private void cb_StorageLocations_SelectedIndexChanged(object sender, EventArgs e)
        {

            string itemSelectedText = cb_StorageLocations.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(itemSelectedText))
            {
                KitInfo.Instance.StorageLocation = itemSelectedText;
            }
        }


        #endregion

        #region Check Boxes
        private void checkBox_Sensor_CheckedChanged(object sender, EventArgs e)
        {
            if (KitInfo.Instance.bIsChild1Checked)
            {
                KitInfo.Instance.bIsChild1Checked = false;
            }
            else
            {
                KitInfo.Instance.bIsChild1Checked = true;
            }
        }

        private void checkBox_Sensor_2_CheckedChanged(object sender, EventArgs e)
        {
            if (KitInfo.Instance.bIsChild2Checked)
            {
                KitInfo.Instance.bIsChild2Checked = false;
            }
            else
            {
                KitInfo.Instance.bIsChild2Checked = true;
            }
        }

        private void checkBox_Cable_CheckedChanged(object sender, EventArgs e)
        {
            if (KitInfo.Instance.bIsChild2Checked)
            {
                KitInfo.Instance.bIsChild2Checked = false;
            }
            else
            {
                KitInfo.Instance.bIsChild2Checked = true;
            }
        }

        private void checkBox_SpareCable_CheckedChanged(object sender, EventArgs e)
        {
            if (KitInfo.Instance.bIsChild3Checked)
            {
                KitInfo.Instance.bIsChild3Checked = false;
            }
            else
            {
                KitInfo.Instance.bIsChild3Checked = true;
            }

        }

        private void checkBox_Remote_CheckedChanged(object sender, EventArgs e)
        {
            if (KitInfo.Instance.bIsChild3Checked)
            {
                KitInfo.Instance.bIsChild3Checked = false;
            }
            else
            {
                KitInfo.Instance.bIsChild3Checked = true;
            }
        } 
        #endregion
    }
}
