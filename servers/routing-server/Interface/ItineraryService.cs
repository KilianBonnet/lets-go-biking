using System.Threading.Tasks;
using routing_server.Implementation;
using routing_server.Implementation.Helper;
using routing_server.Implementation.locomotion;

namespace routing_server.Interface
{
    public class ItineraryService : IItineraryService
    {
        private readonly ApiProcessing apiProcessing = ApiProcessing.Instance;
        private readonly ActivemqProducer activemqProducer = ActivemqProducer.Instance;
        
        public async Task<LgbDirections> GetItinerary(string departureAddress, string arrivalAddress)
        {
            if (departureAddress == null || arrivalAddress == null)
                return null;

            OpenRoutePoint departurePoint = await apiProcessing.GetOpenRoutePoint(departureAddress);
            OpenRoutePoint arrivalPoint = await apiProcessing.GetOpenRoutePoint(arrivalAddress);

            LgbDirections bikeLocomotionDirections = await new BikeLocomotion(departurePoint, arrivalPoint).GetDirections();
            LgbDirections footLocomotionDirections = await new FootLocomotion(departurePoint.ToGeoCoordinate(), arrivalPoint.ToGeoCoordinate()).GetDirections();

            string queueId;
            if (bikeLocomotionDirections.TotalDuration < footLocomotionDirections.TotalDuration)
            {
                queueId = activemqProducer.StackSteps(bikeLocomotionDirections.Steps);
                bikeLocomotionDirections.activemqQueueID = queueId;
                return bikeLocomotionDirections;
            }
            queueId = activemqProducer.StackSteps(footLocomotionDirections.Steps);
            footLocomotionDirections.activemqQueueID = queueId;
            return footLocomotionDirections;
        }
    }
}
