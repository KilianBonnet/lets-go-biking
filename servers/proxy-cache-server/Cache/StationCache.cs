using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using class_library;
using Newtonsoft.Json;

namespace proxy_cache_server.Cache
{
    internal class StationCache : Cache
    {
        public StationInformation content;
        private readonly string contractName;
    
        public StationCache(string contractName) : base(new TimeSpan(0, 1, 0))
        {
            this.contractName = contractName;
        }

        public async Task Regenerate()
        {
            // Ask JCDecaux servers to send the json containing all stations from a contract
            string response = await JCDecauxClient.Instance.RequestStationsAsync(contractName);

            // If the the request leads to an unsuccessful response code
            if (response == null)
                return;

            lastUpdate = DateTime.Now;
            content = JsonConvert.DeserializeObject<StationInformation>(response);
        }
    }
}