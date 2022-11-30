using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using proxy_cache_server.Implementation;

namespace proxy_cache_server.Interface
{
    [ServiceContract]
    public interface IJCDecauxService
    {
        [OperationContract]
        Task<List<Contract>>GetContractsAsync();

        [OperationContract]
        Task<List<Station>> GetStationsAsync(string contractName);

        [OperationContract]
        Task<StationInformation> GetStationInfoAsync(string contractName, int stationNumber);
    }
}