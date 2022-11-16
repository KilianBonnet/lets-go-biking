using System;
using System.Threading.Tasks;

namespace proxy_cache_server.Cache
{
    internal class StationCache : Cache
    {
        private readonly string contractName;
    
        public StationCache(string contractName) : base(new TimeSpan(0, 0, 10))
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
}