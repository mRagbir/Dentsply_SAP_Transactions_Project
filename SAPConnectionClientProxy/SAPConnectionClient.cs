// SAPConnectionClientProxy.SAPConnectionClient
using Dentsply_SAP_Transactions_Service;

using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace SAPConnectionClientProxy
{
    public class SAPConnectionClient : ClientBase<ISapService>, ISapService
    {
        public SAPConnectionClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        public string Test(string value)
        {
            try
            {
                string Test = base.Channel.Test(value);
                base.Close();
                return Test;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                return e.Message;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                return e.Message;
            }
        }

        public string TestSAPConnection(string args)
        {
            string results = string.Empty;
            try
            {

                string TestSAPConnection = base.Channel.TestSAPConnection(args);
                base.Close();
                return TestSAPConnection;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                return e.Message;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                return e.Message;
            }
        }

        public string PerformSAPHierarchyTransaction(string[] args)
        {
            try
            {
                string PerformSAPHierarchyTransaction = base.Channel.PerformSAPHierarchyTransaction(args);
                base.Close();
                return PerformSAPHierarchyTransaction;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                return e.Message;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                return e.Message;
            }
        }

        public DataTable CheckIfSensorUsedInAnyKit(string sensorMaterialNumber, string sensorSerial)
        {
            try
            {                
                DataTable dtTemp =  base.Channel.CheckIfSensorUsedInAnyKit(sensorMaterialNumber, sensorSerial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetSensorPartsListID(string serial)
        {
            try
            {
                DataTable dtTemp = base.Channel.GetSensorPartsListID(serial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetMaterialInfoUsingRowID(string materialNumber, int rowID)
        {
            try
            {
                DataTable dtTemp = base.Channel.GetMaterialInfoUsingRowID(materialNumber, rowID);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable CheckIfCableSerialExists(string materialNumber, string serial)
        {
            try
            {
                DataTable dtTemp = base.Channel.CheckIfCableSerialExists(materialNumber, serial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable CheckIfKitSerialExists(string materialNumber, string serial)
        {
            try
            {
                DataTable dtTemp = base.Channel.CheckIfKitSerialExists(materialNumber, serial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable CheckIfRemoteSerialExists(string materialNumber, string serial)
        {
            try
            {
                DataTable dtTemp = base.Channel.CheckIfRemoteSerialExists(materialNumber, serial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable CheckIfSensorSerialExists(string materialNumber, string serial)
        {
            try
            {
                DataTable dtTemp = base.Channel.CheckIfSensorSerialExists(materialNumber, serial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetKitRowID(string kitMaterialNumber, string kitSerial)
        {
            try
            {
                DataTable dtTemp = base.Channel.GetKitRowID(kitMaterialNumber, kitSerial);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetMaterialInfoUsingMaterialNumber(string _materialNumber)
        {
            try
            {
                DataTable dtTemp = base.Channel.GetMaterialInfoUsingMaterialNumber(_materialNumber);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetUDISpecialCases()
        {
            try
            {
                DataTable dtTemp = base.Channel.GetUDISpecialCases();
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public List<string> ParseUDIBarcode(string barcodeString)
        {
            try
            {
                List<string> lTemp = base.Channel.ParseUDIBarcode(barcodeString);
                base.Close();
                return lTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public bool ValidateMaterialNumber(string materialNumber)
        {
            try
            {
                bool bIsValid =  base.Channel.ValidateMaterialNumber(materialNumber);
                base.Close();
                return bIsValid;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetCablesTable()
        {
            try
            {
                DataTable dtTemp = base.Channel.GetCablesTable();
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetCablesConversionTable()
        {
            try
            {
                DataTable dtTemp = base.Channel.GetCablesConversionTable();
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable GetWarehouseLocations()
        {
            try
            {
                DataTable dtTemp = base.Channel.GetWarehouseLocations();
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataSet GetAllMaterialInfo()
        {
            try
            {
                DataSet dsTest = base.Channel.GetAllMaterialInfo();
                base.Close();
                return dsTest;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertCableKits(string orderNumber, string cableKitMaterialNumber, string cableMaterialNumber, string cableSerial, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertCableKits(orderNumber, cableKitMaterialNumber, cableMaterialNumber, cableSerial, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertRemote(string RemoteMaterialNumber, string RemoteSerialNumber, string KitMaterial_WhereUsed, int WHERE_USED_ID, string UAPID, string NOTE)
        {
            throw new NotImplementedException();
        }

        public DataTable spInsertSchick33orEliteStarterKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, int sensorSerialID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertSchick33orEliteStarterKit(kitMaterialNumber, kitSerial, sensorMaterialNumber, sensorSerialID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertSchick33EliteSensorKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string spareCableSerial, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertSchick33EliteSensorKit(kitMaterialNumber, kitSerial, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, spareCableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertSchick33EliteRmaOrPdsiKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertSchick33EliteRmaOrPdsiKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertAEComboKit(string kitMaterialNumber, string kitSerialNumber, string sensor_S1_MaterialNumber, int sensor_S1_SerialNumberID, string sensor_S2_MaterialNumber, int sensor_S2_SerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertAEComboKit(kitMaterialNumber, kitSerialNumber, sensor_S1_MaterialNumber, sensor_S1_SerialNumberID, sensor_S2_MaterialNumber, sensor_S2_SerialNumberID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertAEStarterKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, int sensorSerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertAEStarterKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, sensorSerialNumberID, remoteMaterialNumber, remoteSerialNumber, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertAESensorShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string spareCableSerial, string orderNumber, int uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertAESensorShipKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, cablePartNumber, cableSerial, spareCableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertAERmaShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string orderNumber, int uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertAERmaShipKit(kitMaterialNumber, kitSerialNumber, sensorMaterialNumber, cablePartNumber, cableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertEliteBasicKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertEliteBasicKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;

            }
        }

        public DataTable spInsertXiosAESensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertXiosAESensorShipKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }

        public DataTable spInsertXgSupremeSelectSensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            try
            {
                DataTable dtTemp = base.Channel.spInsertXgSupremeSelectSensorShipKit(kitMaterialNumber, sensorMaterialNumber, sensorSerial, cableMaterialNumber, cableSerial, orderNumber, uapid, note);
                base.Close();
                return dtTemp;
            }
            catch (TimeoutException e)
            {
                base.Abort();
                throw e;
            }
            catch (CommunicationException e)
            {
                base.Abort();
                throw e;
            }
        }
    }
}
