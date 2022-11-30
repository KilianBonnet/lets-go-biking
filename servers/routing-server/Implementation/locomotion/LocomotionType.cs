namespace routing_server.Implementation.locomotion
{
    public class LocomotionType
    {
        public static readonly LocomotionType FOOT = new LocomotionType("foot-walking");
        public static readonly LocomotionType BIKE = new LocomotionType("cycling-regular");

        private readonly string type;
        
        private LocomotionType(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return type;
        }
    }
}