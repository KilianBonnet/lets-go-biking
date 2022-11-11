﻿using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace proxy_cache_server
{   
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IJCDecauxService
    {
        [OperationContract]
        Task<string> GetContractsAsync();

        [OperationContract]
        Task<string> GetStationsAsync(string contractName);

        [OperationContract]
        Task<string> GetStationInfoAsync(string contractName, int stationNumber);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "proxy_cache_server.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
