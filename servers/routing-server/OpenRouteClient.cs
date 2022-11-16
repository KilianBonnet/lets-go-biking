using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

class OpenRouteClient
{
    // Singleton design pattern
    public static OpenRouteClient Istance = new OpenRouteClient();

    // Client configuration
    private readonly HttpClient client = new HttpClient();
    private const string BASE_URL = "https://api.openrouteservice.org/v2/directions/cycling-road";

    private OpenRouteClient(){}

    public async Task<string> RequestDirectionsAsync()
    {
        // Generating the necessary DefaultRequestHeaders
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your-api-key");

        return null;
    }
}

