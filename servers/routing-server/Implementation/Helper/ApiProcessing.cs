using System;
using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Implementation.Helper.open_route_objects;
using routing_server.JCDecauxService;

namespace routing_server.Implementation.Helper
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

        private async Task<string> GetClosestContractName(OpenRoutePoint openRoutePoint)
        {
            string cityName = openRoutePoint.features[0].properties.locality;

            Contract[] contracts = await jcDecauxClient.GetContractsAsync();
            foreach (var contract in contracts)
            {
                if (contract.cities == null)
                    continue;
                
                foreach (var city in contract.cities)
                    if (city.Equals(cityName)) return contract.name;
            }
            
            throw new CityNotCoveredException();
        }

        public async Task<Station> GetNearestAvailableStation(OpenRoutePoint openRoutePoint)
        {
            // Retrieving the contract who covers the user's city
            string coveringContractName = await GetClosestContractName(openRoutePoint);

            // Retrieving all the stations (without the details) form the given contract
            Station[] stations = await jcDecauxClient.GetStationsAsync(coveringContractName);

            // Finding the number of the closest station
            return FindClosestStation(openRoutePoint, stations);
        }

        private Station FindClosestStation(OpenRoutePoint openRoutePoint, Station[] stations)
        {
            int bestIndex = 0;
            GeoCoordinate bestPosition = new GeoCoordinate(stations[0].position.lat, 
                stations[0].position.lng);
            GeoCoordinate userPosition = new GeoCoordinate(openRoutePoint.features[0].geometry.coordinates[1],
                openRoutePoint.features[0].geometry.coordinates[0]);

            for (int i = 1; i < stations.Length; i++)
            {
                GeoCoordinate currentGeoCoordinate = new GeoCoordinate(stations[i].position.lat,
                    stations[i].position.lng);
                if (currentGeoCoordinate.GetDistanceTo(userPosition) < bestPosition.GetDistanceTo(userPosition))
                {
                    bestIndex = i;
                    bestPosition = currentGeoCoordinate;
                }
            }
            Console.WriteLine(stations[bestIndex].name);
            return stations[bestIndex];
        }
    }
}