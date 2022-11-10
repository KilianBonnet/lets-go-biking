using System;
using System.Threading.Tasks;

namespace proxy_cache_server
{
    public class JCDecauxService : IJCDecauxService
    {
        private readonly JCDecauxClient JCDecauxClient = JCDecauxClient.Istance;

        public Task<string> GetContracts()
        {
            return JCDecauxClient.getContractsAsync();
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
