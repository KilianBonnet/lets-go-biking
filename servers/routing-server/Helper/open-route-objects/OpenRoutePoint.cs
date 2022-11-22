using System.Collections.Generic;
using System.Device.Location;
using Newtonsoft.Json;

namespace routing_server.Helper.open_route_objects
{
    public class OpenRoutePoint
    {
        [JsonProperty(PropertyName="features")] 
        public List<PointFeature> features { get; set; }
        
        public GeoCoordinate ToGeoCoordinate()
        {
            if (features.Count == 0)
                throw new AddressNotFoundException();

            if (features.Count > 1)
                throw new MultipleMatchingAddressException();

            List<double> coordinates = features[0].geometry.coordinates;
            return new GeoCoordinate(coordinates[1], coordinates[0]);
        }
    }
}