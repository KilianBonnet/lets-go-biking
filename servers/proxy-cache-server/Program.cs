using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using proxy_cache_server.Implementation;
using proxy_cache_server.Interface;

// add the WCF ServiceModel namespace 
using System.ServiceModel;
using System.ServiceModel.Description;

namespace proxy_cache_server
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/proxy_cache_server/JCDecauxService/");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(JCDecauxService), httpUrl);
            
            //Add IJCDecauxService service endpoint
            host.AddServiceEndpoint(typeof(IJCDecauxService), new BasicHttpBinding(), ""); 

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior {
                HttpGetEnabled = true
            };
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now);
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

        }
    }
}