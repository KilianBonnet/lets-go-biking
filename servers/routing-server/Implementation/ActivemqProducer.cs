using System;
using System.Collections.Generic;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using routing_server.Implementation.Helper.open_route_objects;


namespace routing_server.Implementation
{
    public class ActivemqProducer
    {
        private static readonly ConnectionFactory connectionFactory = new ConnectionFactory("activemq:tcp://localhost:61616");
        
        //Singleton design patter
        public static readonly ActivemqProducer Instance = new ActivemqProducer();
        private ActivemqProducer() {}

        public string StackSteps(List<LgbStep> lgbSteps)
        {
            // Create a single Connection from the Connection Factory.
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();

            // Create a session from the Connection.
            ISession session = connection.CreateSession();
            
            // Use the session to create a new queue with a random guid
            Guid guid = Guid.NewGuid();
            IDestination destination = session.GetQueue(guid.ToString());
            
            // Create a Producer targeting the selected queue.
            IMessageProducer producer = session.CreateProducer(destination);
            
            // Configuring message before sending it
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;


            foreach (var step in lgbSteps)
            {
                // Sending message
                ITextMessage iTextMessage = session.CreateTextMessage(JsonConvert.SerializeObject(step));
                producer.Send(iTextMessage);
            }
            
            session.Close();
            connection.Close();
            
            // Returning to the user the channel name to listen to.
            return guid.ToString();
        }
    }
}