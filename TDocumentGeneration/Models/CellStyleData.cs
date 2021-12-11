namespace TDocumentGeneration.Models
{
    public class CellStyleData
    {
        public string BackgroundColor { get; }

        public CellStyleData(string backgroundColor)
        {
            BackgroundColor = backgroundColor;
        }
    }
}
