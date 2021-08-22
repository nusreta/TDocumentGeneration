using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidFileDataException : Exception
    {
        public InvalidFileDataException(string message) : base(message)
        {
            
        }
    }
}
