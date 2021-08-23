using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidBookmarkNameException : Exception
    {
        public InvalidBookmarkNameException() : base("Bookmark name cannot be null or white space.")
        {
            
        }
    }
}
