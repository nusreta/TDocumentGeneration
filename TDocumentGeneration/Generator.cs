using System.Collections.Generic;
using System.IO;
using Aspose.BarCode.Generation;
using Aspose.Words;
using Aspose.Words.Replacing;
using TDocumentGeneration.Models;
using File = TDocumentGeneration.Models.File;

namespace TDocumentGeneration
{
    public class Generator
    {
        public Generator(Licenses licenses = null)
        {
            if (licenses == null) return;
            if (licenses.Words != null) new License().SetLicense(licenses.Words);
            if (licenses.BarCode != null) new Aspose.BarCode.License().SetLicense(licenses.BarCode);
        }

        public void Generate(Data data)
        {
            var document = new Document(data.File.Template);

            ImportPlaceholders(document, data.Placeholders);
            ImportBarCodeData(document, data.BarCodes);
            ImportTableData(document, data.Tables);
            SaveToDirectory(document, data.File);
        }

        private static void ImportPlaceholders(Node document, IEnumerable<Placeholder> placeholders)
        {
            foreach (var placeholder in placeholders)
            {
                document.Range.Replace($"::{placeholder.Name}::", placeholder.Text, new FindReplaceOptions(FindReplaceDirection.Forward));
            }
        }

        private static void ImportBarCodeData(Document document, IEnumerable<BarCode> barCodes)
        {
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

        private static void ImportTableData(Node document, IEnumerable<Table> tables)
        {
            foreach (var tableData in tables)
            {
                var bookmark = document.Range.Bookmarks[tableData.Bookmark];
                var table = bookmark.BookmarkStart.GetAncestor(NodeType.Table) as Aspose.Words.Tables.Table;

                foreach (var rowData in tableData.GetOrderedRows)
                {
                    var row = (Aspose.Words.Tables.Row)table?.LastRow.Clone(true);

                    foreach (Aspose.Words.Tables.Cell cell in row.Cells)
                    {
                        cell.RemoveAllChildren();
                        cell.EnsureMinimum();
                        var run = new Run((Document)table.ParentNode.Document, rowData.GetCellText(row.Cells.IndexOf(cell)));
                        cell.FirstParagraph.Runs.Add(run);
                    }

                    table.AppendChild(row);
                }
            }
        }

        private static void SaveToDirectory(Document document, File file)
        {
            using var stream = new MemoryStream();

            document.Save(stream, SaveFormat.Pdf);

            System.IO.File.WriteAllBytes(file.GetPath(), stream.ReadAllBytes());
        }
    }
}
