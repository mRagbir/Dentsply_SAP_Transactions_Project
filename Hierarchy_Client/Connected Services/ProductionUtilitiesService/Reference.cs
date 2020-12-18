﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hierarchy_Client.ProductionUtilitiesService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductionUtilitiesService.IServiceContracts")]
    public interface IServiceContracts {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetAllMaterialInfo", ReplyAction="http://tempuri.org/IServiceContracts/GetAllMaterialInfoResponse")]
        System.Data.DataSet GetAllMaterialInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetAllMaterialInfo", ReplyAction="http://tempuri.org/IServiceContracts/GetAllMaterialInfoResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetAllMaterialInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/getName", ReplyAction="http://tempuri.org/IServiceContracts/getNameResponse")]
        string getName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/getName", ReplyAction="http://tempuri.org/IServiceContracts/getNameResponse")]
        System.Threading.Tasks.Task<string> getNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetErrorCodeDescription", ReplyAction="http://tempuri.org/IServiceContracts/GetErrorCodeDescriptionResponse")]
        System.Data.DataSet GetErrorCodeDescription(int errorCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetErrorCodeDescription", ReplyAction="http://tempuri.org/IServiceContracts/GetErrorCodeDescriptionResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetErrorCodeDescriptionAsync(int errorCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/ValidateMaterialNumber", ReplyAction="http://tempuri.org/IServiceContracts/ValidateMaterialNumberResponse")]
        System.Data.DataSet ValidateMaterialNumber(string _materialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/ValidateMaterialNumber", ReplyAction="http://tempuri.org/IServiceContracts/ValidateMaterialNumberResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ValidateMaterialNumberAsync(string _materialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckCableSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckCableSerialResponse")]
        System.Data.DataSet CheckCableSerial(string cableMaterialNumber, string cableSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckCableSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckCableSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckCableSerialAsync(string cableMaterialNumber, string cableSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckKitSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckKitSerialResponse")]
        System.Data.DataSet CheckKitSerial(string kitMaterialNumber, string kitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckKitSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckKitSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckKitSerialAsync(string kitMaterialNumber, string kitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckSensorSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckSensorSerialResponse")]
        System.Data.DataSet CheckSensorSerial(string sensorMaterialNumber, string sensorSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckSensorSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckSensorSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckSensorSerialAsync(string sensorMaterialNumber, string sensorSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckRemoteSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckRemoteSerialResponse")]
        System.Data.DataSet CheckRemoteSerial(string remoteSerialNumber, string remotePartNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckRemoteSerial", ReplyAction="http://tempuri.org/IServiceContracts/CheckRemoteSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckRemoteSerialAsync(string remoteSerialNumber, string remotePartNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckStarterKitSensor", ReplyAction="http://tempuri.org/IServiceContracts/CheckStarterKitSensorResponse")]
        System.Data.DataSet CheckStarterKitSensor(string starterKitPartNumber, string sensorSerial);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckStarterKitSensor", ReplyAction="http://tempuri.org/IServiceContracts/CheckStarterKitSensorResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckStarterKitSensorAsync(string starterKitPartNumber, string sensorSerial);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckAEComboKitSensor", ReplyAction="http://tempuri.org/IServiceContracts/CheckAEComboKitSensorResponse")]
        System.Data.DataSet CheckAEComboKitSensor(string comboKitPartNumber, string size1Serial, string size2Serial);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/CheckAEComboKitSensor", ReplyAction="http://tempuri.org/IServiceContracts/CheckAEComboKitSensorResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> CheckAEComboKitSensorAsync(string comboKitPartNumber, string size1Serial, string size2Serial);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCableKitSerials", ReplyAction="http://tempuri.org/IServiceContracts/InsertCableKitSerialsResponse")]
        System.Data.DataSet InsertCableKitSerials(string _cableMaterialNumber, string _cableSerial, string _orderNumber, string _kitMaterialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCableKitSerials", ReplyAction="http://tempuri.org/IServiceContracts/InsertCableKitSerialsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertCableKitSerialsAsync(string _cableMaterialNumber, string _cableSerial, string _orderNumber, string _kitMaterialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAEComboKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAEComboKitResponse")]
        System.Data.DataSet InsertAEComboKit(string _kitMaterialNumber, string _kitSerial, string _size1Sensor, string _size2Sensor, string _remoteSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAEComboKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAEComboKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertAEComboKitAsync(string _kitMaterialNumber, string _kitSerial, string _size1Sensor, string _size2Sensor, string _remoteSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAERmaKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAERmaKitResponse")]
        System.Data.DataSet InsertAERmaKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAERmaKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAERmaKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertAERmaKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAESensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAESensorShipKitResponse")]
        System.Data.DataSet InsertAESensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAESensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAESensorShipKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertAESensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAEStarterKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAEStarterKitResponse")]
        System.Data.DataSet InsertAEStarterKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerialNumber, string _remoteSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertAEStarterKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertAEStarterKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertAEStarterKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerialNumber, string _remoteSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertSensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertSensorShipKitResponse")]
        System.Data.DataSet InsertSensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertSensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertSensorShipKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertSensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertRMASensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertRMASensorShipKitResponse")]
        System.Data.DataSet InsertRMASensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertRMASensorShipKit", ReplyAction="http://tempuri.org/IServiceContracts/InsertRMASensorShipKitResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertRMASensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _orderNumber, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertNote", ReplyAction="http://tempuri.org/IServiceContracts/InsertNoteResponse")]
        System.Data.DataSet InsertNote(int rowId, string _materialNumber, string _note, string _uapid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertNote", ReplyAction="http://tempuri.org/IServiceContracts/InsertNoteResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertNoteAsync(int rowId, string _materialNumber, string _note, string _uapid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCableSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertCableSerialResponse")]
        System.Data.DataSet InsertCableSerial(string _cableMaterialNumber, string _cableSerial, string _kitMaterialCableWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCableSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertCableSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertCableSerialAsync(string _cableMaterialNumber, string _cableSerial, string _kitMaterialCableWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertRemoteSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertRemoteSerialResponse")]
        System.Data.DataSet InsertRemoteSerial(string _remoteMaterialNumber, string _remoteSerial, string _kitMaterialRemoteWasUsedIn, string _kitSerialRemoteWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertRemoteSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertRemoteSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertRemoteSerialAsync(string _remoteMaterialNumber, string _remoteSerial, string _kitMaterialRemoteWasUsedIn, string _kitSerialRemoteWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertSensorSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertSensorSerialResponse")]
        System.Data.DataSet InsertSensorSerial(string _sensorMaterialNumber, string _sensorSerial, string _kitMaterialSensorWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertSensorSerial", ReplyAction="http://tempuri.org/IServiceContracts/InsertSensorSerialResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertSensorSerialAsync(string _sensorMaterialNumber, string _sensorSerial, string _kitMaterialSensorWasUsedIn, string _note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCalibDetails", ReplyAction="http://tempuri.org/IServiceContracts/InsertCalibDetailsResponse")]
        System.Data.DataSet InsertCalibDetails(string _serialNumber, string _chipID, string _lotNumber, string _calibStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/InsertCalibDetails", ReplyAction="http://tempuri.org/IServiceContracts/InsertCalibDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> InsertCalibDetailsAsync(string _serialNumber, string _chipID, string _lotNumber, string _calibStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetCalibDetails", ReplyAction="http://tempuri.org/IServiceContracts/GetCalibDetailsResponse")]
        System.Data.DataSet GetCalibDetails(string _serialNumber, string _chipID, string _lotNumber, string _calibStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContracts/GetCalibDetails", ReplyAction="http://tempuri.org/IServiceContracts/GetCalibDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetCalibDetailsAsync(string _serialNumber, string _chipID, string _lotNumber, string _calibStation);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceContractsChannel : Hierarchy_Client.ProductionUtilitiesService.IServiceContracts, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceContractsClient : System.ServiceModel.ClientBase<Hierarchy_Client.ProductionUtilitiesService.IServiceContracts>, Hierarchy_Client.ProductionUtilitiesService.IServiceContracts {
        
        public ServiceContractsClient() {
        }
        
        public ServiceContractsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceContractsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetAllMaterialInfo() {
            return base.Channel.GetAllMaterialInfo();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetAllMaterialInfoAsync() {
            return base.Channel.GetAllMaterialInfoAsync();
        }
        
        public string getName(string name) {
            return base.Channel.getName(name);
        }
        
        public System.Threading.Tasks.Task<string> getNameAsync(string name) {
            return base.Channel.getNameAsync(name);
        }
        
        public System.Data.DataSet GetErrorCodeDescription(int errorCode) {
            return base.Channel.GetErrorCodeDescription(errorCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetErrorCodeDescriptionAsync(int errorCode) {
            return base.Channel.GetErrorCodeDescriptionAsync(errorCode);
        }
        
        public System.Data.DataSet ValidateMaterialNumber(string _materialNumber) {
            return base.Channel.ValidateMaterialNumber(_materialNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ValidateMaterialNumberAsync(string _materialNumber) {
            return base.Channel.ValidateMaterialNumberAsync(_materialNumber);
        }
        
        public System.Data.DataSet CheckCableSerial(string cableMaterialNumber, string cableSerialNumber) {
            return base.Channel.CheckCableSerial(cableMaterialNumber, cableSerialNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckCableSerialAsync(string cableMaterialNumber, string cableSerialNumber) {
            return base.Channel.CheckCableSerialAsync(cableMaterialNumber, cableSerialNumber);
        }
        
        public System.Data.DataSet CheckKitSerial(string kitMaterialNumber, string kitSerialNumber) {
            return base.Channel.CheckKitSerial(kitMaterialNumber, kitSerialNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckKitSerialAsync(string kitMaterialNumber, string kitSerialNumber) {
            return base.Channel.CheckKitSerialAsync(kitMaterialNumber, kitSerialNumber);
        }
        
        public System.Data.DataSet CheckSensorSerial(string sensorMaterialNumber, string sensorSerialNumber) {
            return base.Channel.CheckSensorSerial(sensorMaterialNumber, sensorSerialNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckSensorSerialAsync(string sensorMaterialNumber, string sensorSerialNumber) {
            return base.Channel.CheckSensorSerialAsync(sensorMaterialNumber, sensorSerialNumber);
        }
        
        public System.Data.DataSet CheckRemoteSerial(string remoteSerialNumber, string remotePartNumber) {
            return base.Channel.CheckRemoteSerial(remoteSerialNumber, remotePartNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckRemoteSerialAsync(string remoteSerialNumber, string remotePartNumber) {
            return base.Channel.CheckRemoteSerialAsync(remoteSerialNumber, remotePartNumber);
        }
        
        public System.Data.DataSet CheckStarterKitSensor(string starterKitPartNumber, string sensorSerial) {
            return base.Channel.CheckStarterKitSensor(starterKitPartNumber, sensorSerial);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckStarterKitSensorAsync(string starterKitPartNumber, string sensorSerial) {
            return base.Channel.CheckStarterKitSensorAsync(starterKitPartNumber, sensorSerial);
        }
        
        public System.Data.DataSet CheckAEComboKitSensor(string comboKitPartNumber, string size1Serial, string size2Serial) {
            return base.Channel.CheckAEComboKitSensor(comboKitPartNumber, size1Serial, size2Serial);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> CheckAEComboKitSensorAsync(string comboKitPartNumber, string size1Serial, string size2Serial) {
            return base.Channel.CheckAEComboKitSensorAsync(comboKitPartNumber, size1Serial, size2Serial);
        }
        
        public System.Data.DataSet InsertCableKitSerials(string _cableMaterialNumber, string _cableSerial, string _orderNumber, string _kitMaterialNumber) {
            return base.Channel.InsertCableKitSerials(_cableMaterialNumber, _cableSerial, _orderNumber, _kitMaterialNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertCableKitSerialsAsync(string _cableMaterialNumber, string _cableSerial, string _orderNumber, string _kitMaterialNumber) {
            return base.Channel.InsertCableKitSerialsAsync(_cableMaterialNumber, _cableSerial, _orderNumber, _kitMaterialNumber);
        }
        
        public System.Data.DataSet InsertAEComboKit(string _kitMaterialNumber, string _kitSerial, string _size1Sensor, string _size2Sensor, string _remoteSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAEComboKit(_kitMaterialNumber, _kitSerial, _size1Sensor, _size2Sensor, _remoteSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertAEComboKitAsync(string _kitMaterialNumber, string _kitSerial, string _size1Sensor, string _size2Sensor, string _remoteSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAEComboKitAsync(_kitMaterialNumber, _kitSerial, _size1Sensor, _size2Sensor, _remoteSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertAERmaKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAERmaKit(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _cableSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertAERmaKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAERmaKitAsync(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _cableSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertAESensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAESensorShipKit(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _cableSerial, _spareCableSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertAESensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorMaterialNumber, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAESensorShipKitAsync(_kitMaterialNumber, _kitSerial, _sensorMaterialNumber, _cableSerial, _spareCableSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertAEStarterKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerialNumber, string _remoteSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAEStarterKit(_kitMaterialNumber, _kitSerial, _sensorSerialNumber, _remoteSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertAEStarterKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerialNumber, string _remoteSerial, string _orderNumber, string _note) {
            return base.Channel.InsertAEStarterKitAsync(_kitMaterialNumber, _kitSerial, _sensorSerialNumber, _remoteSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertSensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertSensorShipKit(_kitMaterialNumber, _kitSerial, _sensorSerial, _cableSerial, _spareCableSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertSensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _spareCableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertSensorShipKitAsync(_kitMaterialNumber, _kitSerial, _sensorSerial, _cableSerial, _spareCableSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertRMASensorShipKit(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertRMASensorShipKit(_kitMaterialNumber, _kitSerial, _sensorSerial, _cableSerial, _orderNumber, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertRMASensorShipKitAsync(string _kitMaterialNumber, string _kitSerial, string _sensorSerial, string _cableSerial, string _orderNumber, string _note) {
            return base.Channel.InsertRMASensorShipKitAsync(_kitMaterialNumber, _kitSerial, _sensorSerial, _cableSerial, _orderNumber, _note);
        }
        
        public System.Data.DataSet InsertNote(int rowId, string _materialNumber, string _note, string _uapid) {
            return base.Channel.InsertNote(rowId, _materialNumber, _note, _uapid);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertNoteAsync(int rowId, string _materialNumber, string _note, string _uapid) {
            return base.Channel.InsertNoteAsync(rowId, _materialNumber, _note, _uapid);
        }
        
        public System.Data.DataSet InsertCableSerial(string _cableMaterialNumber, string _cableSerial, string _kitMaterialCableWasUsedIn, string _note) {
            return base.Channel.InsertCableSerial(_cableMaterialNumber, _cableSerial, _kitMaterialCableWasUsedIn, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertCableSerialAsync(string _cableMaterialNumber, string _cableSerial, string _kitMaterialCableWasUsedIn, string _note) {
            return base.Channel.InsertCableSerialAsync(_cableMaterialNumber, _cableSerial, _kitMaterialCableWasUsedIn, _note);
        }
        
        public System.Data.DataSet InsertRemoteSerial(string _remoteMaterialNumber, string _remoteSerial, string _kitMaterialRemoteWasUsedIn, string _kitSerialRemoteWasUsedIn, string _note) {
            return base.Channel.InsertRemoteSerial(_remoteMaterialNumber, _remoteSerial, _kitMaterialRemoteWasUsedIn, _kitSerialRemoteWasUsedIn, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertRemoteSerialAsync(string _remoteMaterialNumber, string _remoteSerial, string _kitMaterialRemoteWasUsedIn, string _kitSerialRemoteWasUsedIn, string _note) {
            return base.Channel.InsertRemoteSerialAsync(_remoteMaterialNumber, _remoteSerial, _kitMaterialRemoteWasUsedIn, _kitSerialRemoteWasUsedIn, _note);
        }
        
        public System.Data.DataSet InsertSensorSerial(string _sensorMaterialNumber, string _sensorSerial, string _kitMaterialSensorWasUsedIn, string _note) {
            return base.Channel.InsertSensorSerial(_sensorMaterialNumber, _sensorSerial, _kitMaterialSensorWasUsedIn, _note);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertSensorSerialAsync(string _sensorMaterialNumber, string _sensorSerial, string _kitMaterialSensorWasUsedIn, string _note) {
            return base.Channel.InsertSensorSerialAsync(_sensorMaterialNumber, _sensorSerial, _kitMaterialSensorWasUsedIn, _note);
        }
        
        public System.Data.DataSet InsertCalibDetails(string _serialNumber, string _chipID, string _lotNumber, string _calibStation) {
            return base.Channel.InsertCalibDetails(_serialNumber, _chipID, _lotNumber, _calibStation);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> InsertCalibDetailsAsync(string _serialNumber, string _chipID, string _lotNumber, string _calibStation) {
            return base.Channel.InsertCalibDetailsAsync(_serialNumber, _chipID, _lotNumber, _calibStation);
        }
        
        public System.Data.DataSet GetCalibDetails(string _serialNumber, string _chipID, string _lotNumber, string _calibStation) {
            return base.Channel.GetCalibDetails(_serialNumber, _chipID, _lotNumber, _calibStation);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetCalibDetailsAsync(string _serialNumber, string _chipID, string _lotNumber, string _calibStation) {
            return base.Channel.GetCalibDetailsAsync(_serialNumber, _chipID, _lotNumber, _calibStation);
        }
    }
}
