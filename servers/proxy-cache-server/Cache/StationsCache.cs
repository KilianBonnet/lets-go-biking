using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

class StationsCache : Cache
{
    private string contractName;
    private readonly Dictionary<int, StationCache> stationsCache = new Dictionary<int, StationCache>();
    public class Station { public int number; }

    // Set here the lifespan of the cache
    public StationsCache(string contractName) : base(new TimeSpan(0, 5, 0))
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
        UpdateStationsCache();
    }

    private void UpdateStationsCache()
    {
        // Retrive all stations from the json
        List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(cachedJson);

        // Check if there is something to update
        if (stations.Count == stationsCache.Count)
            return;

        // Associate the name of the station to a new empty cache to be filled
        foreach (Station station in stations)
            stationsCache[station.number] = new StationCache(contractName);
    }

    public StationCache FindStationCache(int stationNumber)
    {
        if (stationsCache.ContainsKey(stationNumber))
            return stationsCache[stationNumber];
        return null;
    }
}
