using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WcfSAPService.Business_Logic
{
    public class DataToDB
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region SQL Helper Methods

        /// <summary>
        /// Used to make a data table
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <returns></returns>
        private static DataTable Get_DataTable(SqlCommand sqlCmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            //'Cleanup
            da.Dispose(); da = null;

            return dt;
        }

        /// <summary>
        /// Use to return a dataset
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <returns></returns>
        public static DataSet Get_DataSet(SqlCommand sqlCmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();

            try
            {
                //'Load the dataset
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            //'Cleanup
            da.Dispose(); da = null;
            return ds;
        }

        private static SqlCommand SqlCmd(string procName, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(procName, conn)
            {
                CommandType = CommandType.StoredProcedure,
                //CommandTimeout = (ConfigurationManager.AppSettings["commandTimeOut"] == null) ? 300 : int.Parse(ConfigurationManager.AppSettings["commandTimeOut"])
            };
            return cmd;
        }

        #endregion

        #region Gets

        /// <summary>
        /// Search Production Utilities DB if material exists
        /// </summary>
        /// <param name="MaterialNumber"></param>
        /// <returns>Datatable</returns>
        public static DataTable SearchByMaterialNumber(string MaterialNumber)
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[Material_Matching] ");
                    qry.Append($"WHERE [Material_Number] = '{MaterialNumber}' ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        public static DataTable GetUDIBarcodeSpecialCases()
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[UDI_Barcode_Parsing] ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        public static DataTable GetMaterialInfoUsingMaterialNumber(string _materialNumber) 
       
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[Material_Matching] ");
                    qry.Append($"INNER JOIN Get_Material_Family_Info ON Material_Matching.FAMILY_INFO = Get_Material_Family_Info.ID ");
                    qry.Append($"WHERE Material_Number = '{_materialNumber}' ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }


        public static DataTable GetKitRowID(string kitMaterialNumber, string kitSerial)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spGetKitRowID", conn);
                    cmd.Parameters.AddWithValue("@KitMaterial", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@KitSerial", kitSerial);
                    dt = Get_DataTable(cmd);
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        #endregion

        #region Get Misc Tables

        public static DataTable dtGetCablesTable()
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[Cables] ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dt;
        }

        public static DataTable GetCablesConversionTable()
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[Cable_PartNumber_Conversions] ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dt;
        }

        public static DataTable dtGetWarehouseLocations()
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[Warehouse_Locations] ");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dt;
        }

        public static DataSet GetAllMaterialInfo()
        {
            DataSet dsMaterialInfo = new DataSet();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    //get the material matching table
                    SqlDataAdapter materialAdapter = new SqlDataAdapter(
                      "SELECT * FROM Material_Matching INNER JOIN Get_Material_Family_Info ON Material_Matching.FAMILY_INFO = Get_Material_Family_Info.ID", conn);
                    materialAdapter.Fill(dsMaterialInfo, "Material_Matching");

                    //get the cable identifier table
                    SqlDataAdapter cableIdentifiersAdapter = new SqlDataAdapter(
                      "SELECT * FROM dbo.Cables", conn);
                    cableIdentifiersAdapter.Fill(dsMaterialInfo, "Cables");

                    //get the Sensor Identification table
                    SqlDataAdapter sensorIdentificationAdapter = new SqlDataAdapter(
                      "SELECT * FROM dbo.Sensor_Identifications", conn);
                    sensorIdentificationAdapter.Fill(dsMaterialInfo, "Sensor_Identifications");

                    //get the remote types table
                    SqlDataAdapter remoteTypesAdapter = new SqlDataAdapter(
                      "SELECT * FROM dbo.Remote_Types", conn);
                    remoteTypesAdapter.Fill(dsMaterialInfo, "Remote_Types");

                    //get the storage locations
                    SqlDataAdapter storageLocationsAdapter = new SqlDataAdapter(
                      "SELECT * FROM dbo.Warehouse_Locations", conn);
                    storageLocationsAdapter.Fill(dsMaterialInfo, "Warehouse_Locations");

                    // close connection
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dsMaterialInfo;

        }

        
        #endregion

        #region Check if serials exist

        //sensor parts list ID
        public static DataTable dtGetSensorPartsListID(string serial)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spGetSensorPartslistID", conn);
                    cmd.Parameters.AddWithValue("@SensorSerialNumber", serial);
                    dt = Get_DataTable(cmd);
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        //kit
        public static DataTable dtCheckKitSerial(string _kitPartNumber, string _kitSerialNumber)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spCheckKitSerial", conn);
                    cmd.Parameters.AddWithValue("@_kitPartNumber", _kitPartNumber);
                    cmd.Parameters.AddWithValue("@_kitSerial", _kitSerialNumber);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        //sensor
        public static DataTable dtCheckSensorSerial(string _sensorPartNumber, string _sensorSerialNumber)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spCheckSensorSerial", conn);
                    cmd.Parameters.AddWithValue("@_sensorPartNumber", _sensorPartNumber);
                    cmd.Parameters.AddWithValue("@_sensorSerial", _sensorSerialNumber);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        //cable
        public static DataTable dtCheckCableSerial(string _cablePartNumber, string _cableSerialNumber)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spCheckCableSerial", conn);
                    cmd.Parameters.AddWithValue("@_cablePartNumber", _cablePartNumber);
                    cmd.Parameters.AddWithValue("@_cableSerial", _cableSerialNumber);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        //remote
        public static DataTable dtCheckRemoteSerial(string _remotePartNumber, string _remoteSerialNumber)
        {
            DataTable dt = new DataTable();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spCheckRemoteSerial", conn);
                    cmd.Parameters.AddWithValue("@_remotePartNumber", _remotePartNumber);
                    cmd.Parameters.AddWithValue("@_remoteSerial", _remoteSerialNumber);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        public static DataTable dtGetMaterialInfoUsingRowID(string materialNumber, int rowID)
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            if (materialNumber.Contains("10000"))
                materialNumber = $"_{materialNumber}";

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.[{materialNumber}] ");
                    qry.Append($"WHERE ID = {rowID}");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dt;
        }

        public static DataTable dtCheckIfSensorUsedInAnyKit(string sensorMaterialNumber, string sensorSerial)
        {
            DataTable dt = null;
            StringBuilder qry = new StringBuilder();
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            if (sensorMaterialNumber.Contains("10000")){
                sensorMaterialNumber = $"_{sensorMaterialNumber}";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    qry.Append("Select * ");
                    qry.Append($"FROM dbo.{sensorMaterialNumber} ");
                    qry.Append($"WHERE KIT = '{sensorSerial}'");

                    cmd.CommandText = qry.ToString();

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }

            return dt;
        }

        #endregion

        #region SQL Inserts

        #region Universal Inserts

        public static DataTable spInsertCableKits(string orderNumber, string cableKitMaterialNumber, string cableMaterialNumber, string cableSerial, string uapid, string note = "")
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertCableKits", conn);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@cableKitMaterialNumber", cableKitMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);


                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        public static DataTable spInsertRemote(string remoteMaterialNumber, string remoteSerialNumber, string kitMaterial_WhereUsed, int WHERE_USED_ID, string uapid, string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertRemote", conn);
                    cmd.Parameters.AddWithValue("@RemoteMaterialNumber", remoteMaterialNumber);
                    cmd.Parameters.AddWithValue("@RemoteSerialNumber", remoteSerialNumber);
                    cmd.Parameters.AddWithValue("@KitMaterial_WhereUsed", kitMaterial_WhereUsed);
                    cmd.Parameters.AddWithValue("@WHERE_USED_ID", WHERE_USED_ID);
                    cmd.Parameters.AddWithValue("@UAPID", uapid);
                    cmd.Parameters.AddWithValue("@NOTE", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

       
        #endregion

        #region Schick33

        public static DataTable spInsertSchick33orEliteStarterKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, int sensorSerialID, string remoteMaterialNumber, string remoteSerialNumber, string orderNumber, string uapid, string note = "")
        {

            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertSchick33/EliteStarterKit", conn);
                    cmd.Parameters.AddWithValue("@_kitMaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@_kitSerial", kitSerial);
                    cmd.Parameters.AddWithValue("@_sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@_sensorSerialID", sensorSerialID);
                    cmd.Parameters.AddWithValue("@_remoteMaterialNumber", remoteMaterialNumber);
                    cmd.Parameters.AddWithValue("@_remoteSerialNumber", remoteSerialNumber);
                    cmd.Parameters.AddWithValue("@_orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@_UAPID", uapid);
                    cmd.Parameters.AddWithValue("@_NOTE", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;

        }

        public static DataTable spInsertSchick33EliteSensorKit(string kitMaterialNumber, string kitSerial, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string spareCableSerial, string orderNumber, string uapid, string note = "")
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertSchick33/EliteSensorKit", conn);
                    cmd.Parameters.AddWithValue("@kitmaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@kitSerialNumber", kitSerial);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerial", sensorSerial);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@spareCableSerial", spareCableSerial);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);


                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }


        public  static DataTable spInsertSchick33EliteRmaOrPdsiKit(string kitMaterialNumber, string kitSerialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertSchick33/EliteRmaOrPdsiKit", conn);
                    cmd.Parameters.AddWithValue("@kitmaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@kitSerialNumber", kitSerialNumber);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerial", sensorSerial);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);


                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

      
        #endregion

        #region AE

        public static DataTable spInsertAEComboKit(string kitMaterialNumber, 
                                                   string kitSerialNumber,
                                                   string sensor_S1_MaterialNumber, 
                                                   int sensor_S1_SerialNumberID, 
                                                   string sensor_S2_MaterialNumber, 
                                                   int sensor_S2_SerialNumberID, 
                                                   string remoteMaterialNumber, 
                                                   string remoteSerialNumber, 
                                                   string orderNumber, 
                                                   int uapid, 
                                                   string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertAEComboKit", conn);
                    cmd.Parameters.AddWithValue("@kitMaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@kitSerial", kitSerialNumber);
                    cmd.Parameters.AddWithValue("@sensor_S1_MaterialNumber", sensor_S1_MaterialNumber);
                    cmd.Parameters.AddWithValue("@sensor_S1_SerialNumberID", sensor_S1_SerialNumberID);
                    cmd.Parameters.AddWithValue("@sensor_S2_MaterialNumber", sensor_S2_MaterialNumber);
                    cmd.Parameters.AddWithValue("@sensor_S2_SerialNumberID", sensor_S2_SerialNumberID);
                    cmd.Parameters.AddWithValue("@remoteMaterialNumber", remoteMaterialNumber);
                    cmd.Parameters.AddWithValue("@remoteSerialNumber", remoteSerialNumber);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);


                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {

                logger.Error($"SQL Error : {ex.StackTrace}");
            }
            return dt;
        }

        public static DataTable spInsertAEStarterKit(string kitMaterialNumber, 
                                                     string kitSerialNumber, 
                                                     string sensorMaterialNumber, 
                                                     int sensorSerialNumberID, 
                                                     string remoteMaterialNumber, 
                                                     string remoteSerialNumber, 
                                                     string orderNumber, 
                                                     int uapid, 
                                                     string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertAEStarterKit", conn);
                    cmd.Parameters.AddWithValue("@kitMaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@kitSerial", kitSerialNumber);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerialNumberID", sensorSerialNumberID);
                    cmd.Parameters.AddWithValue("@remoteMaterialNumber", remoteMaterialNumber);
                    cmd.Parameters.AddWithValue("@remoteSerialNumber", remoteSerialNumber);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);


                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }

        public static DataTable spInsertAESensorShipKit(string kitMaterialNumber, 
                                                        string kitSerialNumber, 
                                                        string sensorMaterialNumber, 
                                                        string cablePartNumber, 
                                                        string cableSerial, 
                                                        string spareCableSerial, 
                                                        string orderNumber, 
                                                        int uapid, 
                                                        string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertAESensorShipKit", conn);
                    cmd.Parameters.AddWithValue("@_kitMaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@_kitSerial", kitSerialNumber);
                    cmd.Parameters.AddWithValue("@_sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@_cablePartNumber", cablePartNumber);
                    cmd.Parameters.AddWithValue("@_cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@_spareCableSerial", spareCableSerial);
                    cmd.Parameters.AddWithValue("@_orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@_uapid", uapid);
                    cmd.Parameters.AddWithValue("@_NOTE", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }

        public static DataTable spInsertAERmaShipKit(string kitMaterialNumber, 
                                                     string kitSerialNumber, 
                                                     string sensorMaterialNumber, 
                                                     string cablePartNumber, 
                                                     string cableSerial, 
                                                     string orderNumber, 
                                                     int uapid, 
                                                     string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertAERmaShipKit", conn);
                    cmd.Parameters.AddWithValue("@_kitMaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@_kitSerial", kitSerialNumber);
                    cmd.Parameters.AddWithValue("@_sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@_cablePartNumber", cablePartNumber);
                    cmd.Parameters.AddWithValue("@_cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@_orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@_uapid", uapid);
                    cmd.Parameters.AddWithValue("@_NOTE", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }




        #endregion

        #region Elite

        public static DataTable spInsertEliteBasicKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertEliteBasicKit", conn);
                    cmd.Parameters.AddWithValue("@kitmaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerial", sensorSerial);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }


        #endregion

        #region XIOS AE

        public static DataTable spInsertXiosAESensorShipKit(string kitMaterialNumber, 
                                                            string sensorMaterialNumber, 
                                                            string sensorSerial, 
                                                            string cableMaterialNumber, 
                                                            string cableSerial, 
                                                            string orderNumber, 
                                                            string uapid, 
                                                            string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertXiosAESensorShipKit", conn);
                    cmd.Parameters.AddWithValue("@kitmaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerial", sensorSerial);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }



        #endregion

        #region XG Supreme / Select


        public static DataTable spInsertXgSupremeSelectSensorShipKit(string kitMaterialNumber, string sensorMaterialNumber, string sensorSerial, string cableMaterialNumber, string cableSerial, string orderNumber, string uapid, string note)
        {
            DataTable dt = null;
            string connection = ConfigurationManager.ConnectionStrings["ProductionUtilitiesDB"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = SqlCmd("spInsertXgSupreme/SelectSensorShipKit", conn);
                    cmd.Parameters.AddWithValue("@kitmaterialNumber", kitMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorMaterialNumber", sensorMaterialNumber);
                    cmd.Parameters.AddWithValue("@sensorSerial", sensorSerial);
                    cmd.Parameters.AddWithValue("@cableMaterialNumber", cableMaterialNumber);
                    cmd.Parameters.AddWithValue("@cableSerial", cableSerial);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@uapid", uapid);
                    cmd.Parameters.AddWithValue("@note", note);

                    dt = Get_DataTable(cmd);

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                logger.Error($"SQL Error : {ex.StackTrace}");
                throw ex;
            }
            return dt;
        }






        #endregion


        #endregion




    }
}
