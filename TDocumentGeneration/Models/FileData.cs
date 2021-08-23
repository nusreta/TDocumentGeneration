using System.IO;
using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class FileData
    {
        public string TemplatePath { get; }
        public string FileName { get; }
        public string DirectoryPath { get; }

        public string DestinationPath => Path.Combine(DirectoryPath, FileName);


        public FileData(string templatePath, string fileName, string directoryPath)
        {
            Validate(templatePath, fileName, directoryPath);

            (TemplatePath, FileName, DirectoryPath) = (templatePath, fileName, directoryPath);
        }

        private static void Validate(string templatePath, string fileName, string directoryPath)
        {
            if (!File.Exists(templatePath)) throw new InvalidTemplatePathException();

            if (string.IsNullOrWhiteSpace(fileName) || !fileName.EndsWith(".pdf")) throw new InvalidFileNameException();

            if (!Directory.Exists(directoryPath)) throw new InvalidDirectoryPathException();
        }
    }
}
