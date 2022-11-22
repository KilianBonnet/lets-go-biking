using System;
using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper.locomotion
{
    public class FootLocomotion : Locomotion
    {
        public FootLocomotion(OpenRoutePoint departure, OpenRoutePoint arrival) : base(departure, arrival) {}

        public override async Task<DirectionsProperties> GetProperties()
        {
            await QueryInformation(); // Query from OpenRouteService the directions from departure to arrival

            if (directions == null)
                throw new BadDirectionRequestException();

            if (directions.features.Count == 0)
                throw new DirectionsNotFoundException();
            
            return directions.features[0].properties;
        }

        public override async Task<double> GetDuration()
        {
            return (await GetProperties()).summary.duration;
        }

        private async Task QueryInformation()
        {
            // Check if the query is already done
            if (directions != null)
                return;

            // Query directions information through openRouteClient
            string directionsJson = await openRouteClient
                .RequestDirections(departure.ToGeoCoordinate(), arrival.ToGeoCoordinate(), LocomotionType.FOOT);
            directions = JsonConvert.DeserializeObject<OpenRouteDirections>(directionsJson);
        }
    }
}