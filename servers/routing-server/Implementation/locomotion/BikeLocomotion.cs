using System.Device.Location;
using System.Threading.Tasks;
using Newtonsoft.Json;
using routing_server.Implementation.Helper;
using routing_server.Implementation.Helper.open_route_objects;
using routing_server.JCDecauxService;

namespace routing_server.Implementation.locomotion
{
    public class BikeLocomotion
    {
        private readonly ApiProcessing apiProcessing = ApiProcessing.Instance;
        private readonly OpenRouteClient openRouteClient = OpenRouteClient.Instance;
        
        private readonly OpenRoutePoint departure;
        private readonly OpenRoutePoint arrival;

        public BikeLocomotion(OpenRoutePoint departure, OpenRoutePoint arrival)
        {
            this.departure = departure;
            this.arrival = arrival;
        }

        public async Task<LgbDirections> GetDirections()
        {
            StationInformation departureStation = null;
            StationInformation arrivalStation = null;
            try
            {
                // Check the nearest station from the departure & the arrival point
                departureStation = await apiProcessing.GetNearestAvailableStation(departure);
                arrivalStation = await apiProcessing.GetNearestAvailableStation(arrival);
            } 
            catch (CityNotCoveredException) {}

            if ((departureStation == null || arrivalStation == null) // If the cites are not covered bt JCDecaux
                || (departureStation.contract_name != arrivalStation.contract_name)) // If both cities are covered by a different contract
            {
                // User will get direction considering him walking.
                return await new FootLocomotion(departure.ToGeoCoordinate(), arrival.ToGeoCoordinate()).GetDirections();
            }
            
            // Transforming StationInformation to GeoCoordinate
            GeoCoordinate departureStationCoordinate = new GeoCoordinate(departureStation.position.lat,
                departureStation.position.lng);
            GeoCoordinate arrivalStationCoordinate = new GeoCoordinate(arrivalStation.position.lat,
                arrivalStation.position.lng);

            return await CalculateOptimalDirection(departureStationCoordinate, arrivalStationCoordinate);
        }


        private async Task<LgbDirections> CalculateOptimalDirection(GeoCoordinate departureStationCoordinate, GeoCoordinate arrivalStationCoordinate)
        {
            // Generate the direction from the departure point to the departure station
            LgbDirections lgbDirections = await new FootLocomotion(departure.ToGeoCoordinate(), departureStationCoordinate).GetDirections();
            LgbStep customStep = new LgbStep
            {
                Distance = 0,
                Duration = 1,
                Indication = "Take a bike from the station."
            };
            LgbDirectionBuilder.AddStep(lgbDirections, customStep, LocomotionType.BIKE);
            
            // Generate the direction using a bike from departure station to arrival station.
            OpenRouteDirections directions = await QueryDirections(departureStationCoordinate, arrivalStationCoordinate);
            LgbDirections directionsToAppend = LgbDirectionBuilder.BuildLgbDirection(directions, LocomotionType.BIKE);
            LgbDirectionBuilder.AppendDirections(lgbDirections, directionsToAppend);
            
            customStep = new LgbStep
            {
                Distance = 0,
                Duration = 1,
                Indication = "Return the bike at the station."
            };
            LgbDirectionBuilder.AddStep(lgbDirections, customStep, LocomotionType.BIKE);
            
            // Generate the direction from the arrival station to the arrival point to 
            directionsToAppend = await new FootLocomotion(arrivalStationCoordinate, arrival.ToGeoCoordinate()).GetDirections();
            LgbDirectionBuilder.AppendDirections(lgbDirections, directionsToAppend);

            return lgbDirections;
        }
        
        private async Task<OpenRouteDirections> QueryDirections(GeoCoordinate start, GeoCoordinate end)
        {
            string directionsJson = await openRouteClient
                .RequestDirections(start, end, LocomotionType.BIKE);
             return JsonConvert.DeserializeObject<OpenRouteDirections>(directionsJson);
        }
    }
}