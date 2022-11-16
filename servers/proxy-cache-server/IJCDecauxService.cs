using System.Runtime.Serialization;
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
    }
}
