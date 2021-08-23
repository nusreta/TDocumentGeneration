namespace TDocumentGeneration.Models
{
    public class LicenseData
    {
        public string Words { get; }
        public string BarCode { get; }

        public LicenseData(string words, string barCode)
        {
            (Words, BarCode) = (words, barCode);
        }
    }
}
