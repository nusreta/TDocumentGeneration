using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class BarCodeData
    {
        public string Bookmark { get; }
        public string Text { get; }

        public BarCodeData(string bookmark, string text)
        {
            Validate(bookmark);

            (Bookmark, Text) = (bookmark, text);
        }

        private static void Validate(string bookmark)
        {
            if (string.IsNullOrWhiteSpace(bookmark)) throw new InvalidBookmarkNameException();
        }
    }
}
