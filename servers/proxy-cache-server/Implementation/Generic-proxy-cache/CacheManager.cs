using System;
using System.Collections.Generic;

namespace proxy_cache_server.Implementation.Generic_proxy_cache
{
    public class CacheManager
    {
        private const double STATION_LIFE_SPAN = 60;
        private readonly DateTimeOffset CONTRACT_LIFE_SPAN = DateTimeOffset.Now.AddDays(1);
        
        // Singleton design pattern
        public static readonly CacheManager Instance = new CacheManager();
        private CacheManager() {}
        
        public List<Contract> GetContracts()
        {
            GenericProxyCache<ContractsItem> contractsCache = new GenericProxyCache<ContractsItem>();
            return (contractsCache.Get("contracts", CONTRACT_LIFE_SPAN).Contracts);
        }

        public List<Station> GetStations(string ContractName) 
        {
            GenericProxyCache<StationsItem> stationCache = new GenericProxyCache<StationsItem>();
            return stationCache.Get(ContractName, STATION_LIFE_SPAN).Stations;
        }
    }
}