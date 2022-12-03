using System.Collections.Generic;
using routing_server.Implementation.Helper;
using routing_server.Implementation.locomotion;

namespace routing_server.Implementation
{
    public class LgbStep
    {
        public double Distance;
        public double Duration;
        public string Indication;
    }

    public class LgbDirections
    {
        public string activemqQueueID;
        
        public double TotalDuration;
        public double TotalDistance;
        
        public double BikeDuration;
        public double BikeDistance;
        
        public double FootDuration;
        public double FootDistance;
        
        public List<LgbStep> Steps;
    }

    public static class LgbDirectionBuilder
    {
        private static LgbDirections CreateDirection()
        {
            return new LgbDirections()
            {
                TotalDuration = 0,
                TotalDistance = 0,
                BikeDuration = 0,
                BikeDistance = 0,
                FootDuration = 0,
                FootDistance = 0,
                Steps = new List<LgbStep>()
            };
        }

        public static void AppendDirections(LgbDirections lgbDirections, LgbDirections directionsToAppend)
        {
            lgbDirections.TotalDuration += directionsToAppend.TotalDuration;
            lgbDirections.TotalDistance += directionsToAppend.TotalDistance;
            lgbDirections.BikeDuration += directionsToAppend.BikeDuration;
            lgbDirections.BikeDistance += directionsToAppend.BikeDistance;
            lgbDirections.FootDuration += directionsToAppend.FootDuration;
            lgbDirections.FootDistance += directionsToAppend.FootDistance;
            lgbDirections.Steps.AddRange(directionsToAppend.Steps);
        }

        public static void AddStep(LgbDirections lgbDirections, LgbStep step, LocomotionType locomotionType)
        {
            lgbDirections.TotalDistance += step.Distance;
            lgbDirections.TotalDuration += step.Duration;
            lgbDirections.Steps.Add(step);

            if (locomotionType == LocomotionType.FOOT)
            {
                lgbDirections.FootDistance += step.Distance;
                lgbDirections.FootDuration += step.Duration;
            } 
            else 
            {
                lgbDirections.BikeDistance += step.Distance;
                lgbDirections.BikeDuration += step.Duration;
            }
        }

        public static LgbDirections BuildLgbDirection(OpenRouteDirections directions, LocomotionType locomotionType)
        {
            LgbDirections lgbDirections = CreateDirection();
            foreach (var step in directions.features[0].properties.segments[0].steps)
            {
                LgbStep lgbStep = new LgbStep
                {
                    Distance = step.distance,
                    Duration = step.duration,
                    Indication = step.instruction
                };
                AddStep(lgbDirections, lgbStep, locomotionType);
            }
            return lgbDirections;
        }
    }
}