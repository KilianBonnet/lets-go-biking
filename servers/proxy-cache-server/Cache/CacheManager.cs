using System.Threading.Tasks;

namespace proxy_cache_server.Cache
{
    internal class CacheManager
    {
        private readonly ContractsCache contractsCache = new ContractsCache();
        
        // Singleton design pattern
        public static readonly CacheManager Instance = new CacheManager();
        private CacheManager() {}

        public async Task<string> GetContractsAsync()
        {
            // Check if the contractsCache is outdated. If so, regenerate it.
            if (contractsCache.IsOutdated())
                await contractsCache.Regenerate();

            return contractsCache.cachedJson;
        }

        public async Task<string> GetStationsAsync(string contractName)
        {
            // Check if the contractsCache is outdated. If so, regenerate it.
            if (contractsCache.IsOutdated())
                await contractsCache.Regenerate();

            // Find the stationsCache in the contractsCache
            StationsCache stationsCache = contractsCache.FindContractCache(contractName);

            // If the stationsCache is not found. This is a bad request
            if (stationsCache == null)
                return "{\"Error\":\"Bad Request\"}";

            // Check if the stationsCache is outdated. If so, regenerate it.
            if (stationsCache.IsOutdated())
                await stationsCache.Regenerate();

            return stationsCache.cachedJson;
        }

        public async Task<string> GetStationInfoAsync(string contractName, int stationNumber)
        {
            // Check if the contractsCache is outdated. If so, regenerate it.
            if (contractsCache.IsOutdated())
                await contractsCache.Regenerate();

            // Find the stationsCache in the contractsCache
            StationsCache stationsCache = contractsCache.FindContractCache(contractName);

            // If the stationsCache is not found. This is a bad request
            if (stationsCache == null)
                return "{\"Error\":\"Bad Request\"}";

            // Check if the stationsCache is outdated. If so, regenerate it.
            if (stationsCache.IsOutdated())
                await stationsCache.Regenerate();

            // Find the stationCache in the ContractCache
            StationCache stationCache = stationsCache.FindStationCache(stationNumber);

            // If the stationCache is not found. This is a bad request
            if (stationCache == null)
                return "{\"Error\":\"Bad Request\"}";

            // Check if the stationCache is outdated. If so, regenerate it.
            if (stationCache.IsOutdated())
                await stationCache.Regenerate();

            return stationCache.cachedJson;
        }
    }
}
