using System.Collections.Generic;
using System.Linq;

namespace TDocumentGeneration.Models
{
    public class Table
    {
        public string Bookmark { get; set; }
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<Row> GetOrderedRows => Rows.OrderBy(x => x.Number);
    }
}
