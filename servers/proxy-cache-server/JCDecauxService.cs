using System.Collections.Generic;
using System.Threading.Tasks;
using class_library;
using proxy_cache_server.Cache;

namespace proxy_cache_server
{
    public class JCDecauxService : IJCDecauxService
    {
        private static readonly CacheManager cacheManager = CacheManager.Instance;

        public async Task<List<Contract>> GetContractsAsync()
        {
            return await cacheManager.GetContractsAsync();
        }

        public async Task<List<Station>> GetStationsAsync(string contractName)
        {
            if (contractName == null) contractName = "";
            return await cacheManager.GetStationsAsync(contractName);
        }

        public async Task<StationInformation> GetStationInfoAsync(string contractName, int stationNumber)
        {
            if (contractName == null) contractName = "";
            return await cacheManager.GetStationInfoAsync(contractName, stationNumber);
        }
    }
}
