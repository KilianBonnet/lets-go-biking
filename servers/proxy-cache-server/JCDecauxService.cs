using System;
using System.Threading.Tasks;

namespace proxy_cache_server
{
    public class JCDecauxService : IJCDecauxService
    {
        private readonly CacheManager cacheManager = CacheManager.Instance;

        public async Task<string> GetContractsAsync()
        {
            return await cacheManager.GetContractsAsync();
        }

        public async Task<string> GetStationsAsync(string contractName)
        {
            return await cacheManager.GetStationsAsync(contractName);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
