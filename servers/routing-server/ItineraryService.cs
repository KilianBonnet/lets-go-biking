using System.Device.Location;
using System.Threading;
using System.Threading.Tasks;
using routing_server.Helper;
using routing_server.Helper.locomotion;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        private readonly OpenRouteProcessing openRouteProcessing = OpenRouteProcessing.Instance;
        

        public async Task<string> GetItinerary(string departureAddress, string arrivalAddress)
        {
            OpenRoutePoint departure = await openRouteProcessing.GetOpenRoutePoint(departureAddress);
            OpenRoutePoint arrival = await openRouteProcessing.GetOpenRoutePoint(arrivalAddress);

            GeoCoordinate start = openRouteProcessing.GetGeoCoordinate(departure);
            GeoCoordinate end = openRouteProcessing.GetGeoCoordinate(arrival);

            FootLocomotion footLocomotion = new FootLocomotion(start, end);
            return "" + footLocomotion.GetDuration();
        }
    }
}
