using System;
using System.Device.Location;
using System.Net.Http;
using System.Threading.Tasks;
using routing_server.Helper.locomotion;


namespace routing_server { 
    internal class OpenRouteClient
    {
        // Client configuration
        private readonly HttpClient client = new HttpClient();

        // Singleton design pattern
        public static readonly OpenRouteClient Instance = new OpenRouteClient();
        private OpenRouteClient(){}
        
        public async Task<string> RequestGeocodeSearch(string address)
        {
            Uri requestedURL = new Uri(
                "https://api.openrouteservice.org/geocode/search?api_key="
                + Config.OPEN_ROUTE_SERVICE_API_KEY
                + "&text=" + address);
            HttpResponseMessage response = await client.GetAsync(requestedURL);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RequestDirections(GeoCoordinate departure, GeoCoordinate arrival, LocomotionType locomotionType)
        {
            Uri requestedURL = new Uri(
                "https://api.openrouteservice.org/v2/directions/"
                + locomotionType
                + "?api_key=" + Config.OPEN_ROUTE_SERVICE_API_KEY
                + "&start=" + departure.Longitude + "," + departure.Latitude
                + "&end=" + arrival.Longitude + "," + arrival.Latitude
                );
            HttpResponseMessage response = await client.GetAsync(requestedURL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
