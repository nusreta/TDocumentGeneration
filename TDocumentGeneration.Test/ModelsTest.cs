using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TDocumentGeneration.Exceptions;
using TDocumentGeneration.Models;
using Xunit;

namespace TDocumentGeneration.Test
{
    public class ModelsTest
    {
        private readonly string _resources;

        public ModelsTest()
        {
            _resources = @$"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\Resources\";
        }

        [Fact]
        public void GivenData_WithNullFileData_ThrowInvalidFileDataException() =>
            Assert.Throws<InvalidFileDataException>(() => new Data(null));

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("test")]
        [InlineData("test.pdf.")]
        [InlineData("test.docx")]
        [InlineData("test.pdf.txt")]
        public void GivenFileData_WithInvalidFileName_ThrowInvalidFileNameException(string fileName) =>
            Assert.Throws<InvalidFileNameException>(() => 
                new FileData(Path.Combine(_resources, "template.docx"), fileName, _resources));

        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("test.docx")]
        [InlineData("template")]
        public void GivenFileData_WithInvalidTemplatePath_ThrowInvalidTemplatePathException(string templateName) =>
            Assert.Throws<InvalidTemplatePathException>(() =>
                new FileData(Path.Combine(_resources, templateName), "test.pdf", _resources));

        [Fact]
        public void GivenFileData_WithInvalidDirectoryPath_ThrowInvalidDirectoryPathException() =>
            Assert.Throws<InvalidDirectoryPathException>(() =>
                new FileData(Path.Combine(_resources, "template.docx"), "test.pdf", Path.Combine(_resources, "destination")));

        [Fact]
        public void GivenFileData_DestinationPath_ShouldBeCorrect() =>
            Assert.True(Path.Combine(_resources, "test.pdf") == 
                        new FileData(Path.Combine(_resources, "template.docx"), "test.pdf", _resources).DestinationPath);

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GivenPlaceholderData_WithInvalidName_ThrowInvalidPlaceholderNameException(string name) =>
            Assert.Throws<InvalidPlaceholderNameException>(() => new PlaceholderData(name, "value"));

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GivenBarCodeData_WithInvalidBookmark_ThrowInvalidBookmarkNameException(string bookmark) =>
            Assert.Throws<InvalidBookmarkNameException>(() => new BarCodeData(bookmark, "value"));

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GivenTableData_WithInvalidBookmark_ThrowInvalidBookmarkNameException(string bookmark) =>
            Assert.Throws<InvalidBookmarkNameException>(() => new TableData(bookmark, new List<RowData>()));

        [Fact]
        public void GivenTableData_WithInvalidDifferentNumberOfCellsInRows_ThrowInvalidRowDataException() =>
            Assert.Throws<InvalidRowDataException>(() => new TableData("table", new List<RowData>
            {
                new RowData(0, new List<CellData>()),
                new RowData(1, new List<CellData> { new CellData(0, "value") })
            }));

        [Fact]
        public void GivenTableData_OrderedRows_ShouldContainRowsSortedByIndex()
        {
            // Given
            var tableData = new TableData("table", new List<RowData>
            {
                new RowData(2, new List<CellData> {new CellData(0, "value")}),
                new RowData(0, new List<CellData> {new CellData(0, "value")}),
                new RowData(1, new List<CellData> {new CellData(0, "value")})
            });

            // When
            var orderedRows = tableData.OrderedRows.ToList();

            // Then
            Assert.True(orderedRows[0].RowIndex == 0);
            Assert.True(orderedRows[1].RowIndex == 1);
            Assert.True(orderedRows[2].RowIndex == 2);
        }

        [Fact]
        public void GivenRowData_GetCellData_ShouldContainValueOfTheCellWithGivenIndex()
        {
            // Given
            var tableData = new TableData("table", new List<RowData>
            {
                new RowData(0, new List<CellData> {new CellData(0, "00"), new CellData(1, "01")}),
                new RowData(1, new List<CellData> {new CellData(0, "10"), new CellData(1, "11")})
            });

            var orderedRows = tableData.OrderedRows.ToList();

            // When + Then
            Assert.True(orderedRows[0].GetCellData(0).Text == "00");
            Assert.True(orderedRows[0].GetCellData(1).Text == "01");
            Assert.True(orderedRows[1].GetCellData(0).Text == "10");
            Assert.True(orderedRows[1].GetCellData(1).Text == "11");
        }
    }
}
