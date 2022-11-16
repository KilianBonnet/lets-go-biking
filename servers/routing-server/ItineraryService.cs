using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace routing_server
{
    public class ItineraryService : IItineraryService
    {
        public string GetItinerary(string departureAddress, string arrivalAddress)
        {
            return "Not implemented";
        }
    }
}
