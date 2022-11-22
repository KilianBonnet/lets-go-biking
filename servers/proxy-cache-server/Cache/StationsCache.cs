﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using class_library;
using Newtonsoft.Json;

namespace proxy_cache_server.Cache
{
    internal class StationsCache : Cache
    {
        private readonly string contractName;
        public List<Station> content;
        private readonly Dictionary<int, StationCache> stationsCache = new Dictionary<int, StationCache>();

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
            content = JsonConvert.DeserializeObject<List<Station>>(response);
            UpdateStationsCache();
        }

        private void UpdateStationsCache()
        {
            // Check if there is something to update
            if (content == null || content.Count == stationsCache.Count)
                return;

            stationsCache.Clear();
            
            // Associate the name of the station to a new empty cache to be filled
            foreach (Station station in content)
                stationsCache[station.number] = new StationCache(contractName);
        }

        public StationCache FindStationCache(int stationNumber)
        {
            return stationsCache.ContainsKey(stationNumber) ? stationsCache[stationNumber] : null;
        }
    }
}