using System.Collections.Generic;
using System.IO;
using Aspose.BarCode.Generation;
using Aspose.Words;
using Aspose.Words.Replacing;
using Aspose.Words.Tables;
using TDocumentGeneration.Models;

namespace TDocumentGeneration
{
    public class Generator
    {
        public Generator(LicenseData license = null)
        {
            if (license == null) return;
            if (license.Words != null) new License().SetLicense(license.Words);
            if (license.BarCode != null) new Aspose.BarCode.License().SetLicense(license.BarCode);
        }

        public void Generate(Data data)
        {
            var template = new FileStream(data.File.TemplatePath, FileMode.Open);
            var document = new Document(template);

            ImportPlaceholders(document, data.Placeholders);
            ImportBarCodeData(document, data.BarCodes);
            ImportTableData(document, data.Tables);
            SaveToDirectory(document, data.File);
        }

        private static void ImportPlaceholders(Node document, IEnumerable<PlaceholderData> placeholders)
        {
            if (placeholders == null) return;

            foreach (var placeholder in placeholders)
            {
                document.Range.Replace($"::{placeholder.Name}::", placeholder.Text, new FindReplaceOptions(FindReplaceDirection.Forward));
            }
        }

        private static void ImportBarCodeData(Document document, IEnumerable<BarCodeData> barCodes)
        {
            if (barCodes == null) return;

            foreach (var barCode in barCodes)
            {
                var documentBuilder = new DocumentBuilder(document);
                documentBuilder.MoveToBookmark(barCode.Bookmark);

                var barcodeGenerator = new BarcodeGenerator(EncodeTypes.Code128, barCode.Text.SanitizeNonPrintableAsciiCharacters());

                var barcodeStream = new MemoryStream();
                barcodeGenerator.Save(barcodeStream, BarCodeImageFormat.Png);
                documentBuilder.InsertImage(barcodeStream);
            }
        }

        private static void ImportTableData(Node document, IEnumerable<TableData> tables)
        {
            if (tables == null) return;

            foreach (var tableData in tables)
            {
                var bookmark = document.Range.Bookmarks[tableData.Bookmark];

                if (!(bookmark.BookmarkStart.GetAncestor(NodeType.Table) is Table table)) return;

                foreach (var rowData in tableData.OrderedRows)
                {
                    var row = (Row) table.LastRow.Clone(true);

                    if (row == null) return;

                    foreach (var node in row.Cells)
                    {
                        var cell = (Cell) node;
                        cell.RemoveAllChildren();
                        cell.EnsureMinimum();
                        var text = rowData.GetCellText(row.Cells.IndexOf(cell));
                        var run = new Run((Document) table.ParentNode.Document, text);
                        cell.FirstParagraph.Runs.Add(run);
                    }

                    table.AppendChild(row);
                }
            }
        }

        private static void SaveToDirectory(Document document, FileData file)
        {
            using var stream = new MemoryStream();

            document.Save(stream, SaveFormat.Pdf);

            File.WriteAllBytes(file.DestinationPath, stream.ReadAllBytes());
        }
    }
}
