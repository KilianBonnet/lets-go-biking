using System.Collections.Generic;
using System.ServiceModel;
using proxy_cache_server.Implementation;

namespace proxy_cache_server.Interface
{
    [ServiceContract]
    public interface IJCDecauxService
    {
        [OperationContract]
        List<Contract> GetContracts();

        [OperationContract]
        List<Station> GetStations(string contractName);
    }
}