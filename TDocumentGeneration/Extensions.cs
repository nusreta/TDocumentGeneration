using System.IO;
using System.Text.RegularExpressions;

namespace TDocumentGeneration
{
    public static class Extensions
    {
        public static string SanitizeNonPrintableAsciiCharacters(this string text, string replacement = "?")
        {
            const string pattern = @"[^\x20-\x7E]";

            var sanitizedText = Regex.Replace(text, pattern, replacement);

            return sanitizedText;
        }

        public static byte[] ReadAllBytes(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            var buffer = new byte[16 * 1024];
            using var ms = new MemoryStream();

            int read;

            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) ms.Write(buffer, 0, read);

            return ms.ToArray();
        }
    }
}
