using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class PlaceholderData
    {
        public string Name { get; }
        public string Text { get; }

        public PlaceholderData(string name, string text)
        {
            Validate(name);

            (Name, Text) = (name, text);
        }

        private static void Validate(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new InvalidPlaceholderNameException();
        }
    }
}
