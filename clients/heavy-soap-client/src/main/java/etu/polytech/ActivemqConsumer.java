package etu.polytech;

import etu.polytech.directionObjects.Step;
import io.cucumber.core.internal.com.fasterxml.jackson.core.JsonProcessingException;
import io.cucumber.core.internal.com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;

public class ActivemqConsumer {
    public static final ActiveMQConnectionFactory connectionFactory = new ActiveMQConnectionFactory("tcp://localhost:61616");

    public static List<Step> ConsumeSteps(String queueGuid) throws JMSException, JsonProcessingException {
        // Create a Connection
        Connection connection = connectionFactory.createConnection();
        connection.start();

        // Create a Session
        Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);

        // Create the destination (Topic or Queue)
        Destination destination = session.createQueue(queueGuid);

        // Create a MessageConsumer from the Session to the Topic or Queue
        MessageConsumer consumer = session.createConsumer(destination);

        List<Step> steps = new ArrayList<>();
        QueueBrowser browser = session.createBrowser(session.createQueue(queueGuid));
        var enu = browser.getEnumeration();
        while (enu.hasMoreElements()) {
            TextMessage message = (TextMessage) enu.nextElement();
            Step step = new ObjectMapper().readValue(message.getText(), Step.class);
            steps.add(step);
        }

        session.close();
        connection.close();

        return steps;
    }
}
