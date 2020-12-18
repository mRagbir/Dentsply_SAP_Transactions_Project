// Dentsply_SAP_Transactions_Service.ISapService
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace Dentsply_SAP_Transactions_Service
{
	[ServiceContract(Namespace = "Dentsply_SAP_Transactions_Service")]
	public interface ISapService
	{
		[OperationContract]
		string Test(string value);

		[OperationContract]
		string PerformSAPHierarchyTransaction(string[] args);

		[OperationContract]
		string TestSAPConnection(string args);

		[OperationContract]
		bool ValidateMaterialNumber(string materialNumber);

		[OperationContract]
		List<string> ParseUDIBarcode(string args);

		[OperationContract]
		DataTable GetUDISpecialCases();

		[OperationContract]
		DataTable GetMaterialInfoUsingMaterialNumber(string args);

		[OperationContract]
		DataSet GetAllMaterialInfo();

		[OperationContract]
		DataTable GetCablesTable();

		[OperationContract]
		DataTable GetCablesConversionTable();

		[OperationContract]
		DataTable GetWarehouseLocations();

		[OperationContract]
		DataTable GetKitRowID(string kitMaterialNumber, string kitSerial);

		[OperationContract]
		DataTable GetSensorPartsListID(string serial);

		[OperationContract]
		DataTable CheckIfKitSerialExists(string materialNumber, string serial);

		[OperationContract]
		DataTable CheckIfSensorSerialExists(string materialNumber, string serial);

		[OperationContract]
		DataTable CheckIfCableSerialExists(string materialNumber, string serial);

		[OperationContract]
		DataTable CheckIfRemoteSerialExists(string materialNumber, string serial);

		[OperationContract]
		DataTable CheckIfSensorUsedInAnyKit(string sensorMaterialNumber, string sensorSerial);

		[OperationContract]
		DataTable GetMaterialInfoUsingRowID(string materialNumber, int rowID);

		[OperationContract]
		DataTable spInsertCableKits(string orderNumber, string cableKitMaterialNumber, string cableMaterialNumber, string cableSerial, string uapid, string note);

		[OperationContract]
		DataTable spInsertRemote(string RemoteMaterialNumber, string RemoteSerialNumber, string KitMaterial_WhereUsed, int WHERE_USED_ID, string UAPID, string NOTE);

		[OperationContract]
		DataTable spInsertSchick33orEliteStarterKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, int sensorSerialID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, string uapid, string note);

		[OperationContract]
		DataTable spInsertSchick33EliteSensorKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string spareCableSerial, string orderNumber, string uapid, string note);

		[OperationContract]
		DataTable spInsertSchick33EliteRmaOrPdsiKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note);

		[OperationContract]
		DataTable spInsertAEComboKit(string kitMaterialNumber, string kitSerialNumber, string sensor_S1_MaterialNumber, int sensor_S1_SerialNumberID, string sensor_S2_MaterialNumber, int sensor_S2_SerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note);

		[OperationContract]
		DataTable spInsertAEStarterKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, int sensorSerialNumberID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, int uapid, string note);

		[OperationContract]
		DataTable spInsertAESensorShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string spareCableSerial, string orderNumber, int uapid, string note);

		[OperationContract]
		DataTable spInsertAERmaShipKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string cablePartNumber, string cableSerial, string orderNumber, int uapid, string note);

		[OperationContract]
		DataTable spInsertEliteBasicKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note);

		[OperationContract]
		DataTable spInsertXiosAESensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note);

		[OperationContract]
		DataTable spInsertXgSupremeSelectSensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note);
	}
}
