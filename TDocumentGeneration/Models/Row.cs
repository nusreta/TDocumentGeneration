using System.Collections.Generic;
using System.Linq;

namespace TDocumentGeneration.Models
{
    public class Row
    {
        public int Number { get; set; }
        public IEnumerable<Cell> Cells { get; set; }

        public string GetCellText(int column) => Cells.Single(x => x.Column == column).Text;
    }
}
