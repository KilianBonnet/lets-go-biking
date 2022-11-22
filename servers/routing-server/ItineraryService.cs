using System.Threading.Tasks;
using routing_server.Helper;
using routing_server.Helper.locomotion;
using routing_server.Helper.open_route_objects;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        private readonly ApiProcessing _apiProcessing = ApiProcessing.Instance;
        

        public async Task<string> GetItinerary(string departureAddress, string arrivalAddress)
        {
            if (departureAddress == null || arrivalAddress == null) return null;
            
            OpenRoutePoint departure = await _apiProcessing.GetOpenRoutePoint(departureAddress);
            OpenRoutePoint arrival = await _apiProcessing.GetOpenRoutePoint(arrivalAddress);

            if (departure == null || arrival == null) return null;
            
            FootLocomotion footLocomotion = new FootLocomotion(departure, arrival);
            
            return "" + footLocomotion.GetProperties().Result.summary.duration;
        }
    }
}
