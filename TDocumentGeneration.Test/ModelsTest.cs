using System;
using System.IO;
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

    }
}
