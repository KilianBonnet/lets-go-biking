using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

class JCDecauxCache : Cache
{
    private readonly Dictionary<string, ContractCahe> contractsCache = new Dictionary<string, ContractCahe>();
    public class Contract { public string name; }

    // Set here the lifespan of the cache
    public JCDecauxCache() : base(new TimeSpan(0, 5, 0)){}

    public async Task Regenerate()
    {
        // Ask JCDecaux servers to send the json containing all contracts
        string response = await JCDecauxClient.Istance.RequestContractsAsync();

        // If the the request leads to an unsuccessful response code
        if (response == null)
            return;

        lastUpdate = DateTime.Now;
        cachedJson = response;
        UpdateContractsCache();
    }

    private void UpdateContractsCache()
    {
        // Retrive all contracts from the json
        List<Contract> contracts = JsonConvert.DeserializeObject<List<Contract>>(cachedJson);

        // Check if there is something to update
        if (contracts.Count == contractsCache.Count)
            return;

        // Associate the name of the contract to a new empty cache to be filled
        foreach (Contract contract in contracts)
            contractsCache[contract.name] = new ContractCahe(contract.name);
    }

    public ContractCahe FindContractCache(string contractName)
    {
        if (contractsCache.ContainsKey(contractName))
            return contractsCache[contractName];
        return null;
    }
}