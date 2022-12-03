using System.Collections.Generic;
using System.Device.Location;
using Newtonsoft.Json;

namespace routing_server.Implementation.Helper
{
    public class PointFeature
    {
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public List<double> coordinates { get; set; }
    }

    public class ParsedText
    {
        public string housenumber { get; set; }
        public string street { get; set; }
    }

    public class Properties
    {
        public string street { get; set; }
        public string postalcode { get; set; }
        public double confidence { get; set; }
        public string country { get; set; }
        public string macroregion { get; set; }
        public string region { get; set; }
        public string macrocounty { get; set; }
        public string county { get; set; }
        public string locality { get; set; }
        public string borough { get; set; }
        public string continent { get; set; }
        public string label { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class DirectionsFeature
    {
        [JsonProperty(PropertyName="properties")] public DirectionsProperties properties { get; set; }
        [JsonProperty(PropertyName="geometry")] public DirectionsGeometry geometry { get; set; }
    }

    public class DirectionsGeometry
    {
        public List<List<double>> coordinates { get; set; }
    }

    public class DirectionsProperties
    {
        public List<Segment> segments { get; set; }
        public Summary summary { get; set; }
        public List<int> way_points { get; set; }
    }

    public class Segment
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public int type { get; set; }
        public string instruction { get; set; }
        public string name { get; set; }
        public List<int> way_points { get; set; }
    }

    public class Summary
    {
        public double distance { get; set; }
        public double duration { get; set; }
    }    
    
    public class OpenRouteDirections
    {
        [JsonProperty(PropertyName="features")] 
        public List<DirectionsFeature> features { get; set; }
    }
    
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


