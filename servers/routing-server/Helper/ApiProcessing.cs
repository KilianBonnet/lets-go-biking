using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Helper.open_route_objects;
using routing_server.JCDecauxService;
using Contract = class_library.Contract;

namespace routing_server.Helper
{
    internal class ApiProcessing
    {
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        private readonly IJCDecauxService jcDecauxClient = new JCDecauxServiceClient();
        
        // Singleton design pattern
        public static readonly ApiProcessing Instance = new ApiProcessing();
        private ApiProcessing() {}

        public async Task<OpenRoutePoint> GetOpenRoutePoint(string address)
        {
            string json = await openRouteClient.RequestGeocodeSearch(address);
            return JsonConvert.DeserializeObject<OpenRoutePoint>(json);
        }

        public async Task<string> GetNearestContractName(OpenRoutePoint openRoutePoint)
        {
            string cityName = openRoutePoint.features[0].properties.locality;

            JCDecauxService.Contract[] contracts = await jcDecauxClient.GetContractsAsync();
            foreach (var contract in contracts)
            foreach (var city in contract.cities)
                if (city == cityName) return contract.name;
            return null;
        }
    }
}