using System.Threading.Tasks;
using routing_server.Helper;
using routing_server.Helper.locomotion;
using routing_server.Helper.open_route_objects;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        private readonly OpenRouteProcessing openRouteProcessing = OpenRouteProcessing.Instance;
        

        public async Task<string> GetItinerary(string departureAddress, string arrivalAddress)
        {
            if (departureAddress == null || arrivalAddress == null) return null;
            
            OpenRoutePoint departure = await openRouteProcessing.GetOpenRoutePoint(departureAddress);
            OpenRoutePoint arrival = await openRouteProcessing.GetOpenRoutePoint(arrivalAddress);

            if (departure == null || arrival == null) return null;
            
            FootLocomotion footLocomotion = new FootLocomotion(departure.ToGeoCoordinate(), arrival.ToGeoCoordinate());
            return "" + footLocomotion.GetDuration();
        }
    }
}
