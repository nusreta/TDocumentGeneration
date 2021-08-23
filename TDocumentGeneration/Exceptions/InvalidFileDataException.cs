using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidFileDataException : Exception
    {
        public InvalidFileDataException() : base("File data cannot be null.")
        {
            
        }
    }
}
