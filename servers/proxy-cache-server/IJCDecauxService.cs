using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using class_library;

namespace proxy_cache_server
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