using Hierarchy_Client.ProductionUtilitiesService;
using Hierarchy_Client.SchickWeb;

using SAPConnectionClientProxy;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy_Client
{
    public class Helper
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region Shared Methods

        public static DataTable dtCreateMaterialTable()
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp.Columns.Add("KitMaterialNumber");
                dtTemp.Columns.Add("CableMaterialNumber");
                dtTemp.Columns.Add("SerialNumber");
                dtTemp.Columns.Add("OrderNumber");
                dtTemp.Columns.Add("StorageLocation");
                dtTemp.Columns.Add("User");
                dtTemp.Columns.Add("Note");
                dtTemp.Columns.Add("BypassInDB");
                dtTemp.Columns.Add("RowIDinDB");
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return dtTemp;

        }

        public static string[] getCredentialsFromBarcode(string _credentials)
        {
            string[] credentials = new string[2];
            try
            {
                string split1 = string.Empty;
                string[] split2 = new string[2];

                if (_credentials.Contains("CREDENTIALS:"))
                {
                    split1 = _credentials.Substring(12);
                    split2 = split1.Split('|');
                }
                else
                {
                    split2 = _credentials.Split('|');
                }

                credentials[0] = split2[0].ToString();
                credentials[1] = split2[1].ToString();
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return credentials;
        }

        public static string Login(string _credentials)
        {
            string[] loginInfo = getCredentialsFromBarcode(_credentials);

            string UAPID = string.Empty;
            try
            {
                SensorDataAccessServiceWSSoapClient schickweb = new SensorDataAccessServiceWSSoapClient();

                //call schickweb login method
                UAPID = schickweb.Login(loginInfo[0], loginInfo[1]);

                //assign the user name to the kit info
                if (!string.IsNullOrEmpty(UAPID))             
                KitInfo.Instance.Username = loginInfo[0].ToString();
            }
            catch (Exception ex)
            {
                //fails to return a UAPID
                logger.Error(ex.StackTrace);
            }

            return UAPID;

        }

        public static DataTable dtGetMaterialInfoUsingMaterialNumber(string _materialNumber)
        {

            DataTable dtValidateMaterial = new DataTable();

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtValidateMaterial = clientProxy.GetMaterialInfoUsingMaterialNumber(_materialNumber);


                    //if (dtValidateMaterial != null && dtValidateMaterial.Rows.Count > 0)
                    //{
                    //    //material is valid add it to the Kit info class
                    //    string _description = dtValidateMaterial.Rows[0][2].ToString();

                    //    KitInfo.Instance.MaterialNumber = _materialNumber;
                    //    KitInfo.Instance.Description = _description;
                    //}
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return dtValidateMaterial;
        }

        public static DataTable dtGetCableTableFromDB()
        {
            DataTable dtCables = new DataTable();

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtCables = clientProxy.GetCablesTable();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return dtCables;
        }

        public static DataTable dtGetCableConversionTable()
        {
            DataTable dtCables = new DataTable();

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtCables = clientProxy.GetCablesConversionTable();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return dtCables;
        }

        public static DataTable dtGetWarehouseLocations()
        {
            DataTable dtCables = new DataTable();

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtCables = clientProxy.GetWarehouseLocations();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return dtCables;
        }

        public static DataSet GetAllMaterialMatchingInformation()
        {

            DataSet dsTemp = new DataSet();

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dsTemp = clientProxy.GetAllMaterialInfo();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return dsTemp;
        }

        /// <summary>
        /// Assign all DB info to KitInfo class
        /// </summary>
        /// <param name="dtMaterialInfoFromDB"></param>
        /// <returns></returns>
        public static bool bGetAndAssignMaterialInfo(DataTable dtMaterialInfoFromDB)
        {
            bool isPassed = true;

            try
            {
                ////get the material info from service
                //KitInfo.Instance.dsMaterialInfo = puc.GetAllMaterialInfo();

                //grab the right table from the returned dataset
                //DataTable dtTemp = KitInfo.Instance.dsMaterialInfo.Tables["Material_Matching"];

                //store the row information in the kit info class
                //KitInfo.Instance.drMaterialInfo = dtTemp.Select($"Material_Number = '{_materialNumber}'");
                KitInfo.Instance.drMaterialInfo = dtMaterialInfoFromDB.Rows[0];

                //check if any results

                foreach (DataRow dr in dtMaterialInfoFromDB.Rows)
                {
                    //Get the identifier from DB
                    if (!string.IsNullOrEmpty(dr["Identifier"].ToString()))
                        KitInfo.Instance.Identifier = dr["Identifier"].ToString().Trim();

                    //Get the material number from DB
                    if (!string.IsNullOrEmpty(dr["Material_Number"].ToString()))
                        KitInfo.Instance.MaterialNumber = dr["Material_Number"].ToString().Trim();

                    //Get the sensor material number
                    if (!string.IsNullOrEmpty(dr["Sensor_Material_Number"].ToString()))
                    {
                        string sensorMaterialNum = dr["Sensor_Material_Number"].ToString();

                        if (sensorMaterialNum.Contains(','))
                        {
                            string[] splitMaterial = sensorMaterialNum.Split(',');

                            //assign the size 2 sensor material number
                            KitInfo.Instance.Sensor1MaterialNumber = splitMaterial[0].Trim();

                            //assign the size 1 sensor material number
                            KitInfo.Instance.Sensor2MaterialNumber = splitMaterial[1].Trim();
                        }
                        else
                        {
                            KitInfo.Instance.Sensor1MaterialNumber = sensorMaterialNum.Trim();
                        }
                    }


                    if (!string.IsNullOrEmpty(dr["Cable_Material_Number"].ToString()))
                        KitInfo.Instance.CableMaterialNumber = dr["Cable_Material_Number"].ToString().Trim();


                    if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                        KitInfo.Instance.Description = dr["Description"].ToString().Trim();

                    if (!string.IsNullOrEmpty(dr["Spare_Cable"].ToString()))
                        KitInfo.Instance.bIsSpareCableNeeded = Convert.ToBoolean(dr["Spare_Cable"]);

                    if (!string.IsNullOrEmpty(dr["IsStarterKit"].ToString()))
                    {
                        KitInfo.Instance.bIsStarterKit = Convert.ToBoolean(dr["IsStarterKit"]);
                        if (KitInfo.Instance.bIsStarterKit)
                        {
                            KitInfo.Instance.bIsChild1Checked = false;
                            KitInfo.Instance.bIsChild2Checked = false;
                        };

                    }

                    if (!string.IsNullOrEmpty(dr["isCableNeededOnSensor"].ToString()))
                        KitInfo.Instance.bIsCableOnSensorNeeded = Convert.ToBoolean(dr["isCableNeededOnSensor"]);

                    if (!string.IsNullOrEmpty(dr["isSensorNeeded"].ToString()))
                        KitInfo.Instance.bIsSensorNeeded = Convert.ToBoolean(dr["isSensorNeeded"]);

                    //if (!KitInfo.Instance.bIsSensorNeeded)
                    //{
                    //    KitInfo.Instance.bIsChild1Checked = true;
                    //    KitInfo.Instance.bIsChild2Checked = true;
                    //    KitInfo.Instance.bIsChild3Checked = false;
                    //}


                    if (!string.IsNullOrEmpty(dr["isEliteStarterKit"].ToString()))
                        KitInfo.Instance.bIsEliteStarterKit = Convert.ToBoolean(dr["isEliteStarterKit"]);

                    if (!string.IsNullOrEmpty(dr["isEliteBasicKit"].ToString()))
                        KitInfo.Instance.bIsEliteBasicKit = Convert.ToBoolean(dr["isEliteBasicKit"]);

                    if (!string.IsNullOrEmpty(dr["IsAEcomboKit"].ToString()))
                        KitInfo.Instance.bIsAEcomboKit = Convert.ToBoolean(dr["IsAEcomboKit"]);

                    if (!string.IsNullOrEmpty(dr["IsAEkit"].ToString()))
                        KitInfo.Instance.bIsAEkit = Convert.ToBoolean(dr["IsAEkit"]);

                    if (!string.IsNullOrEmpty(dr["isRemoteNeeded"].ToString()))
                        KitInfo.Instance.bIsRemoteNeeded = Convert.ToBoolean(dr["isRemoteNeeded"]);

                    if (!string.IsNullOrEmpty(dr["MATERIAL_FAMILY"].ToString()))
                        KitInfo.Instance.MaterialFamily = dr["MATERIAL_FAMILY"].ToString().Trim();

                    if (!string.IsNullOrEmpty(dr["IS_COMBO_KIT"].ToString()))
                    {
                        KitInfo.Instance.bIsComboKit = Convert.ToBoolean(dr["IS_COMBO_KIT"]);
                        if (KitInfo.Instance.bIsComboKit)
                        {
                            KitInfo.Instance.bIsChild1Checked = true;
                            KitInfo.Instance.bIsChild2Checked = true;
                            KitInfo.Instance.bIsChild3Checked = true;
                        };
                    }

                    if (!string.IsNullOrEmpty(dr["IS_BASIC_KIT"].ToString()))
                    {
                        KitInfo.Instance.bIsBasicKit = Convert.ToBoolean(dr["IS_BASIC_KIT"]);
                        if (KitInfo.Instance.bIsBasicKit)
                        {
                            KitInfo.Instance.bIsChild1Checked = true;
                        };
                    }

                    if (!string.IsNullOrEmpty(dr["IS_SENSOR_SHIP_KIT"].ToString()))
                    {
                        KitInfo.Instance.bIsSensorShipKit = Convert.ToBoolean(dr["IS_SENSOR_SHIP_KIT"]);
                        if (KitInfo.Instance.bIsSensorShipKit)
                        {
                            
                            if (!KitInfo.Instance.bIsSensorNeeded)
                            {
                                KitInfo.Instance.bIsChild1Checked = true;
                                KitInfo.Instance.bIsChild2Checked = true;
                                KitInfo.Instance.bIsChild3Checked = false;
                            }
                            else
                            {
                                KitInfo.Instance.bIsChild1Checked = false;
                                KitInfo.Instance.bIsChild2Checked = true;
                                KitInfo.Instance.bIsChild3Checked = true;
                            }
                        }
                      
                    }
                    if (!string.IsNullOrEmpty(dr["IS_RMA_KIT"].ToString()))
                    {
                        KitInfo.Instance.bIsRmaKit = Convert.ToBoolean(dr["IS_RMA_KIT"]);
                        if (KitInfo.Instance.bIsRmaKit)
                        {
                            if (!KitInfo.Instance.bIsSensorNeeded)
                            {
                                KitInfo.Instance.bIsChild1Checked = true;
                            }
                            else
                            {
                                KitInfo.Instance.bIsChild1Checked = false;
                                KitInfo.Instance.bIsChild2Checked = true;
                            };
                        };
                    }

                    if (!string.IsNullOrEmpty(dr["IS_SENSOR_SCANNED"].ToString()))
                        KitInfo.Instance.bIsRmaKit = Convert.ToBoolean(dr["IS_SENSOR_SCANNED"]);

                    //check if this is a cable kit
                    bool bIsCableKit = KitInfo.Instance.Description.ToUpper().Contains("CABLE KIT");
                    KitInfo.Instance.bIsCableKit = (bIsCableKit) ? true : false;

                    //assign the default check box states



                    isPassed = true;
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                isPassed = false;
            }

            return isPassed;
        }

        private KitInfo SetInsertKeyForHierarchy(KitInfo kitInfo)
        {
            //If an AE kit then determine which type , then assign the hierarchy key code
            if (kitInfo.bIsAEkit)
            {
                if (kitInfo.bIsAEcomboKit)
                {
                    kitInfo.KitInsertKey = 1;
                }
                else if (kitInfo.bIsAERmaKit)
                {
                    kitInfo.KitInsertKey = 3;
                }
                else if (kitInfo.bIsStarterKit)
                {
                    kitInfo.KitInsertKey = 2;
                }
                else
                {
                    kitInfo.KitInsertKey = 0;
                }
            }
            else
            {
                if (kitInfo.bIsSpareCableNeeded)
                {
                    kitInfo.KitInsertKey = 4;
                }

            }

            return kitInfo;

        }

        public static List<string> lRemoveBarcodeSpecialCharacters(string _barcode)
        {
            List<string> results = new List<string>();

            //// grab the cable info table
            //DataTable cableInfo = KitInfo.Instance.dsMaterialInfo.Tables["Cables"];

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    results = clientProxy.ParseUDIBarcode(_barcode);
                }

                //string temp = Regex.Replace(_barcode, @"[+%$]", "");
                //string remove = temp.Remove(0, 4);
                //int findIndexOfFirstBackSlash = remove.IndexOf("/");
                //string removeTheLastChar = remove.Remove(findIndexOfFirstBackSlash - 1, 1);
                //var tempSplit = removeTheLastChar.Split('/').ToList();

                ////check if the part number being used is a cable
                //DataRow[] result = cableInfo.Select($"Part_Number = '{tempSplit[0].ToString()}' OR Identifier = '{tempSplit[0].ToString()}'");

                //if (result.Any())
                //{
                //    //what the length of serial is supposed to be (from DB)
                //    int lengthOfSerial = (int)result[0][4];

                //    if (tempSplit[1].Length != lengthOfSerial)
                //    {
                //        //check what the identifier is supposed to be
                //        string dbIdentifier = result[0][1].ToString();

                //        if (!tempSplit[1].StartsWith(dbIdentifier))
                //        {
                //            //get the index of the identifier
                //            int indexOfIdentifier = tempSplit[1].IndexOf(dbIdentifier);

                //            //delete everything up to that index
                //            tempSplit[1] = CutStringByIndex(tempSplit[1], indexOfIdentifier);//tempSplit[1].Substring(indexOfIdentifier, tempSplit[1].Length - 1);

                //        }
                //    }
                //}

                // results = tempSplit;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return results;
        }

        private static string CutStringByIndex(string stringVal, int startIndex)
        {
            string returnVal = string.Empty;


            return returnVal = stringVal.Substring(startIndex, stringVal.Length - 1);

        }

        private static DataTable CopyHierarchyInfoToDatatable(string parentMaterial, string parentSerial, Dictionary<string, string> sapInfo)
        {
            DataTable dtTemp = new DataTable();
            DataRow dr;
            DataColumn column;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Material";
            dtTemp.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Serial";
            dtTemp.Columns.Add(column);

            //add parent info to table first
            dr = dtTemp.NewRow();
            dr["Material"] = parentMaterial;
            dr["Serial"] = parentSerial;
            dtTemp.Rows.Add(dr);

            foreach (var item in sapInfo)
            {
                var serial = item.Key;
                var material = item.Value;


                dr = dtTemp.NewRow();
                dr["Material"] = material;
                dr["Serial"] = serial;


                dtTemp.Rows.Add(dr);
            };


            return dtTemp;

        }

        #endregion

        #region Check if individual material was already used

        public static DataTable dtWasKitSerialAlreadyUsed(string kitMaterial, string kitSerial)
        {
            DataTable dtTemp = new DataTable("dtWasKitSerialAlreadyUsed");
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.CheckIfKitSerialExists(kitMaterial, kitSerial);
                    //KitInfo.Instance.dsSerialUsed = new DataSet();
                    //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dtTemp;

        }

        public static DataTable dtWasSensorShipKitAlreadyUsed(string sensorMaterialNumber, string sensorSerialNumber)
        {
            DataTable dtTemp = new DataTable("dtWasSensorShipKitAlreadyUsed");
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.CheckIfSensorUsedInAnyKit(sensorMaterialNumber, sensorSerialNumber);

                    //KitInfo.Instance.dsSerialUsed = new DataSet();
                    //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dtTemp;

        }

        public static DataTable dtWasSensorSerialAlreadyUsed(string sensorMaterial, string sensorSerial)
        {
            DataTable dtTemp = new DataTable("dtWasSensorSerialAlreadyUsed");
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.CheckIfSensorSerialExists(sensorMaterial, sensorSerial);

                    //KitInfo.Instance.dsSerialUsed = new DataSet();
                    //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dtTemp;

        }

        public static DataTable dtWasCableAlreadyUsed(string cableMaterialNumber, string cableSerialNumber)
        {
            DataTable dtTemp = new DataTable("dtWasCableAlreadyUsed");
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.CheckIfCableSerialExists(cableMaterialNumber, cableSerialNumber);

                    //KitInfo.Instance.dsSerialUsed = new DataSet();
                    //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dtTemp;
        }

        public static DataTable dtWasRemoteSerialAlreadyUsed(string remotePartNumber, string remoteSerial)
        {

            DataTable dtTemp = new DataTable();
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.CheckIfRemoteSerialExists(remotePartNumber, remoteSerial);

                    //KitInfo.Instance.dsSerialUsed = new DataSet();
                    //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dtTemp;



        }

        //public static DataTable dtWasAEComboKitSensorAlreadyUsed(string comboKitPartNumber, string size1Serial = "", string size2Serial = "")
        //{
        //    DataTable dtTemp = new DataTable("dtWasAEComboKitSensorAlreadyUsed");
        //    try
        //    {
        //        using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
        //        {
        //            dtTemp = clientProxy.CheckIfSensorUsedInAnyKit(remotePartNumber, remoteSerial);

        //            //KitInfo.Instance.dsSerialUsed = new DataSet();
        //            //KitInfo.Instance.dsSerialUsed.Tables.Add(dtTemp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.StackTrace);
        //    }
        //    return dtTemp;

        //}

        #endregion

        #region Get Table ID's

        public static int GetKitID(string materialNumber, string serialNumber)
        {

            int kitID = -1;

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {

                    DataTable dtTemp = clientProxy.GetKitRowID(materialNumber, serialNumber);



                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };

            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return kitID;



        }

        public static DataTable GetMaterialInfoUsingRowID(string materialNumber , int rowID)
        {
            DataTable dtTemp = new DataTable("GetMaterialInfoUsingRowID");
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {
                    dtTemp = clientProxy.GetMaterialInfoUsingRowID(materialNumber, rowID);                 
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return dtTemp;
        }



        #endregion

        #region Schick33/Elite


        #region Starter kit

        public static int InsertStarterKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, int _sensorSerialID, string _remoteMaterialNumber,
                                       string _remoteSerialNumber, string _orderNumber, string _uapid, string _note)
        {

            int kitID = -1;

            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {

                    DataTable dtTemp = clientProxy.spInsertSchick33orEliteStarterKit(_kitMaterialNumber,
                                                                             _kitSerial,
                                                                             _sensorMaterialNumber,
                                                                             _sensorSerialID,
                                                                             _remoteMaterialNumber,
                                                                             _remoteSerialNumber,
                                                                             _orderNumber,
                                                                             _uapid,
                                                                             _uapid
                                                                             );


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }

                };




            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return kitID;
        }


        #endregion

        #region Basic Kit
        public static int InsertBasicKit(string _kitMaterialNumber, string _sensorMaterialNumber,
                                 string _kitSerial, string _cableMaterialNumber, string _cableSerial,
                                 string _orderNumber, string _uapid, string _note)
        {
            int kitID = -1;
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {

                    DataTable dtTemp = clientProxy.spInsertEliteBasicKit(_kitMaterialNumber,
                                                                         _sensorMaterialNumber,
                                                                         _kitSerial,
                                                                         _cableMaterialNumber,
                                                                         _cableSerial,
                                                                         _orderNumber,
                                                                         _uapid,
                                                                         _note);


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return kitID;
        }




        #endregion

        #region Ship Kit

        public static int InsertShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber,
                                  string _sensorSerial, string _cableMaterialNumber, string _cableSerial, string _spareCableSerial,
                                  string _orderNumber, string _uapid, string _note)
        {
            int kitID = -1;
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {

                    DataTable dtTemp = clientProxy.spInsertSchick33EliteSensorKit(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _sensorSerial, _cableMaterialNumber, _cableSerial,
                            _spareCableSerial, _orderNumber, _uapid, _note);


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return kitID;
        }




        #endregion

        #region RMA Kit

        public static int InsertRmaKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber,
                                 string _sensorSerial, string _cableMaterialNumber, string _cableSerial,
                                 string _orderNumber, string _uapid, string _note)
        {
            int kitID = -1;
            try
            {
                using (SAPConnectionClient clientProxy = new SAPConnectionClient("SAPTCP"))
                {

                    DataTable dtTemp = clientProxy.spInsertSchick33EliteRmaOrPdsiKit(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _sensorSerial, _cableMaterialNumber, _cableSerial,
                             _orderNumber, _uapid, _note);


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return kitID;
        }




        #endregion


        #endregion

        #region AE Sensors (Inserts)

        #region AE Combo Kit
        /// <summary>
        ///
        /// </summary>
        /// <param name="_kitMaterialNumber">Top level kit material number</param>
        /// <param name="_kitSerial">Top level kit serial number</param>
        /// <param name="_size1SensorSerial">Size 1 sensor serial number</param>
        /// <param name="_size2SensorSerial">Size 2 sensor serial number</param>
        /// <param name="_remoteSerial">Remote serial number</param>
        /// <param name="_orderNumber">Current order number</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static int InsertAEComboKit(string _kitMaterialNumber,
                                                 string _kitSerial,
                                                 string _size1MaterialNumber,
                                                 int _size1SerialID,
                                                 string _size2MaterialNumber,
                                                 int _size2SerialID,
                                                 string _remoteMaterialNumber,
                                                 string _remoteSerial,
                                                 string _orderNumber,
                                                 int _uapid,
                                                 string _note = "")
        {
            int kitID = -1;
            DataTable dtTemp = new DataTable();

            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertAEComboKit(_kitMaterialNumber,
                                                       _kitSerial,
                                                       _size1MaterialNumber,
                                                       _size1SerialID,
                                                       _size2MaterialNumber,
                                                       _size2SerialID,
                                                       _remoteMaterialNumber,
                                                       _remoteSerial,
                                                       _orderNumber,
                                                       _uapid,
                                                       _note);

                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }

                };

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;

        }
        #endregion

        #region AE Starter Kit
        /// <summary>
        /// Insert AE starter kit
        /// </summary>
        /// <param name="_kitMaterialNumber">Top level kit material number</param>
        /// <param name="_kitSerial">Top level kit serial number</param>
        /// <param name="_sensorSerialNumber">Sensor serial number</param>
        /// <param name="_remoteSerial">Remote serial number</param>
        /// <param name="_orderNumber">Order number</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static int InsertAEStarterKit(string _kitMaterialNumber,
                                                     string _kitSerial,
                                                     string _sensorMaterialNumber,
                                                     int _sensorSerialID,
                                                     string _remoteMaterialNumber,
                                                     string _remoteSerial,
                                                     string _orderNumber,
                                                     int _uapid,
                                                     string _note = "")
        {

            int kitID = -1;
            DataTable dtTemp = new DataTable();

            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertAEStarterKit(_kitMaterialNumber,
                                                       _kitSerial,
                                                       _sensorMaterialNumber,
                                                       _sensorSerialID,
                                                       _remoteMaterialNumber,
                                                       _remoteSerial,
                                                       _orderNumber,
                                                       _uapid,
                                                       _note);
                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;



        }

        #endregion

        #region AE Ship Kit
        /// <summary>
        /// Insert AE Sensor Ship Kit Hierarchy
        /// </summary>
        /// <param name="_kitMaterialNumber">Top level kit material number</param>
        /// <param name="_kitSerial">Top level kit serial number</param>
        /// <param name="_sensorMaterialNumber">Sensor material number</param>
        /// <param name="_cableSerial">Cable serial number</param>
        /// <param name="_spareCableSerial">Spare cable serial number</param>
        /// <param name="_orderNumber">Order number</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static int InsertAESensorShipKit(string _kitMaterialNumber, string _kitSerial,
                                                string _sensorMaterialNumber, string _cablePartNumber,
                                                string _cableSerial, string _spareCableSerial,
                                                string _orderNumber, int _uapid, string _note = "")
        {
            int kitID = -1;
            DataTable dtTemp = new DataTable();

            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertAESensorShipKit(_kitMaterialNumber,
                                                               _kitSerial,
                                                               _sensorMaterialNumber,
                                                               _cablePartNumber,
                                                               _cableSerial,
                                                               _spareCableSerial,
                                                               _orderNumber,
                                                               _uapid,
                                                               _note
                                                              );


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;

        }

        #endregion

        #region AE Rma KIt
        /// <summary>
        /// Insert AE RMA Kit Hierarchy information
        /// </summary>
        /// <param name="_kitMaterialNumber">Top level kit material number</param>
        /// <param name="_kitSerial">Top level kit serial number</param>
        /// <param name="_sensorMaterialNumber">Sensor Part number</param>
        /// <param name="_cableSerial">Cable serial number</param>
        /// <param name="_orderNumber">Current order number</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static int InsertAERmaKit(string _kitMaterialNumber, string _kitSerial,
                                                string _sensorMaterialNumber, string _cablePartNumber,
                                                string _cableSerial, string _orderNumber,
                                                int _uapid, string _note = "")
        {
            int kitID = -1;
            DataTable dtTemp = new DataTable();
            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertAERmaShipKit(_kitMaterialNumber,
                                                               _kitSerial,
                                                               _sensorMaterialNumber,
                                                               _cablePartNumber,
                                                               _cableSerial,
                                                               _orderNumber,
                                                               _uapid,
                                                               _note
                                                              );


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;



        }


        #endregion


        #endregion

        #region XIOS AE


        public static int InsertXiosAeKit(string _kitMaterialNumber, string _sensorMaterialNumber,
                                          string _sensorSerial, string _cablePartNumber,
                                          string _cableSerial, string _orderNumber,
                                          string _uapid, string _note = "")
        {
            int kitID = -1;
            DataTable dtTemp = new DataTable();
            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertXiosAESensorShipKit(_kitMaterialNumber,
                                                               _sensorMaterialNumber,
                                                               _sensorSerial,
                                                               _cablePartNumber,
                                                               _cableSerial,
                                                               _orderNumber,
                                                               _uapid,
                                                               _note);


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;

        }


        #endregion

        #region XG Supreme 

        public static int InsertXgSupSelShipKit(string _kitMaterialNumber, string _sensorMaterialNumber,
                                          string _sensorSerial, string _cablePartNumber,
                                          string _cableSerial, string _orderNumber,
                                          string _uapid, string _note = "")
        {
            int kitID = -1;
            DataTable dtTemp = new DataTable();
            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertXgSupremeSelectSensorShipKit(_kitMaterialNumber,
                                                               _sensorMaterialNumber,
                                                               _sensorSerial,
                                                               _cablePartNumber,
                                                               _cableSerial,
                                                               _orderNumber,
                                                               _uapid,
                                                               _note);


                    if (dtTemp.Rows.Count > 0 && dtTemp != null)
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            kitID = Convert.ToInt32(dr[0]);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return kitID;

        }




        #endregion

        #region Universal Inserts


        /// <summary>
        /// Insert a cable kit serial
        /// </summary>
        /// <param name="_cableMaterialNumber">Cable Material Number</param>
        /// <param name="_cableSerial">Cable Serial Number</param>
        /// <param name="_orderNumber">Order Number</param>
        /// <param name="_kitMaterialNumber">Top level kit material number</param>
        /// <returns></returns>
        public static DataTable dtInsertCableKit(string _orderNumber, string _kitMaterialNumber, string _cableMaterialNumber, string _cableSerial, string uapid, string _note = "")
        {
            DataTable dtTemp = new DataTable();
            try
            {
                using (SAPConnectionClient client = new SAPConnectionClient("SAPTCP"))
                {

                    dtTemp = client.spInsertCableKits(_orderNumber, _kitMaterialNumber, _cableMaterialNumber, _cableSerial, uapid, _note);
                    
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return dtTemp;
        }

        /// <summary>
        /// Add a note to an existing record
        /// </summary>
        /// <param name="rowId">Existing row id</param>
        /// <param name="_materialNumber">Top level material number</param>
        /// <param name="_note">Text to append to record</param>
        /// <param name="_user">User Name</param>
        /// <returns></returns>
        public static DataSet dsInsertNote(int rowId, string _materialNumber, string _note, string _user)
        {
            DataSet dsTemp = new DataSet();

            try
            {
                // dsTemp = puc.InsertNote(rowId, _materialNumber, _note, _user);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dsTemp;
        }

        /// <summary>
        /// Insert one cable serial number
        /// </summary>
        /// <param name="_cableMaterialNumber">Cable part number</param>
        /// <param name="_cableSerial">Cable serial number</param>
        /// <param name="_kitMaterialCableWasUsedIn">Top level material number where cable was used</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static DataSet dsInsertCableSerial(string _cableMaterialNumber, string _cableSerial, string _kitMaterialCableWasUsedIn, string _note = "")
        {
            DataSet dsTemp = new DataSet();

            try
            {
                // dsTemp = puc.InsertCableSerial( _cableMaterialNumber,_cableSerial,_kitMaterialCableWasUsedIn,_note);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dsTemp;
        }

        /// <summary>
        /// Insert Sensor serial
        /// </summary>
        /// <param name="_sensorMaterialNumber">Sensor material number</param>
        /// <param name="_sensorSerial">Sensor part number</param>
        /// <param name="_kitMaterialSensorWasUsedIn">Top level material number where sensor was used</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static DataSet dsInsertSensorSerial(string _sensorMaterialNumber, string _sensorSerial, string _kitMaterialSensorWasUsedIn, string _note = "")
        {
            DataSet dsTemp = new DataSet();

            try
            {
                //dsTemp = puc.InsertSensorSerial(_sensorMaterialNumber, _sensorSerial,  _kitMaterialSensorWasUsedIn, _note);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dsTemp;
        }

        /// <summary>
        /// Insert Remote serial
        /// </summary>
        /// <param name="_remoteMaterialNumber">Remote part number</param>
        /// <param name="_remoteSerial">Remote serial number</param>
        /// <param name="_kitMaterialRemoteWasUsedIn">Top level material number where remote was used</param>
        /// <param name="_kitSerialRemoteWasUsedIn">Top level serial number remote where remote was used</param>
        /// <param name="_note">*Optional* Add a note to kit information</param>
        /// <returns></returns>
        public static DataSet dsInsertRemoteSerial(string _remoteMaterialNumber, string _remoteSerial, string _kitMaterialRemoteWasUsedIn, string _kitSerialRemoteWasUsedIn, string _note = "")
        {
            DataSet dsTemp = new DataSet();

            try
            {
                // dsTemp = puc.InsertRemoteSerial( _remoteMaterialNumber, _remoteSerial, _kitMaterialRemoteWasUsedIn, _kitSerialRemoteWasUsedIn, _note );
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
            return dsTemp;
        }


        #endregion

        #region SAP

        #region Hierarchy Insert

        public static string PerformSapHierarchy
            (
                string OrderNumber,
                string KitMaterial,
                string KitSerial,
                string StorageLocation,
                string TypeOfGR,
                string bIsSensorNeeded,
                string bIsSpareCableNeeded,
                string bIsAeComboKit,
                string bIsStarterKit,
                string bIsBasicKit,
                string bIsCableNeededOnSensor,
                string bIsChild1Checked,
                string bIsChild2Checked,
                string bIsChild3Checked,
                string SensorMaterialNumber,
                string SensorSerialNumber,
                string SensorMaterialNumber_2,
                string SensorSerialNumber_2,
                string CableMaterialNumber,
                string CableSerial,
                string SpareCableSerial,
                string RemotePartNumber,
                string RemoteSerialNumber

             )
        {

            string results = string.Empty;
            try
            {
                string[] argsForHierarchy = new string[]
                {
                     OrderNumber,
                     KitMaterial,
                     KitSerial,
                     StorageLocation,
                     TypeOfGR,
                     bIsSensorNeeded,
                     bIsSpareCableNeeded,
                     bIsAeComboKit,
                     bIsStarterKit,
                     bIsBasicKit,
                     bIsCableNeededOnSensor,
                     bIsChild1Checked,
                     bIsChild2Checked,
                     bIsChild3Checked,
                     SensorMaterialNumber,
                     SensorSerialNumber,
                     SensorMaterialNumber_2,
                     SensorSerialNumber_2,
                     CableMaterialNumber,
                     CableSerial,
                     SpareCableSerial,
                     RemotePartNumber,
                     RemoteSerialNumber
                };


                //test sap service
                // SAPConnectionClient client = new SAPConnectionClient("SAPTCP");

                // results = client.PerformSAPHierarchyTransaction(argsForHierarchy);

                results = SAP_CONNECTION.SAP_Hierarchy.SapHierarchyTransactions(argsForHierarchy).ToString();

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return results;
        }
        #endregion

        #region Print Hierarchy Report

        public static bool PrintReport(string materialNumber)
        {
            bool bIsPassed = false;

            try
            {
                bIsPassed = SAP_CONNECTION.Print.PrintHierarchyRecord(materialNumber);

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            return bIsPassed;

        }



        #endregion

        #region Hierarchy Lookup

        public static DataTable dtSAP_PerformSerialLookup(string parentMaterial,string parentSerial)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.TableName = "SAP_PerformSerialLookup";

         
            try
            {
                var getInfo = SAP_CONNECTION.SAP_Serial_Lookup.SAP_PerformSerialLookup(parentMaterial, parentSerial);

                if(getInfo != null)
                {
                    dtTemp = CopyHierarchyInfoToDatatable(parentMaterial, parentSerial, getInfo);
                }

            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
            }

            return dtTemp;

        }



        #endregion


        #endregion



    }
}
