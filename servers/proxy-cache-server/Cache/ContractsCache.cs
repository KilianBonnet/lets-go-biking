using System;
using System.Threading.Tasks;

class ContractsCache : Cache
{
    public ContractsCache() : base(new TimeSpan(0, 5, 0)){}

    public async Task Regenerate()
    {
        string response = await JCDecauxClient.Istance.RequestContractsAsync();

        // If the the request leads to an unsuccessful response code
        if (response == null)
            return;

        lastUpdate = DateTime.Now;
        cachedJson = response;
    }
}