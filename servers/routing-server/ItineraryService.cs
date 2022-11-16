using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        private static readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;

        public async Task<string> GetItinerary(string departureAddress, string arrivalAddress)
        {
            return await openRouteClient.RequestGeocodeSearch(departureAddress);
        }
    }
}
