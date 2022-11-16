using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace proxy_cache_server.Cache
{
    internal class StationsCache : Cache
    {
        private readonly string contractName;
        private readonly Dictionary<int, StationCache> stationsCache = new Dictionary<int, StationCache>();
        private class Station { public int number; }

        // Set here the lifespan of the cache
        public StationsCache(string contractName) : base(new TimeSpan(24, 0, 0))
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
            cachedJson = response;
            UpdateStationsCache();
        }

        private void UpdateStationsCache()
        {
            // Retrieve all stations from the json
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(cachedJson);

            // Check if there is something to update
            if (stations == null || stations.Count == stationsCache.Count)
                return;

            // Associate the name of the station to a new empty cache to be filled
            foreach (Station station in stations)
                stationsCache[station.number] = new StationCache(contractName);
        }

        public StationCache FindStationCache(int stationNumber)
        {
            return stationsCache.ContainsKey(stationNumber) ? stationsCache[stationNumber] : null;
        }
    }
}