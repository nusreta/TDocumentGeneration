namespace TDocumentGeneration.Models
{
    public class CellData
    {
        public int ColumnIndex { get; }
        public string Text { get; }
        public CellStyleData Style { get; }

        public CellData(int columnIndex, string text, CellStyleData cellStyleData = null)
        {
            (ColumnIndex, Text, Style) = (columnIndex, text, cellStyleData);
        }
    }
}
