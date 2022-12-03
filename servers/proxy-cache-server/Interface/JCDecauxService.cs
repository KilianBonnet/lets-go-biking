using System.Collections.Generic;
using System.Threading.Tasks;
using proxy_cache_server.Implementation;
using proxy_cache_server.Implementation.Generic_proxy_cache;

namespace proxy_cache_server.Interface
{
    public class JCDecauxService : IJCDecauxService
    {
        private static readonly CacheManager cacheManager = CacheManager.Instance;

        public List<Contract> GetContracts()
        {
            return cacheManager.GetContracts();
        }

        public List<Station> GetStations(string contractName)
        {
            if (contractName == null) contractName = "";
            return cacheManager.GetStations(contractName);
        }
    }
}
