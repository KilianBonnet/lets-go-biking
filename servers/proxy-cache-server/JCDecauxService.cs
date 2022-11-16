using System.Threading.Tasks;
using proxy_cache_server.Cache;

namespace proxy_cache_server
{
    public class JCDecauxService : IJCDecauxService
    {
        private static readonly CacheManager cacheManager = CacheManager.Instance;

        public async Task<string> GetContractsAsync()
        {
            return await cacheManager.GetContractsAsync();
        }

        public async Task<string> GetStationsAsync(string contractName)
        {
            if (contractName == null) contractName = "";
            return await cacheManager.GetStationsAsync(contractName);
        }

        public async Task<string> GetStationInfoAsync(string contractName, int stationNumber)
        {
            if (contractName == null) contractName = "";
            return await cacheManager.GetStationInfoAsync(contractName, stationNumber);
        }
    }
}
