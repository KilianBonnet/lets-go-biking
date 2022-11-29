using System;
using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper.locomotion
{
    public class FootLocomotion
    {
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        private readonly GeoCoordinate departure;
        private readonly GeoCoordinate arrival;
        
        public FootLocomotion(GeoCoordinate departure, GeoCoordinate arrival)
        {
            this.departure = departure;
            this.arrival = arrival;
        }

        public async Task<LgbDirections> GetDirections()
        {
            OpenRouteDirections directions = await QueryDirections(); // Query from OpenRouteService the directions from departure to arrival
            if (directions == null) throw new BadDirectionRequestException();
            if (directions.features.Count == 0) throw new DirectionsNotFoundException();
            return LgbDirectionBuilder.BuildLgbDirection(directions, LocomotionType.FOOT);
        }
        
        private async Task<OpenRouteDirections> QueryDirections()
        {
            // Query directions information through openRouteClient
            string directionsJson = await openRouteClient
                .RequestDirections(departure, arrival, LocomotionType.FOOT);
            return JsonConvert.DeserializeObject<OpenRouteDirections>(directionsJson);
        }
    }
}