using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidDirectoryPathException : Exception
    {
        public InvalidDirectoryPathException() : base("Directory with given path does not exist.")
        {
            
        }
    }
}
