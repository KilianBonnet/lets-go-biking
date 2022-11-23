using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace proxy_cache_server.Cache
{
    internal class StationCache : GenericProxyCache
    {
        public StationInformation content;
        private readonly string contractName;
        private readonly int stationNumber;
    
        public StationCache(string contractName, int stationNumber) : base(new TimeSpan(0, 1, 0))
        {
            this.contractName = contractName;
            this.stationNumber = stationNumber;
        }

        public async Task Regenerate()
        {
            // Ask JCDecaux servers to send the json containing all stations from a contract
            string response = await JCDecauxClient.Instance.RequestStationInfoAsync(contractName, stationNumber);

            // If the the request leads to an unsuccessful response code
            if (response == null)
                return;

            lastUpdate = DateTime.Now;
            content = JsonConvert.DeserializeObject<StationInformation>(response);
        }
    }
}