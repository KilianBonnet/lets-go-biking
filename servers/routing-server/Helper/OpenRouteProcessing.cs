using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper
{
    internal class OpenRouteProcessing
    {
        private class AddressNotFoundException : Exception { }
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        
        // Singleton design pattern
        public static readonly OpenRouteProcessing Instance = new OpenRouteProcessing();
        private OpenRouteProcessing() {}

        public async Task<OpenRoutePoint> GetOpenRoutePoint(string address)
        {
            string json = await openRouteClient.RequestGeocodeSearch(address);
            return JsonConvert.DeserializeObject<OpenRoutePoint>(json);
        }
    }
}