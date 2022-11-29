﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using routing_server.Helper.open_route_objects;

namespace routing_server
{
    [ServiceContract]
    public interface IItineraryService
    {
        [OperationContract]
        Task<LgbDirections> GetItinerary(string departureAddress, string arrivalAddress);
    }
}
