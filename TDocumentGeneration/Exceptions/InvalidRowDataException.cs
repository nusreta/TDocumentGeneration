using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidRowDataException : Exception
    {
        public InvalidRowDataException() : base("Every row needs to have the same number of cells.")
        {
            
        }
    }
}
