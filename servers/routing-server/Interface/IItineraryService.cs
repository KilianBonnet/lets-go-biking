using System.ServiceModel;
using System.Threading.Tasks;
using routing_server.Implementation.Helper.open_route_objects;

namespace routing_server.Interface
{
    [ServiceContract]
    public interface IItineraryService
    {
        [OperationContract]
        Task<LgbDirections> GetItinerary(string departureAddress, string arrivalAddress);
    }
}
