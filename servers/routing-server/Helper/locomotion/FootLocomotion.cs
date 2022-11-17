using System.Device.Location;
using Newtonsoft.Json;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper.locomotion
{
    public class FootLocomotion : ILocomotion
    {
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        private readonly OpenRouteDirections directions;

        public FootLocomotion(GeoCoordinate departure, GeoCoordinate arrival)
        {
            string directionsJson = openRouteClient.RequestDirections(departure, arrival, LocomotionType.FOOT).Result;
            directions = JsonConvert.DeserializeObject<OpenRouteDirections>(directionsJson);
        }

        public double GetDuration()
        {
            return directions.features[0].properties.summary.duration;
        }
    }
}