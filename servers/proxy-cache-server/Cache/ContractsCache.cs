using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace proxy_cache_server.Cache
{
    internal class ContractsCache : GenericProxyCache
    {
        // The GetContracts Json converted to a List<Contract>
        public List<Contract> content;
        // The association of a stationName and its Stations
        private readonly Dictionary<string, StationsCache> contractsCache = new Dictionary<string, StationsCache>();

        // Set here the lifespan of the cache
        public ContractsCache() : base(new TimeSpan(24, 0, 0)){}

        public async Task Regenerate()
        {
            // Ask JCDecaux servers to send the json containing all contracts
            string response = await JCDecauxClient.Instance.RequestContractsAsync();

            // If the the request leads to an unsuccessful response code
            if (response == null)
                return;

            lastUpdate = DateTime.Now;
            content = JsonConvert.DeserializeObject<List<Contract>>(response);
            UpdateContractsCache();
        }

        private void UpdateContractsCache()
        {
            // Check if a new contract has been found
            if (content == null || content.Count == contractsCache.Count)
                return;

            contractsCache.Clear();
            
            // Associate the name of the contract to a new empty cache to be filled
            foreach (Contract contract in content)
                contractsCache[contract.name] = new StationsCache(contract.name);
        }

        public StationsCache FindContractCache(string contractName)
        {
            return contractsCache.ContainsKey(contractName) ? contractsCache[contractName] : null;
        }
    }
}