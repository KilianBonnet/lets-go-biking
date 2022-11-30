package etu.polytech;

import etu.polytech.directionObjects.Step;
import etu.polytech.ws.client.generated.IItineraryService;
import etu.polytech.ws.client.generated.ItineraryService;
import etu.polytech.ws.client.generated.LgbDirections;
import etu.polytech.ws.client.generated.LgbStep;
import io.cucumber.core.internal.com.fasterxml.jackson.core.JsonProcessingException;

import javax.jms.JMSException;
import java.util.List;
import java.util.Scanner;

public class Main {
    private static final ItineraryService itineraryService = new ItineraryService();
    private static IItineraryService lgbService;

    public static void main(String[] args) throws JMSException, JsonProcessingException {
        // Initializing services
        lgbService = itineraryService.getBasicHttpBindingIItineraryService();

        // Asking directions
        LgbDirections lgbDirections = askDirections();

        displayItineraryInformation(lgbDirections);

        List<Step> steps = ActivemqConsumer.ConsumeSteps(lgbDirections.getActivemqQueueID().getValue());
        displaySteps(steps);
    }

    private static LgbDirections askDirections(){
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the departure address: ");
        String departureAddress = scanner.nextLine();
        System.out.print("Enter the arrival address: ");
        String arrivalAddress = scanner.nextLine();
        try {
            return lgbService.getItinerary(departureAddress, arrivalAddress);
        }
        catch (Exception e){
            System.err.println("Invalid address, may try to enter more details (city, code, ...)");
            return askDirections();
        }
    }

    private static void displayItineraryInformation(LgbDirections directions){
        separator();
        if(directions.getBikeDuration() > 0){
            System.out.println("[INFO] A bike will be needed for this itinerary!");
            separator();
        }
        System.out.println("Total distance: " + String.format("%.02f", directions.getTotalDistance() / 1000 ) + "km");
        System.out.println("Total duration: " + ((int)(directions.getTotalDuration() / 60)) + "min");
        separator();
        if(directions.getBikeDuration() > 0){
            System.out.println("Foot distance: " + String.format("%.02f", directions.getFootDistance() / 1000 ) + "km");
            System.out.println("Foot duration: " + ((int)(directions.getFootDuration() / 60)) + "min");

            System.out.println("Bike distance: " + String.format("%.02f", directions.getBikeDistance() / 1000 )  + "km");
            System.out.println("Bike duration: " + ((int)(directions.getBikeDuration() / 60)) + "min");
            separator();
        }
    }

    private static void displaySteps(List<Step> steps){
        // Displaying the different steps of the itinerary
        for(Step step : steps){
            System.out.println(step.Indication);
            if(step.Distance > 0)
                System.out.println("    Distance: " + String.format("%.02f", step.Distance / 1000) + "km");
            if(step.Duration > 0)
                System.out.println("    Duration: " + ((int)(step.Duration / 60)) + "min");
            System.out.println();
        }
    }

    private static void separator(){
        System.out.println("-------------------------------------");
    }
}