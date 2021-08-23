using System.Collections.Generic;
using System.Linq;
using TDocumentGeneration.Exceptions;

namespace TDocumentGeneration.Models
{
    public class TableData
    {
        public string Bookmark { get; }
        public IEnumerable<RowData> Rows { get; }

        public IEnumerable<RowData> OrderedRows => Rows.OrderBy(x => x.RowIndex);

        public TableData(string bookmark, IEnumerable<RowData> rows)
        {
            Validate(bookmark, rows);

            (Bookmark, Rows) = (bookmark, rows);
        }

        private static void Validate(string bookmark, IEnumerable<RowData> rows)
        {
            if (string.IsNullOrWhiteSpace(bookmark)) throw new InvalidBookmarkNameException();

            if (!rows.All(x => x.Cells.Count() == rows.First().Cells.Count())) throw new InvalidRowDataException();
        }
    }
}
