using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        public InvalidFileNameException(string message) : base(message)
        {
            
        }
    }
}
