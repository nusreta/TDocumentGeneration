using System.Collections.Generic;
using System.Linq;

namespace TDocumentGeneration.Models
{
    public class RowData
    {
        public int RowIndex { get; }
        public IEnumerable<CellData> Cells { get; }

        public string GetCellText(int columnIndex) => Cells.Single(x => x.ColumnIndex == columnIndex).Text;

        public RowData(int rowIndex, IEnumerable<CellData> cells)
        {
            (RowIndex, Cells) = (rowIndex, cells);
        }
    }
}
