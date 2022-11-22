using System.Device.Location;
using System.Threading.Tasks;
using routing_server.Helper.open_route_objects;

namespace routing_server.Helper.locomotion
{
    public class BikeLocomotion : Locomotion
    {
        public BikeLocomotion(OpenRoutePoint departure, OpenRoutePoint arrival) : base(departure, arrival) {}

        public override Task<DirectionsProperties> GetProperties()
        {
            throw new System.NotImplementedException();
        }

        public override Task<double> GetDuration()
        {
            throw new System.NotImplementedException();
        }

        private async Task QueryInformation()
        {
            // Check if the query is already done
            if (directions != null)
                return;
            
            // Check the nearest station from the departure point
            
            
            // Query directions information through openRouteClient
            
        }

    }
}