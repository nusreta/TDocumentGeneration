using System.IO;
using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class FileData
    {
        public string TemplatePath { get; }
        public string FileName { get; }
        public string DirectoryPath { get; }

        public FileData(string templatePath, string fileName, string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new InvalidFileNameException("File name cannot be null or white space.");

            (TemplatePath, FileName, DirectoryPath) = (templatePath, fileName, directoryPath);
        }

        public string GetPath() => Path.Combine(DirectoryPath, FileName);
    }
}
