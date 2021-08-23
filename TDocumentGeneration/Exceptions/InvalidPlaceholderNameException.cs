using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidPlaceholderNameException : Exception
    {
        public InvalidPlaceholderNameException() : base("Placeholder name cannot be null or white space.")
        {
            
        }
    }
}
