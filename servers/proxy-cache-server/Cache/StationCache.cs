using System;
using System.Threading.Tasks;

class StationCache : Cache
{
    private string contractName;
    
    public StationCache(string contractName) : base(new TimeSpan(0, 5, 0))
    {
        this.contractName = contractName;
    }

    public async Task Regenerate()
    {
        // Ask JCDecaux servers to send the json containing all stations from a contract
        string response = await JCDecauxClient.Istance.RequestStationsAsync(contractName);

        // If the the request leads to an unsuccessful response code
        if (response == null)
            return;

        lastUpdate = DateTime.Now;
        cachedJson = response;
    }
}

