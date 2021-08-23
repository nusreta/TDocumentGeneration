using System.Collections.Generic;
using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class Data
    {
        public FileData File { get; }
        public IEnumerable<PlaceholderData> Placeholders { get; }
        public IEnumerable<BarCodeData> BarCodes { get; }
        public IEnumerable<TableData> Tables { get; }

        public Data(
            FileData file, 
            IEnumerable<PlaceholderData> placeholders = null, 
            IEnumerable<BarCodeData> barCodes = null,
            IEnumerable<TableData> tables = null)
        {
            
            Validate(file);

            (File, Placeholders, BarCodes, Tables) = (file, placeholders, barCodes, tables);
        }

        private static void Validate(FileData file)
        {
            if (file == null) throw new InvalidFileDataException();
        }
    }
}
