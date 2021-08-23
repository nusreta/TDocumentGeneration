using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        public InvalidFileNameException() : base("File name needs to have .pdf extension.")
        {
            
        }
    }
}
