using System.Collections.Generic;

namespace TDocumentGeneration.Models
{
    public class Data
    {
        public File File { get; set; }
        public IEnumerable<Placeholder> Placeholders { get; set; }
        public IEnumerable<BarCode> BarCodes { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}
