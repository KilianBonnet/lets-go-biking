using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace routing_server
{
    [ServiceContract]
    public interface IItineraryService
    {
        [OperationContract]
        string GetItinerary(string departureAddress, string arrivalAddress);
    }
}
