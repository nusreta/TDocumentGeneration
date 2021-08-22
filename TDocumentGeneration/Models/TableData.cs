using System.Collections.Generic;
using System.Linq;

namespace TDocumentGeneration.Models
{
    public class TableData
    {
        public string Bookmark { get; set; }
        public IEnumerable<RowData> Rows { get; set; }

        public IEnumerable<RowData> GetOrderedRows => Rows.OrderBy(x => x.Number);
    }
}
