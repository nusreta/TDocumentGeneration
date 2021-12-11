using System;
using System.Collections.Generic;
using System.IO;
using TDocumentGeneration.Models;
using Xunit;

namespace TDocumentGeneration.Test
{
    public class GeneratorTest : IDisposable
    {
        private readonly Generator _generator;
        private readonly string _resources;

        public GeneratorTest()
        {
            _generator = new Generator();
            _resources = @$"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\Resources\";
        }


        [Fact]
        public void ShouldCreateEmptyPdf()
        {
            // Given
            var data = new Data(new FileData(Path.Combine(_resources, "template.docx"), "test.pdf", _resources));

            // When
            _generator.Generate(data);

            // Then
            Assert.True(File.Exists(Path.Combine(_resources, "test.pdf")));
        }

        [Fact]
        public void ExampleWith_Placeholders_BarCodes_Tables()
        {
            // Template and document information
            var templateLocation = Path.Combine(_resources, "example-template.docx");
            const string nameOfThePdfToBe = "example.pdf";
            var locationOfThePdfToBe = _resources;
            var fileData = new FileData(templateLocation, nameOfThePdfToBe, locationOfThePdfToBe);

            // Simple values to replace placeholders with
            var simplePlaceholdersToReplace = new List<PlaceholderData>
            {
                new PlaceholderData("FirstNamePlaceholder", "Nusreta"),
                new PlaceholderData("LastNamePlaceholder", "Sinanovic")
            };

            // Bar codes
            var barCodesToDraw = new List<BarCodeData>
            {
                new BarCodeData("BarCodeBookmark1", "Nusreta"),
                new BarCodeData("BarCodeBookmark2", "Sinanovic")
            };

            // Tables
            var cell11Style = new CellStyleData("PaleGreen");

            var cellsInTheRow0 = new List<CellData>
            {
                new CellData(0, "ROW-0 COL-0"), new CellData(1, "ROW-0 COL-1"), new CellData(2, "ROW-0 COL-2")
            };

            var cellsInTheRow1 = new List<CellData>
            {
                new CellData(0, "ROW-1 COL-0"), new CellData(1, "ROW-1 COL-1", cell11Style), new CellData(2, "ROW-1 COL-2")
            };

            var tableRows = new List<RowData>
            {
                new RowData(0, cellsInTheRow0),
                new RowData(1, cellsInTheRow1),
            };

            var tables = new List<TableData>
            {
                new TableData("TableBookmark", tableRows)
            };

            // Data to send to pdf generator
            var dataToSendToPdfGenerator = new Data(
                fileData, 
                simplePlaceholdersToReplace,
                barCodesToDraw,
                tables);

            // Call generator to create the document filled out with data
            _generator.Generate(dataToSendToPdfGenerator);
        }

        public void Dispose() => File.Delete(Path.Combine(_resources, "test.pdf"));
    }
}
