using System.IO;

namespace TDocumentGeneration.Models
{
    public class File
    {
        public Stream Template { get; set; }
        public string Name { get; set; }
        public string Directory { get; set; }

        public string GetPath() => Path.Combine(Directory, Name);
    }
}
