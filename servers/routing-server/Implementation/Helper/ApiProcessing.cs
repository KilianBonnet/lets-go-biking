using System;
using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<Station> GetNearestAvailableStation(OpenRoutePoint openRoutePoint, BikeAvailability availability)
        {
            // Retrieving the contract who covers the user's city
            string coveringContractName = await GetClosestContractName(openRoutePoint);

            // Retrieving all the stations form the given contract
            Station[] stations = await jcDecauxClient.GetStationsAsync(coveringContractName);
            if (stations.Length == 0)
                throw new CityNotCoveredException();

            // Finding the number of the closest station
            return FindClosestStation(openRoutePoint, stations, availability);
        }

        private Station FindClosestStation(OpenRoutePoint openRoutePoint, Station[] stations, BikeAvailability availability)
        {
            GeoCoordinate userPosition = new GeoCoordinate(openRoutePoint.features[0].geometry.coordinates[1],
                openRoutePoint.features[0].geometry.coordinates[0]);
            
            int bestIndex = -1;
            GeoCoordinate bestPosition = null;

            for (int i = 0; i < stations.Length; i++)
            {
                // Check if there is an available bike stand on the given station when user want to deposit his bike
                if(availability == BikeAvailability.DEPOSIT && stations[0].available_bike_stands == 0)
                    continue;
                
                // Check if there is an available bike on the given station when user want to take a bike
                if(availability == BikeAvailability.TAKE && stations[0].available_bikes == 0)
                    continue;
                
                GeoCoordinate currentGeoCoordinate = new GeoCoordinate(stations[i].position.lat,
                    stations[i].position.lng);
                
                if (bestPosition == null)
                {
                    bestIndex = i;
                    bestPosition = currentGeoCoordinate;
                }
                if (currentGeoCoordinate.GetDistanceTo(userPosition) >= bestPosition.GetDistanceTo(userPosition))
                    continue;
                
                bestIndex = i;
                bestPosition = currentGeoCoordinate;
            }
            
            return stations[bestIndex];
        }
    }
}