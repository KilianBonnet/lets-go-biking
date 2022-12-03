using System;
using System.ServiceModel;
using System.ServiceModel.Description;

using routing_server.Interface;

namespace routing_server
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/routing_server/ItineraryService/");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(ItineraryService), httpUrl);
            
            //Add IJCDecauxService service endpoint
            host.AddServiceEndpoint(typeof(IItineraryService), new BasicHttpBinding(), ""); 

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior {
                HttpGetEnabled = true
            };
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();

            Console.WriteLine("Routing server is host at " + DateTime.Now);
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}