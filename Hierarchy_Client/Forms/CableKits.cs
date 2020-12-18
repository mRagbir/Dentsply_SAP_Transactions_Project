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
using MetroFramework.Forms;



namespace Hierarchy_Client
{
    public partial class CableKits : MetroForm
    {
        DataTable dtCableTable = Helper.dtCreateMaterialTable();
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DataTable dtCablesTable = Helper.dtGetCableTableFromDB();

        //get the cable conversion table
        DataTable conversionTable = new DataTable();


        public CableKits()
        {
            InitializeComponent();
        }

        private void CableKits_Load(object sender, EventArgs e)
        {
            //hide some group boxes
            gb_Step2.Visible = false;
            gb_Step3.Visible = false;
            gb_Step4.Visible = false;

            //assign the kit number and description to the labels
            lbl_MaterialNumber.Text = KitInfo.Instance.MaterialNumber;
            lbl_MaterialDescription.Text = KitInfo.Instance.Description;

            //load default storage location
            tb_StorageLocation.Text = "FG-S11";

            //get app version from appconfig and display on form
            label_Version.Text = $"Version {ConfigurationManager.AppSettings["Version"].ToString()}";

            try
            {
                conversionTable = Helper.dtGetCableConversionTable();
            }
            catch (Exception )
            {

                MessageBox.Show("Failed to get Conversion Table");
            }
        }

        private void tb_StorageLocation_TextChanged(object sender, EventArgs e)
        {
            gb_Step2.Visible = true;

        }

        private void tb_OrderNumber_TextChanged(object sender, EventArgs e)

        {

        }

        /// <summary>
        /// Captures cable serial,evaluate for duplicates in DB, then adds to the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_ScanSerial_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                //make the submit button visible
                gb_Step4.Visible = true;

                //clear certain fields in Kit info to add cable info
                KitInfo.Instance.ClearForCableKits();

                try
                {

                    DataSet dsCheckSerialUse = new DataSet();

                    //create a new instance of barcode info class
                    BarcodeInfo bi = new BarcodeInfo();
                    bi.FullString = tb_ScanSerial.Text;
                    bi.MaterialNumber = KitInfo.Instance.MaterialNumber;

                    if (!string.IsNullOrEmpty(bi.FullString))
                    {
                        if (bi.FullString.Contains("/")) //<~~~~ A UDI barcode was scanned
                        {
                            //split the barcode
                            List<string> BarcodeSplit = Helper.lRemoveBarcodeSpecialCharacters(bi.FullString);

                            //get the serial number and from the previous list
                            bi.SerialNumber = BarcodeSplit[1];
                            bi.MaterialNumber = BarcodeSplit[0];


                            //get the cable material number from material matching table
                            var materialMatchingTableInfo = Helper.dtGetMaterialInfoUsingMaterialNumber(KitInfo.Instance.MaterialNumber);

                            if (materialMatchingTableInfo.Rows.Count < 1) { MessageBox.Show($"Error retrieving material info for {KitInfo.Instance.MaterialNumber}"); return; };

                            //store correct material number
                            string cableMaterialNumberFromMatchingTable = materialMatchingTableInfo.Rows[0]["Cable_Material_Number"].ToString();

                            

                            var checkIfMaterialNeedsConversion = conversionTable.Select($"SironaCableMaterial = '{bi.MaterialNumber}' ");
                            if (checkIfMaterialNeedsConversion.Any())
                            {
                                string convertedMaterialNumber = checkIfMaterialNeedsConversion[0]["ConvertedMaterial"].ToString();
                                bi.MaterialNumber = convertedMaterialNumber;
                            }

                            if (bi.MaterialNumber != cableMaterialNumberFromMatchingTable)
                            {
                                MessageBox.Show($"Wrong cable is being used for this kit" + Environment.NewLine + $"You are using a {bi.MaterialNumber} but system is looking for a {cableMaterialNumberFromMatchingTable}");

                                //clear the textbox contents
                                tb_ScanSerial.Text = string.Empty;

                                //refocus on the textbox for another serial entry
                                tb_ScanSerial.Focus();

                                return;
                            }

                        }
                        else
                        {
                            //assign the cable serial number
                            KitInfo.Instance.CableSerial = bi.FullString;

                            //get the cable identifier
                            string subCableIdentifier = bi.FullString.Substring(0, 2);

                            //get the identifier from the database
                            DataRow[] dbIdentifier = dtCablesTable.Select($"Identifier = '{subCableIdentifier}'");

                            //grab only the part number from the returned info from database
                            string dbPartNum = dbIdentifier[0][2].ToString();

                            string dbKitPartNum = dbIdentifier[0][5].ToString();

                            //compare the scanned cable material to the kit info cable material , return error if the material doesn't match
                            if (dbKitPartNum != KitInfo.Instance.MaterialNumber) { MessageBox.Show($"Wrong cable is being used - {bi.MaterialNumber}"); return; };

                            //assign to the barcode info class
                            bi.MaterialNumber = dbPartNum;
                            bi.SerialNumber = bi.FullString;

                            
                        }

                        //check if the serial was already scanned
                        if (listbox_Serials1.Items.Contains(bi.SerialNumber))
                        {
                            MessageBox.Show($"This cable was already scanned - {bi.SerialNumber}");
                            tb_ScanSerial.Text = string.Empty;
                            tb_ScanSerial.Focus();
                            return;
                        };



                        //assign the cable material number
                        KitInfo.Instance.CableMaterialNumber = bi.MaterialNumber;

                        //check if the cable was already used as a single cable
                        DataTable dtTemp = Helper.dtWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);
                        //dsCheckSerialUse = Helper.dsWasCableAlreadyUsed(bi.MaterialNumber, bi.SerialNumber);    


                        //show user if Kit was already used
                        if (dtTemp.Rows.Count < 1)
                        {
                            //assign the serial number to the textbox
                            tb_ScanSerial.Text = bi.SerialNumber;

                            //assign the serial number to the list box
                            listbox_Serials1.Items.Add(bi.SerialNumber);

                            //update the QTY counter
                            tb_Qty.Text = listbox_Serials1.Items.Count.ToString();

                            //clear the textbox contents
                            tb_ScanSerial.Text = string.Empty;

                            //refocus on the textbox for another serial entry
                            tb_ScanSerial.Focus();

                            // add row info
                            // AddTableRowInfo();


                            //assign the serial number to the textbox
                            //tb_ScanSerial.Text = bi.SerialNumber;

                            ////assign the error message
                            //KitInfo.Instance.ErrorDescription = ($"Cable Serial { bi.SerialNumber} was already used");

                            ////show the was already used form
                            //WasAlreadyUsed wau = new WasAlreadyUsed();
                            //wau.ShowDialog();

                            ////assign to KitInfo
                            //KitInfo.Instance.CableSerial = tb_ScanSerial.Text;

                            ////refocus on the textbox for another serial entry
                            //tb_ScanSerial.Focus();

                            ////if cable is not going to be bypassed then user needs to enter another cable serial so exit here
                            //if (KitInfo.Instance.Bypass == false)
                            //{
                            //    return;//exit
                            //}
                        }
                        else
                        {
                            //assign the serial number to the textbox
                            tb_ScanSerial.Text = bi.SerialNumber;

                            //************************************************************************************

                            //use the rowID from dtTemp and get the full material info using the ID
                            int rowID = (int)dtTemp.Rows[0][0];

                            DataTable dtFullInfo = Helper.GetMaterialInfoUsingRowID(bi.MaterialNumber, rowID);

                            //assign the datatable to the where used data set                      
                            KitInfo.Instance.dsSerialUsed = new DataSet();
                            KitInfo.Instance.dsSerialUsed.Tables.Add(dtFullInfo);

                            //************************************************************************************


                            //assign the error message
                            KitInfo.Instance.ErrorDescription = ($"Cable Serial { bi.SerialNumber} was already used");

                            //show the was already used form
                            WasAlreadyUsed wau = new WasAlreadyUsed();
                            wau.ShowDialog();

                            //assign to KitInfo
                            KitInfo.Instance.CableSerial = tb_ScanSerial.Text;

                            //refocus on the textbox for another serial entry
                            tb_ScanSerial.Focus();

                            //if cable is not going to be bypassed then user needs to enter another cable serial so exit here
                            if (KitInfo.Instance.Bypass)
                            {
                                //assign the serial number to the textbox
                                tb_ScanSerial.Text = bi.SerialNumber;

                                //assign the serial number to the list box
                                listbox_Serials1.Items.Add(bi.SerialNumber);

                                //update the QTY counter
                                tb_Qty.Text = listbox_Serials1.Items.Count.ToString();

                                //clear the textbox contents
                                tb_ScanSerial.Text = string.Empty;

                                //refocus on the textbox for another serial entry
                                tb_ScanSerial.Focus();
                            }


                            // KitInfo.Instance.Bypass = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");

                    // MessageBox.Show($"Error : Please check log for error");
                    if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                    }

                }
                finally
                {
                    //refocus on the textbox for another serial entry
                    tb_ScanSerial.Focus();
                }
            }
        }

        private void AddTableRowInfo()
        {
            DataRow dr = dtCableTable.NewRow();

            //add values to the data row
            dr["KitMaterialNumber"] = KitInfo.Instance.MaterialNumber;
            dr["CableMaterialNumber"] = KitInfo.Instance.CableMaterialNumber;
            dr["SerialNumber"] = KitInfo.Instance.CableSerial;
            dr["OrderNumber"] = KitInfo.Instance.OrderNumber;
            dr["StorageLocation"] = KitInfo.Instance.OrderNumber;
            dr["User"] = KitInfo.Instance.Username;
            dr["Note"] = KitInfo.Instance.NoteForBypass == string.Empty ? KitInfo.Instance.ReasonForBypass : KitInfo.Instance.NoteForBypass;
            dr["BypassInDB"] = KitInfo.Instance.Bypass ? "True" : "False";
            dr["RowIDinDB"] = KitInfo.Instance.RowIDofBypassInDB;

            //add the row to data table
            dtCableTable.Rows.Add(dr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //close this form
            this.Hide();

            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();

            //reopen the material number form
            Login login = new Login();
            login.ShowDialog();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            //clear the list box
            listbox_Serials1.Items.Clear();
        }

        private void MessageBoxMessage(string message)
        {
            MessageBox.Show(message);
        }

        private bool CheckForEmptyValues()
        {
            bool isPassed = true;

            try
            {
                if (tb_OrderNumber.Text == string.Empty)
                {
                    isPassed = false; MessageBoxMessage("Enter Order Number!");
                }
                else
                {
                    KitInfo.Instance.OrderNumber = tb_OrderNumber.Text;
                }

                if (tb_StorageLocation.Text == string.Empty)
                {
                    isPassed = false; MessageBoxMessage("Enter Storage Location!");
                }
                else
                {
                    KitInfo.Instance.StorageLocation = tb_StorageLocation.Text;
                };

                //if (tb_StorageLocation.Text == string.Empty)
                //{
                //    isPassed = false; MessageBoxMessage("Enter Storage Location!");
                //}
                //else
                //{
                //    KitInfo.Instance.StorageLocation = tb_StorageLocation.Text;
                //};



            }
            catch (Exception up)
            {
                logger.Error($"User :{KitInfo.Instance.Username} - {up.StackTrace}");
                MessageBox.Show($"Error : {up.StackTrace}");
            }

            return isPassed;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

            DataTable dtEnterCableKit = new DataTable();
            //check for empty values before continuing
            bool checkTextBoxValues = CheckForEmptyValues();

            if (!checkTextBoxValues) { return; };

            DialogResult areYouReady = MessageBox.Show("Are you logged into SAP and have 3 session windows open??",
                            "SAP connection check",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            //ready to continue
            if (areYouReady == DialogResult.Yes)
            {

                //grab all serials into a temp list 
                List<string> lSerials = new List<string>();

                foreach (string serial in listbox_Serials1.Items)
                {
                    lSerials.Add(serial);
                }

                //perform sap transaction
                bool sapTrans = SAP_CONNECTION.CableKits.SAP_CableKits(KitInfo.Instance.MaterialNumber,
                                                                       KitInfo.Instance.OrderNumber,
                                                                       KitInfo.Instance.StorageLocation,
                                                                       lSerials);

                //string getSapTransactionCode = sapTrans[0].ToString();

                //if there is SAP error during transaction then throw user a message
                if (!sapTrans)
                {
                    MessageBox.Show("An SAP transaction error has occurred. Check SAP screen for details or make sure you have 3 SAP windows open and try again");
                    return;
                }
                else
                {
                    //if everything goes well then insert each serial into the sql data base
                    foreach (string serial in lSerials)
                    {
                        //enter kit info
                        dtEnterCableKit = Helper.dtInsertCableKit(KitInfo.Instance.OrderNumber,
                                                                  KitInfo.Instance.MaterialNumber,
                                                                  KitInfo.Instance.CableMaterialNumber,
                                                                  serial,
                                                                  KitInfo.Instance.UAPID,
                                                                  KitInfo.Instance.NoteForBypass);

                        //get the entered kit ID returned from db
                        int dbEntry = (int)dtEnterCableKit.Rows[0][0];
                        if (dbEntry < 1)
                        {
                            MessageBoxMessage($"A SQL server error has occurred trying to insert : {serial}. " + Environment.NewLine + "Please write down the serial number then contact an Admin ASAP");
                            return;
                        }
                    }

                }



                //test for data base only , comment out when finished
                //foreach (DataRow item in dtCableTable.Rows)
                //{
                //    //DataSet dsResults = Helper.dsInsertCableKit(KitInfo.Instance.CableMaterialNumber, item.ToString(), 
                //    //                                            KitInfo.Instance.OrderNumber, KitInfo.Instance.MaterialNumber);
                //    //  if (dsResults.Tables.Contains("Error")) { MessageBoxMessage("A SQL server error has occurred during insert. Contact Admin!"); return; };

                //    //insert the full cable kit into DB
                //    //DataSet dsResults = Helper.dsInsertCableKit(item["CableMaterialNumber"].ToString(),
                //    //                                            item["SerialNumber"].ToString(),
                //    //                                            item["OrderNumber"].ToString(),
                //    //                                            item["KitMaterialNumber"].ToString());

                //    //if (dsResults.Tables.Contains("Error")) { MessageBoxMessage("A SQL server error has occurred during insert. Contact Admin!"); return; };

                //    ////check if the original cable needs a note, add if needed
                //    //if (!string.IsNullOrEmpty(item["Note"].ToString()))
                //    //{
                //    //    //add the note to the original row id of the serial

                //    //};






                //    ////perform the sap transaction
                //    //var sapInput = SAP_CONNECTION.CableKits.SAP_CableKits(KitInfo.Instance.MaterialNumber, KitInfo.Instance.OrderNumber,
                //    //                                                      KitInfo.Instance.StorageLocation, KitInfo.Instance.dicBypassedCables);

                //    //var getCode = sapInput[1].ToString();

                //    ////if there is SAP error during transaction then throw user a message
                //    //if (getCode != "0")
                //    //{
                //    //    MessageBox.Show("An SAP transaction error has occurred. Check SAP screen for details or make sure you have 3 SAP windows open and try again");
                //    //    return;
                //    //}
                //    //else
                //    //{
                //    //    //if everything goes well then insert each serial into the sql data base
                //    //    foreach (var item in listbox_Serials.Items)
                //    //    {
                //    //       DataSet dsResults = Helper.dsInsertCableKit(KitInfo.Instance.CableMaterialNumber, item.ToString(), KitInfo.Instance.OrderNumber, KitInfo.Instance.MaterialNumber);
                //    //    }
                //}

            }
            else
            {
                return;
            }

            MessageBoxMessage("All serials have been entered :) ");

        }

        private void tb_OrderNumber_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                gb_Step3.Visible = true;
                tb_ScanSerial.Focus();
                KitInfo.Instance.OrderNumber = tb_OrderNumber.Text;
            }
        }

        private void metroButton_Submit_Click(object sender, EventArgs e)
        {

            try
            {

                DataTable dtEnterCableKit = new DataTable();
                //check for empty values before continuing
                bool checkTextBoxValues = CheckForEmptyValues();

                if (!checkTextBoxValues) { return; };

                DialogResult areYouReady = MessageBox.Show("Are you logged into SAP and have 3 session windows open??",
                                "SAP connection check",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                //ready to continue
                if (areYouReady == DialogResult.Yes)
                {

                    //grab all serials into a temp list 
                    List<string> lSerials = new List<string>();

                    foreach (string serial in listbox_Serials1.Items)
                    {
                        lSerials.Add(serial);
                    }

                    //perform sap transaction
                    bool sapTrans = SAP_CONNECTION.CableKits.SAP_CableKits(KitInfo.Instance.MaterialNumber,
                                                                           KitInfo.Instance.OrderNumber,
                                                                           KitInfo.Instance.StorageLocation,
                                                                           lSerials);

                    //string getSapTransactionCode = sapTrans[1].ToString();

                    //if there is SAP error during transaction then throw user a message
                    if (!sapTrans)
                    {
                        MessageBox.Show("An SAP transaction error has occurred. Check SAP screen for details or make sure you have 3 SAP windows open and try again");
                        return;
                    }
                    else
                    {
                        //if everything goes well then insert each serial into the sql data base
                        foreach (string serial in lSerials)
                        {
                            //enter kit info
                            dtEnterCableKit = Helper.dtInsertCableKit(KitInfo.Instance.OrderNumber,
                                                                      KitInfo.Instance.MaterialNumber,
                                                                      KitInfo.Instance.CableMaterialNumber,
                                                                      serial,
                                                                      KitInfo.Instance.UAPID,
                                                                      KitInfo.Instance.NoteForBypass);

                            //get the entered kit ID returned from db
                            int dbEntry = (int)dtEnterCableKit.Rows[0][0];
                            if (dbEntry < 1)
                            {
                                MessageBoxMessage($"A SQL server error has occurred trying to insert : {serial}. " + Environment.NewLine + "Please write down the serial number then contact an Admin ASAP");
                                return;
                            }
                        }

                    }

                }
                else
                {
                    return;
                }

                MessageBoxMessage("All serials have been entered :) ");
            }
            catch (Exception ex)
            {
                logger.Error($"User :{KitInfo.Instance.Username} - {ex.StackTrace}");

                // MessageBox.Show($"Error : Please check log for error");
                if (MessageBox.Show("Error found - Check log?", "Error Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"C:\Logs\Hierarchy_Client.log");
                }
            }

        }

        private void metroButton_ClearList_Click(object sender, EventArgs e)
        {
            //clear the list box
            listbox_Serials1.Items.Clear();

            tb_Qty.Text = listbox_Serials1.Items.Count.ToString();
        }

        private void metroButton_Home_Click(object sender, EventArgs e)
        {
            //close this form
            this.Hide();
            this.Close();

            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();

            //reopen the material number form
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
        }


    }
}
