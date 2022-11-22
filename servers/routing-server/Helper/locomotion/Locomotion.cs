using System;
using System.Device.Location;
using System.Threading.Tasks;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper.locomotion
{
    public abstract class Locomotion
    {
        protected readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        protected readonly OpenRoutePoint departure;
        protected readonly OpenRoutePoint arrival;
        protected OpenRouteDirections directions;

        protected Locomotion(OpenRoutePoint departure, OpenRoutePoint arrival)
        {
            // Check if the departure input is correct
            if (departure == null || arrival == null || departure.features.Count == 0 || arrival.features.Count == 0)
                throw new AddressNotFoundException();
            
            this.departure = departure;
            this.arrival = arrival;
        }

        public abstract Task<DirectionsProperties> GetProperties();
        public abstract Task<double> GetDuration();
    }
}