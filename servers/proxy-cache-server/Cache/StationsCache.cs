using System;
using System.Threading.Tasks;

class StationsCache : Cache
{
    public string contractName;
    public StationsCache(string contractName) : base(new TimeSpan(0, 5, 0))
    {
        this.contractName = contractName;
    }

    public async Task<bool> Regenerate()
    {
        string response = await JCDecauxClient.Istance.RequestStationsAsync(contractName);

        // If the the request leads to an unsuccessful response code
        if (response == null)
            return false;

        lastUpdate = DateTime.Now;
        cachedJson = response;
        return true;
    }
}