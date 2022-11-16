using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;


namespace routing_server { 
    internal class OpenRouteClient
    {
        // Singleton design pattern
        public static readonly OpenRouteClient Instance = new OpenRouteClient();

        // Client configuration
        private readonly HttpClient client = new HttpClient();
        private const string BASE_URL = "https://api.openrouteservice.org/v2/directions/cycling-road";

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
    }
}
