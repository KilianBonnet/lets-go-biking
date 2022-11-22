using System;

namespace routing_server.Helper
{
    [Serializable]
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException() { }
        public AddressNotFoundException(string message) : base(message) { }
    }

    [Serializable]
    public class DirectionsNotFoundException : Exception
    {
        public DirectionsNotFoundException() { }
        public DirectionsNotFoundException(string message) : base(message) { }
    }
    
    [Serializable]
    public class BadDirectionRequestException : Exception
    {
        public BadDirectionRequestException() { }
        public BadDirectionRequestException(string message) : base(message) { }
    }
    
    [Serializable]
    public class MultipleMatchingAddressException : Exception
    {
        public MultipleMatchingAddressException() { }
        public MultipleMatchingAddressException(string message) : base(message) { }
    }
}