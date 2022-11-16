using System.Collections.Generic;
using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace routing_server.Helper
{
    internal class OpenRouteProcessing
    {
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        
        // Singleton design pattern
        public static readonly OpenRouteProcessing Instance = new OpenRouteProcessing();
        private OpenRouteProcessing() {}

        public async Task<OpenRoutePoint> GetOpenRoutePoint(string address)
        {
            string json = await openRouteClient.RequestGeocodeSearch(address);
            return JsonConvert.DeserializeObject<OpenRoutePoint>(json);
        }

        public GeoCoordinate GetGeoCoordinate(OpenRoutePoint openRoutePoint)
        {
            List<double> coordinates = openRoutePoint.features[0].geometry.coordinates;
            return new GeoCoordinate(coordinates[1], coordinates[0]);
        }
    }
}