using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using WcfSAPService.Business_Logic;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WcfSAPService
{

    public class SapService : ISapService
    {
        public delegate void MonitorMessageDelegate(string aMessage);

        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event MonitorMessageDelegate Messages = null;

        public string Test(string value)
        {
            if (this.Messages != null)
            {
                this.Messages(value);
            }
            return string.Format("From Dentsply_SAP_Transactions_Service -- You entered: " + value);
        }
        public string PerformSAPHierarchyTransaction(string[] args)
        {
            string returnResults = string.Empty;

            try
            {
                if (args.Length < 22)
                {
                    returnResults = "Incorrect number of args, please check if you have 23 args before using api";
                }
                else
                {
                    string[] tempArr = new string[1]
                    {
                    "PerformHierarchy"
                    };
                    string[] finalArr = tempArr.Concat(args).ToArray();
                    string fileLocation = Environment.CurrentDirectory + "\\SAP_CONNECTION.exe";
                    Process compiler = new Process();
                    string AppPath = fileLocation;
                    if (!File.Exists(AppPath))
                    {
                        throw new Exception("Cannot Find file location");
                    }
                    compiler = null;
                    string arguments = string.Join(" ", finalArr);
                    compiler = new Process();
                    compiler.StartInfo.FileName = AppPath;
                    compiler.StartInfo.Verb = "runas";
                    compiler.StartInfo.Arguments = arguments;
                    compiler.StartInfo.UseShellExecute = false;
                    compiler.StartInfo.RedirectStandardOutput = true;
                    compiler.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    compiler.Start();
                    compiler.WaitForExit();
                    returnResults = compiler.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                returnResults = ex.InnerException.ToString();
                logger.Error("Error found : " + ex.StackTrace);
            }
            return returnResults;
        }

        public string TestSAPConnection(string args)
        {
            string results = string.Empty;
            try
            {
                string fileLocation = Environment.CurrentDirectory + "\\SAP_CONNECTION.exe";
                Process compiler = new Process();
                string AppPath = fileLocation;
                if (!File.Exists(AppPath))
                {
                    throw new Exception("Cant find exe file location!");
                }
                compiler = null;
                compiler = new Process();
                compiler.StartInfo.FileName = AppPath;
                compiler.StartInfo.Verb = "runas";
                compiler.StartInfo.Arguments = args;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                compiler.Start();
                compiler.WaitForExit();
                return compiler.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                logger.Error("Error found : " + ex.StackTrace);
                return ex.Message;
            }
        }

        public string TestSAPConnection()
        {
            return "Not Currently used";
        }

        bool ISapService.ValidateMaterialNumber(string materialNumber)
        {
            bool bIsValid = false;
            try
            {
                DataTable dbTemp = DataToDB.SearchByMaterialNumber(materialNumber);
                dbTemp.TableName = "ValidateMaterialNumber";
                bIsValid = ((dbTemp.Rows.Count > 0) ? true : false);
            }
            catch (Exception ex)
            {
                logger.Error("Error : " + ex.StackTrace);
            }
            return bIsValid;
        }

        public DataTable GetMaterialInfoUsingMaterialNumber(string _materialNumber)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.GetMaterialInfoUsingMaterialNumber(_materialNumber);
                dtTemp.TableName = "GetMaterialInfoUsingMaterialNumber";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetKitRowID(string kitMaterialNumber, string kitSerial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.GetKitRowID(kitMaterialNumber, kitSerial);
                dtTemp.TableName = "GetKitRowID";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public List<string> ParseUDIBarcode(string _barcode)
        {
            List<string> results = new List<string>();
            DataTable cableInfo = DataToDB.dtGetCablesTable();
            try
            {
                string temp = Regex.Replace(_barcode, "[+%$]", "");
                string remove = temp.Remove(0, 4);
                int findIndexOfFirstBackSlash = remove.IndexOf("/");
                string removeTheLastChar = remove.Remove(findIndexOfFirstBackSlash - 1, 1);
                List<string> tempSplit = removeTheLastChar.Split('/').ToList();
                string materialNumber = tempSplit[0].ToString();
                string serialNumber = tempSplit[1].ToString();
                DataRow[] drSC = cableInfo.Select("Part_Number = '" + materialNumber + "'");
                if (drSC.Any())
                {
                    DataRow[] array = drSC;
                    foreach (DataRow item in array)
                    {
                        string valFromDB = item["Identifier"].ToString();
                        string currentSerialIdentifier = serialNumber.Substring(0, 2);
                        if (!(currentSerialIdentifier == valFromDB) || 1 == 0)
                        {
                            serialNumber = serialNumber.Remove(0, 1);
                            if (char.IsLetter(serialNumber, serialNumber.Length - 1))
                            {
                                serialNumber = serialNumber.Remove(serialNumber.Length - 1, 1);
                            }
                            tempSplit[1] = serialNumber;
                        }
                    }
                }
                results = tempSplit;
            }
            catch (Exception)
            {
            }
            return results;
        }

        public DataTable GetUDISpecialCases()
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.GetUDIBarcodeSpecialCases();
                dtTemp.TableName = "GetUDISpecialCases";
            }
            catch (Exception ex)
            {
                logger.Error("Error : " + ex.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetSensorPartsListID(string serial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtGetSensorPartsListID(serial);
                dtTemp.TableName = "CheckIfKitSerialExists";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable CheckIfKitSerialExists(string materialNumber, string serial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtCheckKitSerial(materialNumber, serial);
                dtTemp.TableName = "CheckIfKitSerialExists";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable CheckIfSensorSerialExists(string materialNumber, string serial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtCheckSensorSerial(materialNumber, serial);
                dtTemp.TableName = "CheckIfSensorSerialExists";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable CheckIfCableSerialExists(string materialNumber, string serial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtCheckCableSerial(materialNumber, serial);
                dtTemp.TableName = "CheckIfCableSerialExists";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable CheckIfRemoteSerialExists(string materialNumber, string serial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtCheckRemoteSerial(materialNumber, serial);
                dtTemp.TableName = "CheckIfRemoteSerialExists";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable CheckIfSensorUsedInAnyKit(string sensorMaterialNumber, string sensorSerial)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtCheckIfSensorUsedInAnyKit(sensorMaterialNumber, sensorSerial);
                dtTemp.TableName = "CheckIfSensorUsedInAnyKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetMaterialInfoUsingRowID(string materialNumber, int rowID)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtGetMaterialInfoUsingRowID(materialNumber, rowID);
                dtTemp.TableName = "GetMaterialInfoUsingRowID";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetCablesTable()
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtGetCablesTable();
                dtTemp.TableName = "GetCablesTable";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetCablesConversionTable()
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.GetCablesConversionTable();
                dtTemp.TableName = "GetCablesConversionTable";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable GetWarehouseLocations()
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.dtGetWarehouseLocations();
                dtTemp.TableName = "GetWarehouseLocations";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataSet GetAllMaterialInfo()
        {
            DataSet dsTemp = new DataSet();
            try
            {
                dsTemp = DataToDB.GetAllMaterialInfo();
                dsTemp.DataSetName = "GetAllMaterialInfo";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dsTemp;
        }

        public DataTable spInsertCableKits(string orderNumber, string cableKitMaterialNumber, string cableMaterialNumber, string cableSerial, string uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertCableKits(orderNumber, cableKitMaterialNumber, cableMaterialNumber, cableSerial, uapid, note);
                dtTemp.TableName = "spInsertCableKits";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertRemote(string RemoteMaterialNumber, string RemoteSerialNumber, string KitMaterial_WhereUsed, int WHERE_USED_ID, string UAPID, string NOTE)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertRemote(RemoteMaterialNumber, RemoteSerialNumber, KitMaterial_WhereUsed, WHERE_USED_ID, UAPID, NOTE);
                dtTemp.TableName = "spInsertRemote";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertSchick33orEliteStarterKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, int sensorSerialID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, string uapid, string note = "")
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertSchick33orEliteStarterKit(kitMaterialNumber, kitSerial, sensorMaterialNumber, sensorSerialID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertSchick33orEliteStarterKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertSchick33EliteSensorKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string spareCableSerial, string orderNumber, string uapid, string note = "")
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertSchick33EliteSensorKit(kitMaterialNumber, kitSerial, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, spareCableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertSchick33EliteSensorKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertSchick33EliteRmaOrPdsiKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertSchick33EliteRmaOrPdsiKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertSchick33EliteRmaOrPdsiKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertAEComboKit(string kitMaterialNumber, string kitSerialNumber, string sensor_S1_MaterialNumber, int sensor_S1_SerialNumberID, string sensor_S2_MaterialNumber, int sensor_S2_SerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertAEComboKit(kitMaterialNumber, kitSerialNumber, sensor_S1_MaterialNumber, sensor_S1_SerialNumberID, sensor_S2_MaterialNumber, sensor_S2_SerialNumberID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertAEComboKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertAEStarterKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, int sensorSerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertAEStarterKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, sensorSerialNumberID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertAEStarterKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertAESensorShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string spareCableSerial, string orderNumber, int uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertAESensorShipKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, cablePartNumber, cableSerial, spareCableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertAESensorShipKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertAERmaShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string orderNumber, int uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertAERmaShipKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, cablePartNumber, cableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertAERmaShipKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertEliteBasicKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertEliteBasicKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertEliteBasicKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertXiosAESensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertXiosAESensorShipKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertXiosAESensorShipKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }

        public DataTable spInsertXgSupremeSelectSensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp = DataToDB.spInsertXgSupremeSelectSensorShipKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                dtTemp.TableName = "spInsertXgSupremeSelectSensorShipKit";
            }
            catch (Exception e)
            {
                logger.Error("Error : " + e.StackTrace);
            }
            return dtTemp;
        }
    }
}
