using System.Collections.Generic;
using Newtonsoft.Json;

namespace routing_server.Helper.open_route_objects
{
    public class OpenRouteDirections
    {
        [JsonProperty(PropertyName="features")] 
        public List<DirectionsFeature> features { get; set; }
    }
}