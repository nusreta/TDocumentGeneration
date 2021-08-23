namespace TDocumentGeneration.Models
{
    public class CellData
    {
        public int ColumnIndex { get; }
        public string Text { get; }

        public CellData(int columnIndex, string text)
        {
            (ColumnIndex, Text) = (columnIndex, text);
        }
    }
}
