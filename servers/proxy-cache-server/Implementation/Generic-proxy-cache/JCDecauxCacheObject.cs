using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace proxy_cache_server.Implementation.Generic_proxy_cache
{
    public class ContractsItem
    {
        // ContractsItem content
        public readonly List<Contract> Contracts;
        
        // GenericProxyCache will call this constructor when the value is null or if the cache need to be updated
        public ContractsItem(string GenericName)
        {
            Console.WriteLine("     [INFO] Contract has been requested to JCDecaux");
            string json = JCDecauxClient.Instance.RequestContractsAsync().Result;
            Contracts = JsonConvert.DeserializeObject<List<Contract>>(json);
        }
    }

    public class StationsItem
    { 
        public readonly List<Station> Stations;
        
        // GenericProxyCache will call this constructor when the value is null or if the cache need to be updated
        public StationsItem(string ContractName)
        {
            Console.WriteLine("     [INFO] Station of " + ContractName +  " has been requested to JCDecaux");
            string json = JCDecauxClient.Instance.RequestStationsAsync(ContractName).Result;
            Stations = JsonConvert.DeserializeObject<List<Station>>(json);
        }
    }
}