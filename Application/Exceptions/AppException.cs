using System;

namespace Application.Exceptions
{
    public class AppException : Exception
    {
        // This class is being used to handle the duplicate Email Issue in a friendly format
        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
