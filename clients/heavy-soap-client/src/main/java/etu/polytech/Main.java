package etu.polytech;

import etu.polytech.ws.client.generated.IItineraryService;
import etu.polytech.ws.client.generated.ItineraryService;
import etu.polytech.ws.client.generated.LgbDirections;
import etu.polytech.ws.client.generated.LgbStep;

import java.util.Scanner;

public class Main {
    private static final ItineraryService itineraryService = new ItineraryService();
    private static IItineraryService lgbService;

    public static void main(String[] args) {
       // Initializing service
        lgbService = itineraryService.getBasicHttpBindingIItineraryService();

        // Asking directions
        LgbDirections directions = askDirections();

        // Displaying directions
        display(directions);
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

    private static void display(LgbDirections directions){
        // Displaying the global information of the itinerary
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

        // Displaying the different steps of the itinerary
        for(LgbStep lgbStep : directions.getSteps().getValue().getLgbStep()){
            System.out.println(lgbStep.getIndication().getValue());
            if(lgbStep.getDistance() > 0)
                System.out.println("    Distance: " + String.format("%.02f", lgbStep.getDistance() / 1000) + "km");
            if(lgbStep.getDuration() > 0)
                System.out.println("    Duration: " + ((int)(lgbStep.getDuration() / 60)) + "min");
            System.out.println();
        }
    }

    private static void separator(){
        System.out.println("-------------------------------------");
    }
}