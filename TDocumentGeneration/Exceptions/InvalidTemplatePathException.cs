using System;

namespace TDocumentGeneration.Exceptions
{
    public class InvalidTemplatePathException : Exception
    {
        public InvalidTemplatePathException() : base("Template with given path does not exist.")
        {
            
        }
    }
}
