using System.Threading.Tasks;
using routing_server.Helper;
using routing_server.Helper.locomotion;
using routing_server.Helper.open_route_objects;
using routing_server.JCDecauxService;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        private readonly ApiProcessing apiProcessing = ApiProcessing.Instance;
        

        public async Task<LgbDirections> GetItinerary(string departureAddress, string arrivalAddress)
        {
            if (departureAddress == null || arrivalAddress == null) return null;

            OpenRoutePoint departurePoint = await apiProcessing.GetOpenRoutePoint(departureAddress);
            OpenRoutePoint arrivalPoint = await apiProcessing.GetOpenRoutePoint(arrivalAddress);

            LgbDirections bikeLocomotionDirections = await new BikeLocomotion(departurePoint, arrivalPoint).GetDirections();
            LgbDirections footLocomotionDirections = await new FootLocomotion(departurePoint.ToGeoCoordinate(), arrivalPoint.ToGeoCoordinate()).GetDirections();
            
            return bikeLocomotionDirections.TotalDuration < footLocomotionDirections.TotalDuration
                ? bikeLocomotionDirections : footLocomotionDirections;
        }

        public string Debug()
        {
            IJCDecauxService jcDecauxService = new JCDecauxServiceClient();
            return jcDecauxService.GetContractsAsync().Result[0].name;
        }
    }
}
