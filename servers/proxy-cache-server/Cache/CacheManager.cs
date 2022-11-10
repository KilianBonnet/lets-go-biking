using System.Collections.Generic;
using System.Threading.Tasks;

class CacheManager
{
    // Singleton design pattern
    public static CacheManager Instance = new CacheManager();

    private ContractsCache contractsCache = new ContractsCache();
    private Dictionary<string, StationsCache> stationsCaches = new Dictionary<string, StationsCache>();

    public async Task<string> GetContractsAsync()
    {
        if (contractsCache.IsOutdated())
            await contractsCache.Regenerate();
        return contractsCache.cachedJson;
    }

    public async Task<string> GetStationsAsync(string contractName)
    {
        // If the request is already cached
        if (stationsCaches.ContainsKey(contractName))
        {
            StationsCache stationsCache = stationsCaches[contractName];
            if (stationsCache.IsOutdated())
                await stationsCache.Regenerate();
            return stationsCache.cachedJson;
        }

        // If the request not cached
        StationsCache newStationCache = new StationsCache(contractName);
        if (await newStationCache.Regenerate())
            stationsCaches[contractName] = newStationCache;
        return newStationCache.cachedJson;
    }
}

