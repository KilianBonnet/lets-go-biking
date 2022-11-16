using System.ServiceModel;
using System.Threading.Tasks;

namespace proxy_cache_server
{
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