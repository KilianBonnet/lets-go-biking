using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

class CacheManager
{
    // Singleton design pattern
    public static CacheManager Instance = new CacheManager();

    private ContractsCache contractsCache = new ContractsCache();
    private Dictionary<string, StationsCache> stationsCaches = new Dictionary<string, StationsCache>();

    public class Contract { public string name; }

        public async Task<string> GetContractsAsync()
    {
        if (contractsCache.IsOutdated())
        {
            await contractsCache.Regenerate();
            UpdatecontractNameList(contractsCache);
        }
        return contractsCache.cachedJson;
    }

    public async Task<string> GetStationsAsync(string contractName)
    {
        if (stationsCaches.Count == 0)
            await GetContractsAsync();

        if (!stationsCaches.ContainsKey(contractName))
            return "{\"Error\":\"Bad Request\"}";

        StationsCache stationsCache = stationsCaches[contractName];
        if (stationsCache.IsOutdated())
            await stationsCache.Regenerate();
        return stationsCache.cachedJson;
    }

    private void UpdatecontractNameList(ContractsCache newCache)
    {
        List<Contract> contracts = JsonConvert.DeserializeObject<List<Contract>>(newCache.cachedJson);
        foreach (Contract contract in contracts)
            if (!stationsCaches.ContainsKey(contract.name))
                stationsCaches[contract.name] = new StationsCache(contract.name);
    }
}

