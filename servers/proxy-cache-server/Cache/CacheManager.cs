using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

class CacheManager
{
    // Singleton design pattern
    public static CacheManager Instance = new CacheManager();
    private JCDecauxCache JCDecauxCache = new JCDecauxCache();

    public async Task<string> GetContractsAsync()
    {
        // Check if the JCDecauxCache is outdated. If so, regenerate it.
        if (JCDecauxCache.IsOutdated())
            await JCDecauxCache.Regenerate();

        return JCDecauxCache.cachedJson;
    }

    public async Task<string> GetStationsAsync(string contractName)
    {
        // Check if the JCDecauxCache is outdated. If so, regenerate it.
        if (JCDecauxCache.IsOutdated())
            await JCDecauxCache.Regenerate();

        // Find the CachedContract in the JCDecauxCache
        ContractCahe contractCache = JCDecauxCache.FindContractCache(contractName);

        // If the contractCache is not found. This is a bad request
        if (contractCache == null)
            return "{\"Error\":\"Bad Request\"}";

        // Check if the ContractCache is outdated. If so, regenerate it.
        if (contractCache.IsOutdated())
            await contractCache.Regenerate();

        return contractCache.cachedJson;
    }

    public async Task<string> GetStationInfoAsync(string contractName, int stationNumber)
    {
        // Check if the JCDecauxCache is outdated. If so, regenerate it.
        if (JCDecauxCache.IsOutdated())
            await JCDecauxCache.Regenerate();

        // Find the CachedContract in the JCDecauxCache
        ContractCahe contractCache = JCDecauxCache.FindContractCache(contractName);

        // If the contractCache is not found. This is a bad request
        if (contractCache == null)
            return "{\"Error\":\"Bad Request\"}";

        // Check if the ContractCahe is outdated. If so, regenerate it.
        if (contractCache.IsOutdated())
            await contractCache.Regenerate();

        // Find the StationCache in the ContractCache
        StationCache stationCache = contractCache.FindStationCache(stationNumber);

        // If the stationCache is not found. This is a bad request
        if (stationCache == null)
            return "{\"Error\":\"Bad Request\"}";

        // Check if the stationCache is outdated. If so, regenerate it.
        if (stationCache.IsOutdated())
            await stationCache.Regenerate();

        return stationCache.cachedJson;
    }
}

