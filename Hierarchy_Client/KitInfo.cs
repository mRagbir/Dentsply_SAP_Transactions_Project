using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy_Client
{
    public class KitInfo
    {
        private KitInfo()
        {
        }

        //Set only one static field and access all the variables through the Instance variable
        private static KitInfo instance = null;

        public static KitInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KitInfo();
                }
                return instance;
            }
        }


        /// <summary>
        /// Clears entire instance of KitInfo
        /// </summary>
        public void ClearAll()
        {
            if(!string.IsNullOrEmpty(KitInfo.Instance.UAPID ) && !string.IsNullOrEmpty(KitInfo.Instance.Username))
            {
                //keep only the user info when changing material number
                string _uapid = KitInfo.Instance.UAPID;
                string _userName = KitInfo.Instance.Username;

                instance = null;

                KitInfo.Instance.UAPID = _uapid;
                KitInfo.Instance.Username = _userName;
            }
            else
            {
                instance = null;
            }
          
          
        }

        /// <summary>
        /// Clears cable kit variables
        /// </summary>
        public void ClearForCableKits()
        {
            CableMaterialNumber = string.Empty;
            CableSerial = string.Empty;
            ReasonForBypass = string.Empty;
            NoteForBypass = string.Empty;
            IsSapBoxChecked = string.Empty;
            IsCableBypassedInDb = string.Empty;
            RowIDofBypassInDB = string.Empty;
        }

        //Datasets

        /// <summary>
        /// Initial Dataset that holds all material info from DB, query this dataset to quickly retrieve DB info.
        /// </summary>
        public DataSet dsMaterialInfo { get; set; }
        public DataRow drMaterialInfo { get; set; }
        public DataSet dsSerialUsed { get; set; }
        public DataSet dsSerialInsert { get; set; }
        public DataSet dsBypassInfo { get; set; }
        public DataSet dsCableInfo { get; set; }


        //Main identifiers
        public string UAPID { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public string MaterialNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string KitSerial { get; set; } = string.Empty;
        public string Sensor1MaterialNumber { get; set; } = string.Empty;
        public string Sensor2MaterialNumber { get; set; } = string.Empty;

        /// <summary>
        /// If AE Combo kit then this value is for a Size 2 Sensor ship kit
        /// </summary>
        public string Sensor1Serial { get; set; } = string.Empty;
        public int Sensor1SerialKitID { get; set; }

        /// <summary>
        /// If AE Combo kit then this value is for a Size 1 Sensor ship kit
        /// </summary>
        public string Sensor2Serial { get; set; } = string.Empty;
        public int Sensor2SerialKitID { get; set; }


        public string CableMaterialNumber { get; set; } = string.Empty;
        public string CableSerial { get; set; } = string.Empty;
        public string SpareCableSerial { get; set; } = string.Empty;
        public string RemoteMaterialNumber { get; set; } = string.Empty;
        public string RemoteSerial { get; set; } = string.Empty;
        public string ErrorDescription { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;

        //material info needed for hierarchy
        public bool bIsSensorNeeded { get; set; } = false;
        public bool bIsStarterKit { get; set; } = false;
        public bool bIsCableOnSensorNeeded { get; set; } = false;
        public bool bIsSpareCableNeeded { get; set; } = false;
        public bool bIsEliteStarterKit { get; set; } = false;
        public bool bIsEliteBasicKit { get; set; } = false;
        public bool bIsAEcomboKit { get; set; } = false;
        public bool bIsAEkit { get; set; } = false;
        public bool bIsAERmaKit { get; set; } = false;
        public bool bIsRemoteNeeded { get; set; } = false;
        public int RemoteType { get; set; }
        public int SenType_ID { get; set; }


        public string MaterialFamily { get; set; }
        public bool bIsComboKit { get; set; } = false;
        public bool bIsBasicKit { get; set; } = false;
        public bool bIsSensorShipKit { get; set; } = false;
        public bool bIsRmaKit { get; set; } = false;


        /// <summary>
        /// 0 = AE ShipKit, 1 = AE ComboKit, 2 = AE StarterKit, 3 = AE RmaKit, 4 = Schick33 ShipKit, 5 = Schick33 RmaKit
        /// </summary>
        public int KitInsertKey { get; set; }

        //Bypass
        public bool bKitSerialDuplicate { get; set; }
        public bool Bypass { get; set; }
        public string RowIDofBypassInDB { get; set; } = string.Empty;
        public string IsSapBoxChecked { get; set; } = string.Empty;
        public string IsCableBypassedInDb { get; set; } = string.Empty;
        public string ReasonForBypass { get; set; } = string.Empty;
        public string NoteForBypass { get; set; } = string.Empty;
        public bool bIsChild1Checked { get; set; } = false;
        public bool bIsChild2Checked { get; set; } = false;
        public bool bIsChild3Checked { get; set; } = false;

        public string MyProperty { get; set; } = string.Empty;
        public Dictionary<string, bool> dicBypassedCables { get; set; } = new Dictionary<string, bool>();

        public int HierarchyType { get; set; } 
        public bool bIsCableKit { get; set; } 

    }
}
