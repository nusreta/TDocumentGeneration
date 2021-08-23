using System;
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

        public void Dispose() => File.Delete(Path.Combine(_resources, "test.pdf"));
    }
}
